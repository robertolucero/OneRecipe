﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OneRecipe.DataAccess;

namespace OneRecipe.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200817210343_AddingDeleteOnCascade")]
    partial class AddingDeleteOnCascade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OneRecipe.Model.Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amount = 1m,
                            Name = "ground beef",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Amount = 1.25m,
                            Name = "bread crumbs",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 3,
                            Amount = 1.25m,
                            Name = "freshly grated parmesan",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 4,
                            Amount = 1m,
                            Name = "large egg, beaten",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 5,
                            Amount = 2m,
                            Name = "cloves garlic, minced",
                            RecipeId = 1
                        },
                        new
                        {
                            Id = 6,
                            Amount = 1.25m,
                            Name = "freshly chopped parsley",
                            RecipeId = 1
                        });
                });

            modelBuilder.Entity("OneRecipe.Model.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Directions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "It's already no-fuss, but throwing everything into a slow cooker makes it even better and easier!",
                            Directions = "1. Make meatballs: In a large bowl, mix together ground beef, bread crumbs, Parmesan, parsley, egg, salt, and crushed red pepper flakes. Form into 16 meatballs and place in the bottom of a Crock Pot.2. In another large bowl, mix together crushed tomatoes, tomato paste, onion, oregano, and garlic. Season with salt, pepper and a pinch of red pepper flakes. Pour sauce over meatballs. Cover Crock Pot with lid and cook on high for 3 hours or on low for 5 hours.3. Add broth spaghetti to Crock Pot, breaking noodles in half to fit and stirring to coat noodles. Replace lid and continue cooking on low for 1 1/2 hour more hours, stirring about every 30 minutes and breaking up any clumps of noodles and adding more broth as needed.4. Garnish with Parmesan and parsley before serving.",
                            ImagePath = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/crock-pot-spaghetti-horizontal-jpg-1522721232.jpg?crop=1xw:1xh;center,top&resize=768:*",
                            Name = "Spaghetti and meatballs"
                        });
                });

            modelBuilder.Entity("OneRecipe.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "test@test.com",
                            Password = "test"
                        });
                });

            modelBuilder.Entity("OneRecipe.Model.Ingredient", b =>
                {
                    b.HasOne("OneRecipe.Model.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

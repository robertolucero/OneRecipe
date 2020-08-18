import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map, tap, take, exhaustMap } from 'rxjs/operators';

import { Recipe } from '../recipes/recipe.model';
import { RecipeService } from '../recipes/recipe.service';

@Injectable({ providedIn: 'root' })
export class DataStorageService {
  constructor(
    private http: HttpClient,
    private recipeService: RecipeService
  ) {}

  CreateRecipe(recipe: Recipe) {
    this.http
      .post(
        'https://localhost:44356/api/Recipe/CreateRecipeAsync',
        recipe
      )
      .subscribe(response => {
        this.fetchRecipes().subscribe();
      });
  }

  DeleteRecipe(recipeId: number) {
    this.http
      .delete(
        'https://localhost:44356/api/Recipe/DeleteRecipeAsync',
        {
          params: new HttpParams().set('recipeId', recipeId.toString())
        }
      )
      .subscribe(response => {
        this.fetchRecipes().subscribe();
      });
  }

  UpdateRecipe(recipe: Recipe) {
    this.http
      .put(
        'https://localhost:44356/api/Recipe/UpdateRecipeAsync',
        recipe
      )
      .subscribe(response => {
        this.fetchRecipes().subscribe();
      });
  }

  fetchRecipes() {
    return this.http
      .get<Recipe[]>(
        'https://localhost:44356/api/Recipe/GetRecipesAsync'
      )
      .pipe(
        map(recipes => {
          return recipes.map(recipe => {
            return {
              ...recipe,
              ingredients: recipe.ingredients ? recipe.ingredients : []
            };
          });
        }),
        tap(recipes => {
          this.recipeService.setRecipes(recipes);
        })
      );
  }
}

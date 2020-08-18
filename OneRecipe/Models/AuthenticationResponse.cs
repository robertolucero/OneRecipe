﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneRecipe.Models
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime TokenExpirationDate { get; set; }
    }
}

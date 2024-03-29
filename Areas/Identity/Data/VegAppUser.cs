﻿using Microsoft.AspNetCore.Identity;
using VegApp.Entities;

namespace VegApp.Areas.Identity.Data
{
    public class VegAppUser : IdentityUser<Guid>
    {
        internal static readonly object UserProvider;

        public string Name { get; set; }
        public DietaryPreferencesEnum DietPreference { get; set; }

        public GenderEnum Gender { get; set; }

        public int Age { get; set; }

        public decimal Weight { get; set; }

        public enum Group { get, set, }

       public List<Product> Products { get; set; } = new List<Product>();



    }






}



﻿using Microsoft.AspNetCore.Identity;

namespace VegApp.Areas.Identity.Data
{
    public class VegAppUser : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public DietaryPreferencesEnum DietPreference { get; set; }

        public GenderEnum Gender { get; set; }

        public int Age { get; set; }

        public decimal Weight { get; set; }
    }
}



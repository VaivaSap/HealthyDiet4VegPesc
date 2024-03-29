﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VegApp;
using VegApp.Areas.Identity.Data;
using VegApp.Data;
using VegApp.Entities;
using VegApp.Migrations;

namespace VegApp.Pages
{
    public class HistoryModel : PageModel
    {
        private readonly VegApp.Data.VegAppContext _context;
        private readonly UserProvider _userProvider;
     
    

        public HistoryModel(VegApp.Data.VegAppContext context, UserProvider userProvider)
        {
            _context = context;
            _userProvider = userProvider;
         
        }

        public IList<IGrouping<string, EatenProductDisplay>> eatenProduct { get; set; } = default!;

      

        public void OnGet()
        {
            if (_context.EatenProducts != null)
            {
                eatenProduct = _context.EatenProducts

                    .Include(j => j.Product)
                    .Where(d => d.VegAppUserId == _userProvider.GetCurrentUserId())
                    .OrderBy(p => p.DateWhenEaten)
                    .Select(z => new EatenProductDisplay(z))
                    .AsEnumerable()
                    .GroupBy(o => o.DateWhenEatenForDisplay)
                    .ToList();  
            }

        }
    }

    public class EatenProductDisplay

    {
        public Guid EatenProductId { get; set; }

        public Product Product { get; set; }

        public string DateWhenEatenForDisplay { get; set; }

        public int Amount { get; set; }


        public EatenProductDisplay(EatenProduct product)
        {
            EatenProductId = product.EatenProductId;
            Product = product.Product;
            DateWhenEatenForDisplay = product.DateWhenEaten.ToString("yyyy-MM-dd");
            Amount = product.Amount;
        }
    }
}


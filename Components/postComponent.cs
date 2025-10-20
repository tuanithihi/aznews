using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aznew.Models;
using Microsoft.AspNetCore.Mvc;

namespace aznews.Components
{
    [ViewComponent(Name = "Post")]
    public class postComponent : ViewComponent
    {
        private readonly DataContext _context;
        public postComponent(DataContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listOfpost = (from p in _context.viewPostMenus
                              where (p.IsActive == true)
                              orderby p.PostID descending
                              select p).Take(8).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listOfpost));
        }
    }
}
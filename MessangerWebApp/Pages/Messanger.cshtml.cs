using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessangerWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MessangerWebApp
{
    public class MessangerModel : PageModel
    {
        private readonly MessangerWebAppContext _context;
        public string usrName;
        public MessangerModel(MessangerWebAppContext context)
        {
            _context = context;
        }
        public void OnGet(string name)
        {
            usrName = name;
        }
        public async Task OnPost(string message, string name)
        {
            usrName = name;

            Models.Message msg = new Models.Message()
            {
                Author = name,
                Content = message,
                Created = DateTime.Now
            };

            _context.Message.Add(msg);
            await _context.SaveChangesAsync();
        }
    }
}
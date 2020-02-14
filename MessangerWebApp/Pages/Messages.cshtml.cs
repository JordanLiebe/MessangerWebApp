using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessangerWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MessangerWebApp
{
    public class MessagesModel : PageModel
    {
        public List<Models.Message> Messages;
        private readonly MessangerWebAppContext _context;
        public MessagesModel(MessangerWebAppContext context)
        {
            _context = context;
        }
        public async Task OnGet()
        {
            Messages = await _context.Message.ToListAsync();
            Messages.Reverse();
        }
    }
}
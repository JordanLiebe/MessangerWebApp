using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessangerWebApp.Data;
using MessangerWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace MessangerWebApp
{
    public class MsgModel : PageModel
    {
        public string Output;
        private readonly MessangerWebAppContext _context;
        public MsgModel(MessangerWebAppContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            Response.ContentType = "text/event-stream";

            Message Last = _context.Message.OrderByDescending(m => m.Created).FirstOrDefault();
            DateTime LastTime = Last.Created;

            await Response.WriteAsync(string.Format("data: {0}\n\n", LastTime.ToUniversalTime().Ticks.ToString()));

            while (true)
            {
                Message LastOne = _context.Message.OrderByDescending(m => m.Created).FirstOrDefault();

                if(LastOne != Last)
                {
                    Last = LastOne;
                    LastTime = Last.Created;
                    await Response.WriteAsync(string.Format("data: {0}\n\n", LastTime.ToUniversalTime().Ticks.ToString()));
                }
            }

            DateTime startDate = DateTime.Now;
            while (startDate.AddMinutes(1) > DateTime.Now)
            {
                await Response.WriteAsync(string.Format("data: {0}\n\n", DateTime.Now.ToString()));

                System.Threading.Thread.Sleep(1000);
            }

            Response.Clear();
        }
        /*public void OnGet()
        {
            Response.Headers.Add("Content-Type", "text/event-stream");

            Message Last = _context.Message.OrderByDescending(m => m.Created).FirstOrDefault();

            if (Last != null)
                Output = Last.Created.ToUniversalTime().Ticks.ToString();
        }*/
    }
}
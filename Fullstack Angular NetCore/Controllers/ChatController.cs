using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fullstack_Angular_NetCore.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private Models.MyDBContext db;
        public ChatController(Models.MyDBContext context) 
        {
            db = context;
        }
        [HttpGet("[action]")]
        public IActionResult Message()
        {
            List<Models.Message> lst = null;

            lst = db.Message.ToList();

            return Json(lst);
        }
    }
}

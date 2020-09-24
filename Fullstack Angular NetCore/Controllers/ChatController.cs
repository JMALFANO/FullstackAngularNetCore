using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Fullstack_Angular_NetCore.Models.Response;
using Fullstack_Angular_NetCore.Models.ViewModels;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
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
        public IEnumerable<MessageViewModel> Message()
        {

            List<MessageViewModel> lst = (from d in db.Message
                                          orderby d.Id descending
                                         select new MessageViewModel
                                         {
                                             Id = d.Id,
                                             Name = d.Name,
                                             Text = d.Text
                                        }).ToList();

            return lst;
        }

        [HttpPost("[action]")]
        public Status Add([FromBody]MessageViewModel model) 
        {
            Status oR = new Status();

            try
            {
                Models.Message oMessage = new Models.Message();
                oMessage.Name = model.Name;
                oMessage.Text = model.Text;
                db.Message.Add(oMessage);
                db.SaveChanges();
                oR.Succes = 1;
            }
            catch (Exception ex){
                oR.Succes = 0;
                oR.Message = ex.Message;
            }
            return oR;
        }
    }
}

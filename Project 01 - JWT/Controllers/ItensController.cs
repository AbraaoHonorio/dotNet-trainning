using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using JWT.Model;
namespace JWT.Controllers
{
    [Route("api/[controller]")]
    public class ItensController : Controller
    {
        IList<Item> itemkList = new List<Item>();

        [HttpGet, Authorize]
        public IEnumerable<Item> Get()
        {
            var currentUser = HttpContext.User;

            itemkList = new List<Item>{
                new Item { id = 1,contact = "pedro@eng.ci.ufpb.br",data = String.Format("{0:d}", DateTime.Now), description = "Caderno perdido na sala CI 101", name= "Cardeno preto", type = "Papelaria" },
                new Item { id = 2,contact = "lucas@cc.ci.ufpb.br",data = String.Format("{0:d}", DateTime.Now), description = "Lapiseira perdido na sala CI 106", name= "Lapiseira preta com branco", type = "Papelaria" },
                new Item { id = 3,contact = "lucaso@mc.ci.ufpb.br",data = String.Format("{0:d}", DateTime.Now), description = "Guarda chuva perdido na sala CI 303", name= "Guarda chuva Xadrez", type = "Acessórios" }
               };


            return itemkList;
        }

      
    }
}

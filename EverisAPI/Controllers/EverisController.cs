using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EverisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EverisController : ControllerBase
    {
        [Route("Empresa")]
        [HttpGet]
        public IEnumerable<Modelo.Empresa> GetEmpresas()
        {
            Controle.Empresa controle = new Controle.Empresa();
            return controle.GetAll();
        }
    }
}
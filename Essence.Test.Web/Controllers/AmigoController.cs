using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Essence.Test.Base.BUS;
using Essence.Test.Domain.DTO;
using Essence.Test.RepositoryCore.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Test.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Amigo")]
    public class AmigoController : Controller
    {
        // POST api/values
        [Authorize("Bearer")]
        [HttpPost]
        public void Add([FromBody]Amigo model)
        {
            AmigoDTO amigo = new AmigoDTO();
            amigo.Latitude = model.Latitude;
            amigo.Longitude = model.Longitude;
            amigo.Nome = model.Nome;
            amigo.Distancia = model.Distancia;

            AmigoBUS bus = new AmigoBUS();
            bus.Add(amigo);
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("GetAll/")]
        public IEnumerable<AmigoDTO> GetAll()
        {
            AmigoBUS bus = new AmigoBUS();
            return bus.GetAll();
        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        [Route("AmigosProximos/{id}")]
        public IEnumerable<AmigoDTO> AmigosProximos(int id)
        {
            AmigoBUS bus = new AmigoBUS();
            return bus.AmigosProximos(id);
        }
    }
}
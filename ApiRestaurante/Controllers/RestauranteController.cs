using System.Collections.Generic;
using ApiRestaurante.Interfaces;
using ApiRestaurante.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiRestaurante.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly ICrudRestaurante crudRestaurante;

        public RestauranteController(ICrudRestaurante crudRestaurante)
        {
            this.crudRestaurante = crudRestaurante;
        }

        [HttpPost]
        [Route("lista")]
        public List<Restaurante> ListaRestaurantes([FromBody] Restaurante restaurante)
        {
            List<Restaurante> r = crudRestaurante.SpMetodos(restaurante);
            return r;
        }      
    }
}

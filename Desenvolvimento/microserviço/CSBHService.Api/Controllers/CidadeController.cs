using CSBHService.Dominio.Entidades;
using CSBHService.Dominio.Interfaces.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSBHService.Api.Controllers
{
    [Route("cidade")]
    public class CidadeController : Controller
    {
        private readonly ICidadeRepositorio _cidadeRepositorio;

        public CidadeController(ICidadeRepositorio cidadeRepositorio)
        {
            _cidadeRepositorio = cidadeRepositorio;
        }


        // POST: CidadeController/Create
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cidade>> Post(
            [FromBody] Cidade cidade)
        {
            if (ModelState.IsValid)
            {
                var teste = await _cidadeRepositorio.InseririOuAtualizar(cidade);
                return cidade;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}

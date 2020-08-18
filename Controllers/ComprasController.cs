using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebCashback.Models;
using WebCashback.Services;

namespace WebCashback.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComprasController : ControllerBase
    {
        private readonly CompraService _compra;

        public ComprasController(CompraService compra)
        {
            _compra = compra;
        }

        [HttpGet("lista/{codigo}")]
        [AllowAnonymous]
        public IActionResult Exibir(int codigo)
        {
            try
            {
                return new ObjectResult(_compra.ExibirCompras(codigo));
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }
        }

        [HttpPost("cadastrar")]
        [Authorize]
        public IActionResult Cadastrar(Compra compra)
        {
            try
            {
                _compra.CadastrarCompra(compra);
                return new ObjectResult("Compra cadastrada com sucesso!");
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }
        }



        [HttpGet("cashback/{cpf}")]
        [AllowAnonymous]
        public async Task<IActionResult> Cashbacks(long cpf)
        {
            try
            {
                return new ObjectResult(await _compra.ExibirCashback(cpf));
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }

        }

    }
}

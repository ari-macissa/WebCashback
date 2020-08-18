using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using WebCashback.Models;
using WebCashback.Services;

namespace WebCashback.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RevendedorController : ControllerBase
    {
        private readonly RevendedorService _revendedor;

        public RevendedorController(RevendedorService revendedor)
        {
            _revendedor = revendedor;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Logar(User user)
        {
            try
            {
                var obj = _revendedor.LogarRevendedor(user);
                if (obj == null) return NotFound();
                return new ObjectResult(obj);
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }
        }

        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public IActionResult Cadastrar(Revendedor revendedor)
        {
            try
            {
                _revendedor.CadastrarRevendedor(revendedor);
                return new ObjectResult("Revendedor cadastrado com sucesso!");
            }
            catch (Exception e)
            {
                return new ObjectResult(e.Message);
            }
        }




    }
}

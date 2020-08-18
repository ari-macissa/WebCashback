using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebCashback.Models;

namespace WebCashback.Services
{
    public class RevendedorService
    {
        private readonly WebCashbackContext _context;

        public RevendedorService(WebCashbackContext context)
        {
            _context = context;
        }

        public User LogarRevendedor(User user)
        {

            try
            {
                if (!_context.Revendedor.Any(r => r.Email == user.Email && r.Senha == user.Senha)) return null;

var revendedor = _context.Revendedor.Where(r => r.Email == user.Email && r.Senha == user.Senha).FirstOrDefault();

                var token = TokenService.GenerateToken(user);
                user.Senha = "";
                user.Id = revendedor.Id;
                user.Token = token;
                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CadastrarRevendedor(Revendedor revendedor)
        {
            if (_context.Revendedor.Any(r => r.Email == revendedor.Email || r.CPF == revendedor.CPF)) throw new Exception("Revendedor já existe.");

            try
            {
                _context.Add(revendedor);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }



    }
}
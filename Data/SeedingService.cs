using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCashback.Models;
using WebCashback.Models.Enums;

namespace WebCashback.Data
{
    public class SeedingService
    {
        private WebCashbackContext _context;

        public SeedingService(WebCashbackContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Compra.Any() ||
                _context.Revendedor.Any()
                )
            {
                return;
            }

            Revendedor revendedor = new Revendedor(1, "Ari", 00009990912, "ari.macissa@gmail.com", "abcd1234");
            Compra compra = new Compra(1, new DateTime(2020, 08, 16), 300.00, StatusCompra.Pendente, revendedor);

            _context.Revendedor.AddRange(revendedor);

            _context.Compra.AddRange(compra);

            _context.SaveChanges();
        }
    }
}

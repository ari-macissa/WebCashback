using System;
using WebCashback.Models.Enums;

namespace WebCashback.Models
{
    public class RegistroCompras
    {
        public int Id { get; set; }

        public DateTime DataCompra { get; set; }

        public double ValorCompra { get; set; }

        public double PorcentagemCashback { get; set; }

        public double ValorCashback { get; set; }

        public StatusCompra StatusCompra { get; set; }

        public long CPFVendedor { get; set; }


        public RegistroCompras() { }

        public RegistroCompras(int id, DateTime dataCompra, double valorCompra, double porcentagemCashback, double valorCashback, StatusCompra statusCompra, long cPFVendedor)
        {
            Id = id;
            DataCompra = dataCompra;
            ValorCompra = valorCompra;
            PorcentagemCashback = porcentagemCashback;
            ValorCashback = valorCashback;
            StatusCompra = statusCompra;
            CPFVendedor = cPFVendedor;
        }

    }
}

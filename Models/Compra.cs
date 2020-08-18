using System;
using System.ComponentModel.DataAnnotations;
using WebCashback.Models;
using WebCashback.Models.Enums;

namespace WebCashback
{
    public class Compra
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Favor informar {0}")]
        public DateTime DataCompra { get; set; }

        [Required(ErrorMessage = "Favor informar {0}")]
        public double ValorCompra { get; set; }

        public StatusCompra StatusCompra { get; set; }

        public Revendedor Revendedor { get; set; }

        public int RevendedorId { get; set; }

        public Compra() { }

        public Compra(int id, DateTime dataCompra, double valorCompra, StatusCompra statusCompra, Revendedor revendedor)
        {
            Id = id;
            DataCompra = dataCompra;
            ValorCompra = valorCompra;
            StatusCompra = statusCompra;
            Revendedor = revendedor;
        }
        public double PorcentoCashback
        {
            get
            {
                if (ValorCompra < 1000) return 10.00;
                else if(ValorCompra >= 1001 && ValorCompra <= 1500) return 15.00;
                else return 20.00;
            }
        }

        public double ValorCashback
        {
            get
            {
                return (ValorCompra * PorcentoCashback) / 100;
            }
        }


    }
}

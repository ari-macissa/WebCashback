using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Net.Http;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;
using WebCashback.Models;
using WebCashback.Models.Enums;

namespace WebCashback.Services
{
    public class CompraService
    {
        private readonly WebCashbackContext _context;
        private readonly IHttpClientFactory _clientFactory;

        public CompraService(WebCashbackContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public List<RegistroCompras> ExibirCompras(int codigoRevendedor)
        {
            try
            {
                return _context.Compra.Where(c => c.RevendedorId == codigoRevendedor)
                 .Include(v => v.Revendedor)
                 .OrderByDescending(c => c.DataCompra)
                .Select(o => new RegistroCompras(o.Id, o.DataCompra, o.ValorCompra, o.PorcentoCashback, o.ValorCashback, o.StatusCompra, o.Revendedor.CPF))
                 .ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CadastrarCompra(Compra compra)
        {
            var revendedor = _context.Revendedor.Find(compra.RevendedorId) ?? throw new Exception("Compra não foi registrada, revendedor não foi encontrado.");

            try
            {
                if (revendedor.CPF == 15350946056) compra.StatusCompra = StatusCompra.Aprovado;
                else compra.StatusCompra = StatusCompra.Pendente;

                compra.Revendedor = revendedor;
                _context.Compra.Add(compra);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<dynamic> ExibirCashback(long cpf)
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "https://mdaqk8ek5j.execute-api.us-east-1.amazonaws.com/v1/cashback?cpf=" + cpf);
            request.Headers.Add("token", "ZXPURQOARHiMc6Y0flhRC1LVlZQVFRnm");
            var client = _clientFactory.CreateClient();

            try
            {
                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var obj = response.Content.ReadAsStreamAsync().Result;
                    StreamReader sr = new StreamReader(obj);
                    var texto = sr.ReadToEnd();
                    var jsonString = JsonSerializer.Deserialize<ExpandoObject>(texto);

                    Compra compra = new Compra();
                    compra.ValorCompra =
                    JsonSerializer.Deserialize<Cashback>(
                        jsonString.ElementAt(1)
                        .Value.ToString()).credit;

                    dynamic objDinamico = new ExpandoObject();
                    objDinamico.ValorCompra = compra.ValorCompra;
                    objDinamico.Cashback = compra.PorcentoCashback;
                    objDinamico.ValorCashback = compra.ValorCashback;
                    return objDinamico;
                }
                else
                {
                    throw new Exception("Não foi achado cashback com este CPF.");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
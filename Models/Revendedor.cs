using System;
using System.ComponentModel.DataAnnotations;

namespace WebCashback.Models
{
    public class Revendedor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} Deve ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        public long CPF { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [EmailAddress(ErrorMessage = "Entre com um email válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} requerido")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "{0} Deve ter entre {2} e {1} caracteres")]
        public string Senha { get; set; }

        public Revendedor()
        {
        }

        public Revendedor(int id, string nome, long cpf, string email, string senha)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            Email = email;
            Senha = senha;
        }

    }
}

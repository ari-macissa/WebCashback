using System;

namespace WebCashback.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
    }
}
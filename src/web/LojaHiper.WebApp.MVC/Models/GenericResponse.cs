using System;

namespace LojaHiper.WebApp.MVC.Models
{
    public class GenericResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public ResponseResult ResponseResult { get; set; }

    }
}

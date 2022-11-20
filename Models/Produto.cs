using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Produto 
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }

    }
}
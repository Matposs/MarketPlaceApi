using System;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Venda
    {
        public Venda() =>
            CriadoEm = DateTime.Now;

        [Key]
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public DateTime CriadoEm { get; set; }

        public double ValorDaCompra { get; set; }

        //Relacionamentos
        public int ConsumidorId { get; set; }
        public Consumidor Consumidor { get; set; }
        

        public int ProdutoId { get; set; }
        public double ProdutoPreco { get; set; }
        public Produto Produto { get; set; }



    }
}
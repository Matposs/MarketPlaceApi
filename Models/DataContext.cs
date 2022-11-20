
using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    //Entity Framework Code First
    //É a classe que define a estrutura do banco de dados
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }

        //Definir quais as classes de modelo servirão para as         
        //tabelas no banco de dados
        public DbSet<Consumidor> Consumidores { get; set; } 

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<Produto> Produtos { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReportViewerSample.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }

        public List<Produtos> ProdutosList() 
        {
            
            return  new List<Produtos>{
                    new Produtos{Id=1, Nome ="Caneta", Quantidade=12, ValorTotal= 26, ValorUnitario=3},
                    new Produtos{Id=1, Nome ="Papel", Quantidade=40, ValorTotal= 40, ValorUnitario=1},
                    new Produtos{Id=1, Nome ="Borracha", Quantidade=5, ValorTotal= 5, ValorUnitario=1},
                    new Produtos{Id=1, Nome ="Regua", Quantidade=8, ValorTotal= 8, ValorUnitario=1}
                    
                };
        
        }
    }
       
}
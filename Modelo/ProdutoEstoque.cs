using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class ProdutoEstoque
    {
        public Empresa Empresa { get; set; }
        public Produto Produto { get; set; }
        public int Estoque { get; set; }

        public ProdutoEstoque(Empresa empresa, Produto produto, int estoque)
        {
            this.Empresa = empresa;
            this.Produto = produto;
            this.Estoque = estoque;
        }

        public ProdutoEstoque() { }
    }
}

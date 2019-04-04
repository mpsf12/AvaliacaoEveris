using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo
{
    public class ProdutoMovimentacao
    {
        public Empresa Empresa { get; set; }
        public Produto Produto { get; set; }
        public int Movimentacao { get; set; }
        public DateTime Data { get; set; }

        public ProdutoMovimentacao(Empresa empresa, Produto produto, int movimentacao, DateTime data)
        {
            this.Empresa = empresa;
            this.Produto = produto;
            this.Movimentacao = movimentacao;
            this.Data = data;
        }

        public ProdutoMovimentacao(Empresa empresa, Produto produto, int movimentacao)
        {
            this.Empresa = empresa;
            this.Produto = produto;
            this.Movimentacao = movimentacao;
            this.Data = DateTime.Now;
        }

        public ProdutoMovimentacao() { }
    }
}

using System;
using System.Collections.Generic;

namespace Modelo
{
    public partial class Produto
    {
        public Produto()
        {
            TbProdutoEstoque = new HashSet<ProdutoEstoque>();
            TbProdutoMovimentacao = new HashSet<ProdutoMovimentacao>();
        }

        public int Id { get; set; }
        public string NomeProduto { get; set; }

        public virtual ICollection<ProdutoEstoque> TbProdutoEstoque { get; set; }
        public virtual ICollection<ProdutoMovimentacao> TbProdutoMovimentacao { get; set; }
    }
}

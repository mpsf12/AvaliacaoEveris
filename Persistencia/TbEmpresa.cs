using System;
using System.Collections.Generic;

namespace Persistencia
{
    public partial class TbEmpresa
    {
        public TbEmpresa()
        {
            TbProdutoEstoque = new HashSet<TbProdutoEstoque>();
            TbProdutoMovimentacao = new HashSet<TbProdutoMovimentacao>();
        }

        public int Id { get; set; }
        public string NomeEmpresa { get; set; }

        public virtual ICollection<TbProdutoEstoque> TbProdutoEstoque { get; set; }
        public virtual ICollection<TbProdutoMovimentacao> TbProdutoMovimentacao { get; set; }
    }
}

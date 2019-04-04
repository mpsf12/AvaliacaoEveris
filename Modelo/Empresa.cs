using System;
using System.Collections.Generic;

namespace Modelo
{
    public partial class Empresa
    {
        public Empresa()
        {
            TbProdutoEstoque = new HashSet<ProdutoEstoque>();
            TbProdutoMovimentacao = new HashSet<ProdutoMovimentacao>();
        }

        public int Id { get; set; }
        public string NomeEmpresa { get; set; }

        public virtual ICollection<ProdutoEstoque> TbProdutoEstoque { get; set; }
        public virtual ICollection<ProdutoMovimentacao> TbProdutoMovimentacao { get; set; }
    }
}

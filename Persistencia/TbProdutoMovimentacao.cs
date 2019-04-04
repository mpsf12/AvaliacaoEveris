using System;
using System.Collections.Generic;

namespace Persistencia
{
    public partial class TbProdutoMovimentacao
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdEmpresa { get; set; }
        public int Movimentacao { get; set; }
        public DateTime Data { get; set; }

        public virtual TbEmpresa IdEmpresaNavigation { get; set; }
        public virtual TbProduto IdProdutoNavigation { get; set; }
    }
}

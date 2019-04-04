using System;
using System.Collections.Generic;

namespace Modelo
{
    public partial class ProdutoMovimentacao
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdEmpresa { get; set; }
        public int Movimentacao { get; set; }
        public DateTime Data { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}

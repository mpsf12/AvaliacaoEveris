using System;
using System.Collections.Generic;

namespace Modelo
{
    public partial class ProdutoEstoque
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public int IdEmpresa { get; set; }
        public int Estoque { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}

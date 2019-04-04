using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle
{
    class ProdutoMovimentacao : Geral<Modelo.Empresa>, IGeral<Modelo.Empresa>
    {
        public new Modelo.ProdutoMovimentacao GetById(int id)
        {
            return _dbContext.ProdutoMovimentacao.FirstOrDefault(e => e.Id == id);
        }
    }
}

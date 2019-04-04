using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controle
{
    class ProdutoEstoque : Geral<Modelo.Empresa>, IGeral<Modelo.Empresa>
    {
        public new Modelo.ProdutoEstoque GetById(int id)
        {
            return _dbContext.ProdutoEstoque.FirstOrDefault(e => e.Id == id);
        }

        public List<Modelo.ProdutoEstoque> EstoquePorEmpresa(Modelo.Empresa empresa)
        {
            return _dbContext.ProdutoEstoque.Where(x => x.IdEmpresa == empresa.Id).ToList();
        }

        public List<Modelo.ProdutoEstoque> EstoquePorEmpresa(int idEmpresa)
        {
            return _dbContext.ProdutoEstoque.Where(x => x.IdEmpresa == idEmpresa).ToList();
        }

    }
}

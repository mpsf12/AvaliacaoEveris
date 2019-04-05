using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EverisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EverisController : ControllerBase
    {
        [Route("Empresa")]
        [HttpGet]
        public IEnumerable<Modelo.Empresa> GetEmpresas()
        {
            Controle.Empresa controle = new Controle.Empresa();
            return controle.GetAll();
        }

        [Route("Empresa")]
        [HttpPost]
        public void PostEmpresa([FromBody] Modelo.Empresa empresa)
        {
            Controle.Empresa controle = new Controle.Empresa();
            controle.Salvar(empresa);
        }

        [Route("Empresa")]
        [HttpDelete]
        public void DeleteEmpresa([FromBody] Modelo.Empresa empresa)
        {
            Controle.Empresa controle = new Controle.Empresa();
            controle.Delete(empresa);
        }

        [Route("Empresa/{id}")]
        [HttpGet]
        public Modelo.Empresa GetEmpresas(int id)
        {
            Controle.Empresa controle = new Controle.Empresa();
            return controle.GetAll().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("Empresa/{id}/Estoque")]
        [HttpGet]
        public IEnumerable<Modelo.ProdutoEstoque> GetEstoqueEmpresa(int id)
        {
            Controle.ProdutoEstoque controle = new Controle.ProdutoEstoque();
            return controle.GetAll().Where(x => x.IdEmpresa == id);
        }

        [Route("Empresa/{idEmpresa}/Estoque/{idProduto}")]
        [HttpGet]
        public IEnumerable<Modelo.ProdutoEstoque> GetEstoqueEmpresa(int idEmpresa, int idProduto)
        {
            Controle.ProdutoEstoque controle = new Controle.ProdutoEstoque();
            return controle.GetAll().Where(x => x.IdEmpresa == idEmpresa && x.IdProduto == idProduto);
        }

        [Route("Produto")]
        [HttpGet]
        public IEnumerable<Modelo.Produto> GetProdutos()
        {
            Controle.Produto controle = new Controle.Produto();
            return controle.GetAll();
        }

        [Route("Produto")]
        [HttpPost]
        public void PostProdutos([FromBody] Modelo.Produto produto)
        {
            Controle.Produto controle = new Controle.Produto();
            controle.Salvar(produto);
        }

        [Route("Produto")]
        [HttpDelete]
        public void DeleteProdutos([FromBody] Modelo.Produto produto)
        {
            Controle.Produto controle = new Controle.Produto();
            controle.Delete(produto);
        }

        [Route("Produto/{id}")]
        [HttpGet]
        public IEnumerable<Modelo.Empresa> GetProdutos(int id)
        {
            Controle.Empresa controle = new Controle.Empresa();
            return controle.GetAll();
        }

        [Route("Produto/{id}/Estoque")]
        [HttpGet]
        public IEnumerable<Modelo.ProdutoEstoque> GetEstoqueProduto(int id)
        {
            Controle.ProdutoEstoque controle = new Controle.ProdutoEstoque();
            return controle.GetAll().Where(x => x.IdProduto == id);
        }

        [Route("ProdutoEstoque")]
        [HttpPost]
        public void PostProdutoEstoque([FromBody] Modelo.ProdutoEstoque produtoEstoque)
        {
            Controle.ProdutoEstoque controle = new Controle.ProdutoEstoque();
            controle.Salvar(produtoEstoque);
        }

        [Route("ProdutoEstoque")]
        [HttpDelete]
        public void DeleteProdutoEstoque([FromBody] Modelo.ProdutoEstoque produtoEstoque)
        {
            Controle.ProdutoEstoque controle = new Controle.ProdutoEstoque();
            controle.Delete(produtoEstoque);
        }

        [Route("ProdutoMovimentacao")]
        [HttpPost]
        public void PostProdutoMovimentacao([FromBody] Modelo.ProdutoMovimentacao produtoEstoque)
        {
            Controle.ProdutoMovimentacao controle = new Controle.ProdutoMovimentacao();
            controle.Salvar(produtoEstoque);
        }

        [Route("ProdutoMovimentacao")]
        [HttpDelete]
        public void DeleteProdutoMovimentacao([FromBody] Modelo.ProdutoEstoque produtoEstoque)
        {
            Controle.ProdutoEstoque controle = new Controle.ProdutoEstoque();
            controle.Delete(produtoEstoque);
        }
    }
}
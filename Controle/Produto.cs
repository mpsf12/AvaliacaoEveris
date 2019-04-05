﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace Controle
{
    public class Produto : Geral<Modelo.Produto>, IGeral<Modelo.Produto>
    {
        public new Modelo.Produto GetById(int id)
        {
            return _dbContext.Produto.FirstOrDefault(e => e.Id == id);
        }

        public new async Task<Modelo.Produto> GetByIdAsync(int id)
        {
            return await _dbContext.Produto.FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Salvar(Modelo.Produto produto)
        {
            if (produto.Id == 0)
                Create(produto);
            else Update(produto);
        }
    }
}

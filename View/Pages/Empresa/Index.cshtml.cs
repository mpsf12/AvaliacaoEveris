using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Modelo;

namespace View.Pages.Empresa
{
    public class IndexModel : PageModel
    {
        //Controle.Empresa _controle = new Controle.Empresa();
        private readonly Persistencia.Context _context;

        public IndexModel(Persistencia.Context context)
        {
            _context = context;
        }

        public IList<Modelo.Empresa> Empresa { get; set; }

        public async Task OnGetAsync()
        {
            Empresa = await _context.Empresa.ToListAsync();
        }
    }
}

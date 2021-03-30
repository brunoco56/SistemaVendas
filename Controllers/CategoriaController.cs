using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Controllers
{
    public class CategoriaController : Controller
    {
        protected ApplicationDbContext mContext;
        public CategoriaController(ApplicationDbContext _context)
        {
            mContext = _context;
        }
        public IActionResult Index()
        {

            try
            {
                IEnumerable<Categoria> lista = mContext.Categoria.ToList();
                //Dispose libera memória
                mContext.Dispose();
                return View(lista);

            }
            catch (Exception e)
            {
                return View(e.Message);
            }
            
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            // IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            CategoriaViewModel categorias = new CategoriaViewModel();

            var categoria =  mContext.Categoria
              .FirstOrDefault(m => m.Codigo == id);
            if (id != null)
            {
                categorias.Codigo = categoria.Codigo;
                categorias.Descricao = categoria.Descricao;
                return View(categorias);
            }
            else { return NotFound(); }
        }


        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            CategoriaViewModel categorias = new CategoriaViewModel();          
                
              var categoria = await mContext.Categoria
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (id != null)
            {
                categorias.Codigo = categoria.Codigo;
                categorias.Descricao = categoria.Descricao;
                return View(categorias);               
            }
            else { return NotFound(); }            
        }
      
    }
}

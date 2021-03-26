using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaVendas.DAL;
using SistemaVendas.Entidades;
using SistemaVendas.Models;
using System;
using System.Collections.Generic;
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
            IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            //Dispose libera memória
            mContext.Dispose();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastro(int? id)
        {
            return View();
        }




        public async Task<IActionResult> Detalhe(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            // IEnumerable<Categoria> lista = mContext.Categoria.ToList();
            CategoriaViewModel funcionarios = new CategoriaViewModel();
           
                
              var funcionario = await mContext.Categoria
                .FirstOrDefaultAsync(m => m.Codigo == id);
            if (id != null)
            {
                funcionarios.Codigo = funcionario.Codigo;
                funcionarios.Descricao = funcionario.Descricao;
                return View(funcionarios);               
            }
            else { return NotFound(); }            
        }









      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PaveControl.Data;
using PaveControl.Models;

namespace PaveControl.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly PaveControlDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProdutosController(PaveControlDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Produtoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        // GET: Produtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Produtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Preco,Estoque,Ativo,ImagemUrl")] Produto produto, IFormFile? foto)
        {
            ModelState.Remove("foto");
            ModelState.Remove("ImagemUrl");

            if (ModelState.IsValid)
            {
                try
                {
                    if (foto != null && foto.Length > 0)
                    {
                        // 1. Verificação de segurança para o caminho
                        string wwwRootPath = _hostEnvironment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                        //if (string.IsNullOrEmpty(wwwRootPath))
                        //{
                        //    // Se você está aqui, o WebRootPath não foi configurado corretamente
                        //    wwwRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                        //}

                        string pastaImagem = Path.Combine(wwwRootPath, "images");

                        if (!Directory.Exists(pastaImagem))
                        {
                            Directory.CreateDirectory(pastaImagem);
                        }

                        string nomeDoArquivo = Guid.NewGuid().ToString() + "_" + Path.GetFileName(foto.FileName);
                        string caminhoCompleto = Path.Combine(pastaImagem, nomeDoArquivo);

                        // 2. Usando o bloco using de forma mais explícita
                        using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                        {
                           foto.CopyTo(stream);
                           stream.Flush();

                        }

                        produto.ImagemUrl = nomeDoArquivo;
                    }

                    _context.Add(produto);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Se der erro, ele não vai mais derrubar o site! 
                    // Ele vai escrever o erro na tela para você ler.
                    ModelState.AddModelError("", "Erro ao salvar o arquivo: " + ex.Message);
                }
            }
            return View(produto);
        }

        // GET: Produtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: Produtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Estoque,Ativo")] Produto produto)
        {
            if (id != produto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: Produtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}

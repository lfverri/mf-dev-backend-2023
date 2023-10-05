using mf_dev_backend_2023.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mf_dev_backend_2023.Controllers
{

    public class VeiculosController : Controller
    {
        private readonly AppDbContext _context;
        public VeiculosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var dados = await _context.Veiculos.ToListAsync();
            return View(dados);
        }

        //criando veiculos

        public IActionResult Create() //get
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Veiculo veiculo) //classe / parametro
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo); //inserçao no banco de dados
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(veiculo);
        }

        public async Task<IActionResult> Edit(int? id) //id da rota do item 
        {
            if (id == null)
                return NotFound();
            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Veiculos.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)

                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)

                return NotFound();

            return View(dados);
            //recupera as informações pelo id, faz as validacoes (if) e exibe na tela view dados
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)

                return NotFound();
            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");

        }

    }
}




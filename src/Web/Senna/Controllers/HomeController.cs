using Dominio.IRepositories;
using Historias.Imoveis;
using Infra.Contexto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Senna.Factories;
using Senna.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Senna.Controllers
{
    public class HomeController : Controller
    {
        private readonly CriarImovel _criarImovel;
        private readonly AlterarImovel _alterarImovel;
        private readonly ExcluirImovel _excluirImovel;
        private readonly ConsultarImovel _consultarImovel;

        private readonly DataContext _dataContext;
        public HomeController(IImovelRepository imovelRepository, DataContext dataContext)
        {
            _criarImovel = new CriarImovel(imovelRepository);
            _alterarImovel = new AlterarImovel(imovelRepository);
            _excluirImovel = new ExcluirImovel(imovelRepository);
            _consultarImovel = new ConsultarImovel(imovelRepository);
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> PesquisaPorCidade(string PesquisarCidade)
        {
            var imoveis = from cidade in _dataContext.Imoveis select cidade;
            if (!string.IsNullOrEmpty(PesquisarCidade))
            {
                imoveis = imoveis.Where(x => x.Cidade.Contains(PesquisarCidade));
            }
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(imoveis);
            return View(listaImoveisViewModel);
        }
        public async Task<IActionResult> PesquisaPorBairro(string PesquisarBairro)
        {
            var imoveis = from bairro in _dataContext.Imoveis select bairro;
            if (!string.IsNullOrEmpty(PesquisarBairro))
            {
                imoveis = imoveis.Where(x => x.Bairro.Contains(PesquisarBairro));
            }
            var listaImoveisViewModel = ImovelFactory.MapearListaImovelViewModel(imoveis);
            return View(listaImoveisViewModel);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(ImovelViewModel imovelViewModel)
        {
            if (ModelState.IsValid)
            {
                var imovel = ImovelFactory.MapearImovel(imovelViewModel);
                await _criarImovel.Executar(imovel);
                return RedirectToAction("Criar");
            }
            return View(imovelViewModel);
        }
        public async Task<IActionResult> Alterar(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if(imovel == null)
            {
                return RedirectToAction("Index");
            }
            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);
            return View(imovelViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, ImovelViewModel imovelViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelViewModel);
            }
            var imovel = ImovelFactory.MapearImovel(imovelViewModel);
            await _alterarImovel.Executar(id, imovel);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detalhar(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if(imovel == null)
            {
                return RedirectToAction("Index");
            }
            var imovelViewModel = ImovelFactory.MapearImovelViewModel(imovel);
            return View(imovelViewModel);
        }
        public async Task<IActionResult> Excluir(int id)
        {
            var imovel = await _consultarImovel.BuscaPeloId(id);
            if(imovel == null)
            {
                return RedirectToAction("Index");
            }
            await _excluirImovel.Executar(imovel);
            return RedirectToAction("Index");
        }
    }
}

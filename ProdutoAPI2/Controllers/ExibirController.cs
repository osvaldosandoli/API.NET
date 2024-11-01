using Microsoft.AspNetCore.Mvc;
using ProdutoAPI2.Models;
using Newtonsoft.Json;

namespace ProdutoAPI2.Controllers
{
    public class ExibirController : Controller
    {
        private readonly HttpClient _httpClient;

        public ExibirController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Ação para a view Index
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("https://localhost:7187/api/produtos"); // Altere para a URL da sua API
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var produtos = JsonConvert.DeserializeObject<List<Produto>>(jsonResponse);

            return View("Exibir", produtos);
        }
    }
}
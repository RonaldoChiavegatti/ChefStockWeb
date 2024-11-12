using Microsoft.AspNetCore.Mvc;
using ChefStock.Models;  // Namespace dos modelos (Funcionario, etc.)
using Microsoft.EntityFrameworkCore;

namespace ChefStock.Controllers
{
    public class GerRestauranteController : Controller
    {
        private readonly AppDbContext _context;

        // Construtor para injeção de dependência do contexto
        public GerRestauranteController(AppDbContext context)
        {
            _context = context;
        }

        // Action para exibir a lista de funcionários
        public IActionResult Index()
        {
            // Obtém todos os funcionários cadastrados e inclui o restaurante associado
            var funcionarios = _context.Funcionarios.Include(f => f.Restaurante).ToList();
            var restaurantes = _context.Restaurantes.ToList(); // Lista de restaurantes

            // Passa os dados para a View
            ViewBag.Restaurantes = restaurantes;  // Envia a lista de restaurantes para o formulário
            return View(funcionarios);  // Retorna a lista de funcionários
        }

        // Action para adicionar um novo funcionário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarFuncionario(string nome, string email, int restauranteId)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o RestauranteId é válido
                var restaurante = await _context.Restaurantes.FindAsync(restauranteId);
                if (restaurante == null)
                {
                    // Se o restaurante não for encontrado, exibe uma mensagem de erro
                    ModelState.AddModelError("", "Restaurante não encontrado.");
                    // Retorna à index e mantém os dados de restaurantes
                    var funcionarios = _context.Funcionarios.Include(f => f.Restaurante).ToList();
                    var restaurantes = _context.Restaurantes.ToList();
                    ViewBag.Restaurantes = restaurantes;
                    return View("Index", funcionarios); 
                }

                // Cria um novo objeto Funcionario
                var funcionario = new Funcionario
                {
                    Nome = nome,
                    Email = email,
                    RestauranteId = restauranteId // Associa o funcionário ao restaurante
                };

                // Adiciona o funcionário ao banco de dados
                _context.Funcionarios.Add(funcionario);
                await _context.SaveChangesAsync();

                // Recarrega os dados de funcionários e restaurantes para atualizar a lista na view
                var funcionariosAtualizados = _context.Funcionarios.Include(f => f.Restaurante).ToList();
                var restaurantesAtualizados = _context.Restaurantes.ToList();

                // Passa os dados atualizados para a View
                ViewBag.Restaurantes = restaurantesAtualizados;
                return View("Index", funcionariosAtualizados);  // Retorna a view com os dados atualizados
            }

            // Se o ModelState não for válido, retorna a view novamente com os erros
            return View("Index");
        }
    }
}

using ChefStock.Models;
using System.Collections.Generic;
using System.Linq; // Certifique-se de ter esse namespace para usar o LINQ

namespace ChefStock.Services
{
    public class RestauranteService : IRestauranteService
    {
        private readonly AppDbContext _context;

        public RestauranteService(AppDbContext context)
        {
            _context = context;
        }

        public Restaurante GetRestaurante()
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Restaurantes.FirstOrDefault();
#pragma warning restore CS8603 // Possible null reference return.
        }

        public List<Funcionario> GetFuncionarios(int restauranteId)
        {
            return _context.Funcionarios.Where(f => f.RestauranteId == restauranteId).ToList();
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
        }

        public Funcionario GetFuncionarioByEmail(string email)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Funcionarios.FirstOrDefault(f => f.Email == email);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            _context.Funcionarios.Remove(funcionario);
            _context.SaveChanges();
        }

        public object GetFuncionarios()
        {
            throw new NotImplementedException();
        }
    }
}

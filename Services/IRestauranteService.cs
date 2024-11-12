using ChefStock.Models;
using System.Collections.Generic;

namespace ChefStock.Services
{
    public interface IRestauranteService
    {
        Restaurante GetRestaurante();
        List<Funcionario> GetFuncionarios(int restauranteId);
        void AdicionarFuncionario(Funcionario funcionario);
        Funcionario GetFuncionarioByEmail(string email);
        void RemoverFuncionario(Funcionario funcionario);
        object GetFuncionarios();
    }
}

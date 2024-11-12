using System.ComponentModel.DataAnnotations.Schema;

namespace ChefStock.Models
{
    public class Funcionario
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public int Id { get; internal set; }
        
        [NotMapped]  // Ignora a propriedade Senha no mapeamento para o banco de dados
        public object? Senha { get; internal set; }
        public int RestauranteId { get; set; }  // Relacionamento com o Restaurante

        // Propriedade de navegação para o restaurante associado
        public Restaurante? Restaurante { get; set; }

    }
}

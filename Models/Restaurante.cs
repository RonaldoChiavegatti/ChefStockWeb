using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ChefStock.Models;

public class Restaurante
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    // Lista de funcionários associados ao restaurante
    public ICollection<Funcionario>? Funcionarios { get; set; }
}
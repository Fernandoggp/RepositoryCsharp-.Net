using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("MERCADO")]
public class MercadoModel
{
    [Key]
    [Column("MERCADOID")]
    public int MercadoId { get; set; }

    [Column("NOMEMERCADO")]
    [Required(ErrorMessage = "O nome do mercado é obrigatório")]
    [StringLength(80,
        MinimumLength = 2,
            ErrorMessage = "O nome deve ter, no mínimo, 2 e, no máximo, 80 caracteres")]
    [Display(Name = "Nome do Mercado")]
    public string? Nome { get; set; }


    [Column("ENDERECO")]
    [Display(Name = "Endereco")]
    public string? Endereco { get; set; }

    

    public MercadoModel()
    {
    }

    public MercadoModel(int mercadoId, string? nome, string? endereco)
    {
        MercadoId = mercadoId;
        Nome = nome;
        Endereco = endereco;
    }
}


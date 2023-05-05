using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("PRODUTO")]
public class ProdutoModel
{
    [HiddenInput]
    [Key]
    [Column("PRODUTOID")]
    public int ProdutoId { get; set; }

    [Display(Name = "Nome do Produto")]
    [Required(ErrorMessage = "Nome do produto é obrigatório!")]
    [MaxLength(70, ErrorMessage = "O tamanho máximo para o campo nome é de 70 caracteres.")]
    [MinLength(2, ErrorMessage = "Digite um nome com 2 ou mais caracteres")]
    [Column("NOME")]
    public string? Nome { get; set; }

    [Display(Name = "Preco")]
    [Required(ErrorMessage = "Preço é obrigatório!")]
    [DataType(DataType.Currency)]
    [Column("PRECO")]
    public double? Preco { get; set; }


    [Display(Name = "Mercado")]
    [Column("MERCADOID")]
    public int MercadoId { get; set; }
    public MercadoModel? Mercado { get; set; }

}

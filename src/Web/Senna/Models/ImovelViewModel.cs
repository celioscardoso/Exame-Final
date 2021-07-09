using Dominio.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Senna.Models
{
    public class ImovelViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [DisplayName("Cidade:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Cidade { get; set; }

        [DisplayName("Bairro:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Bairro { get; set; }

        [DisplayName("N° de Quartos:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public int QtdDeQuartos { get; set; }

        [DisplayName("Tipo:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public ETipoCasa Tipo { get; set; }

        [DisplayName("Valor:")]
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public decimal ValorDoAluguel { get; set; }
    }
}

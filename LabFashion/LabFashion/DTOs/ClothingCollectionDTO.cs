using LabFashion.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.DTOs
{
    public class ClothingCollectionDTO
    {
        public int IdCollection { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Nome da Coleção")]
        public string NameCollection { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Id do Usuário na Coleção")]
        public int IdPerson { get; set; }

        [Required(ErrorMessage = "É necessário inserir a Marca da Coleção")]
        public string BrandCollection { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Orçamento da Coleção")]
        public double BudgetCollection { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Ano de Lançamento da Coleção")]
        [MaxLength(4, ErrorMessage = "Tamanho máximo de 4 caracteres.")]
        [MinLength(4, ErrorMessage = "Tamanho mínimo de 4 caracteres.")]
        public string ReleaseYearCollection { get; set; }

        [Required(ErrorMessage = "É necessário inserir a Estação da Coleção")]
        public LaunchStation launchStation { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Status da Coleção")]
        public SystemStatus systemStatus { get; set; }
    }
}

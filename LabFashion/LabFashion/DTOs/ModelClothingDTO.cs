using LabFashion.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.DTOs
{
    public class ModelClothingDTO
    {
        public int IdModel { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Nome do Modelo")]
        public string NameModel { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Id da Coleção")]
        public int IdCollection { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Tipo do Modelo")]
        public TypeModel TypeModel { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Layout do Modelo")]
        public LayoutModel LayoutModel { get; set; }
    }
}

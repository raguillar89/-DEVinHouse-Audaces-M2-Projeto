using LabFashion.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.DTOs
{
    public class ClothingCollectionStatusDTO
    {
        [Required(ErrorMessage = "É necessário inserir o Status da Coleção")]
        public SystemStatus systemStatus { get; set; }
    }
}

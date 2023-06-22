using LabFashion.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFashion.Models
{
    public class ModelClothing
    {
        [Key]
        public int IdModel { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Nome do Modelo")]
        public string NameModel { get; set; }        

        [Required(ErrorMessage = "É necessário inserir o Tipo do Modelo")]
        [EnumDataType(typeof(TypeModel))]
        public TypeModel TypeModel { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Layout do Modelo")]
        [EnumDataType(typeof(LayoutModel))]
        public LayoutModel LayoutModel { get; set; }

        [ForeignKey("ClothingCollection")]
        [Required(ErrorMessage = "É necessário inserir o Id da Coleção")]
        public int IdCollection { get; set; }

        public virtual ClothingCollection? ClothingCollection { get; set; }    
    }
}

using LabFashion.Enums;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : Person
    {
        [Required(ErrorMessage = "É necessário inserir o E-mail do Usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Tipo de Usuário")]
        [EnumDataType(typeof(TypeUser))]
        public TypeUser TypeUser { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Status de Usuário")]
        [EnumDataType(typeof(SystemStatus))]
        public SystemStatus SystemStatus { get; set; }
    }
}

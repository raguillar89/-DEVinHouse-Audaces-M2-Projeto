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
        public TypeUser TypeUser { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Status de Usuário")]
        public SystemStatus SystemStatus { get; set; }
    }
}

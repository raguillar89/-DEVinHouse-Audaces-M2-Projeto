using LabFashion.Enums;
using LabFashion.Models;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.DTOs
{
    public class UserDTO : PersonDTO
    {
        [Required(ErrorMessage = "É necessário inserir o E-mail do Usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Tipo de Usuário")]
        public TypeUser TypeUser { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Status de Usuário")]
        public SystemStatus SystemStatus { get; set; }
    }
}

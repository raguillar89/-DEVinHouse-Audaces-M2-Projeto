using LabFashion.Enums;
using LabFashion.Models;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.DTOs
{
    public class UserStatusDTO
    {
        [Required(ErrorMessage = "É necessário inserir o Status de Usuário")]
        public SystemStatus SystemStatus { get; set; }
    }
}

﻿using LabFashion.Enums;
using LabFashion.Models;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.DTOs
{
    public class UserDTO : PersonDTO
    {
        public int IdUser { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Tipo de Usuário")]
        public TypeUser TypeUser { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Status de Usuário")]
        public SystemStatus SystemStatus { get; set; }
    }
}

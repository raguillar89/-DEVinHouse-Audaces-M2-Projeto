﻿using LabFashion.Enums;
using System.ComponentModel.DataAnnotations;

namespace LabFashion.Models
{
    public class User : Person
    {
        [Required(ErrorMessage = "É necessário inserir o Tipo de Usuário")]
        public TypeUser TypeUser { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Status de Usuário")]
        public SystemStatus SystemStatus { get; set; }
    }
}

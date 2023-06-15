﻿using LabFashion.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabFashion.Models
{
    public class ClothingCollection
    {
        [Key]
        public int IdCollection { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Nome da Coleção")]
        public string NameCollection { get; set; }

        [ForeignKey("Usuário")]
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
        public LaunchStation LaunchStation { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Status da Coleção")]
        public SystemStatus SystemStatus { get; set; }

        public virtual User? User { get; set; }
    }
}

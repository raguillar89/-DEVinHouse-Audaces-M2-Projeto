using System.ComponentModel.DataAnnotations;

namespace LabFashion.DTOs
{
    public class PersonDTO
    {
        [Required(ErrorMessage = "É necessário inserir o Nome do Usuário.")]
        [MaxLength(40, ErrorMessage = "Tamanho máximo de 40 caracteres.")]
        public string NamePerson { get; set; }

        [Required(ErrorMessage = "É necessário inserir o Gênero do Usuário.")]
        [MaxLength(9, ErrorMessage = "Tamanho máximo de 9 caracteres.")]
        public string GenrePerson { get; set; }

        [Required(ErrorMessage = "É necessário inserir a Data de Nascimento do Usuário.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "dd/MM/yyyy")]
        public DateTime BirthDatePerson { get; set; }

        [Required(ErrorMessage = "É necessário inserir o CPF ou CNPJ do Usuário.")]
        [MaxLength(18, ErrorMessage = "Tamanho máximo de 18 caracteres.")]
        public string DocumentPerson { get; set; }

        [Required(ErrorMessage = "É necessário inserir o telefone do Usuário.")]
        [MaxLength(15, ErrorMessage = "Tamanho máximo de 15 caracteres.")]
        public string PhoneNumberPerson { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace back.Models
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo NOME é obrigatorio")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O campo deve ter de 3 a 60 caracteres")]
        public string Name { get; set; }



        public Fornecedor()
        {
            Id = Guid.NewGuid();
        }





    }
}

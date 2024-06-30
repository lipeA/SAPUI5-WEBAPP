using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace back.Models
{
    public class NotaFiscal
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Inoforme o identificador do cliente!")]
        public Guid ClienteId { get; set; }
        
        public Cliente Cliente { get; set; } // relacionamento cliente


        [Required(ErrorMessage = "Informe o identificador do fornecedor!")]
        public Guid FornecedorId { get; set; }
        
        public Fornecedor Fornecedor { get; set; } // relacionamento fornecedor


        [Required]
        [StringLength(100, ErrorMessage ="O campo Descrição deve ter até 100 caracteres!")]
        public string Descricao { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal valorNota { get; set; }

        public DateTime DataCriacao { get; set; } = DateTime.Now;



        public NotaFiscal()
        {
            Id = Guid.NewGuid();
        }

       
        
       

    }
}

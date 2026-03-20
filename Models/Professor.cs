using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gestao_escolar.Models
{

    [Table("Professor")]
    public class Professor
    {
        [Key]
         public int Id { get; set;}
         [Required(ErrorMessage = "Nome é obrigatório :")]
         [StringLength(100, ErrorMessage = "Nao pode exceder a 100 caracteres : ")]
         [Display(Name = "Nome Completo")]
         public String Nome { get; set ;}

         [Required(ErrorMessage = "Email é obrigatório ")]
         [EmailAddress(ErrorMessage = "Email Invalido")]
         [StringLength(150)]
         public String Email { get; set; }
         [StringLength(150)]
         [Display(Name = "Area de Especialidade")]
         public String Especialidade { get; set; }
         [Phone(ErrorMessage = "Telefone Inválido ")]
         [StringLength(20)]
        public String Telefone { get; set; }

        [Required(ErrorMessage = "Data de Admissao é obrigatória")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Admissao ")]
           public DateTime dataAdmissao { get ; set ;}

           [Display(Name = "Ativo")]
           public Boolean Ativo {get ; set ;}

           //Propriedade de Navegacao  Relação 1: N

           public ICollection<Disciplina>? Disciplinas { get; set;}





    }
}
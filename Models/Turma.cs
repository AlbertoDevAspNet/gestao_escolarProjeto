using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gestao_escolar.Models
{
    [Table("Turma")]
    public class Turma
    {
        [Key]
        public int Id {get ; set;}

        [Required(ErrorMessage = "O Código é obrigatório ")]
        [StringLength(20)]
        [Display(Name = "Código da Turma")]
        public String CodigoTurma { get; set;}
        [Required(ErrorMessage = "Nome da turma é obrigatório")]
        [StringLength(100)]
        [Display(Name = "Nome da Turma")]

        public String Nome { get ; set; }
        [Required(ErrorMessage = "O Ano Letivo é obrigatório ")]
        [Range(2020, 2030)]
        [Display(Name = "Ano Letivo ")]
        public int AnoLetivo {get ; set;}

        [Required(ErrorMessage = "Periodo é obrigatório")]
        [StringLength(20)]
        [Display(Name = "Periodo")]
        public String Periodo { get; set;} = string.Empty;
        [Display(Name = "Capacidade")]
        public int Capacidade { get; set; }
        [StringLength(20)]
        public String? Sala { get; set; }
        [Display(Name = "Ativo")]
        public Boolean Ativo { get; set;}

        public ICollection<Disciplina>? Disciplinas{ get; set;} 
    }
}
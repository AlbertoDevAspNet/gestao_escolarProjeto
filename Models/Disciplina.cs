using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace gestao_escolar.Models
{

    [Table("Disciplina")]
    public class Disciplina
    {
        [Key]
     public int   Id {get; set;}
     [Required(ErrorMessage = "Nome é obrigatório")]
     [StringLength(100)]
     [Display(Name = "Nome Disciplina ")]
     public String Nome {get; set ;} = string.Empty;
     [Required(ErrorMessage = "Código é obrigatório")]
     [StringLength(20)]
     [Display(Name = "Código")]
     public String? Codigo {get ; set;} 
     [Required(ErrorMessage = "Carga horaria é obrigatória em horas")]
    
     [Display(Name = "Carga Horaria (horas)")]
     [Range(1,500)]
     public int CargaHoraria {get; set;}
     [Display(Name = "Ementa")]
     public String? Ementa{ get; set;}
     [Display(Name = "Professor")]
     public int? ProfessorId{get; set;} 
     [ForeignKey("ProfessorId")]
     public Professor? Professor{ get; set;}
     [Display(Name = "Turma")]
     public int TurmaId{ get; set;} 
     [ForeignKey("TurmaId")]
     public Turma? Turma{ get; set;} 
     [Display(Name = "Ativo")]
     public Boolean Ativo{ get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dev_Appdb.Models
{
    [Table("View")]
    public class View
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ViewId { get; set; }

        [Required(ErrorMessage = "É Obrigatório informar a Descrição")]
        [StringLength(50), MinLength(3, ErrorMessage = "Descrição deverá ter entre 3 e 50 caracteres.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [MaxLength(50)]
        [StringLength(50), MinLength(3, ErrorMessage = "Controle deverá ter entre 3 e 50 caracteres.")]
        [Required(ErrorMessage = "Campo Controller Name é Obrigatório")]
        [DisplayName("Controller Name")]
        public string ControllerName { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "Campo Action Name é Obrigatório")]
        [StringLength(25), MinLength(3, ErrorMessage = "Descrição deverá ter entre 3 e 25 caracteres.")]
        [DisplayName("Action Name")]
        public string ActionName { get; set; }

        [ScaffoldColumn(false)]
        [ReadOnly(true)]
        [Display(Name = "Usuário de Criação")]
        public int CreateUserId { get; set; }

        [ScaffoldColumn(false)]
        [ReadOnly(true)]
        [Display(Name = "Usuário de Atualização")]
        public int UpdateUserId { get; set; }

        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = true)]
        [Display(Name = "Data de Criação")]
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        [ScaffoldColumn(false)]
        [ReadOnly(true)]
        [DataType(DataType.DateTime)]
        [Display(Name = "Data de Atualização")]
        public DateTime UpdateDate { get; set; }

        [Display(Name = "Registro Ativo")]
        public Boolean Active { get; set; }

        [Required(ErrorMessage = "É obrigatório informar o campo Menu Aplicação")]
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

    }
}
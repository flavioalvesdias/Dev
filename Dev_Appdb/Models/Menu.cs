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

    [Table("Menu")]
    public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "Campo Descrição é Obrigatório.")]
        [MaxLength(50), MinLength(3, ErrorMessage = "Descrição deverá ter entre 3 e 50 caracteres.")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [ScaffoldColumn(false)]
        [ReadOnly(true)]
        [Display(Name = "Usuário de Criação")]
        public int CreateUserId { get; set; }

        public int? MenuPaiId { get; set; }

        [ForeignKey("MenuPaiId")]
        public virtual Menu MenuPai { get; set; }
        
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

    }
}
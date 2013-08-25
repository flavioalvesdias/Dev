using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaintenanceDB.Models
{
    /// <summary>
    /// Author Flávio Dias
    /// Classe referente aos Menus que a aplicação terá
    /// </summary>
    [Table("SysMenu")]
    public class SysMenu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(100), MinLength(3, ErrorMessage = "Descrição deverá ter entre 3 e 100 caracteres.")]
        public string Descricao { get; set; }
        public int? MenuPaiId { get; set; }

        [ForeignKey("MenuPaiId")]
        public virtual SysMenu MenuPai { get; set; }
        public string CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserId { get; set; }
        public Boolean Active { get; set; }

        
    }
}
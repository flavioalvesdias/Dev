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
    /// Classe responsável por conter dados sobre todas as visões que existiram no sistema
    /// Apenas visões cadastradas serão mostradas no menu da aplicação
    /// </summary>
    
    [Table("SysView")]
    public class SysView
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ViewId { get; set; }

        [Required(ErrorMessage = "*")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "*")]
        public string ControllerName { get; set; }

        [MaxLength(25)]
        [Required(ErrorMessage = "*")]
        public string ActionName { get; set; }

        public string CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateUserId { get; set; }
        public Boolean Active { get; set; }

        [Required(ErrorMessage = "*")]
        public int MenuId { get; set; }

        [ForeignKey("MenuId")]
        public virtual SysMenu sysMenu { get; set; }
    }
}
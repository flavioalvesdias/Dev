using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;




namespace Dev_Appdb.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Obrigatório Informar o Usuário")]
        [MaxLength(30)]
        public string Usuario { get; set; }


        [Required(ErrorMessage = "Obrigatório Informar o Nome do Usuário")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É obrigatório informar a Senha")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Senha deve ter entre 2 e 100 caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Required(ErrorMessage = "É obrigatório informar a Confirmação de Senha")]
        [Compare("Password", ErrorMessage = "A senha e confirmação de senha não estão combinando.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Número máximo de caracteres é 100")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*",
            ErrorMessage = "Email não está em um formato válido")]
        public String Email { get; set; }

        public int CreateUserId { get; set; }
        [ScaffoldColumn(false)]
        [ReadOnly(true)]
        [Display(Name = "Usuário de Atualização")]

        public int UpdateUserId { get; set; }
        [ScaffoldColumn(false)]
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
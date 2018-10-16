using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Administration
{
    [Table("USERS0")]
    public class UserModel : BaseModel, IBaseModel<UserModel>
    {
        public UserModel()
        {
            Admin = false;
            Picture = "user.png";
            Perfil = new List<PerfilModel>();
        }

        [Required]
        [Display(Name="Usuário")]
        [NotMapped]
        public string User {get => Name;set => Name = value;}
        
        [Required]
        [Display(Name="Nome")]
        public string FullName {get;set;}

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="E-mail")]
        public string Email {get;set;}
        [NotMapped]
        public string Picture {get;set;}

        [Display(Name="Perfil ID")]
        public int PerfilId {get;set;}
        [NotMapped]
        [Display(Name="Perfil")]
        public string PerfilName {get;set;}
        [NotMapped]
        [Display(Name="Perfil")]
        public List<PerfilModel> Perfil {get;set;}

        [Required]
        [Display(Name="Senha")]
        [DataType(DataType.Password)]
        public string PasswdHash {get; protected set;}

        [Display(Name="Senha")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string Passwd {get; set;}

        [Display(Name="Lembrar acesso")]
        public bool Remember {get;set;}

        [Display(Name="Administrador")]
        public bool Admin {get;set;}

        [Display(Name="Termos de uso")]
        public bool Terms {get;set;}
        
        #region Other autentication
        public string AutToken {get;set;}
        public string AutCookie {get;set;}
        
        [Display(Name="Valido até")]
        public DateTime? AutDueDate {get;set;}
        #endregion

        #region ERP
        [Display(Name="Vendedor")]
        public int ERPVendor {get;set;}

        [Display(Name="Filial")]
        public string ERPBranch {get;set;}

        [Display(Name="Usuário (ERP)")]
        public string ERPUser {get;set;}

        [DataType(DataType.Password)]
        [Display(Name="Senha (ERP)")]
        public string ERPPasswd {get;set;}

        [Display(Name="Integração (ERP)")]
        public bool ERPEnabled {get;set;}
        #endregion

        public void Update(UserModel model)
        {
            FullName = model.FullName;
            Email = model.Email;
            PerfilId = model.PerfilId;
            Admin = model.Admin;
            ERPVendor = model.ERPVendor;
            ERPBranch = model.ERPBranch;
            ERPUser = model.ERPUser;
            ERPPasswd = model.ERPPasswd;
            if(!String.IsNullOrEmpty(model.Passwd))
                AddHashPasswd();

            base.Update(model);
        }


        public void AddHashPasswd(String passwd = null)
        {
            if(!String.IsNullOrEmpty(passwd))
                this.Passwd = passwd;

            if(!Shell.IsValidPasswd(this.Passwd))
                throw new Exception("Senha não atende nivel de segurança mínimo");

            PasswdHash = Shell.HashMD5(this.Passwd, Unique);
        }

        public bool IsValidPasswd(string passwd = null)
        {
            if(!String.IsNullOrEmpty(passwd))
                this.Passwd = passwd;

            return PasswdHash == Shell.HashMD5(this.Passwd, Unique);
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {

            var e = modelBuilder.Entity<UserModel>();
            e.HasIndex(x => x.Email).IsUnique();
            e.HasIndex(x => x.Name).IsUnique();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<UserModel>(modelBuilder);
        }


        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new UserModel()).OnModelCreating(modelBuilder);
        }
    }
}
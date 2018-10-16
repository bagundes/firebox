using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace webviews.Models
{
        public interface IBaseModel<T> where T : BaseModel 
        {
            void Update(T model);
        }
        
    public abstract class BaseModel
    {
        public BaseModel()
        {
            UUID = System.Guid.NewGuid();
            Actived = true;
            Blocked = false;
        }

        #region Identificação

        [Display(Name="Identificador")]
        public int Id {get; protected set;}
        [NotMapped]
        [Display(Name="Identificador Primário")]
        public int Indentify {get;set;}
        public virtual int FatherId {get; protected set;}

        [Required]
        [Display(Name="Identificador Único")]
        public Guid UUID { get; set; }
        
        [Display(Name="Código")]
        public virtual int? Code {get; set;}

        [StringLength(50)]
        [Display(Name="Nome")]
        public virtual String Name {get; set;}

        

        [Display(Name="Identificador Único")]
        [NotMapped]
        public String Unique {get => UUID.ToString("N");}
        #endregion

        #region Estado
        [Display(Name="Ativado")]
        public bool Actived { get; set;}

        [Display(Name="Bloqueado")]
        public bool Blocked { get; set;}
        [Display(Name="Status")]
        public Enums.BaseStatus Status { get; set;}

        [Display(Name="Validade")]
        public DateTime? ValidUntil {get;set;}
        #endregion

        
        [Display(Name="Ordem")]
        public virtual int VisOrder {get; set;}

        #region Propriedade
        [Display(Name="Proprietário")]
        public int UserIdProper {get; set;}

        [Display(Name="Criado em")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt  { get; protected set;} = System.DateTime.Now;

        [Display(Name="Atualizado por")]
        public int UserIdUpdate {get; set;}

        [Display(Name="Atualizado em")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? UpdateAt  { get; protected set;}
        #endregion
        public virtual void Update(BaseModel model)
        {
            Code = model.Code;
            Name = model.Name;
            Actived = model.Actived;
            Blocked = model.Blocked;
            ValidUntil = model.ValidUntil;
            UpdateAt = System.DateTime.Now;
        }

        public virtual void OnModelCreating<T>(ModelBuilder modelBuilder) where T : BaseModel
        {

            var e = modelBuilder.Entity<T>();

            e.HasKey(t => new {t.Id, t.FatherId});
            e.Property(t => t.Id).ValueGeneratedOnAdd().IsRequired(true);
            e.Property(t => t.Name).HasMaxLength(50);
            e.Property(p => p.CreatedAt).ValueGeneratedOnAdd();
            e.Property(p => p.UpdateAt).ValueGeneratedOnAddOrUpdate();
            //e.HasIndex(t => t.Code).IsUnique();
            //e.HasIndex(t => t.Name).IsUnique();
            e.HasIndex(t => t.UUID).IsUnique();
        }
    }
}
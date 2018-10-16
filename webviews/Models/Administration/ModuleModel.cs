using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System;

namespace webviews.Models.Administration
{
    [Table("MODLS0")]
    public class ModuleModel: BaseModel, IBaseModel<ModuleModel>
    {
        [NotMapped]
        [Required]
        [Display(Name="Módulo")]
        public string Module {get => Name; set => Name = value;}
        
        [NotMapped]
        [Required]
        [Display(Name="Módulo Pai")]
        public int Father {get => FatherId; set => FatherId = value;}

        [Required]
        [Display(Name="Nível")]
        public int Nivel {get;set;}
        [Display(Name="Menu")]
        public bool Popup {get => String.IsNullOrEmpty(Action); }
        [Display(Name="Controle")]
        public string Controller {get;set;}
        [Display(Name="Ação")]
        public string Action {get;set;}
        [Display(Name="Grupo Icones")]
        public string PrefixIcons {get; set;} = "mid mid-";
        [Display(Name="Icone")]
        public string Icon {get;set;} = "apple-keyboard-option";

        public void Update(ModuleModel model)
        {
            Module = model.Module;
            Father = model.Father;
            Controller = model.Controller;
            Action = model.Action;
            PrefixIcons = model.PrefixIcons;
            Icon = model.Icon;
            base.Update(model);
        }

        public ModuleModel(){}
        public ModuleModel(ModuleModel father)
        {
            Father = father.Id;
            Nivel = father.Nivel + 1;
        }

        public ModuleModel(ModuleModel father, string module, string controller = null, string action = null)
        {
            Module = module;
            Father = father.Id;
            Nivel = father.Nivel + 1;
            Controller = controller;
            Action = action;
            UserIdProper = -1;
            UserIdUpdate = -1;
        }

        public void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var e = modelBuilder.Entity<ModuleModel>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            e.Property(t => t.Name).IsRequired();
            base.OnModelCreating<ModuleModel>(modelBuilder);
        }


        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new ModuleModel()).OnModelCreating(modelBuilder);
        }
    }
}
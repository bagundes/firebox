using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using static webviews.Models.BaseModel;

namespace webviews.Models.Administration
{
    [Table("PERFL0")]
    public class PerfilModel : BaseModel, IBaseModel<PerfilModel>
    {
        public PerfilModel()
        {
            View = false;
            Add = false;
            Edit = false;
            AllUsers = false;
        } 
        
        [Display(Name="PerfilId")]
        public int PerfilId {get => (int)Code; set => Code = value;}
        [Required]
        [Display(Name="Perfil")]
        public string Perfil {get => Name; set => Name = value;}

        [Required]
        [Display(Name="Módulo ID")]
        public int ModuleId {get;set;}
        
        [NotMapped]
        [Display(Name="Módulo")]
        public ModuleModel Module {get; set;} = new ModuleModel();

        [Display(Name="Visualizar")]
        public bool View {get; set;}  = false;
        [Display(Name="Adicionar")]
        public bool Add {get;set;} = false;
        [Display(Name="Editar")]
        public bool Edit {get;set;}  = false;
        [Display(Name="Ver todos os usuários")]
        public bool AllUsers {get;set;}  = false;

        public void Update(PerfilModel model)
        {
            base.Update(model);
            Perfil = model.Perfil;
            ModuleId = model.ModuleId;

            View = model.View;
            Add = model.Add;
            Edit = model.Edit;
            AllUsers = model.AllUsers;
        }
        public void OnModelCreating(ModelBuilder modelBuilder) 
        {
            var e = modelBuilder.Entity<PerfilModel>();
            //e.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired(true);
            base.OnModelCreating<PerfilModel>(modelBuilder);
        }


        public static void ModelCreating(ModelBuilder modelBuilder)
        {
            (new PerfilModel()).OnModelCreating(modelBuilder);
        }
    }
}
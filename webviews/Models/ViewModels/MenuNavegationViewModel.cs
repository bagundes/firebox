using System.Collections.Generic;
using webviews.Models.Administration;
using webviews.Repositories.Administration;
using System.Linq;

namespace webviews.Models.ViewModels
{
    public class MenuNavegationViewModel
    {
        
        public readonly List<ModuleModel> ListModuleModel = new List<ModuleModel>();


        public MenuNavegationViewModel(UserModel userModel, IPerfilRepository PerfilRepository, IModuleRepository ModuleRepository)
        {
            if(userModel.Admin)
            {
                ListModuleModel = ModuleRepository.GetAll();
            } else {
                var perfilModel = PerfilRepository.GetPerfilId(userModel.PerfilId);
                
                ListModuleModel = ModuleRepository.GetByPerfil(perfilModel);
            }
        }
    }
}
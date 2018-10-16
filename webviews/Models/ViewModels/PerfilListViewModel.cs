using webviews.Models.Administration;
using webviews.Repositories.Administration;
using System.Linq;
using System.Collections.Generic;

namespace webviews.Models.ViewModels
{
    public class PerfilListViewModel
    {
        public readonly List<PerfilModel> PerfilsModel;

        public PerfilListViewModel(IPerfilRepository PerfilRepository)
        {
            PerfilsModel = PerfilRepository.Get().OrderBy( t => t.Module.FatherId).OrderBy( t => t.Module.Nivel).OrderBy( t => t.Module.VisOrder).ToList();
        }
    }
}
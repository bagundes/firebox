using System.Collections.Generic;
using webviews.Models.Administration;
using webviews.Repositories.Administration;
using Microsoft.AspNetCore.Mvc.Rendering;
using webviews.Repositories.Invariable;
namespace webviews.Models.ViewModels
{
    public class UsersViewModel
    {
        public List<UserModel> ListUserModel {get; set;} = new List<UserModel>();
        
        public UserModel UserModel {get;set;}

        public IEnumerable<SelectListItem> SelPerfils {get;set;}
        public IEnumerable<SelectListItem> SelVendors {get;set;}

        public UsersViewModel() {}
        public UsersViewModel(int userId, IUserRepository UserRepository, Enums.PermissionsControl permission)
        {
            switch(permission)
            {
                case Enums.PermissionsControl.YesAll:
                    ListUserModel = UserRepository.Get(); break;
                case Enums.PermissionsControl.Yes:
                    ListUserModel = UserRepository.GetListByUser(userId); break;
            }
        }

        public UsersViewModel(string unique, 
            IUserRepository UserRepository, 
            IPerfilRepository PerfilRepository,
            IVendorRepository VendorRepository)
        {
            UserModel = UserRepository.Get(unique);
            SelPerfils = PerfilRepository.GetForSelect();
            SelVendors = VendorRepository.GetForSelect();
        }
    }
}
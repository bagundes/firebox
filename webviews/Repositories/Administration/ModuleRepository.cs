using System.Collections.Generic;
using webviews.Models.Administration;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using System;

namespace webviews.Repositories.Administration
{

    public interface IModuleRepository : IBaseRepository<ModuleModel>
    {
        List<ModuleModel> GetChildren(int fatherId, bool recursive = false);
        ModuleModel Add(ModuleModel model, ModuleModel father);
        ModuleModel Add(ModuleModel father, string module, string controller = null, string action = null);
        List<ModuleModel> GetAll();
        List<ModuleModel> GetByPerfil(List<PerfilModel> perfils);
    }
    public class ModuleRepository : BaseRepository<ModuleModel>, IModuleRepository
    {
        


        public ModuleRepository(AppContext context) : base(context)
        {

        }

        public ModuleModel Add(ModuleModel model, ModuleModel father)
        {
            model.Father = father.Id;
            model.Nivel  = father.Nivel + 1;
            return this.Add(model);
        }

        public ModuleModel Add(ModuleModel father, string module, string controller = null, string action = null)
        {
            var model = new ModuleModel(father, module, controller, action);


            var vis = 0;
            if(dbSet.Where(t => t.FatherId == father.Id && t.Nivel == model.Nivel).Any()) // Max null - gera erro
                vis = dbSet.Where(t => t.FatherId == father.Id && t.Nivel == model.Nivel).Max(t => t.VisOrder);

            model.VisOrder = vis + 1;
            return this.Add(model);
        }

        public void CreateDefault()
        {
            if(dbSet.Any())
                return;

            #region Administracao 
            // 1.       Administracao
            // 1.1      Usuários
            // 1.1.1    Cadastro
            // 1.1.2    Clientes
            // 1.2      Perfil
            // 1.2.1    Cadastro
            // 1.2.2    Usuários
            // 1.3      Clientes
            // 1.3.1    Lista de Preço
            // 1.3.1    Usuários

            var m01 = new ModuleModel() {
                Module = "Administração",
                VisOrder = 1,
                UserIdProper = 1,
                Father = 0,
                UserIdUpdate = 1,
                Nivel = 1
            };
            
            var m01_admininst = Add(m01);
            var m0101_usuario = Add(m01_admininst, "Usuários");
            var m010101_cadas = Add(m0101_usuario,"Cadastro","User","List");
            var m010102_clien = Add(m0101_usuario,"Clientes","Client","ListUser");
            var m0102_perfil_ = Add(m01_admininst, "Perfil");
            var m010201_cadas = Add(m0102_perfil_,"Cadastro","Perfil","List");
            var m010202_usuar = Add(m0102_perfil_,"Usuários","Perfil","Users");
            var m0103_cliente = Add(m01_admininst,"Clientes");
            var m010301_listp = Add(m0103_cliente,"Lista de Preço","ListPrice","Client");
            var m010302_vende = Add(m0103_cliente,"Vendedores","Client","ListClient");
            
            #endregion
            #region Vendas
            // 2.   Vendas
            // 2.1  Orçamento
            // 2.2  Pedido de venda
            // 2.3  Nota Fiscal
            // 2.4  Efetivar (Solicitações)
            // 2.5  Histórico

            var m02 = new ModuleModel() {
                Module = "Vendas",
                VisOrder = 2,
                UserIdProper = 1,
                Father = 0,
                UserIdUpdate = 1,
                Nivel = 1
            };
            
            var m02_vendas___ = Add(m02);
            var m0201_orcamen = Add(m02_vendas___, "Orçamento","Budget", "List");
            var m0202_pedidod = Add(m02_vendas___, "Pedido de Venda","Order", "List");
            var m0203_notafis = Add(m02_vendas___, "Nota Fiscal","Invoice", "List");
            var m0204_efetiva = Add(m02_vendas___, "Efetivar (Solicitações)","Documents", "List");
            var m0204_histori = Add(m02_vendas___, "Histórico","Documents", "Status");
            #endregion
            #region Registrar
            // 3.   Registrar
            // 3.1  Atividades
            
            var m03 = new ModuleModel() {
                Module = "Registrar",
                VisOrder = 3,
                UserIdProper = 1,
                Father = 0,
                UserIdUpdate = 1,
                Nivel = 1
            };
            
            var m03_registrar = Add(m03);
            var m0301_ativida = Add(m03_registrar, "Atividades","Activities", "List");
            #endregion
        }

        public override ModuleModel Add(ModuleModel model)
        {
            SecurityRulles(ref model, Enums.ActionRepository.Add);
            return base.Add(model);
        }

        public override List<ModuleModel> GetListByCode(int? code)
        {
            return dbSet.Where(t => t.Code == code).OrderBy(t => t.VisOrder).ToList();
        }
 
        public override void SecurityRulles(ref ModuleModel model, Enums.ActionRepository action)
        {
            switch (action)
            {
                case Enums.ActionRepository.All:
                    this.SecurityRulles(ref model, action);
                    SecurityRulles(ref model, Enums.ActionRepository.Add);
                    SecurityRulles(ref model, Enums.ActionRepository.Update);
                    SecurityRulles(ref model, Enums.ActionRepository.Delete);
                    SecurityRulles(ref model, Enums.ActionRepository.None); 
                    break;
                case Enums.ActionRepository.Add: break;
                case Enums.ActionRepository.Update: break;
                case Enums.ActionRepository.Delete: break;
                case Enums.ActionRepository.None: break;

            }

            if(model.Nivel < 0 || model.Nivel > 3)
                throw new Exception("Nivel deverá estar entre 1 a 3");

            base.SecurityRulles(ref model, action); 

            #region Required
            #endregion
        }

        public List<ModuleModel> GetChildren(int fatherId, bool recursive = false)
        {
            return GetListByFather(fatherId);

        }

        public List<ModuleModel> GetAll()
        {
            return dbSet.ToList();
        }

        public List<ModuleModel> GetByPerfil(List<PerfilModel> perfils)
        {
            var modules = new List<ModuleModel>();
            
            foreach(var perfil in perfils)
                modules.Add(Get(perfil.ModuleId));

            return modules;

        }
    }
}
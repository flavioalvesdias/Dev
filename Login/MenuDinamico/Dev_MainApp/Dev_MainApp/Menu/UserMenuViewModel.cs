using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MenuDinamico;
using System.Web.Security;
using Dev_Appdb.Models;

namespace Dev_MainApp.Menu
{
    public class UserMenuViewModel
    {
        private DevAppDB contextDB = new DevAppDB();
        private int userId { get; set; }
               
        public UserMenuViewModel() 
        {
            setInfoUser();
        }
        
        /// <summary>
        ///  Retorna todos os menus ativos
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Dev_Appdb.Models.Menu> GetUserMenuAdmin()
        {
            var menu = (from l in contextDB.Menu
                        where l.Active.Equals(true)

                        select l).AsEnumerable();

            return menu;
        }


        /// <summary>
        /// Retorna todas as visões ativas
        /// </summary>
        /// <returns></returns>
        private IEnumerable<ViewAppMenu> GetUserViewAppByMenuAdmin()
        {
            var view = (from k in contextDB.View
                        where k.Active.Equals(true)
                        select new ViewAppMenu
                        {
                            MenuId = k.MenuId,
                            ViewId = k.ViewId,
                            Action = k.ActionName,
                            Controller = k.ControllerName,
                            Description = k.Descricao,
                            MenuPaiId = k.MenuId
                            
                        }
                            ).OrderBy(x => x.ViewId).AsEnumerable();

            return view;

        }


        public List<IMenu> GetMainMenu()
        {

            if (userId > 0)
            {
                IEnumerable<Dev_Appdb.Models.Menu> menu;

                menu = GetUserMenuAdmin();
                
                var items = new List<IMenu>();

                foreach (var menuUser in menu)
                {
                    items.Add(new MenuDinamico.Menu
                    {
                        Id = menuUser.MenuId,
                        Descricao = menuUser.Descricao,
                        MenuPaiId = menuUser.MenuPaiId,
                        Url = "/",
                        Controller = "",
                        Action = ""
                    });
                }

                return items;
            }
            else
            {
                return null;
            }
        }


        public List<IMenu> GetViewApp()
        {

            if (userId > 0)
            {
                IEnumerable<ViewAppMenu> viewAppMenu;

                viewAppMenu = GetUserViewAppByMenuAdmin();
                

                var items = new List<IMenu>();

                foreach (var viewApp in viewAppMenu)
                {
                    items.Add(new MenuDinamico.Menu
                    {
                        Id = viewApp.ViewId,
                        Descricao = viewApp.Description,
                        Action = viewApp.Action,
                        Controller = viewApp.Controller,
                        MenuPaiId = viewApp.MenuPaiId

                    });
                }

                return items;
            }
            else
            {
                return null;
            }

        }

        private void setInfoUser()
        {
            userId = 0;
            if (Membership.GetUser()!= null)
            {
                userId = Convert.ToInt16(Membership.GetUser().ProviderUserKey.ToString());
            }
            
        }

        public class ViewAppMenu
        {
            public  int MenuId { get; set; }
            public int MenuPaiId { get; set; }
            public  int ViewId { get; set; }
            public  string Description { get; set; }
            public  string Controller { get; set; }
            public  string Action { get; set; }
        }

        public class infoUser
        {
            public int UserId { get; set; }
            public Boolean IsAdmin { get; set; }
        }
    }
}

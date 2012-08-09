using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Data;
using System.Web.Mvc.Html;


namespace MenuDinamico
{
    public static class MenuHelper
    {
        /// <summary>
        /// As duas properties abaixo serão utilizadas para criar o menu princial e o menu com o link para as
        /// visões do sistema.
        /// </summary>
        public static List<IMenu> siteMainMenu { get; set; }
        public static List<IMenu> siteViewApp { get; set; }

        /// <summary>
        /// Método responsável por criar o helper. Este método irá retornar uma string com o conteúdo do menu
        /// da aplicação.
        /// Observação: Inserir nas referências do projetos as seguintes DLL's:
        /// System.Web; System.Web.Mvc
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="menuMain"></param>
        /// <param name="menuView"></param>
        /// <returns></returns>
        public static MvcHtmlString SiteMenuList(this HtmlHelper helper, List<IMenu> menuMain,
            List<IMenu> menuView)
        {
            try
            {
                siteMainMenu = menuMain;
                siteViewApp = menuView;

                if (siteMainMenu == null || siteMainMenu.Count == 0)
                    return MvcHtmlString.Empty;

                return MvcHtmlString.Create(dMenuItems(helper));
            }
            catch
            {
            }

            return null;
        }

        /// <summary>
        /// Método responsável por criar a string do Menu dinâmico
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        private static string dMenuItems(HtmlHelper helper)
        {
            try
            {
                string tagFinal = "";
                string tagLiSub = "";
                var mainMenu = siteMainMenu.Where(p => p.MenuPaiId.Equals(null));
                foreach (var main in mainMenu)
                {
                    tagLiSub = "";
                    var liSubFinal = new TagBuilder("li");
                    var liView = new TagBuilder("li");

                    var liSub = new TagBuilder("li");
                    var ulSub = new TagBuilder("ul");
                    var divSub = new TagBuilder("div");

                    var liFinal = new TagBuilder("li");
                    var ulFinal = new TagBuilder("ul");
                    var dvFinal = new TagBuilder("div");


                    var subMenu = siteMainMenu.Where(p => p.MenuPaiId.Equals(main.Id));

                    foreach (var sub in subMenu)
                    {
                        var viewApp = siteViewApp.Where(p => p.MenuPaiId.Equals(sub.Id));

                        divSub.InnerHtml = "";
                        ulSub.InnerHtml = "";
                        foreach (var view in viewApp)
                        {
                            liView.InnerHtml = helper.ActionLink(view.Descricao, view.Action, view.Controller).ToHtmlString();
                            ulSub.InnerHtml += liView.ToString();
                        }

                        //divSub.InnerHtml = ulSub.ToString();
                        liSub.InnerHtml = "<a href='#'>" + sub.Descricao + "</a>";
                        if (ulSub.InnerHtml != "")
                            liSubFinal.InnerHtml = liSub.InnerHtml + ulSub.ToString();
                        else
                            liSubFinal.InnerHtml = liSub.InnerHtml;

                        ulFinal.InnerHtml = liSubFinal.ToString();
                        tagLiSub += ulFinal.InnerHtml;
                    }
                    ulFinal.InnerHtml = tagLiSub;
                    //dvFinal.InnerHtml = ulFinal.ToString();
                    liFinal.InnerHtml = "<a href='#'>" + main.Descricao + "</a>";

                    if (tagLiSub != "")
                        liFinal.InnerHtml += ulFinal.ToString();


                    tagFinal += liFinal.ToString();

                }
                return tagFinal;
            }
            catch
            {

            }
            return null;
        }
    }
}

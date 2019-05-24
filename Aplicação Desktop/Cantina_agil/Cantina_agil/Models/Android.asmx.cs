using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Cantina_agil.Models
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Android : System.Web.Services.WebService
    {
        private static Cantina_agilEntities db = new Cantina_agilEntities();

        [WebMethod]
        public static IQueryable<Produto> SelectProdutos()
        {
            return db.Produto.Where(a => a.ativoProduto != false);
        }
    }
}

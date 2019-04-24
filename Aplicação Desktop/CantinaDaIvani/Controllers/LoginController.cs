using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CantinaDaIvani.Controllers
{
    public class LoginController : Controller
    {
        private string serverAdress = "Server=ESN509VMSSQL;Database=2019_3it_LuannCampos;User id=Aluno;Password=Senai1234";

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            //saves on Database
            SqlConnection con = new SqlConnection(serverAdress);

            con.Open();
            SqlCommand query = new SqlCommand("SELECT * FROM Usuario WHERE nickname = @name and password = @password ", con);

            SqlDataReader reader = query.ExecuteReader();
            if (reader.Read())
            {
                con.Close();
                return RedirectToAction("Index");
            }
            query.ExecuteNonQuery();
            con.Close();

            return RedirectToAction("Index");
        }
    }
}
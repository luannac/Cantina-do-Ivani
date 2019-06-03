using Cantina_agil.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Cantina_agil
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private static Cantina_agilEntities db = new Cantina_agilEntities();

        [WebMethod]
        public bool enviaSugestao(string sugestao)
        {
            Sugestao suges = new Sugestao();
            suges.sugestao1 = sugestao;

            db.Sugestao.Add(suges);

            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

            }
            return false;

            /*
            //Configuração da conexão com o MySlq
            SqlConnection conexao = new SqlConnection(
                 "Server=ESN509VSSQL;Database=CantinaAgil;User=aluno;Pwd=Senai1234;SslMode=none");

            string sql = "INSERT INTO Sugestao VALUES(@sugestao);";

            //vinculando o comando SQL e a conexão
            SqlCommand comando = new SqlCommand(sql, conexao);

            //passagem de valores para cada parâmetro do SQL
            comando.Parameters.AddWithValue("@sugestao", sugestao);

            conexao.Open(); //abrir a conexão

            //executar o comando e testar quantas linhas foram alteradas
            if (comando.ExecuteNonQuery() != 0)// retorna quantas linhas foram alteradas. Usa pra update, delete também (pra select não!!!)
            {
                conexao.Close();
                return true;
            }
            else
            {
                conexao.Close();
                return false;
            }*/
        }

        // :::: WEB METHOD PARA O MOBILE VER A TABELA DE PRODUTOS - SALGADOS (SELECT TABELA DE SUGETÕES) :::: //
        [WebMethod]
        public void verSalgados()
        {
            List<String> lista = new List<string>();
            IQueryable<Produto> result = db.Produto.Where(a => a.tipo.Equals("S"));

            foreach (var item in result)
            {
                lista.Add(item.idProduto + " " + item.nomeProduto + " " + item.valor);
            }

            //Configura a saída do HTML como JSON e a saída de caracteres como UTF-8
            Context.Response.ContentType = "application/json; charset=utf-8";
            //Conteúdo a ser convertido para JSON
            Context.Response.Write(new JavaScriptSerializer().Serialize(lista));

            //Caso a listaCliente não tenha encontrado nada no banco, será serializado um
            //objeto cliente em branco o que não ocasionará erro no webservice


            /*
            //Configuração da conexão com o MySlq
            SqlConnection conexao = new SqlConnection(
                 "Server=ESN509VSSQL;Database=CantinaAgil;User=aluno;Pwd=Senai1234;SslMode=none");

            //se der erro ver se o tipo cadastrado é S minúsculo
            //no android fica montado o adapter, list view etc pra mostrar os dados da tabela
            //essa query no sql é assim: selecione o campos x, y, z etc da tabela A onde campo w = "bla bla bla" 
            string sql = "SELECT idProduto, nomeProduto, valor FROM produto WHERE tipo = 'S';";

            //vinculando o comando SQL e a conexão
            SqlCommand comando = new SqlCommand(sql, conexao);

            //passagem de valores para cada parâmetro do SQL


            conexao.Open(); //abrir a conexão

            //executar o comando e testar quantas linhas foram alteradas
            if (comando.ExecuteNonQuery() != 0)// retorna quantas linhas foram alteradas. Usa pra update, delete também (pra select não!!!)
            {
                conexao.Close();
            }
            else
            {
                conexao.Close();
            }*/
        }

        // :::: WEB METHOD PARA O MOBILE VER A TABELA DE PRODUTOS - REFEIÇÕES (SELECT TABELA DE SUGETÕES) :::: //
        [WebMethod]
        public void verRefeicoes()
        {
            List<String> lista = new List<string>();
            IQueryable<Produto> result = db.Produto.Where(a => a.tipo.Equals("R"));

            foreach (var item in result)
            {
                lista.Add(item.idProduto + " " + item.nomeProduto + " " + item.valor);
            }

            //Configura a saída do HTML como JSON e a saída de caracteres como UTF-8
            Context.Response.ContentType = "application/json; charset=utf-8";
            //Conteúdo a ser convertido para JSON
            Context.Response.Write(new JavaScriptSerializer().Serialize(lista));

            /*
            //Configuração da conexão com o MySlq
            SqlConnection conexao = new SqlConnection(
                 "Server=ESN509VSSQL;Database=CantinaAgil;User=aluno;Pwd=Senai1234;SslMode=none");

            //se der erro ver se o tipo cadastrado é R minúsculo
            //no android fica montado o adapter, list view etc pra mostrar os dados da tabela
            //essa query no sql é assim: selecione o campos x, y, z etc da tabela A onde campo w = "bla bla bla" 
            string sql = "SELECT idProduto, nomeProduto, valor FROM produto WHERE tipo = 'R';";

            //vinculando o comando SQL e a conexão
            SqlCommand comando = new SqlCommand(sql, conexao);

            //passagem de valores para cada parâmetro do SQL


            conexao.Open(); //abrir a conexão

            //executar o comando e testar quantas linhas foram alteradas
            if (comando.ExecuteNonQuery() != 0)// retorna quantas linhas foram alteradas. Usa pra update, delete também (pra select não!!!)
            {
                conexao.Close();
            }
            else
            {
                conexao.Close();
            }*/
        }


        // :::: WEB METHOD PARA O MOBILE VER A TABELA DE PRODUTOS - BEBIDAS (SELECT TABELA DE SUGETÕES) :::: //
        [WebMethod]
        public void verBebidas()
        {

            List<String> lista = new List<string>();
            IQueryable<Produto> result = db.Produto.Where(a => a.tipo.Equals("B"));

            foreach (var item in result)
            {
                lista.Add(item.idProduto + " " + item.nomeProduto + " " + item.valor);
            }

            //Configura a saída do HTML como JSON e a saída de caracteres como UTF-8
            Context.Response.ContentType = "application/json; charset=utf-8";
            //Conteúdo a ser convertido para JSON
            Context.Response.Write(new JavaScriptSerializer().Serialize(lista));

            /*

            //Configuração da conexão com o MySlq
            SqlConnection conexao = new SqlConnection(
                 "Server=ESN509VSSQL;Database=CantinaAgil;User=aluno;Pwd=Senai1234;SslMode=none");

            //se der erro ver se o tipo cadastrado é B minúsculo
            //no android fica montado o adapter, list view etc pra mostrar os dados da tabela
            //essa query no sql é assim: selecione o campos x, y, z etc da tabela A onde campo w = "bla bla bla" 
            string sql = "SELECT idProduto, nomeProduto, valor FROM produto WHERE tipo = 'B';";

            //vinculando o comando SQL e a conexão
            SqlCommand comando = new SqlCommand(sql, conexao);

            //passagem de valores para cada parâmetro do SQL


            conexao.Open(); //abrir a conexão

            //executar o comando e testar quantas linhas foram alteradas
            if (comando.ExecuteNonQuery() != 0)// retorna quantas linhas foram alteradas. Usa pra update, delete também (pra select não!!!)
            {
                conexao.Close();
            }
            else
            {
                conexao.Close();
            }*/
        }
    }
}

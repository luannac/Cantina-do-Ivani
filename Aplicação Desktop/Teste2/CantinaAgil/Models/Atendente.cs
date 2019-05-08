/*
Programa: Cantina Agil
Autor: Luann
Data: 07/04/2019
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CantinaAgil.Controllers;

namespace CantinaAgil.Models
{

    public partial class Atendente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Atendente()
        {
            this.Sangria = new HashSet<Sangria>();
        }
    
        public int idAtendente { get; set; }
        public string nomeAtendente { get; set; }
        public string loginAtendente { get; set; }
        public string senhaAtendente { get; set; }
        public string emailAtendente { get; set; }
        public Nullable<bool> ativoAtendente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sangria> Sangria { get; set; }

        public bool Login( )
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["BCD"].ConnectionString);
            try
            {
                con.Open();
                SqlCommand comando = new SqlCommand("SELECT * FROM Atendente where nomeAtendente = @login AND senhaAtendente = @password AND ativoAtendente IS NULL or ativoAtendente != 0");
                comando.Parameters.AddWithValue("@login", loginAtendente);
                comando.Parameters.AddWithValue("@password", senhaAtendente);

                SqlDataReader resposta = comando.ExecuteReader();

                if (resposta.Read())
                {/*
                    LogController.globalAtendente.idAtendente = Convert.ToInt32(resposta["idAtendente"]);
                    LogController.globalAtendente.nomeAtendente = resposta["nomeAtendente"].ToString();
                    LogController.globalAtendente.loginAtendente = resposta["loginAtendente"].ToString();
                    LogController.globalAtendente.senhaAtendente = resposta["senhaAtendente"].ToString();
                    LogController.globalAtendente.emailAtendente = resposta["emailAtendente"].ToString();
                    */
                    idAtendente = Convert.ToInt32(resposta["idAtendente"]);
                    nomeAtendente = resposta["nomeAtendente"].ToString();
                    emailAtendente = resposta["emailAtendente"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                
            }
            finally
            {
                con.Close();
            }
            return false;
        }
    }
}

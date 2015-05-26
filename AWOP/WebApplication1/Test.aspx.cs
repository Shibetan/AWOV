using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Controladores;
using Entidades;

namespace WebApplication1
{
    public partial class Test : System.Web.UI.Page
    {

        public DataTable dtActividades;
        private CActividad cActividad;

        protected void Page_Load(object sender, EventArgs e)
        {
            cActividad = new CActividad();

            if (!Page.IsPostBack)
            {
                dtActividades = cActividad.getActividades().Tabla;
    

            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Resultados.aspx");
        }
    }
}
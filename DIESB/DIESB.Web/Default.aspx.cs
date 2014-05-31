using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DIESB.Negocio;
using System.Collections.Generic;

namespace DIESB.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlEstado.DataSource = Instituicao.GetUFS();
            ddlEstado.DataBind();
        }

        protected void ddlEstado_Click(object sender, EventArgs e)
        {
            String estado = ddlEstado.SelectedValue;
        }
    }
}

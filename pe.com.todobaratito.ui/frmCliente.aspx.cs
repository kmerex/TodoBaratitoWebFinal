using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using pe.com.todobaratito.bal;
using pe.com.todobaratito.bo;

namespace pe.com.todobaratito.ui
{
    public partial class frmCliente : System.Web.UI.Page
    {
        private ClienteBAL bal = new ClienteBAL();
        private DistritoBAL baldis = new DistritoBAL();
        private TipoDocumentoBAL baltipd = new TipoDocumentoBAL();
        private ClienteBO obj = new ClienteBO();
        private DistritoBO objdis = new DistritoBO();
        private TipoDocumentoBO objtipd = new TipoDocumentoBO();

        //Declaramos variables globales
        private int cod = 0, coddis = 0, codtipd = 0, indice = -1;
        private string nom = "", apep = "", apem = "", doc = "", dir = "", tel = "", cel = "", cor = "";

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (gvCliente.PageIndex < gvCliente.PageCount - 1)
            {
                gvCliente.PageIndex += 1;
                CargarCliente();
                BindPager();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Desbloquear();
            btnNuevo.Enabled = false;
            Limpiar();
            txtCod.Text = bal.MostrarCodigoCliente().ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                MessageBox.Show("Ingresar el Nombre");
                txtNom.Focus();

            }
            else if (txtApep.Text == "")
            {
                MessageBox.Show("Ingresar el Apellido Paterno");
                txtApep.Focus();

            }
            else if (txtApem.Text == "")
            {
                MessageBox.Show("Ingresar el Apellido Materno");
                txtApem.Focus();

            }
            else if (txtDoc.Text == "")
            {
                MessageBox.Show("Ingresar Documento");
                txtDoc.Focus();

            }
            else if (txtDir.Text == "")
            {
                MessageBox.Show("Ingresar Dirección");
                txtDir.Focus();

            }
            else if (txtTel.Text == "")
            {
                MessageBox.Show("Ingresar Telefono");
                txtTel.Focus();

            }
            else if (txtCel.Text == "")
            {
                MessageBox.Show("Ingresar Celular");
                txtCel.Focus();

            }
            else if (txtCor.Text == "")
            {
                MessageBox.Show("Ingresar Correo");
                txtCor.Focus();

            }
            else if (cboDistrito.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccionar un Distrito");
                cboDistrito.Focus();
            }
            else if (cboTipoDocumento.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccionar un Tipo de Documento");
                cboTipoDocumento.Focus();
            }
            else
            {
                //capturando valores
                nom = txtNom.Text;
                apep = txtApep.Text;
                apem = txtApem.Text;
                doc = txtDoc.Text;
                dir = txtDir.Text;
                tel = txtTel.Text;
                cel = txtCel.Text;
                cor = txtCor.Text;
                coddis = Convert.ToInt32(cboDistrito.SelectedValue.ToString());
                codtipd = Convert.ToInt32(cboTipoDocumento.SelectedValue.ToString());
                if (chkEst.Checked == true)
                {
                    est = true;
                }
                else
                {
                    est = false;
                }
                //Enviamos los valores a la clase
                obj.nombre = nom;
                obj.apellidopaterno = apep;
                obj.apellidomaterno = apem;
                obj.documento = doc;
                obj.direccion = dir;
                obj.telefono = tel;
                obj.celular = cel;
                obj.correo = cor;
                obj.estado = est;

                objdis.codigo = coddis;
                obj.distrito = objdis;
                objtipd.codigo = codtipd;
                obj.tipodocumento = objtipd;

                //ejecutamos la funcion
                res = bal.RegistrarCliente(obj);
                if (res == true)
                {
                    MessageBox.Show("Se registro el Cliente");
                    CargarCliente();
                    Limpiar();
                    Bloquear();
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se registro el Cliente");
                    Limpiar();
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //capturando valores
            cod = Convert.ToInt32(txtCod.Text);
            nom = txtNom.Text;
            apep = txtApep.Text;
            apem = txtApem.Text;
            doc = txtDoc.Text;
            dir = txtDir.Text;
            tel = txtTel.Text;
            cel = txtCel.Text;
            cor = txtCor.Text;
            coddis = Convert.ToInt32(cboDistrito.SelectedValue.ToString());
            codtipd = Convert.ToInt32(cboTipoDocumento.SelectedValue.ToString());
            if (chkEst.Checked == true)
            {
                est = true;
            }
            else
            {
                est = false;
            }
            //Enviamos los valores a la clase
            //Enviamos los valores a la clase
            obj.codigo = cod;
            obj.nombre = nom;
            obj.apellidopaterno = apep;
            obj.apellidomaterno = apem;
            obj.documento = doc;
            obj.direccion = dir;
            obj.telefono = tel;
            obj.celular = cel;
            obj.correo = cor;
            obj.estado = est;

            objdis.codigo = coddis;
            obj.distrito = objdis;
            objtipd.codigo = codtipd;
            obj.tipodocumento = objtipd;

            //ejecutamos la funcion
            res = bal.ActualizarCliente(obj);
            if (res == true)
            {
                MessageBox.Show("Se actualizo el Cliente");
                CargarCliente();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se actualizo el Cliente");
                Limpiar();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturando valores
            cod = Convert.ToInt32(txtCod.Text);

            if (chkEst.Checked == true)
            {
                est = true;
            }
            else
            {
                est = false;
            }
            //Enviamos los valores a la clase
            obj.codigo = cod;


            //declaramos una variable para el cuadro de dialogo
            DialogResult resultado = MessageBox.Show("¿Quieres eliminar el Cliente?", "Eliminado el Cliente", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
                //ejecutamos la funcion
                res = bal.EliminarCliente(obj);
                if (res == true)
                {
                    MessageBox.Show("Se elimino el Cliente");
                    CargarCliente();
                    Limpiar();
                    Bloquear();
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se elimino el Cliente");
                    Limpiar();
                }
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            //capturando valores
            cod = Convert.ToInt32(txtCod.Text);

            if (chkEst.Checked == true)
            {
                est = true;
            }
            else
            {
                est = false;
            }
            //Enviamos los valores a la clase
            obj.codigo = cod;

            //declaramos una variable para el cuadro de dialogo
            DialogResult resultado = MessageBox.Show("¿Quieres habilitar el Cliente?", "Habilitado el Cliente", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
                //ejecutamos la funcion
                res = bal.HabilitarCliente(obj);
                if (res == true)
                {
                    MessageBox.Show("Se habilito el Cliente");
                    CargarCliente();
                    Limpiar();
                    Bloquear();
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se habilito el Cliente");
                    Limpiar();
                }
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (gvCliente.PageIndex > 0)
            {
                gvCliente.PageIndex -= 1;
                CargarCliente();
                BindPager();
            }
        }
        private void BindPager()
        {
            int totalPages = (int)Math.Ceiling((double)bal.MostrarClienteTodo().Count / gvCliente.PageSize);
            List<int> pageNumbers = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pageNumbers.Add(i);
            }
            rptPager.DataSource = pageNumbers;
            rptPager.DataBind();
        }

        protected void gvCliente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarCliente();
            BindPager();
        }

        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //cuando seleccionamos la fila de la tabla
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;
                //cupturamos el indice
                int index = Convert.ToInt32(e.CommandArgument);
                //fila seleccionada
                GridViewRow selectedRow = gvCliente.Rows[index];
                //asignamos los valores a los controles
                txtCod.Text = selectedRow.Cells[0].Text;
                txtNom.Text = HttpUtility.HtmlDecode(selectedRow.Cells[1].Text);
                txtApep.Text = HttpUtility.HtmlDecode(selectedRow.Cells[2].Text);
                txtApem.Text = HttpUtility.HtmlDecode(selectedRow.Cells[3].Text);
                txtDoc.Text = selectedRow.Cells[4].Text;
                txtDir.Text = HttpUtility.HtmlDecode(selectedRow.Cells[5].Text);
                txtTel.Text = selectedRow.Cells[6].Text;
                txtCel.Text = selectedRow.Cells[7].Text;
                txtCor.Text = selectedRow.Cells[8].Text;
                //para la marca
                string distritoseleccionada = HttpUtility.HtmlDecode(selectedRow.Cells[9].Text);
                //buscamos dentro de la lista marca
                List<DistritoBO> distritos = baldis.MostrarDistrito();
                DistritoBO distritoencontrada = distritos.FirstOrDefault(d => d.nombre.Equals(distritoseleccionada, StringComparison.OrdinalIgnoreCase));
                int codd = -1;
                if (distritoencontrada != null)
                {
                    codd = distritoencontrada.codigo;
                }
                else
                {
                    codd = 0;
                }
                cboDistrito.SelectedValue = codd.ToString();
                //para la tipoDocumento
                string tipoDocumentoseleccionada = HttpUtility.HtmlDecode(selectedRow.Cells[10].Text);
                //buscamos dentro de la lista marca
                List<TipoDocumentoBO> tipos = baltipd.MostrarTipoDocumento();
                TipoDocumentoBO tipoDocumentoencontrada = tipos.FirstOrDefault(t => t.nombre.Equals(tipoDocumentoseleccionada, StringComparison.OrdinalIgnoreCase));
                int codt = -1;
                if (tipoDocumentoencontrada != null)
                {
                    codt = tipoDocumentoencontrada.codigo;
                }
                else
                {
                    codt = 0;
                }
                cboTipoDocumento.SelectedValue = codt.ToString();

                //para el checkbox
                if (((selectedRow.Cells[11].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
                {
                    chkEst.Checked = true;
                }
                else
                {
                    chkEst.Checked = false;
                }

            }
        }

        private bool est = false, res = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Bloquear();
            SoloLectura();
            if (!IsPostBack)
            {
                CargarCliente();
                BindPager();
                //cargamos los combos
                CargarCombos();
            }
        }

        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            txtApep.Enabled = false;
            txtApem.Enabled = false;
            txtDoc.Enabled = false;
            txtDir.Enabled = false;
            txtTel.Enabled = false;
            txtCel.Enabled = false;
            txtCor.Enabled = false;

            cboDistrito.Enabled = false;
            cboTipoDocumento.Enabled = false;
            chkEst.Enabled = false;
            btnRegistrar.Enabled = false;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            btnHabilitar.Enabled = false;
        }

        private void Desbloquear()
        {
            txtCod.Enabled = true;
            txtNom.Enabled = true;
            txtApep.Enabled = true;
            txtApem.Enabled = true;
            txtDoc.Enabled = true;
            txtDir.Enabled = true;
            txtTel.Enabled = true;
            txtCel.Enabled = true;
            txtCor.Enabled = true;

            cboDistrito.Enabled = true;
            cboTipoDocumento.Enabled = true;
            chkEst.Enabled = true;
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnHabilitar.Enabled = true;
        }
        private void Limpiar()
        {
            txtCod.Text="";
            txtNom.Text = ""; 
            txtApep.Text = "";
            txtApem.Text = "";
            txtDoc.Text = "";
            txtDir.Text = "";
            txtTel.Text = "";
            txtCel.Text = "";
            txtCor.Text = "";

            cboDistrito.SelectedIndex = 0;
            cboTipoDocumento.SelectedIndex = 0;
            chkEst.Checked = false;
          
        }
        private void SoloLectura()
        {
            txtCod.ReadOnly = true;
        }
        private void CargarCombos()
        {
            //generamos listas con los valores de la base de datos
            List<DistritoBO> distritos = baldis.MostrarDistrito();
            List<TipoDocumentoBO> tipos = baltipd.MostrarTipoDocumento();
            //insertamos un valor dentro de la lista
            DistritoBO distrito = new DistritoBO
            {
                codigo = 0,
                nombre = "Seleccione un Distrito",
                estado = false
            };
            TipoDocumentoBO tipodocumento = new TipoDocumentoBO
            {
                codigo = 0,
                nombre = "Seleccione un Tipo de Documento",
                estado = false
            };
            distritos.Insert(0, distrito);
            tipos.Insert(0, tipodocumento);
            //cargamos los combos
            //distrito
            cboDistrito.DataSource = distritos;
            //es lo que se muestra en el combo
            cboDistrito.DataTextField = "nombre";
            //valor al seleccionar el combo
            cboDistrito.DataValueField = "codigo";
            cboDistrito.DataBind();

            cboTipoDocumento.DataSource = tipos;
            //es lo que se muestra en el combo
            cboTipoDocumento.DataTextField = "nombre";
            //valor al seleccionar el combo
            cboTipoDocumento.DataValueField = "codigo";
            cboTipoDocumento.DataBind();

        }
        private void CargarCliente()
        {
            List<ClienteBO> categorias = bal.MostrarClienteTodo();
            //asignamos la lista al Datagridview
            gvCliente.DataSource = categorias;
            gvCliente.DataBind();
        }
    }
}
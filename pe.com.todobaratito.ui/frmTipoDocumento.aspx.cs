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
    public partial class frmTipoDocumento : System.Web.UI.Page
    {
        //Creamos un objeto de TipoDocumentoBAL
        private TipoDocumentoBAL bal = new TipoDocumentoBAL();

        //creamos un objeto de la clase TipoDocumentoO

        private TipoDocumentoBO obj = new TipoDocumentoBO();

        //Declaramos variables globales
        private int cod = 0, indice = -1;
        private string nom = "";
        private bool est = false, res = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Bloquear();
            //solo lectura
            SoloLectura();
            //llamamos al procedimiento para cargar TipoDocumento
            CargarTipoDocumento();
            BindPager();
        }
        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
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
            chkEst.Checked = false;
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Desbloquear();
            btnNuevo.Enabled = false;
            //Limpiamos 
            Limpiar();
            //asignamos el focus
            txtNom.Focus();
            //Mostramos el codigo 
            txtCod.Text = bal.MostrarCodigoTipoDocumento().ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            //validar el registro
            if (txtNom.Text == "")
            {
                MessageBox.Show("Ingresa el nombre");
                txtNom.Focus();
            }
            else
            {
                //Capturando valores
                nom = txtNom.Text;
                est = chkEst.Checked;
                //enviamos los valores al objeto
                obj.nombre = nom;
                obj.estado = est;
                //llamamos a la funcion para registrar
                res = bal.RegistrarTipoDocumento(obj);
                if (res == true)
                {
                    MessageBox.Show("Se registro el Tipo de Documento con éxito");
                    //que se muestren los datos de TipoDocumento
                    CargarTipoDocumento();
                    //Limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;

                }
                else
                {
                    MessageBox.Show("No se registro el Tipo de Documento");
                    //que se muestren los datos de TipoDocumento
                    CargarTipoDocumento();
                    //Limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;
                }

            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //Capturando valores
            cod = Convert.ToInt32(txtCod.Text);
            nom = txtNom.Text;
            est = chkEst.Checked;
            //enviamos los valores al objeto
            obj.codigo = cod;
            obj.nombre = nom;
            obj.estado = est;
            //llamamos a la funcion para registrar
            res = bal.ActualizarTipoDocumento(obj);
            if (res == true)
            {
                MessageBox.Show("Se actualizó el Tipo de Documento con éxito");
                //que se muestren los datos de TipoDocumento
                CargarTipoDocumento();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;

            }
            else
            {
                MessageBox.Show("No se actualizó el Tipo de Documento");
                //que se muestren los datos de marca
                CargarTipoDocumento();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //capturando valores
            cod = Convert.ToInt32(txtCod.Text);
            //enviamos los valores al objeto
            obj.codigo = cod;
            //declaramos una variable para el cuadro de dialogo
            DialogResult resultado = MessageBox.Show("¿Quieres eliminar el Tipo de Documento?", "Eliminando Tipo de Documento", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
                //llamamos a la funcion para registrar
                res = bal.EliminarTipoDocumento(obj);
                if (res == true)
                {
                    MessageBox.Show("Se elimino el Tipo de Documento");
                    //que se muestre los datos de TipoDocumento
                    CargarTipoDocumento();
                    //limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se elimino el Tipo de Documento");
                    //que se muestre los datos de marca
                    CargarTipoDocumento();
                    //limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;
                }
            }
        }

        protected void btnHabilitar_Click(object sender, EventArgs e)
        {
            //Capturando valores
            cod = Convert.ToInt32(txtCod.Text);
            //enviamos los valores al objeto
            obj.codigo = cod;

            //llamamos a la funcion para registrar
            res = bal.HabilitarTipoDocumento(obj);
            if (res == true)
            {
                MessageBox.Show("Se habilito el Tipo de Documento con éxito");
                //que se muestren los datos de TipoDocumento
                CargarTipoDocumento();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;

            }
            else
            {
                MessageBox.Show("No se habilito el Tipo de Documento");
                //que se muestren los datos de marca
                CargarTipoDocumento();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;
            }
        }

        protected void gvTipoDocumento_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //cuando seleccionamos la fila de la tabla
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;
                //cupturamos el indice
                int index = Convert.ToInt32(e.CommandArgument);
                //fila seleccionada
                GridViewRow selectedRow = gvTipoDocumento.Rows[index];
                //asignamos los valores a los controles
                txtCod.Text = selectedRow.Cells[0].Text;
                txtNom.Text = selectedRow.Cells[1].Text;
                //para el checkbox
                if (((selectedRow.Cells[2].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
                {
                    chkEst.Checked = true;
                }
                else
                {
                    chkEst.Checked = false;
                }

            }
        }
        //creamos un procedimiento para la paginacion
        private void BindPager()
        {
            int totalPages = (int)Math.Ceiling((double)bal.MostrarTipoDocumentoTodo().Count / gvTipoDocumento.PageSize);
            List<int> pageNumbers = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pageNumbers.Add(i);
            }
            rptPager.DataSource = pageNumbers;
            rptPager.DataBind();
        }

        protected void gvTipoDocumento_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarTipoDocumento();
            BindPager();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (gvTipoDocumento.PageIndex > 0)
                        {
                            gvTipoDocumento.PageIndex -= 1;
                            CargarTipoDocumento();
                            BindPager();
                        }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (gvTipoDocumento.PageIndex < gvTipoDocumento.PageCount - 1)
            {
                gvTipoDocumento.PageIndex += 1;
                CargarTipoDocumento();
                BindPager();
            }
        }

        private void SoloLectura()
        {
            txtCod.ReadOnly = true;
        }

        //creamos un prcedimiento para cargar el DataGridView
        private void CargarTipoDocumento()
        {
            List<TipoDocumentoBO> tipos = bal.MostrarTipoDocumentoTodo();
            //asignamos la lista al datagridview
            gvTipoDocumento.DataSource = tipos;
            gvTipoDocumento.DataBind();
        }
    }
}
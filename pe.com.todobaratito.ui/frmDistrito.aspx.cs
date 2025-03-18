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
    public partial class frmDistrito : System.Web.UI.Page
    {
        //Creamos un objeto de DistritoBAL
        private DistritoBAL bal = new DistritoBAL();

        //creamos un objeto de la clase DistritoBO

        private DistritoBO obj = new DistritoBO();

        //Declaramos variables globales
        private int cod = 0, indice = -1;
        private string nom = "";
        private bool est = false, res = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //bloqueamos
            Bloquear();
            //solo lectura
            SoloLectura();
            //llamamos al procedimiento para cargar distritos
            CargarDistrito();
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

        private void SoloLectura()
        {
            txtCod.ReadOnly = true;
        }

        //creamos un prcedimiento para cargar el DataGridView
        
        private void CargarDistrito()
        {
            List<DistritoBO> distritos = bal.MostrarDistritoTodo();
            //asignamos la lista al datagridview
            gvDistrito.DataSource = distritos;
            gvDistrito.DataBind();
        }




        //creamos un procedimiento para la paginacion
        private void BindPager()
        {
            int totalPages = (int)Math.Ceiling((double)bal.MostrarDistritoTodo().Count / gvDistrito.PageSize);
            List<int> pageNumbers = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pageNumbers.Add(i);
            }
            rptPager.DataSource = pageNumbers;
            rptPager.DataBind();
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
            txtCod.Text = bal.MostrarCodigoDistrito().ToString();
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
                res = bal.RegistrarDistrito(obj);
                if (res == true)
                {
                    MessageBox.Show("Se registro el Distrito con éxito");
                    //que se muestren los datos de marca
                    CargarDistrito();
                    //Limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;

                }
                else
                {
                    MessageBox.Show("No se registro el Distrito");
                    //que se muestren los datos de marca
                    CargarDistrito();
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
            res = bal.ActualizarDistrito(obj);
            if (res == true)
            {
                MessageBox.Show("Se actualizó el Distrito con éxito");
                //que se muestren los datos de marca
                CargarDistrito();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;

            }
            else
            {
                MessageBox.Show("No se actualizó el Distrito");
                //que se muestren los datos de marca
                CargarDistrito();
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
            DialogResult resultado = MessageBox.Show("¿Quieres eliminar el Distrito?", "Eliminando Distrito", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
                //llamamos a la funcion para registrar
                res = bal.EliminarDistrito(obj);
                if (res == true)
                {
                    MessageBox.Show("Se elimino el Distrito");
                    //que se muestre los datos de marca
                    CargarDistrito();
                    //limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se elimino el Distrito");
                    //que se muestre los datos de marca
                    CargarDistrito();
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
            obj.codigo = cod;
            //declaramos una variable para el cuadro de dialogo
            DialogResult resultado = MessageBox.Show("¿Quieres habilitar el distrito?", "Habilitando Distrito", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
        //llamamos a la funcion para registrar
                        res = bal.HabilitarDistrito(obj);
                    if (res == true)
                    {
                        MessageBox.Show("Se habilito el Distrito con éxito");
                        //que se muestren los datos de marca
                        CargarDistrito();
                        //Limpiamos
                        Limpiar();
                        //bloqueamos
                        Bloquear();
                        //desbloqueamos el boton nuevo
                        btnNuevo.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show("No se habilito el Distrito");
                        //que se muestren los datos de marca
                        CargarDistrito();
                        //Limpiamos
                        Limpiar();
                        //bloqueamos
                        Bloquear();
                        //desbloqueamos el boton nuevo
                        btnNuevo.Enabled = true;
                    }
            }
       
        }

        protected void gvDistrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //cuando seleccionamos la fila de la tabla
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;
                //cupturamos el indice
                int index = Convert.ToInt32(e.CommandArgument);
                //fila seleccionada
                GridViewRow selectedRow = gvDistrito.Rows[index];
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

        protected void gvDistrito_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarDistrito();
            BindPager();

        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (gvDistrito.PageIndex > 0)
            {
                gvDistrito.PageIndex -= 1;
                CargarDistrito();
                BindPager();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            {
                gvDistrito.PageIndex += 1;
                CargarDistrito();
                BindPager();
            }
        }
    }
}
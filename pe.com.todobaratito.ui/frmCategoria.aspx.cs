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
    public partial class Categoria : System.Web.UI.Page
    {
        //Creamos un objeto de CategoriaBAL
        private CategoriaBAL bal = new CategoriaBAL();

        //creamos un objeto de la clase CategoriaBO

        private CategoriaBO obj = new CategoriaBO();

        //Declaramos variables globales
        private int cod = 0, indice = -1;
        private string nom = "";
        private bool est = false, res = false;

        //esto es equivalente al metodo constructor
        protected void Page_Load(object sender, EventArgs e)
        {
            //bloqueamos
            Bloquear();
            //solo lectura
            SoloLectura();
            //llamamos al procedimiento para cargar categorias
            CargarCategoria();
            BindPager();

        }

        //creamos un procedimiento para bloquear
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

        //creamos un procedimiento para desbloquear
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

        //creamos un procedimiento para limpiar
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
            txtCod.Text = bal.MostrarCodigoCategoria().ToString();
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
                res = bal.RegistrarCategoria(obj);
                if (res == true)
                {
                    MessageBox.Show("Se registro la categoría con éxito");
                    //que se muestren los datos de categoria
                    CargarCategoria();
                    //Limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;

                }
                else
                {
                    MessageBox.Show("No se registro la categoría");
                    //que se muestren los datos de categoria
                    CargarCategoria();
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
            res = bal.ActualizarCategoria(obj);
            if (res == true)
            {
                MessageBox.Show("Se actualizó la categoría con éxito");
                //que se muestren los datos de categoria
                CargarCategoria();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;

            }
            else
            {
                MessageBox.Show("No se actualizó la categoría");
                //que se muestren los datos de categoria
                CargarCategoria();
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
            DialogResult resultado = MessageBox.Show("¿Quieres eliminar la categoria?", "Eliminado Categoria", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
                //llamamos a la funcion para registrar
                res = bal.EliminarCategoria(obj);
                if (res == true)
                {
                    MessageBox.Show("Se elimino la categoria");
                    //que se muestre los datos de categoria
                    CargarCategoria();
                    //limpiamos
                    Limpiar();
                    //bloqueamos
                    Bloquear();
                    //desbloqueamos el boton nuevo
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se elimino la categoria");
                    //que se muestre los datos de categoria
                    CargarCategoria();
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
            //declaramos una variable para el cuadro de dialogo
            DialogResult resultado = MessageBox.Show("¿Quieres habilitar la categoria?", "Habilitando Categoria", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
         //llamamos a la funcion para registrar
                res = bal.HabilitarCategoria(obj);
            if (res == true)
            {
                MessageBox.Show("Se habilito la categoría con éxito");
                //que se muestren los datos de categoria
                CargarCategoria();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;

            }
            else
            {
                MessageBox.Show("No se habilito la categoría");
                //que se muestren los datos de categoria
                CargarCategoria();
                //Limpiamos
                Limpiar();
                //bloqueamos
                Bloquear();
                //desbloqueamos el boton nuevo
                btnNuevo.Enabled = true;
            }
            }
       
        }

        protected void gvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //cuando seleccionamos la fila de la tabla
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;
                //cupturamos el indice
                int index = Convert.ToInt32(e.CommandArgument);
                //fila seleccionada
                GridViewRow selectedRow = gvCategoria.Rows[index];
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
            int totalPages = (int)Math.Ceiling((double)bal.MostrarCategoriaTodo().Count / gvCategoria.PageSize);
            List<int> pageNumbers = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pageNumbers.Add(i);
            }
            rptPager.DataSource = pageNumbers;
            rptPager.DataBind();
        }

        protected void gvCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarCategoria();
            BindPager();


        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (gvCategoria.PageIndex > 0)
            {
                gvCategoria.PageIndex -= 1;
                CargarCategoria();
                BindPager();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (gvCategoria.PageIndex < gvCategoria.PageCount - 1)
            {
                gvCategoria.PageIndex += 1;
                CargarCategoria();
                BindPager();
            }
        }


        //creamos un procedimiento de solo lectura
        private void SoloLectura()
        {
            txtCod.ReadOnly = true;
        }

        //creamos un prcedimiento para cargar el DataGridView
        private void CargarCategoria()
        {
            List<CategoriaBO> categorias = bal.MostrarCategoriaTodo();
            //asignamos la lista al datagridview
            gvCategoria.DataSource = categorias;
            gvCategoria.DataBind();
        }
    }
}
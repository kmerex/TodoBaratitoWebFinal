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
    public partial class frmProducto : System.Web.UI.Page
    {
        private ProductoBAL bal = new ProductoBAL();
        private MarcaBAL balmar = new MarcaBAL();
        private CategoriaBAL balcat = new CategoriaBAL();
        private ProductoBO obj = new ProductoBO();
        private MarcaBO objmar = new MarcaBO();
        private CategoriaBO objcat = new CategoriaBO();
        private int cod = 0, codmar = 0, codcat = 0, can = 0, indice = -1;
        private string nom = "", des = "";
        private double pre = 0;
        private bool est = false, res = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            Bloquear();
            SoloLectura();
            if (!IsPostBack)
            {
                CargarProducto();
                BindPager();
                //cargamos los combos
                CargarCombos();
            }
        }
protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Desbloquear();
            btnNuevo.Enabled = false;
            Limpiar();
            txtCod.Text = bal.MostrarCodigoProducto().ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtNom.Text == "")
            {
                MessageBox.Show("Ingrese el nombre");
                txtNom.Focus();
            }
            else if (txtDes.Text == "")
            {
                MessageBox.Show("Ingrese la descripcion");
                txtDes.Focus();
            }
            else if (txtPre.Text == "")
            {
                MessageBox.Show("Ingrese el precio");
                txtPre.Focus();
            }
            else if (txtCan.Text == "")
            {
                MessageBox.Show("Ingrese la cantidad");
                txtCan.Focus();
            }
            else if (cboMarca.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione una marca");
                cboMarca.Focus();
            }
            else if (cboCategoria.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione una categoria");
                cboCategoria.Focus();
            }
            else
            {
                //capturando valores
                nom = txtNom.Text;
                des = txtDes.Text;
                pre = Convert.ToDouble(txtPre.Text);
                can = Convert.ToInt32(txtCan.Text);
                codmar = Convert.ToInt32(cboMarca.SelectedValue.ToString());
                codcat = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
                if (chkEst.Checked == true)
                {
                    est = true;
                }
                else
                {
                    est = false;
                }
                //enviamos los valores a la clase
                obj.nombre = nom;
                obj.descripcion = des;
                obj.precio = pre;
                obj.cantidad = can;
                obj.estado = est;

                objmar.codigo = codmar;
                obj.marca = objmar;

                objcat.codigo = codcat;
                obj.categoria = objcat;

                //ejecutamos la funcion
                res = bal.RegistrarProducto(obj);
                if (res == true)
                {
                    MessageBox.Show("Se registro el producto");
                    CargarProducto();
                    Limpiar();
                    Bloquear();
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo  registrar el producto");
                    Limpiar();
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            //capturando valores
            cod = Convert.ToInt32(txtCod.Text);
            nom = txtNom.Text;
            des = txtDes.Text;
            pre = Convert.ToDouble(txtPre.Text);
            can = Convert.ToInt32(txtCan.Text);
            codmar = Convert.ToInt32(cboMarca.SelectedValue.ToString());
            codcat = Convert.ToInt32(cboCategoria.SelectedValue.ToString());
            if (chkEst.Checked == true)
            {
                est = true;
            }
            else
            {
                est = false;
            }
            //enviamos los valores a la clase
            obj.codigo = cod;
            obj.nombre = nom;
            obj.descripcion = des;
            obj.precio = pre;
            obj.cantidad = can;
            obj.estado = est;

            objmar.codigo = codmar;
            obj.marca = objmar;

            objcat.codigo = codcat;
            obj.categoria = objcat;

            //ejecutamos la funcion
            res = bal.ActualizarProducto(obj);
            if (res == true)
            {
                MessageBox.Show("Se actualizo el producto");
                CargarProducto();
                Limpiar();
                Bloquear();
                btnNuevo.Enabled = true;
            }
            else
            {
                MessageBox.Show("No se pudo  actualizar el producto");
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
            //enviamos los valores a la clase
            obj.codigo = cod;

            //declaramos una variable para el cuadro de dialogo
            DialogResult resultado = MessageBox.Show("¿Quieres eliminar el producto?", "Eliminado Categoria", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
                //ejecutamos la funcion
                res = bal.EliminarProducto(obj);
                if (res == true)
                {
                    MessageBox.Show("Se elimino el producto");
                    CargarProducto();
                    Limpiar();
                    Bloquear();
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el producto");
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
            //enviamos los valores a la clase
            obj.codigo = cod;

            //declaramos una variable para el cuadro de dialogo
            DialogResult resultado = MessageBox.Show("¿Quieres habilitar el producto?", "Eliminado Categoria", MessageBoxButtons.YesNo);
            //evaluamos el resultado
            if (resultado == DialogResult.Yes)
            {
                //ejecutamos la funcion
                res = bal.HabilitarProducto(obj);
                if (res == true)
                {
                    MessageBox.Show("Se habilito el producto");
                    CargarProducto();
                    Limpiar();
                    Bloquear();
                    btnNuevo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No se pudo habilitar el producto");
                    Limpiar();
                }
            }
        }

        private void BindPager()
        {
            int totalPages = (int)Math.Ceiling((double)bal.MostrarProductoTodo().Count / gvProducto.PageSize);
            List<int> pageNumbers = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pageNumbers.Add(i);
            }
            rptPager.DataSource = pageNumbers;
            rptPager.DataBind();
        }

        protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //cuando seleccionamos la fila de la tabla
            if (e.CommandName == "Seleccionar")
            {
                Desbloquear();
                btnRegistrar.Enabled = false;
                //cupturamos el indice
                int index = Convert.ToInt32(e.CommandArgument);
                //fila seleccionada
                GridViewRow selectedRow = gvProducto.Rows[index];
                //asignamos los valores a los controles
                txtCod.Text = selectedRow.Cells[0].Text;
                txtNom.Text = HttpUtility.HtmlDecode(selectedRow.Cells[1].Text);
                txtDes.Text = HttpUtility.HtmlDecode(selectedRow.Cells[2].Text);
                txtPre.Text = selectedRow.Cells[3].Text;
                txtCan.Text = selectedRow.Cells[4].Text;
                //para la marca
                string marcaseleccionada = HttpUtility.HtmlDecode(selectedRow.Cells[5].Text);
                //buscamos dentro de la lista marca
                List<MarcaBO> marcas = balmar.MostrarMarca();
                MarcaBO marcaencontrada = marcas.FirstOrDefault(m => m.nombre.Equals(marcaseleccionada, StringComparison.OrdinalIgnoreCase));
                int codm = -1;
                if (marcaencontrada != null)
                {
                    codm = marcaencontrada.codigo;
                }
                else
                {
                    codm = 0;
                }
                cboMarca.SelectedValue = codm.ToString();
                //para la categoria
                string categoriaseleccionada = HttpUtility.HtmlDecode(selectedRow.Cells[6].Text);
                //buscamos dentro de la lista marca
                List<CategoriaBO> categorias = balcat.MostrarCategoria();
                CategoriaBO categoriaencontrada = categorias.FirstOrDefault(c => c.nombre.Equals(categoriaseleccionada, StringComparison.OrdinalIgnoreCase));
                int codc = -1;
                if (categoriaencontrada != null)
                {
                    codc = categoriaencontrada.codigo;
                }
                else
                {
                    codc = 0;
                }
                cboCategoria.SelectedValue = codc.ToString();

                //para el checkbox
                if (((selectedRow.Cells[7].Controls[0] as DataBoundLiteralControl).Text).Trim().Equals("Habilitado"))
                {
                    chkEst.Checked = true;
                }
                else
                {
                    chkEst.Checked = false;
                }

            }
        }

        protected void gvProducto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CargarProducto();
            BindPager();
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            if (gvProducto.PageIndex > 0)
            {
                gvProducto.PageIndex -= 1;
                CargarProducto();
                BindPager();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            if (gvProducto.PageIndex < gvProducto.PageCount - 1)
            {
                gvProducto.PageIndex += 1;
                CargarProducto();
                BindPager();
            }
        }


        private void Bloquear()
        {
            txtCod.Enabled = false;
            txtNom.Enabled = false;
            txtDes.Enabled = false;
            txtPre.Enabled = false;
            txtCan.Enabled = false;
            cboMarca.Enabled = false;
            cboCategoria.Enabled = false;
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
            txtDes.Enabled = true;
            txtPre.Enabled = true;
            txtCan.Enabled = true;
            cboMarca.Enabled = true;
            cboCategoria.Enabled = true;
            chkEst.Enabled = true;
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            btnHabilitar.Enabled = true;
        }

        //creamos un procedimiento para limpiar
        private void Limpiar()
        {
            txtCod.Text = "";
            txtNom.Text = "";
            txtDes.Text = "";
            txtPre.Text = "";
            txtCan.Text = "";
            cboCategoria.SelectedIndex = 0;
            cboMarca.SelectedIndex = 0;
            chkEst.Checked = false;
        }

        //creamos un procedimiento de solo lectura
        private void SoloLectura()
        {
            txtCod.ReadOnly = true;
        }

        private void CargarCombos()
        {
            //generamos listas con los valores de la base de datos
            List<MarcaBO> marcas = balmar.MostrarMarca();
            List<CategoriaBO> categorias = balcat.MostrarCategoria();
            //insertamos un valor dentro de la lista
            MarcaBO marca = new MarcaBO
            {
                codigo = 0,
                nombre = "Seleccione una marca",
                estado = false
            };
            CategoriaBO categoria = new CategoriaBO
            {
                codigo = 0,
                nombre = "Seleccione una categoria",
                estado = false
            };
            marcas.Insert(0, marca);
            categorias.Insert(0, categoria);
            //cargamos los combos
            //marca
            cboMarca.DataSource = marcas;
            //es lo que se muestra en el combo
            cboMarca.DataTextField = "nombre";
            //valor al seleccionar el combo
            cboMarca.DataValueField = "codigo";
            cboMarca.DataBind();
            //categoria
            cboCategoria.DataSource = categorias;
            //es lo que se muestra en el combo
            cboCategoria.DataTextField = "nombre";
            cboCategoria.DataValueField = "codigo";
            cboCategoria.DataBind();
            //valor al seleccionar el combo

        }

        private void CargarProducto()
        {
            List<ProductoBO> categorias = bal.MostrarProductoTodo();
            //asignamos la lista al Datagridview
            gvProducto.DataSource = categorias;
            gvProducto.DataBind();
        }
    }
       
    }

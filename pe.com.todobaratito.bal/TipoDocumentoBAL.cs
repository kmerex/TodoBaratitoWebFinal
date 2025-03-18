using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pe.com.todobaratito.bo;
using pe.com.todobaratito.dal;

namespace pe.com.todobaratito.bal
{
    public class TipoDocumentoBAL
    {
        TipoDocumentoDAL dal = new TipoDocumentoDAL();
        public List<TipoDocumentoBO> MostrarTipoDocumento()
        {
            return dal.MostrarTipoDocumento();
        }

        public List<TipoDocumentoBO> MostrarTipoDocumentoTodo()
        {
            return dal.MostrarTipoDocumentoTodo();
        }
        public bool RegistrarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.RegistrarTipoDocumento(t);
        }
        public bool ActualizarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.ActualizarTipoDocumento(t);
        }
        public bool EliminarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.EliminarTipoDocumento(t);
        }
        public bool HabilitarTipoDocumento(TipoDocumentoBO t)
        {
            return dal.HabilitarTipoDocumento(t);
        }
        public int MostrarCodigoTipoDocumento()
        {
            return dal.MostrarCodigoTipoDocumento();
        }

    }
}


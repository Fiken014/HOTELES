using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD_HOTELES.Mantenimientos
{
    public class cls_Hoteles_DAL
    {
        #region Variables Privadas
        //Sección de campos de la tabla
        private int _iId_Hotel;
        private string _sCodigo_Hotel, _sNombre_Hotel, _sDescripcion_Hotel, _sDireccion, _sTelefono, _sCorreo, _sUrl_Hotel, _sEstado;
        private decimal _dArea_Construccion;
        private DateTime _dFecha_Construccion;
        //Sección de campos de la tabla

        //Sección presente en todas las clases 
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        #endregion
        //Sección presente en todas las clases 

        #region Variables Públicas o Constructores
        public int iId_Hotel { get => _iId_Hotel; set => _iId_Hotel = value; }
        public string sCodigo_Hotel { get => _sCodigo_Hotel; set => _sCodigo_Hotel = value; }
        public string sNombre_Hotel { get => _sNombre_Hotel; set => _sNombre_Hotel = value; }
        public string sDescripcion_Hotel { get => _sDescripcion_Hotel; set => _sDescripcion_Hotel = value; }
        public string sDireccion { get => _sDireccion; set => _sDireccion = value; }
        public string sTelefono { get => _sTelefono; set => _sTelefono = value; }
        public string sCorreo { get => _sCorreo; set => _sCorreo = value; }
        public string sUrl_Hotel { get => _sUrl_Hotel; set => _sUrl_Hotel = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public decimal dArea_Construccion { get => _dArea_Construccion; set => _dArea_Construccion = value; }
        public DateTime dFecha_Construccion { get => _dFecha_Construccion; set => _dFecha_Construccion = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion
    }
}

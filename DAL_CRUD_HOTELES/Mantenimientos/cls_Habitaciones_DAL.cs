using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//CHECK
namespace DAL_CRUD_HOTELES.Mantenimientos
{
    public class cls_Habitaciones_DAL
    {
        #region Variables Privadas
        //Sección de campos de la tabla
        private int _iId_Habitacion, _iId_Hotel;
        private string _sDescripcion_Habitacion, _sTipo_Habitacion, _sEstado;
        //Sección de campos de la tabla

        //Sección presente en todas las clases 
        private string _sValorScalar, _sAXN, _sMSJError;
        private DataTable _dtDatos, _dtParametros;
        private int _iIdUsuarioGlobal;
        //Sección presente en todas las clases 
        #endregion

        #region Variables Públicas o Constructores
        public int iId_Habitacion { get => _iId_Habitacion; set => _iId_Habitacion = value; }
        public int iId_Hotel { get => _iId_Hotel; set => _iId_Hotel = value; }
        public string sDescripcion_Habitacion { get => _sDescripcion_Habitacion; set => _sDescripcion_Habitacion = value; }
        public string sTipo_Habitacion { get => _sTipo_Habitacion; set => _sTipo_Habitacion = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAXN { get => _sAXN; set => _sAXN = value; }
        public string sMSJError { get => _sMSJError; set => _sMSJError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public DataTable dtParametros { get => _dtParametros; set => _dtParametros = value; }
        public int iIdUsuarioGlobal { get => _iIdUsuarioGlobal; set => _iIdUsuarioGlobal = value; }
        #endregion

    }
}

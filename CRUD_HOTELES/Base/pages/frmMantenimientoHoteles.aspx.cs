using BLL_CRUD_HOTELES.Mantenimientos;
using DAL_CRUD_HOTELES.Mantenimientos;
using System.Collections.Generic;
using System.Web.Services;
using System.Globalization;
using System;
//CHECK
namespace CRUD_HOTELES.Base.pages
{
    public partial class frmMantenimientoHoteles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string CargaInfoHoteles(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Hoteles_DAL obj_Hoteles_DAL = new cls_Hoteles_DAL();
                cls_Hoteles_BLL obj_Hoteles_BLL = new cls_Hoteles_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Hoteles_DAL.iId_Hotel = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Hoteles_DAL.iId_Hotel != 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Hoteles_BLL.Obtiene_Informacion_Hoteles(ref obj_Hoteles_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Hoteles_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Hoteles_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][4].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][5].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][6].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][7].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][8].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][9].ToString() + "<SPLITER>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[0][10].ToString();
                    }
                    else
                    {
                        _mensaje = "No se encontraron registros";
                    }
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static string MantenimientoHotel(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Hoteles_DAL obj_Hoteles_DAL = new cls_Hoteles_DAL();
                cls_Hoteles_BLL obj_Hoteles_BLL = new cls_Hoteles_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Hoteles_DAL.iId_Hotel = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Hoteles_DAL.sCodigo_Hotel = obj_Parametros_JS[1].ToString();
                obj_Hoteles_DAL.sNombre_Hotel = obj_Parametros_JS[2].ToString();
                obj_Hoteles_DAL.sDescripcion_Hotel = obj_Parametros_JS[3].ToString();
                obj_Hoteles_DAL.sDireccion = obj_Parametros_JS[4].ToString();
                obj_Hoteles_DAL.sTelefono = obj_Parametros_JS[5].ToString();
                obj_Hoteles_DAL.sCorreo = obj_Parametros_JS[6].ToString();
                obj_Hoteles_DAL.sUrl_Hotel = obj_Parametros_JS[7].ToString();
                obj_Hoteles_DAL.dArea_Construccion = decimal.Parse(obj_Parametros_JS[8].ToString());
                obj_Hoteles_DAL.dFecha_Construccion = Convert.ToDateTime(obj_Parametros_JS[9].ToString()); 
                obj_Hoteles_DAL.sEstado = obj_Parametros_JS[10].ToString();
                obj_Hoteles_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[11].ToString());

                /*Si el identificador del valor de la cookie del registro es un 0:: es un dato nuevo vamos a insertar*/
                if (obj_Hoteles_DAL.iId_Hotel == 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Hoteles_BLL.crearHoteles(ref obj_Hoteles_DAL);
                }
                else
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Hoteles_BLL.modificarHoteles(ref obj_Hoteles_DAL);
                }

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Hoteles_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un registro con la misma información.";
                }
                else if (obj_Hoteles_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Hoteles_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static string eliminarHotel(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                cls_Hoteles_DAL objHotelesDAL = new cls_Hoteles_DAL();
                cls_Hoteles_BLL objHotelesBLL = new cls_Hoteles_BLL();

                objHotelesDAL.iId_Hotel = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                objHotelesDAL.iIdUsuarioGlobal = 1;

                objHotelesBLL.eliminarHoteles(ref objHotelesDAL);

                if (objHotelesDAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "No se puede eliminar el hotel, existen dependencias.";
                }
                else if (objHotelesDAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Error al intentar eliminar el registro.";
                }
                else
                {
                    _mensaje = objHotelesDAL.sValorScalar + "<SPLITER>" + "Hotel eliminado correctamente.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el hotel: " + ex.Message);
            }
        }
    }
}
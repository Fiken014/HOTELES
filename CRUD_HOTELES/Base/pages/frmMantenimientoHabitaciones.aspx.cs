using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_CRUD_HOTELES.Mantenimientos;
using DAL_CRUD_HOTELES.Mantenimientos;

namespace CRUD_HOTELES.Base.pages
{
    public partial class frmMantenimientoHabitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaInfoHabitacion(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Habitaciones_DAL obj_Habitaciones_DAL = new cls_Habitaciones_DAL();
                cls_Habitaciones_BLL obj_Habitaciones_BLL = new cls_Habitaciones_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Habitaciones_DAL.iId_Habitacion = Convert.ToInt32(obj_Parametros_JS[0].ToString());

                if (obj_Habitaciones_DAL.iId_Habitacion != 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Habitaciones_BLL.Obtiene_Informacion_Habitaciones(ref obj_Habitaciones_DAL);

                    //Evaluamos la respuesta de la lógica de negocio
                    if (obj_Habitaciones_DAL.dtDatos.Rows.Count != 0)
                    {
                        _mensaje = obj_Habitaciones_DAL.dtDatos.Rows[0][0].ToString() + "<SPLITER>" +
                                    obj_Habitaciones_DAL.dtDatos.Rows[0][1].ToString() + "<SPLITER>" +
                                    obj_Habitaciones_DAL.dtDatos.Rows[0][2].ToString() + "<SPLITER>" +
                                    obj_Habitaciones_DAL.dtDatos.Rows[0][3].ToString() + "<SPLITER>" +
                                    obj_Habitaciones_DAL.dtDatos.Rows[0][4].ToString();
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
        public static string MantenimientoHabitacion(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Habitaciones_DAL obj_Habitaciones_DAL = new cls_Habitaciones_DAL();
                cls_Habitaciones_BLL obj_Habitaciones_BLL = new cls_Habitaciones_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Habitaciones_DAL.iId_Habitacion = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Habitaciones_DAL.iId_Hotel = Convert.ToInt32(obj_Parametros_JS[1].ToString());
                obj_Habitaciones_DAL.sDescripcion_Habitacion = obj_Parametros_JS[2].ToString();
                obj_Habitaciones_DAL.sTipo_Habitacion = obj_Parametros_JS[3].ToString();
                obj_Habitaciones_DAL.sEstado = obj_Parametros_JS[4].ToString();
                obj_Habitaciones_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[5].ToString());

                /*Si el identificador del valor de la cookie del registro es un 0:: es un dato nuevo vamos a insertar*/
                if (obj_Habitaciones_DAL.iId_Habitacion == 0)
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Habitaciones_BLL.crearHabitaciones(ref obj_Habitaciones_DAL);
                }
                else
                {
                    //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                    obj_Habitaciones_BLL.modificarHabitaciones(ref obj_Habitaciones_DAL);
                }

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Habitaciones_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Ya existe un registro con la misma información.";
                }
                else if (obj_Habitaciones_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar guardar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Habitaciones_DAL.sValorScalar + "<SPLITER>" + "Información guardada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [WebMethod]
        public static string EliminarHabitaciones(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Habitaciones_DAL obj_Habitaciones_DAL = new cls_Habitaciones_DAL();
                cls_Habitaciones_BLL obj_Habitaciones_BLL = new cls_Habitaciones_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Habitaciones_DAL.iId_Habitacion = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Habitaciones_DAL.iIdUsuarioGlobal = Convert.ToInt32(obj_Parametros_JS[1].ToString());

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Habitaciones_BLL.eliminarHabitaciones(ref obj_Habitaciones_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Habitaciones_DAL.sValorScalar == "-1")
                {
                    _mensaje = "-1" + "<SPLITER>" + "Existen registros con dependencia asociados a la información que desea eliminar. Verifique!!!";
                }
                else if (obj_Habitaciones_DAL.sValorScalar == "0")
                {
                    _mensaje = "0" + "<SPLITER>" + "Ocurrió un error al intentar eliminar la información del registro. Intente de nuevo.";
                }
                else
                {
                    _mensaje = obj_Habitaciones_DAL.sValorScalar + "<SPLITER>" + "Información eliminada de forma correcta.";
                }

                return _mensaje;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
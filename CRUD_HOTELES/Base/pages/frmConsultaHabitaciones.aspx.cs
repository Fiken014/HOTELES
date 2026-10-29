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
    public partial class frmConsultaHabitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod]
        public static string CargaListaHabitaciones(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Habitaciones_DAL obj_Habitaciones_DAL = new cls_Habitaciones_DAL();
                cls_Habitaciones_BLL obj_Habitaciones_BLL = new cls_Habitaciones_BLL();

                //Descomponemos los valores que nos envíe el js y lo asignamos a nuestro objeto
                obj_Habitaciones_DAL.iId_Hotel = Convert.ToInt32(obj_Parametros_JS[0].ToString());
                obj_Habitaciones_DAL.sDescripcion_Habitacion = obj_Parametros_JS[1].ToString();
                obj_Habitaciones_DAL.sEstado = obj_Parametros_JS[2].ToString();

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Habitaciones_BLL.listarFiltrarHabitaciones(ref obj_Habitaciones_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Habitaciones_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Id Habitacion</th>" +
                        "<th>Descripcion Habitacion</th>" +
                        "<th>Hotel</th>" +
                        "<th>Estado</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Habitaciones_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: defineHabitacion(" + obj_Habitaciones_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Habitaciones_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Habitaciones_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Habitaciones_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td>" + (obj_Habitaciones_DAL.dtDatos.Rows[i][3]).ToString() + "</td>" +
                            "<td style='text-align:center'><i class='bi bi-trash-fill' onclick='javascript: eliminaHabitacion(" + obj_Habitaciones_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
                            "</tr>";
                    }

                    _mensaje += "</tbody>";
                }
                else
                {
                    _mensaje = "No se encontraron registros";
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL_CRUD_HOTELES.Mantenimientos;
using DAL_CRUD_HOTELES.Mantenimientos;

//Check
namespace CRUD_HOTELES.Base.pages
{
    public partial class frmConsultaHoteles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string CargaListaHoteles(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                // Instancias de las capas DAL y BLL
                cls_Hoteles_DAL obj_Hoteles_DAL = new cls_Hoteles_DAL();
                cls_Hoteles_BLL obj_Hoteles_BLL = new cls_Hoteles_BLL();

                // Asignar parámetros enviados desde JavaScript
                obj_Hoteles_DAL.sCodigo_Hotel = obj_Parametros_JS[0].ToString();
                obj_Hoteles_DAL.sNombre_Hotel = obj_Parametros_JS[1].ToString();
                obj_Hoteles_DAL.sEstado = obj_Parametros_JS[2].ToString();

                // Ejecutar la consulta filtrada
                obj_Hoteles_BLL.listarFiltrarHoteles(ref obj_Hoteles_DAL);

                if (obj_Hoteles_DAL.dtDatos.Rows.Count != 0)
                {
                    _mensaje = "" +
                        "<thead>" +
                        "<tr>" +
                        "<th>Id Hotel</th>" +
                        "<th>Codigo del Hotel</th>" +
                        "<th>Nombre del Hotel</th>" +
                        "<th>Descripción del Hotel</th>" +
                        "<th>Direccion del Hotel</th>" +
                        "<th>Telefono</th>" +
                        "<th>Correo</th>" +
                        "<th>Url Hotel</th>" +
                        "<th>Area de Construccion</th>" +
                        "<th>Fecha de Construccion</th>" +
                        "<th>Estado</th>" +
                        "<th style='text-align:center'>Eliminar</th>" +
                        "</tr>" +
                        "</thead>" +
                        "<tbody>";

                    for (int i = 0; i < obj_Hoteles_DAL.dtDatos.Rows.Count; i++)
                    {
                        _mensaje += "<tr><td style='cursor:pointer;' onclick='javascript: defineHotel(" + obj_Hoteles_DAL.dtDatos.Rows[i][0].ToString() + ")'>" +
                            obj_Hoteles_DAL.dtDatos.Rows[i][0].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][1].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][2].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][3].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][4].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][5].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][6].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][7].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][8].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][9].ToString() + "</td>" +
                            "<td>" + obj_Hoteles_DAL.dtDatos.Rows[i][10].ToString() + "</td>" +
                            "<td style='text-align:center'><i class='bi bi-trash-fill' onclick='javascript: eliminaHotel(" + obj_Hoteles_DAL.dtDatos.Rows[i][0].ToString() + ")' style='cursor:pointer'></i></td>" +
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

        [WebMethod]
        public static string CargaListaHotelesCombo(List<string> obj_Parametros_JS)
        {
            try
            {
                string _mensaje = string.Empty;

                //Objetos de la entidad con la que estamos trabajando
                cls_Hoteles_DAL obj_Hoteles_DAL = new cls_Hoteles_DAL();
                cls_Hoteles_BLL obj_Hoteles_BLL = new cls_Hoteles_BLL();

                //Ejecutar en la lógica de negocio el proceso o la acción necesaria
                obj_Hoteles_BLL.listarFiltrarHoteles(ref obj_Hoteles_DAL);

                //Evaluamos la respuesta de la lógica de negocio
                if (obj_Hoteles_DAL.dtDatos.Rows.Count != 0)
                {
                    for (int i = 0; i < obj_Hoteles_DAL.dtDatos.Rows.Count; i++)
                    {
                        //<option value="1">Bavaro</option>
                        _mensaje += "<option value='" + obj_Hoteles_DAL.dtDatos.Rows[i]["Id_Hotel"].ToString().Trim() + "'>" +
                                    obj_Hoteles_DAL.dtDatos.Rows[i]["Nombre_Hotel"].ToString().Trim() + "</option>";

                    }
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
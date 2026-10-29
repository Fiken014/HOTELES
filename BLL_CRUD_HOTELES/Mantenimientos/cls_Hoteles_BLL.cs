using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_CRUD_HOTELES.BD;
using DAL_CRUD_HOTELES.BD;
using DAL_CRUD_HOTELES.Mantenimientos;

namespace BLL_CRUD_HOTELES.Mantenimientos
{
    public class cls_Hoteles_BLL
    {
        public void listarFiltrarHoteles(ref cls_Hoteles_DAL obj_Hoteles_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                //Listar
                if (
                    ((obj_Hoteles_DAL.sNombre_Hotel == string.Empty) || (obj_Hoteles_DAL.sNombre_Hotel == null))
                    &&
                    ((obj_Hoteles_DAL.sEstado == string.Empty) || (obj_Hoteles_DAL.sEstado == null))
                    )
                {
                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Hoteles"];
                    obj_BD_DAL.DT_Parametros = null;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Hoteles";
                }
                else //Filtrar
                {
                    /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                    obj_Hoteles_DAL.dtParametros = null;
                    obj_Hoteles_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hoteles_DAL.dtParametros);

                    //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                    //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                    obj_Hoteles_DAL.dtParametros.Rows.Add("@Nombre_Hotel", "6", obj_Hoteles_DAL.sNombre_Hotel);
                    obj_Hoteles_DAL.dtParametros.Rows.Add("@Codigo_Hotel", "6", obj_Hoteles_DAL.sCodigo_Hotel);
                    obj_Hoteles_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Hoteles_DAL.sEstado);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Hoteles"];
                    //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Hoteles_DAL.dtParametros;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Hoteles";
                }

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hoteles_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Hoteles_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Hoteles(ref cls_Hoteles_DAL obj_Hoteles_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hoteles_DAL.dtParametros = null;
                obj_Hoteles_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hoteles_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Hoteles_DAL.dtParametros.Rows.Add("@IdHotel", "1", obj_Hoteles_DAL.iId_Hotel);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Hoteles"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hoteles_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Hoteles";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hoteles_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Hoteles_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearHoteles(ref cls_Hoteles_DAL obj_Hoteles_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hoteles_DAL.dtParametros = null;
                obj_Hoteles_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hoteles_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Codigo_Hotel", "6", obj_Hoteles_DAL.sCodigo_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Nombre_Hotel", "6", obj_Hoteles_DAL.sNombre_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Descripcion_Hotel", "6", obj_Hoteles_DAL.sDescripcion_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Hoteles_DAL.sDireccion);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Hoteles_DAL.sTelefono);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Hoteles_DAL.sCorreo);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Url_Hotel", "6", obj_Hoteles_DAL.sUrl_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Area_Construccion", "2", obj_Hoteles_DAL.dArea_Construccion);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Fecha_Construccion", "8", obj_Hoteles_DAL.dFecha_Construccion);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Hoteles_DAL.sEstado);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Hoteles_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Hoteles"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hoteles_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hoteles_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hoteles_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Hoteles_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hoteles_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarHoteles(ref cls_Hoteles_DAL obj_Hoteles_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hoteles_DAL.dtParametros = null;
                obj_Hoteles_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hoteles_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor

                obj_Hoteles_DAL.dtParametros.Rows.Add("@Id_Hotel", "1", obj_Hoteles_DAL.iId_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Codigo_Hotel", "6", obj_Hoteles_DAL.sCodigo_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Nombre_Hotel", "6", obj_Hoteles_DAL.sNombre_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Descripcion_Hotel", "6", obj_Hoteles_DAL.sDescripcion_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Direccion", "6", obj_Hoteles_DAL.sDireccion);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Telefono", "6", obj_Hoteles_DAL.sTelefono);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Hoteles_DAL.sCorreo);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Url_Hotel", "6", obj_Hoteles_DAL.sUrl_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Area_Construccion", "2", obj_Hoteles_DAL.dArea_Construccion);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Fecha_Construccion", "8", obj_Hoteles_DAL.dFecha_Construccion);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Hoteles_DAL.sEstado);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Hoteles_DAL.iIdUsuarioGlobal);


                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Hoteles"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hoteles_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hoteles_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hoteles_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Hoteles_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hoteles_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarHoteles(ref cls_Hoteles_DAL obj_Hoteles_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Hoteles_DAL.dtParametros = null;
                obj_Hoteles_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Hoteles_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Hoteles_DAL.dtParametros.Rows.Add("@IdHotel", "1", obj_Hoteles_DAL.iId_Hotel);
                obj_Hoteles_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Hoteles_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Hoteles"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Hoteles_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Hoteles_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hoteles_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Hoteles_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Hoteles_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }

}
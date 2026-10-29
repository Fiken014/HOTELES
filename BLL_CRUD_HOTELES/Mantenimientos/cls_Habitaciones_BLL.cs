using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_CRUD_HOTELES.BD;
using DAL_CRUD_HOTELES.BD;
using DAL_CRUD_HOTELES.Mantenimientos;

//CHECK cambios en listar
namespace BLL_CRUD_HOTELES.Mantenimientos
{
    public class cls_Habitaciones_BLL
    {
        public void listarFiltrarHabitaciones(ref cls_Habitaciones_DAL obj_Habitaciones_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                //Listar
                if (
                    ((obj_Habitaciones_DAL.sDescripcion_Habitacion == string.Empty) || (obj_Habitaciones_DAL.sDescripcion_Habitacion == null))
                    &&
                    ((obj_Habitaciones_DAL.iId_Hotel == 0) && (string.IsNullOrEmpty(obj_Habitaciones_DAL.sEstado)))
                    )
                {
                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LST_Habitaciones"];
                    obj_BD_DAL.DT_Parametros = null;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Habitaciones";
                }
                else //Filtrar
                {
                    /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                    obj_Habitaciones_DAL.dtParametros = null;
                    obj_Habitaciones_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Habitaciones_DAL.dtParametros);

                    //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                    //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                    obj_Habitaciones_DAL.dtParametros.Rows.Add("@Nombre_Hotel", "1", obj_Habitaciones_DAL.iId_Hotel);
                    obj_Habitaciones_DAL.dtParametros.Rows.Add("@Descripcion_Habitacion", "6", obj_Habitaciones_DAL.sDescripcion_Habitacion);
                    obj_Habitaciones_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Habitaciones_DAL.sEstado);

                    //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FIL_Habitaciones"];
                    //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                    obj_BD_DAL.DT_Parametros = obj_Habitaciones_DAL.dtParametros;
                    //Definimos un nombre lógico del data table de respuesta de la base de datos 
                    obj_BD_DAL.sNomTabla = "Habitaciones";
                }

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Habitaciones_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Habitaciones_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Obtiene_Informacion_Habitaciones(ref cls_Habitaciones_DAL obj_Habitaciones_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Habitaciones_DAL.dtParametros = null;
                obj_Habitaciones_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Habitaciones_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Id_Habitacion", "1", obj_Habitaciones_DAL.iId_Habitacion);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Habitaciones"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Habitaciones_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Habitaciones";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Habitaciones_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Habitaciones_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void crearHabitaciones(ref cls_Habitaciones_DAL obj_Habitaciones_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Habitaciones_DAL.dtParametros = null;
                obj_Habitaciones_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Habitaciones_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Descripcion_Habitacion", "6", obj_Habitaciones_DAL.sDescripcion_Habitacion);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Tipo_Habitacion", "6", obj_Habitaciones_DAL.sTipo_Habitacion);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Id_Hotel", "1", obj_Habitaciones_DAL.iId_Hotel);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Habitaciones_DAL.sEstado);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Habitaciones_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Insert_Habitaciones"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Habitaciones_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Habitaciones_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Habitaciones_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Habitaciones_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Habitaciones_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void modificarHabitaciones(ref cls_Habitaciones_DAL obj_Habitaciones_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Habitaciones_DAL.dtParametros = null;
                obj_Habitaciones_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Habitaciones_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Id_Habitacion", "1", obj_Habitaciones_DAL.iId_Habitacion);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Descripcion_Habitacion", "6", obj_Habitaciones_DAL.sDescripcion_Habitacion);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Tipo_Habitacion", "6", obj_Habitaciones_DAL.sTipo_Habitacion);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Id_Hotel", "1", obj_Habitaciones_DAL.iId_Hotel);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Estado", "6", obj_Habitaciones_DAL.sEstado);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Habitaciones_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Update_Habitaciones"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Habitaciones_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Habitaciones_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Habitaciones_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Habitaciones_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Habitaciones_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void eliminarHabitaciones(ref cls_Habitaciones_DAL obj_Habitaciones_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Habitaciones_DAL.dtParametros = null;
                obj_Habitaciones_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Habitaciones_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@Id_Habitacion", "1", obj_Habitaciones_DAL.iId_Habitacion);
                obj_Habitaciones_DAL.dtParametros.Rows.Add("@IdUsuario_Global", "1", obj_Habitaciones_DAL.iIdUsuarioGlobal);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_Delete_Habitaciones"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Habitaciones_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Habitaciones_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Habitaciones_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Habitaciones_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Habitaciones_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

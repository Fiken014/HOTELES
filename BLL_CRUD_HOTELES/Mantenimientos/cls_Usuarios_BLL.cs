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
    public class cls_Usuarios_BLL
    {
        public void Inicio_Sesion_Usuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Correo", "6", obj_Usuarios_DAL.sCorreo);
                obj_Usuarios_DAL.dtParametros.Rows.Add("@Password", "6", obj_Usuarios_DAL.sPassword);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LogIn_Usuarios"];
                //Definir el tipo de acción que vamos a ejecutar (SCALAR / NORMAL)
                obj_BD_DAL.sIndAxn = "SCALAR";
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosComando(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar;
                }
                else
                {
                    obj_Usuarios_DAL.sMSJError = obj_BD_DAL.sMsjErrorBD;
                    obj_Usuarios_DAL.sValorScalar = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Obtiene_Informacion_Usuarios(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /*Objetos para comunicación a la base de datos*/
                cls_BD_DAL obj_BD_DAL = new cls_BD_DAL(); //Objeto que tiene los atributos de acceso a datos
                cls_BD_BLL obj_BD_BLL = new cls_BD_BLL(); //Objeto que tiene la lógica de negocio de base de datos

                /*Dar forma al atributo de Data Table de Parámetros del objeto en cuestión*/
                obj_Usuarios_DAL.dtParametros = null;
                obj_Usuarios_DAL.dtParametros = obj_BD_BLL.ObtieneDTParametros(obj_Usuarios_DAL.dtParametros);

                //agregar al data table de parametros la lista de parametros que requiere el procedimiento almacenado
                //Regla: Orden de valores del Parámetro: Nombre, Código Tipo de Dato, Valor
                obj_Usuarios_DAL.dtParametros.Rows.Add("@IdUsuario", "1", obj_Usuarios_DAL.iId_Usuario);

                //Definimos el nombre del Key que contiene el valor del procedimiento almacenado de la base de datos
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Usuarios"];
                //Asignamos al DATA TABLE de Parametros de la base de datos nuestro Data Table construido anteriormente en el objeto en cuestión
                obj_BD_DAL.DT_Parametros = obj_Usuarios_DAL.dtParametros;
                //Definimos un nombre lógico del data table de respuesta de la base de datos 
                obj_BD_DAL.sNomTabla = "Usuarios";

                //Ejecutamos en base de datos la sentencia / instrucción de SQL 
                obj_BD_BLL.EjecutaProcesosTabla(ref obj_BD_DAL);

                //Validar los resultados
                //Si el mensaje de error de base de datos es vacío.... todo salió de forma correcta, recuperemos los valores
                if (obj_BD_DAL.sMsjErrorBD == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

}

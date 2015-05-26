/*
 * Creado por   : Rosario Alvarez
 * Fecha        : 25/05/2014
 * Descripción  : Clase que contiene los servicios del ADO.Net
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Entidades;

namespace Controladores
{
    public class BaseADONet
    {
        protected string cadenaConexion;

        public BaseADONet()
        {
            cadenaConexion = "Data Source=KALY\\SQLEXPRESS;Initial Catalog=orientacion_vocacional;Integrated Security=True";
            //cadenaConexion = ConfigurationManager.ConnectionStrings["WinCascada.Properties.Settings.BDGIMNASIO_cadenaConexion"].ToString();
        }


        /// <summary>
        /// RAAR: Ejecuta una setencia (un select, un procedimiento almacenado o vista) 
        /// sin enviar parámetros y retorna un DataTable
        /// </summary>
        protected Resultado ExecuteSql_Select(string query)
        {
            Resultado oResultado = new Resultado();
            DataTable dt = new DataTable();

            //Abre la conexión dentro de un bloque using para garantizar
            //que la conexión se cierre automáticamente cuando el código sale del bloque
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = null;
                SqlDataAdapter da = null;
                //necesario para comprobar la conexión a la base de datos
                try
                {
                    cmd = cn.CreateCommand();
                    cmd.Connection = cn;
                    da = new SqlDataAdapter();
                }
                catch (SqlException ex)
                {
                    oResultado.isCorrecto = false;
                    oResultado.Mensaje = ex.Message;
                    return oResultado;
                }


                try
                {
                    cmd.CommandText = query;
                    cmd.CommandType = System.Data.CommandType.Text;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    oResultado.Tabla = dt;
                    oResultado.isCorrecto = true;
                }
                catch (Exception ex)
                {
                    oResultado.isCorrecto = false;
                    oResultado.Mensaje = ex.Message;
                }
                finally
                {
                    cmd.Dispose();
                    da.Dispose();
                }
            }
            return oResultado;
        }

        /// <summary>
        /// RAAR: Ejecuta una transacción de Transact-SQL (INSERT, UPDATE O DELETE)
        /// a través de un procedimiento almacenado
        /// </summary>
        //protected Resultado ExecuteStoredProcedure_InsDelUpd(SqlCommand cmd, string storedProcedure)
        //{
        //    Resultado oResultado = new Resultado();
        //    int filasAfectadas = 0;
        //    using (SqlConnection cn = new SqlConnection(cadenaConexion))
        //    {
        //        cn.Open();
        //        //Se inicia la transacción local
        //        SqlTransaction oSqlTransaction = cn.BeginTransaction();

        //        cmd.Connection = cn;
        //        cmd.Transaction = oSqlTransaction;

        //        try
        //        {
        //            cmd.CommandText = storedProcedure;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            filasAfectadas = cmd.ExecuteNonQuery();

        //            oSqlTransaction.Commit();
        //            oResultado.isCorrecto = true;
        //            oResultado.FilasAfectadas = filasAfectadas;
        //        }
        //        catch (Exception ex)
        //        {
        //            oResultado.isCorrecto = false;
        //            oResultado.Mensaje = ex.Message;

        //            // Al producirse cualquier error, la transacción se deshace
        //            try
        //            {
        //                oSqlTransaction.Rollback();
        //            }
        //            catch (Exception ex2)
        //            {
        //                //...
        //            }
        //        }
        //        finally
        //        {
        //            oSqlTransaction.Dispose();
        //            cmd.Dispose();
        //        }
        //    }
        //    return oResultado;
        //}


        /// <summary>
        /// RAAR: Ejecuta una transacción de Transact-SQL (INSERT, UPDATE O DELETE)
        /// con un simple query
        /// </summary>
        protected Resultado ExecuteSqlTransaction_InsDelUpd(string query)
        {
            Resultado oResultado = new Resultado();
            int filasAfectadas = 0;
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlCommand cmd = cn.CreateCommand();

                //Se inicia la transacción local
                SqlTransaction oSqlTransaction = cn.BeginTransaction();

                cmd.Connection = cn;
                cmd.Transaction = oSqlTransaction;

                try
                {
                    cmd.CommandText = query;
                    filasAfectadas = cmd.ExecuteNonQuery();

                    oSqlTransaction.Commit();
                    oResultado.FilasAfectadas = filasAfectadas;
                    oResultado.isCorrecto = true;
                }
                catch (Exception ex)
                {
                    oResultado.isCorrecto = false;
                    oResultado.Mensaje = ex.Message;

                    // Al producirse cualquier error, la transacción se deshace
                    try
                    {
                        oSqlTransaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        //...
                    }
                }
                finally
                {
                    oSqlTransaction.Dispose();
                    cmd.Dispose();
                }
            }
            return oResultado;
        }


        /// <summary>
        /// RAAR: Recibe un SqlCommand y ejecuta un procedimiento almacenado en el servidor, 
        /// retornando el Id del elemento insertado
        /// </summary>
        /// <param name="cmd">recibe el comando con los parámetros</param>
        //protected Resultado ExecuteStoredProcedure_Ins(SqlCommand cmd, string storedProcedure)
        //{
        //    Resultado oResultado = new Resultado();
        //    int id = 0;

        //    using (SqlConnection cn = new SqlConnection(cadenaConexion))
        //    {
        //        cn.Open();
        //        SqlTransaction oSqlTransaction = cn.BeginTransaction();
        //        cmd.Connection = cn;
        //        cmd.Transaction = oSqlTransaction;
        //        try
        //        {
        //            cmd.CommandText = storedProcedure;
        //            cmd.CommandType = CommandType.StoredProcedure;

        //            cmd.ExecuteNonQuery();
        //            id = (int)cmd.Parameters["@Id"].Value;
        //            oSqlTransaction.Commit();

        //            oResultado.isCorrecto = true;
        //            oResultado.Id = id;

        //        }
        //        catch (Exception ex)
        //        {
        //            oResultado.isCorrecto = false;
        //            oResultado.Mensaje = ex.Message;
        //            try
        //            {
        //                oSqlTransaction.Rollback();
        //            }
        //            catch (Exception ex2)
        //            {
        //                //...
        //            }
        //        }
        //        finally
        //        {
        //            oSqlTransaction.Dispose();
        //            cmd.Dispose();
        //        }
        //    }
        //    return oResultado;
        //}
    }
}


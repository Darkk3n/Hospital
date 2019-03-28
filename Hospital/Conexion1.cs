using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Security;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace Hospital
{
    public class Conexion1
    {
        private MySqlConnection conexion;
        private MySqlDataAdapter adaptador;
        private MySqlCommand comando;
        private string _cadenaConexion;
        private string _excepcion = "";

        #region "Constructor"
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor de la clase cConexion, crea una conexion con la cadena de conexión predeterminada.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public Conexion1()
        {

            _cadenaConexion = ConfigurationManager.ConnectionStrings["Hospital"].ConnectionString;
            conexion = new MySqlConnection();
            conexion.ConnectionString = _cadenaConexion;
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Constructor de la clase cConexion, crea una conexión personalizada.
        /// </summary>
        /// <param name="cadenaConexion">Cadena de conexión</param>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public Conexion1(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
            conexion = new MySqlConnection();
            conexion.ConnectionString = _cadenaConexion;
        }
        #endregion

        #region "Propiedades"
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Obtiene la cadena de conexión.
        /// </summary>
        /// <value>Cadena de conexión</value>
        /// <remarks>
        /// </remarks>

        /// -----------------------------------------------------------------------------
        public string cadenaConexion
        {
            get
            {
                return this._cadenaConexion;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Obtiene el mensaje de error generado por una excepción en una transacción de la clase cConexion
        /// </summary>
        /// <value>Mensaje de error generado</value>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public virtual string excepcion
        {
            get
            {
                return this._excepcion;
            }
        }
        #endregion

        #region "Métodos"
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Abre la conexión.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        private void conectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Closed)
                {
                    conexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Cierra la conexión.
        /// </summary>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        private void desconectar()
        {
            try
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Obtiene un mensaje de error personalizado dependiendo el número de la excepción.
        /// </summary>
        /// <param name="excepcionSql">Excepción sql generada.</param>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        private void recuperarError(MySqlException excepcionSql)
        {
            switch (excepcionSql.Number)
            {
                case 2627:
                    this._excepcion = "El registro que intenta guardar ya se encuentra en la base de datos";
                    break;
                case 2601:
                    this._excepcion = "El registro que intenta guardar ya se encuentra en la base de datos";
                    break;
                case 547:
                    this._excepcion = "No se puede realizar la operación debido a que hay información relacionada con este registro";
                    break;
                default:
                    this._excepcion = excepcionSql.Message;
                    break;
            }

        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Ejecuta una operación que no devuelve valor.
        /// </summary>
        /// <param name="command">Comando sql a ejectuar.</param>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public void ejecutarOperacion(MySqlCommand command)
        {
            comando = command;
            comando.Connection = conexion;
            try
            {
                conectar();
                comando.ExecuteNonQuery();
                _excepcion = "";
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
            }
            finally
            {
                desconectar();
            }

        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Ejecuta una operación que no devuelve valor.
        /// </summary>
        /// <param name="consulta">Consulta sql a ejecutar.</param>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public void ejecutarOperacion(string consulta)
        {
            comando = new MySqlCommand();
            comando.CommandText = consulta;
            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
            try
            {
                conectar();
                comando.ExecuteNonQuery();
                _excepcion = "";
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
            }
            finally
            {
                desconectar();
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Ejecuta una operación recibiendo un parámetro de salida.
        /// </summary>
        /// <param name="command">Comando sql a ejecutar.</param>
        /// <returns>Parámetro de salida.</returns>
        /// <remarks>
        /// </remarks>
        /// <history>
        /// 	[Daniel Vanoye Bravo]	01/02/2007	Created
        /// </history>
        /// -----------------------------------------------------------------------------
        public string ejecutarOperacionOutput(MySqlCommand command, string parametroSalida)
        {
            comando = command;
            comando.Connection = conexion;
            try
            {
                conectar();
                comando.ExecuteNonQuery();
                _excepcion = "";
                return Convert.ToString(comando.Parameters[parametroSalida].Value);
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
                return null;
            }
            finally
            {
                desconectar();
            }


        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        ///  Ejecuta una operación recibiendo un parámetro de salida.
        /// </summary>
        /// <param name="consulta">Consulta sql a ejectutar.</param>
        /// <returns>Parámetro de salida.</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public string ejecutarOperacionOutput(string consulta)
        {
            string ultimo;
            consulta = consulta + " " + "declare @id as varchar(10) " + "select @id= @@identity " + "select @id ";
            ultimo = this.recuperarValor(consulta);
            return ultimo;

        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Obtiene un datatable a partir de la ejecución de un comando de sql.
        /// </summary>
        /// <param name="command">Comando sql a ejecutar.</param>
        /// <returns>Datatable resultado de la ejecución del comando.</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public DataTable recuperarDatatable(MySqlCommand command)
        {
            DataTable dt = new DataTable();
            comando = command;
            comando.Connection = conexion;
            try
            {
                conectar();
                adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(dt);
                _excepcion = "";
                return dt;
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
                return null;
            }
            finally
            {
                desconectar();
            }
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Obtiene un datatable a partir de la ejecución de un comando de sql.
        /// </summary>
        /// <param name="consulta">Consulta sql a ejecutar.</param>
        /// <returns>Datatable resultado de la ejecución de la consulta sql.</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public DataSet recuperarDataSet(MySqlCommand command)
        {
            DataSet ds = new DataSet();
            comando = command;
            comando.Connection = conexion;
            try
            {
                conectar();
                adaptador = new MySqlDataAdapter(comando);
                adaptador.Fill(ds);
                _excepcion = "";
                return ds;
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
                return null;
            }
            finally
            {
                desconectar();
            }
        }
        public DataTable recuperarDatatable(string consulta)
        {
            DataTable dt = new DataTable();

            try
            {
                conectar();
                adaptador = new MySqlDataAdapter(consulta, conexion);
                adaptador.Fill(dt);
                _excepcion = "";
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
            }
            finally
            {
                desconectar();
            }
            return dt;
        }
        /// -----------------------------------------------------------------------------
        /// <summary>
        /// Obtiene un valor único resultado de la ejecución de una consulta sql.
        /// </summary>
        /// <param name="consulta">Consulta sql a ejecutar.</param>
        /// <returns>Valor resultado de la ejecución de la consulta sql.</returns>
        /// <remarks>
        /// </remarks>
        /// -----------------------------------------------------------------------------
        public string recuperarValor(string consulta)
        {
            string valor;
            try
            {
                conectar();
                comando = new MySqlCommand(consulta, conexion);
                valor = comando.ExecuteScalar().ToString();
                _excepcion = "";
                return valor;
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
                return null;
            }
            finally
            {
                desconectar();
            }
        }
        public string recuperarValor(MySqlCommand command)
        {
            string valor;
            comando = command;
            comando.Connection = conexion;

            try
            {
                conectar();
                valor = comando.ExecuteScalar().ToString();
                _excepcion = "";
                return valor;
            }
            catch (MySqlException ex)
            {
                recuperarError(ex);
                return null;
            }
            finally
            {
                desconectar();
            }
        }

        #endregion
    }

}

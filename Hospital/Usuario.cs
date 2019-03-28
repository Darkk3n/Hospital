using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Hospital
{
    public class Usuario : Conexion1
    {
        public string Cod_Hosp, Nombre_Hosp, Num_Quirof, Tipo_Hosp, Presupuesto, Tipo_Serv, NombrePar;
        public string Cod_Jefe, Cod_Medico, Codigo;


        public DataTable InsertarHosp()
        {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "InsertarHospital";
            command.Parameters.AddWithValue("@Cod_Hosp", Cod_Hosp);
            command.Parameters.AddWithValue("@Nombre_Hosp", Nombre_Hosp);
            command.Parameters.AddWithValue("@Num_Quirof", Num_Quirof);
            command.Parameters.AddWithValue("@Tipo_Hosp", Tipo_Hosp);
            command.Parameters.AddWithValue("@Presupuesto", Presupuesto);
            command.Parameters.AddWithValue("@Tipo_Serv", Tipo_Serv);

            dt = recuperarDatatable(command);
            return (dt);
        }

        public DataTable InsertMed() {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "SP_MEDICO";

            command.Parameters.AddWithValue("@Cod_Jefe", Cod_Jefe);
            command.Parameters.AddWithValue("@Cod_Medico", Cod_Medico);

            dt = recuperarDatatable(command);
            return (dt);
        
        }

        public DataTable BuscarAsegura()
        {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BuscarAsegur";
            command.Parameters.AddWithValue("@NombrePar", NombrePar);

            dt = recuperarDatatable(command);
            return (dt);
        }

        public DataTable BuscarDoctor()
        {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BuscarDoctor";
            command.Parameters.AddWithValue("@NombrePar", NombrePar);

            dt = recuperarDatatable(command);
            return (dt);
        }

        public DataTable BuscarHospital()
        {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BuscarHosp";
            command.Parameters.AddWithValue("@NombrePar", NombrePar);

            dt = recuperarDatatable(command);
            return (dt);
        }

        public DataTable BorrarAsegurado()
        {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BorrarAsegurado";
            command.Parameters.AddWithValue("@Codigo", Codigo);

            dt = recuperarDatatable(command);
            return (dt);
        }

        public DataTable BorrarDoctor()
        {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BorrarDoctor";
            command.Parameters.AddWithValue("@Codigo", Codigo);

            dt = recuperarDatatable(command);
            return (dt);
        }

        public DataTable BorrarHospital()
        {
            DataTable dt;
            MySqlCommand command = new MySqlCommand();

            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "BorrarHospital";
            command.Parameters.AddWithValue("@Codigo", Codigo);

            dt = recuperarDatatable(command);
            return (dt);
        }
    }
}
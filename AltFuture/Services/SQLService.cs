﻿using Microsoft.Data.SqlClient;
using System.Data;

namespace AltFuture.Services
{
    public class SQLService : ISQLService
    {

        public IConfiguration _configuration;
        public SQLService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public DataTable GetDT(string storedProcName, List<Object>? parameters = null, string connectionStringName = "AltFuture")
        {
            DataTable dt = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName));
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(storedProcName, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlCommandBuilder.DeriveParameters(cmd);
            SqlDataAdapter sqlAdapter = new SqlDataAdapter(storedProcName, sqlConnection);
            sqlAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (cmd.Parameters.Count > 1)
            {
                for (int i = 1; i < cmd.Parameters.Count; i++)
                {
                    cmd.Parameters[i].Value = parameters[i - 1];
                    //System.Diagnostics.Debug.WriteLine(cmd.Parameters[i].Value);
                }
            }

            sqlAdapter.SelectCommand = cmd;
            sqlAdapter.Fill(dt);
            sqlConnection.Close();

            return dt;
        }


        public int GetRetVal(string storedProcName, List<Object>? parameters = null, string connectionStringName = "AltFuture")
        {
            int retVal;

            SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString(connectionStringName));
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(storedProcName, sqlConnection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlCommandBuilder.DeriveParameters(cmd);

            if (cmd.Parameters.Count > 1)
            {
                for (int i = 1; i < cmd.Parameters.Count; i++)
                {
                    cmd.Parameters[i].Value = parameters[i - 1];
                    //System.Diagnostics.Debug.WriteLine(cmd.Parameters[i].Value);
                }
            }

            retVal = cmd.ExecuteNonQuery();
            sqlConnection.Close();

            return retVal;
        }
    }
}
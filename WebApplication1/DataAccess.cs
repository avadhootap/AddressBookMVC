﻿using AddressBook.Modules;
using Microsoft.AspNetCore.Components;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;

namespace AddressBook
{
    public class DataAccess
    {
        //name of server to connect,name of database,and Authentication type. 
        string connectionstring = "data source=localHost; database=AddressBook;TrustServerCertificate=true; integrated security=True";

        public DataTable Get(string query, IDictionary<string, object> mydictionary = null)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            if (mydictionary != null)
            {
                foreach (var data in mydictionary)
                {
                    cmd.Parameters.AddWithValue(data.Key, data.Value);
                }
            }
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            connection.Close();
            return dt;
        }

        //declaring generic type method
        //public void add<T>(string query,T entity)
        //{
        //    //making connection
        //    SqlConnection connection = new SqlConnection(connectionstring);
        //    //opening connnection
        //    connection.Open();
        //    //performing commands
        //    SqlCommand cmd = new SqlCommand(query, connection);

        //    //declaring property array which holdes properties ex pesonId,firstName,lastName etc.
        //    PropertyInfo[] prop=entity.GetType().GetProperties();
        //    foreach (PropertyInfo property in prop)
        //    {
        //        //holdes the name of parameter ex firstname,lastName
        //        string parameterName = $"@{property.Name}";
        //        //holds the value
        //        object parametervalue = entity.GetType().GetProperty(property.Name).GetValue(entity);
        //        //add values into parameter ex FirstName       "Ram"
        //        cmd.Parameters.AddWithValue(parameterName, parametervalue);
        //    }
        //   //Executes query which is used for INSERT UPDATE DELETE
        //    cmd.ExecuteNonQuery();
        //    connection.Close();
        //}
        //public void update<T>(string query,T entity)
        //{
        //    SqlConnection connection = new SqlConnection( connectionstring);
        //    connection.Open();
        //    SqlCommand cmd=new SqlCommand(query, connection);
        //    PropertyInfo[] prop = entity.GetType().GetProperties();
        //    foreach (PropertyInfo property in prop)
        //    {

        //        string parameterName = $"@{property.Name}";
        //        object parametervalue = entity.GetType().GetProperty(property.Name).GetValue(entity);

        //        cmd.Parameters.AddWithValue(parameterName, parametervalue);
        //    }
        //    cmd.ExecuteNonQuery();
        //    connection.Close();

        //}

        //public void delete<T>(string query,T entity,string id)
        //{

        //    SqlConnection connection = new SqlConnection(connectionstring);
        //    connection.Open();
        //    SqlCommand cmd = new SqlCommand(query, connection);
        //    PropertyInfo[] prop = entity.GetType().GetProperties();
        //    for(int i=0;i<1;i++)
        //    {
        //        string parameterName = prop[i].Name;
        //        cmd.Parameters.AddWithValue(parameterName, id);

        //    }
        //    cmd.ExecuteNonQuery();
        //    connection.Close();
        //}

        public DataTable GetDetailsBypersonId(string query,string personId)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@personId", personId);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            connection.Close();
            return dt;

        }

        public void adddata(string query,IDictionary<string,Object>mydictionary) 
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
           if(mydictionary != null)
            {
                foreach (var data in mydictionary)
                {
                    command.Parameters.AddWithValue(data.Key, data.Value);
                }
            }
            command.ExecuteNonQuery();
            connection.Close();
          
        }

        public void updatedata(string query,IDictionary<string,Object> mydictionary)
        {
            SqlConnection connection = new SqlConnection( connectionstring);
            connection.Open();
            SqlCommand cmd=new SqlCommand(query, connection);
            if(mydictionary != null )
            {
                foreach (var data in mydictionary)
                {
                    cmd.Parameters.AddWithValue(data.Key,data.Value);
                }
            }
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void DeleteData(string query,string id,IDictionary<string ,Object> mydictionary) 
        {
            SqlConnection connection=new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query,connection);
            if(mydictionary != null)
            {
                foreach (var data in mydictionary)
                {
                    cmd.Parameters.AddWithValue(data.Key, id);
                }
            }
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}

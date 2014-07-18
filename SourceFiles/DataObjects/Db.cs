using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace DoFactory.DataLayer.DataObjects
{
       public static class Db
    {
        // Note: Static initializers are thread safe.
        // If this class had a static constructor then these initialized 
        // would need to be initialized there.
        private static readonly string dataProvider = ConfigurationManager.AppSettings.Get("DataProvider");
        private static readonly DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings[dataProvider].ConnectionString;
        
        #region Data Update handlers

        /// <summary>
        /// Executes Update statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Number of rows affected.</returns>
        public static int Update(string sql)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Executes Insert statements in the database. Optionally returns new identifier.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <param name="getId">Value indicating whether newly generated identity is returned.</param>
        /// <returns>Newly generated identity value (autonumber value).</returns>
        public static int Insert(string sql, bool getId)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    
                    connection.Open();
                    command.ExecuteNonQuery();

                    int id = -1;

                    // Check if new identity is needed.
                    if (getId)
                    {
                        // Execute db specific autonumber or identity retrieval code
                        // SELECT SCOPE_IDENTITY() -- for SQL Server
                        // SELECT @@IDENTITY -- for MS Access
                        // SELECT MySequence.NEXTVAL FROM DUAL -- for Oracle
                        string identitySelect;
                        switch(dataProvider)
                        {
                            // Access
                            case "System.Data.OleDb":
                                identitySelect = "SELECT @@IDENTITY";
                                break;
                            // Sql Server
                            case "System.Data.SqlClient":
                                identitySelect = "SELECT SCOPE_IDENTITY()";
                                break;
                            // Oracle
                            case "System.Data.OracleClient":
                                identitySelect = "SELECT MySequence.NEXTVAL FROM DUAL";
                                break;
                            default:
                                identitySelect = "SELECT @@IDENTITY";
                                break;
                        }
                        command.CommandText = identitySelect;
                        id = int.Parse(command.ExecuteScalar().ToString());
                    }
                    return id;
                }
            }
        }

        /// <summary>
        /// Executes Insert statements in the database.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        public static void Insert(string sql)
        {
            Insert(sql, false);
        }

        #endregion

        #region Data Retrieve Handlers

        /// <summary>
        /// Populates a DataSet according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataSet.</returns>
        public static DataSet GetDataSet(string sql)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = sql;

                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;

                        DataSet ds = new DataSet();
                        adapter.Fill(ds);

                        return ds;
                    }
                }
            }
        }

        /// <summary>
        /// Populates a DataTable according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataTable.</returns>
        public static DataTable GetDataTable(string sql)
        {
            return GetDataSet(sql).Tables[0];
        }

        /// <summary>
        /// Populates a DataRow according to a Sql statement.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Populated DataRow.</returns>
        public static DataRow GetDataRow(string sql)
        {
            DataRow row = null;

            DataTable dt = GetDataTable(sql);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }

            return row;
        }

        /// <summary>
        /// Executes a Sql statement and returns a scalar value.
        /// </summary>
        /// <param name="sql">Sql statement.</param>
        /// <returns>Scalar value.</returns>
        public static object GetScalar(string sql)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                  //  command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
        public static object GetScalar1(string sql)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = sql;
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }
        /// <returns>A DataSet containing the results of the query</returns>
        public static DataTable SelectQuery(string strTableName, string[] strArrSelectValues, string[] strArrWhereValues)
        {
            DataTable dsReturnData = new DataTable();
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                   

                    command.CommandText = BuildSelectQuery(strTableName, strArrSelectValues, strArrWhereValues);
                    command.Connection = connection;
                    connection.Open();
                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;

                       
                        adapter.Fill(dsReturnData);

                    }
                    
                    connection.Close();
                }
            }
            return dsReturnData;
        }
        /// <summary>
        /// Transforms three letter acronym into actual table name.
        /// </summary>
        /// <param name="strTableName">A 3 character string value representing a table name.</param>		
        /// <returns>A string value containing the actual table name</returns>
        /// /// <remarks>
        /// strTableName should only contain the values that follow below. The meaning of the values is also listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code>
        /// Pseudocode follows below.
        /// <code>
        /// Begin
        ///		Determine table name based on passed string value
        ///		return full table name
        ///	End
        /// </code>
        /// </remarks>
        public static string GetTableName(string strTableName)
        {
            switch (strTableName)
            {
                case "DocDT":
                    return "Doctor";

                case "DDT":
                    return "Day_Data_Table";

                case "TDT":
                    return "Time_Data_Table";

                case "SDT":
                    return "Patient";

                case "PAT":
                    return "Patient_Appointment_Table";

                default:
                    return "False_Data_Table";

            }
        }
        /// <summary>
        /// Builds Select statement.
        /// </summary>
        /// <param name="strTableName">A 3 character string value representing the table name</param>
        /// <param name="strArrSelectValues">An array of strings containg the fields to be selected</param>
        /// <param name="strArrWhereValues">An array of strings containing field names and search values to be searched on</param>
        /// <returns>A string value containing the SQL select statement.</returns>
        /// <remarks>
        /// strArrWhereValues should contain the field and search value in consecutive pairs.
        /// strTableName should only contain the values that follow below. The meaning of the values are listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code> 
        /// Pseudocode follows below.
        /// <code>
        /// Begin
        ///		Determine if there is a single search value.
        ///			Determine if it is a select all.
        ///				Build first part of select all query.
        ///			Else
        ///				Build first part of select query.
        ///			End Determine
        ///		Else
        ///			Build first select value into query.
        ///			For each remaing value.
        ///				Add value to query.
        ///			End For
        ///		End Determine
        ///		Determine if there is a single value to search by.
        ///			Return query.
        ///		Else
        ///			Add first search field/value pair to query
        ///			For each remaining field/value pair
        ///				Add field/value pair to query.
        ///			End For.
        ///			Return query.
        ///		End Determine
        ///	End			
        /// </code>
        /// Note that strArrSelectValues should only contain a single element that is null if the select is a select all.
        /// </remarks>
        public static string BuildSelectQuery(string strTableName, string[] strArrSelectValues, string[] strArrWhereValues)
        {
            // Variables used for building query.
            string strTable = GetTableName(strTableName);
            string strSelectQuery = "";

            // Build First half of query.
            // Determine if it is possible for search value to be a select all.
            if (strArrSelectValues.Length == 1)
            {
                if (strArrSelectValues[0] == "")
                {
                    strSelectQuery = "SELECT * FROM " + strTable;
                }
                else
                {
                    strSelectQuery = "SELECT " + strArrSelectValues[0] + " FROM " + strTable;
                }
            }
            else
            {
                // Prime for loop with first selected field
                strSelectQuery = "SELECT " + strArrSelectValues[0];
                // Add other fields
                for (int x = 1; x < strArrSelectValues.Length; ++x)
                {
                    strSelectQuery = strSelectQuery + ", " + strArrSelectValues[x];
                }
                strSelectQuery = strSelectQuery + " FROM " + strTable;
            }

            //Build second half of query.
            if (strArrWhereValues.Length == 1)
            {
                return strSelectQuery;
            }
            else
            {
                strSelectQuery = strSelectQuery + " WHERE " + strArrWhereValues[0] + " = " + strArrWhereValues[1];
                for (int x = 2; x < strArrWhereValues.Length; ++x)
                {
                    strSelectQuery = strSelectQuery + " AND " + strArrWhereValues[x] + " = " + strArrWhereValues[x + 1];
                    ++x;
                }
                return strSelectQuery;
            }
        }
        /// <summary>
        /// Builds and executes an Insert query.
        /// </summary>
        /// <param name="strTableName">A 3 character field representing the table that the query will run against.</param>
        /// <param name="strFields">An array of string values representing fields to be inserted.</param>
        /// <param name="strValues">An array of string values representing values to be inserted</param>
        /// /// <remarks>
        /// strTableName should only contain the values that follow below. The meaning of the values is also listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code>
        /// Note that for strValue, values that are string fields in the database must be enclosed in single quotes ("'").
        ///  Pseudocode follows below.
        /// <code>
        /// Begin
        ///		Get Insert query.
        ///		ExecuteInsert query.
        ///	End					
        /// </code>
        /// </remarks>
        /// <example>
        /// Below is an example of the usage of this method.
        /// <code>
        /// Internweb.DBManipulator dbMangler = new Internweb.DBManipulator();
        /// 
        /// dbMangler.InsertQuery("IDT", strArrayOfFieldsToInsert, strArrayOfValuesToInsert);
        /// </code>
        /// </example>
        public static void InsertQuery(string strTableName, string[] strFields, string[] strValues)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.CommandText = BuildInsertQuery(strTableName, strFields, strValues);
                    command.Connection = connection;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
        public static DataSet SelectLike(string strSearchCharacter)
        {
            
            System.Data.DataSet dsReturnData = new DataSet();
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {

                    command.CommandText = "SELECT DocID, FirstName, LastName FROM Doctor WHERE LastName LIKE '" + strSearchCharacter + "%'" ;
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    connection.Open();
                    using (DbDataAdapter adapter = factory.CreateDataAdapter())
                    {
                        adapter.SelectCommand = command;


                        adapter.Fill(dsReturnData);

                    }
                    connection.Close();
                }
            }

            return dsReturnData;
        }
        /// <summary>
        /// Builds an Insert query.
        /// </summary>
        /// <param name="strTableName">A 3 character field representing the table that the query will run against.</param>
        /// <param name="strFields">An array of string values representing fields to be inserted.</param>
        /// <param name="strValues">An array of string values representing values to be inserted</param>
        /// <returns>A string value containing the Insert query</returns>
        /// <remarks>
        /// strTableName should only contain the values that follow below. The meaning of the values is also listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code>
        /// Pseudocode follows below.
        /// <code>
        /// Begin
        ///		Add first part of insert query.
        ///		For each field
        ///			Add field to query
        ///		End For.
        ///		Begin value section of query
        ///		For each value
        ///			Add value to query.
        ///		End For.
        ///		Finalize query.
        ///		Return query.
        ///	End
        /// </code>
        /// Note that for strValue, values that are string fields in the database must be enclosed in single quotes ("'").
        /// </remarks>
        private static string BuildInsertQuery(string strTableName, string[] strFields, string[] strValues)
        {
            string strReturnQuery = "";
            string strTable = GetTableName(strTableName);

            // Build insert fields
            strReturnQuery = "INSERT INTO " + strTable + " (" + strFields[0];
            for (int x = 1; x < strFields.Length; ++x)
            {
                strReturnQuery = strReturnQuery + ", " + strFields[x];
            }

            //Build insert values
            strReturnQuery = strReturnQuery + ") VALUES (" + strValues[0];
            for (int x = 1; x < strFields.Length; ++x)
            {
                strReturnQuery = strReturnQuery + ", " + strValues[x];
            }

            //Finalize insert query
            strReturnQuery = strReturnQuery + ")";

            return strReturnQuery;
        }
        /// <summary>
        /// Builds and executes a delete query
        /// </summary>
        /// <param name="strTableName">A 3 character string value representing a table name</param>
        /// <param name="strFieldValuePair">An array of string values containing field/value pairs</param>
        /// <remarks>
        /// strTableName should only contain the values that follow below. The meaning of the values is also listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code>
        /// strFieldValuePair should contain pairs of fields and values in consecutive order. Pseudocode follows below
        /// <code>
        /// Begin
        ///		Build SQL Delete query.
        ///		Execute SQL Delete query.
        ///	End
        /// </code>
        /// Note that for strFieldValuePair, values that are string fields in the database must be enclosed in single quotes ("'").
        /// </remarks>
        /// <example>
        /// An example of the usage of this method follows below.
        /// <code>
        /// Internweb.DBManipulator dbMangler = new DBManipulator();
        /// 
        /// dbMangler.DeleteQuery("IDT", strArrayOfFieldValuePairs);
        /// </code>
        /// </example>
        public static void DeleteQuery(string strTableName, string[] strFieldValuePair)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = BuildDeleteQuery(strTableName, strFieldValuePair);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        /// <summary>
        /// Builds a SQL delete query
        /// </summary>
        /// <param name="strTableName">A 3 character string value representing a table name</param>
        /// <param name="strFieldValuePair">An array of string values containing field/value pairs</param>
        /// <returns>A string value containg a SQL Delete query.</returns>
        /// <remarks>
        /// strTableName should only contain the values that follow below. The meaning of the values is also listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code>
        /// strFieldValuePair should contain pairs of fields and values in consecutive order. Pseudocode follows below
        /// <code>
        /// Begin
        ///		Build first half of Delete query.
        ///		Add first field/value pair to query.
        ///		For each remaining field/value pair
        ///			Add field/value pair to query
        ///		End For.
        ///		Return query.
        ///	End
        /// </code>
        /// Note that for strFieldValuePair, values that are string fields in the database must be enclosed in single quotes ("'").
        /// </remarks>
        private static string BuildDeleteQuery(string strTableName, string[] strFieldValuePair)
        {
            string strTable = GetTableName(strTableName);
            string strDeleteQuery = "";

            // Begin building query
            strDeleteQuery = "DELETE FROM " + strTable + " WHERE " + strFieldValuePair[0] + " = " + strFieldValuePair[1];

            // Add field/value pairs to query
            for (int x = 2; x < strFieldValuePair.Length; ++x)
            {
                strDeleteQuery = strDeleteQuery + " AND " + strFieldValuePair[x] + " = " + strFieldValuePair[x + 1];
                ++x;
            }

            return strDeleteQuery;
        }
        /// <summary>
        /// Builds and executes a SQL Update query.
        /// </summary>
        /// <param name="strTableName">A 3 character string value representing a table.</param>
        /// <param name="strSetValuePair">An array of field/value pairs to update in the table.</param>
        /// <param name="strWhereValuePair">An array of field/value pairs to qualify the update operation.</param>
        /// <remarks>
        /// strTableName should only contain the values that follow below. The meaning of the values is also listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code>
        /// strSetValuePair and strWhereValuePair should contain pairs of fields and values in consecutive order. Pseudocode follows below
        /// <code>
        /// Begin
        ///		Build SQL Update query.
        ///		Execute SQL Update query.
        ///	End
        /// </code>
        /// Note that for strWhereValuePair and strSetValuePair, values that are string fields in the database must be enclosed in single quotes ("'").
        /// </remarks>
        /// <example>
        /// An example of the usage of this method follows below.
        /// <code>
        /// Internweb.DBManipulator dbMangler = new DBManipulator();
        /// 
        /// dbMangler.UpdateQuery("IDT", strArrayOfSetValuePairs, strArrayOfWhereValuePairs);
        /// </code>
        /// </example>
        public static void UpdateQuery(string strTableName, string[] strSetValuePair, string[] strWhereValuePair)
        {
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = connectionString;

                using (DbCommand command = factory.CreateCommand())
                {
                    command.Connection = connection;
                    command.CommandText = BuildUpdateQuery(strTableName, strSetValuePair, strWhereValuePair);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        /// <summary>
        /// Build a SQL Update query
        /// </summary>
        /// <param name="strTableName">A 3 character string value representing a table.</param>
        /// <param name="strSetValuePair">An array of field/value pairs to update in the table.</param>
        /// <param name="strWhereValuePair">An array of field/value pairs to qualify the update operation.</param>
        /// <returns>A string value containing a SQL Update query</returns>
        /// <remarks>
        /// strTableName should only contain the values that follow below. The meaning of the values is also listed below.
        /// <code>
        /// IDT = Instructor_Data_Table
        /// SDT = Student_Data_Table
        /// DDT = Day_Data_Table
        /// SAT = Student_Appointment_Table
        /// TDT = Time_Data_Table
        /// </code>
        /// strSetValuePair and strWhereValuePair should contain pairs of fields and values in consecutive order. Pseudocode follows below
        /// <code>
        /// Begin
        ///		Build first part of Update query.
        ///		For each SET field/value pair
        ///			Add SET field/value pair to query.
        ///		End For
        ///		Add WHERE portion of query and add first WHERE field/value pair.
        ///		For each WHERE field/value pair
        ///			Add field/value pair to query.
        ///		End For.
        ///		Return Update query.
        ///	End
        /// </code>
        /// Note that for strWhereValuePair and strSetValuePair, values that are string fields in the database must be enclosed in single quotes ("'").
        /// </remarks>
        private static string BuildUpdateQuery(string strTableName, string[] strSetValuePair, string[] strWhereValuePair)
        {
            string strTable = GetTableName(strTableName);
            string strReturnQuery = "";

            // Build first part of query.
            strReturnQuery = "UPDATE " + strTable + " SET " + strSetValuePair[0] + " = " + strSetValuePair[1];
            // Add additional field/value pairs.
            for (int x = 2; x < strSetValuePair.Length; ++x)
            {
                strReturnQuery = strReturnQuery + ", " + strSetValuePair[x] + " = " + strSetValuePair[x + 1];
                ++x;
            }
            // Setup WHERE portion of query.
            strReturnQuery = strReturnQuery + " WHERE " + strWhereValuePair[0] + " = " + strWhereValuePair[1];
            for (int x = 2; x < strWhereValuePair.Length; ++x)
            {
                strReturnQuery = strReturnQuery + " AND " + strWhereValuePair[x] + " = " + strWhereValuePair[x + 1];
                ++x;
            }

            return strReturnQuery;
        }
        /// <summary>
        /// Builds and executes a specialized SELECT query with the LIKE keyword.
        /// </summary>
        /// <param name="strSearchCharacter">A single alphabetic character.</param>
        /// <returns>A DataSet containing the results of the query.</returns>
        /// <remarks>
        /// Pseudocode follows below
        /// <code>
        /// Begin
        ///		Build select query.
        ///		Fill dataset.
        ///		Return dataset.
        ///	End
        /// </code>
        /// </remarks>
        /// <example>
        /// An example of this method's use follows below.
        /// <code>
        /// Internweb.DBManipulator dbMangler = new DBManipulator();
        /// 
        /// dbMangler.SelectLike("A"); 
        /// </code>
        /// </example>
        //public  static DataSet SelectLike(string strSearchCharacter)
        //{
        //    System.Data.SqlClient.SqlCommand sqlSelectQuery = new SqlCommand();
        //    System.Data.SqlClient.SqlDataAdapter dbAdapter = new SqlDataAdapter();
        //    System.Data.DataSet dsReturnData = new DataSet();

        //    sqlSelectQuery.CommandText = "SELECT DocID, FirstName, Last_Name FROM doctor WHERE Last_Name LIKE '" + strSearchCharacter.ToUpper() + "%' OR LastName LIKE '" + strSearchCharacter.ToLower() + "%'";
        //    sqlSelectQuery.Connection = dbConnection;
        //    dbAdapter.SelectCommand = sqlSelectQuery;

        //    dbConnection.Open();
        //    dbAdapter.Fill(dsReturnData);
        //    dbConnection.Close();

        //    return dsReturnData;
        //}



        #endregion

        #region Utility methods

        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <returns>Escaped output string.</returns>
        public static string Escape(string s)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
                return "'" + s.Trim().Replace("'", "''") + "'";
        }

        /// <summary>
        /// Escapes an input string for database processing, that is, 
        /// surround it with quotes and change any quote in the string to 
        /// two adjacent quotes (i.e. escape it). 
        /// Also trims string at a given maximum length.
        /// If input string is null or empty a NULL string is returned.
        /// </summary>
        /// <param name="s">Input string.</param>
        /// <param name="maxLength">Maximum length of output string.</param>
        /// <returns>Escaped output string.</returns>
        public static string Escape(string s, int maxLength)
        {
            if (String.IsNullOrEmpty(s))
                return "NULL";
            else
            {
                s = s.Trim();
                if (s.Length > maxLength) s = s.Substring(0, maxLength - 1);
                return "'" + s.Trim().Replace("'", "''") + "'";
            }
        }

        #endregion
    }
}

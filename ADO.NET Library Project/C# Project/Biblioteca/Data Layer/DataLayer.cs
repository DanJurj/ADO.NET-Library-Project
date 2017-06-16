using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Biblioteca
{
    public class DataLayer
    {
        public SqlConnection _connection;
        public DataLayer()
        {
            try
            {
                string _connectionString = ConfigurationManager.ConnectionStrings["connString"].ConnectionString;
                _connection = new SqlConnection(_connectionString);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        public bool OpenConnection()
        {
            try
            {
                if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                    _connection.Open();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
            return true;
        }
        public void CloseConnection()
        {
            try
            {
                if(_connection.State==ConnectionState.Open)
                    _connection.Close();
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
            }
        }
        private SqlCommand CreateCommand (string command, CommandType type, List<SqlParameter> parameters)
        {
            try
            {
                SqlCommand _command = new SqlCommand(command, _connection);
                _command.CommandType = type;
                if (parameters.Count > 0)
                {
                    foreach (var param in parameters)
                    {
                        _command.Parameters.Add(param);
                    }
                }
                return _command;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
        public DataTable SelectData(string command, CommandType type,List<SqlParameter> parameters)
        {
            try
            {
                    OpenConnection();
                    DataTable _tabRet = new DataTable();
                    SqlCommand _command = CreateCommand(command, type, parameters);
                    SqlDataAdapter _adapter = new SqlDataAdapter(_command);
                    _adapter.Fill(_tabRet);
                    CloseConnection();
                    return _tabRet;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
        public string SelectDataBy(string command, CommandType type, List<SqlParameter> parameters)
        {
            try
            {
                OpenConnection();
                string res = string.Empty;
                SqlCommand _command = CreateCommand(command, type, parameters);
                SqlDataReader rdr = _command.ExecuteReader();
                if (rdr != null)
                    if (rdr.Read())
                        res = rdr[0].ToString();
                CloseConnection();
                return res;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
        }
        public int CountData(string command, CommandType type, List<SqlParameter> parameters)
        {
            try
            {
                OpenConnection();
                Int32 _result;
                SqlCommand _command = CreateCommand(command, type, parameters);
                _result = (Int32)_command.ExecuteScalar();
                CloseConnection();
                return _result;
            }
            catch(Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return 0;
            }
            finally
            {
                CloseConnection();
            }

        }
        public bool DeleteRow(string command, CommandType type, List<SqlParameter> parameters)
        {
            SqlCommand _command = CreateCommand(command, type, parameters);
            try
            {
                OpenConnection();
                int rowsAffected = _command.ExecuteNonQuery();
                CloseConnection();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }

        }
        public bool InsertRow(string command, CommandType type, List<SqlParameter> parameters)
        {
            SqlCommand _command = CreateCommand(command, type, parameters);
            try
            {
                OpenConnection();
                int rowsAffected = _command.ExecuteNonQuery();
                CloseConnection();
                if (rowsAffected == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool ExistRow(string command, CommandType type, List<SqlParameter> parameters)
        {
            SqlCommand _command = CreateCommand(command, type, parameters);
            try
            {
                OpenConnection();
                Int32 _nrRowsReturned;
                _nrRowsReturned = (Int32)_command.ExecuteScalar();
                CloseConnection();
                if (_nrRowsReturned > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public bool UpdateRow(string command, CommandType type, List<SqlParameter> parameters)
        {
            SqlCommand _command = CreateCommand(command, type, parameters);
            try
            {
                OpenConnection();
                int rowsAffected = _command.ExecuteNonQuery();
                CloseConnection();
                if (rowsAffected >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public string GetData(string command, CommandType type, List<SqlParameter> parameters)
        {
            try
            {
                OpenConnection();
                string _result;
                SqlCommand _command = CreateCommand(command, type, parameters);
                _result = (string)_command.ExecuteScalar();
                CloseConnection();
                return _result;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

    }
}

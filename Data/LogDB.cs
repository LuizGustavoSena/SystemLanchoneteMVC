using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Util;

namespace Data
{
    public class LogDB : ILogDB
    {
        private ConnectionDB _conn;

        public void Insert(string log)
        {
            string sql = string.Format(Log.INSERT, log);

            using(_conn = new ConnectionDB()){
                _conn.ExecQuery(sql);
            }
        }

        public List<Log> Select()
        {
            string sql = Log.SELECT;

            using(_conn = new ConnectionDB()){
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformReturnDataToList(returnData);
            }
        }

        private List<Log> TransformReturnDataToList(SqlDataReader returnData)
        {
            List<Log> list = new List<Log>();

            while (returnData.Read())
            {
                Log log = new Log
                {
                    DateInformation = DateTime.Parse(returnData["dateInformation"].ToString()),
                    Descricao = returnData["descricao"].ToString()
                };

                list.Add(log);
            }
            return list;
        }
    }
}

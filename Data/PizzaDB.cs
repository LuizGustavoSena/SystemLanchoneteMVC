using Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using Util;

namespace Data
{
    public class PizzaDB : IPizzaDB
    {
        private ConnectionDB _conn;

        public bool Insert(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format(Pizza.INSERT, pizza.Descricao, pizza.Valor);
            using(_conn = new ConnectionDB())
            {
                int id = _conn.ExecQueryReturnId(sql);
                sql = string.Format(Pizza.INSERTFK, id);
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public List<Pizza> Select()
        {
            string sql = Pizza.SELECT;

            using(_conn = new ConnectionDB())
            {
                var returnData = _conn.ExecQueryReturn(sql);
                return TransformDataReaderToList(returnData);
            }
        }

        public Pizza Consultar(int id)
        {
            string sql = string.Format(Pizza.SELECTUNIQ, id);
            
            using(_conn = new ConnectionDB())
            {
                Pizza pizza;
                var returnData = _conn.ExecQueryReturn(sql);
                if (returnData.Read()) { 
                    pizza = new Pizza
                    {
                        Id = int.Parse(returnData["id"].ToString()),
                        Descricao = returnData["descricao"].ToString(),
                        Valor = decimal.Parse(returnData["valor"].ToString())
                    };
                    return pizza;
                }
                return null;
            }
        }

        public bool Atualizar(Pizza pizza)
        {
            bool status = false;
            string sql = string.Format(Pizza.UPDATE, pizza.Descricao, pizza.Valor, pizza.Id);
            using(_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        public bool Deletar(int id)
        {
            bool status = false;
            string sql = string.Format(Pizza.DELETAR, id);
            using(_conn = new ConnectionDB())
            {
                status = _conn.ExecQuery(sql);
            }
            return status;
        }

        private List<Pizza> TransformDataReaderToList(SqlDataReader returnData)
        {
            List<Pizza> list = new List<Pizza>();

            while (returnData.Read())
            {
                Pizza pizza = new Pizza
                {
                    Id = int.Parse(returnData["id"].ToString()),
                    Descricao = returnData["descricao"].ToString(),
                    Valor = decimal.Parse(returnData["valor"].ToString())
                };
                list.Add(pizza);
            }

            return list;
        }
    }
}

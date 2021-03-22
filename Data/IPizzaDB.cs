using Model;
using System.Collections.Generic;

namespace Data
{
    public interface IPizzaDB
    {
        bool Insert(Pizza pizza);
        List<Pizza> Select();
        Pizza Consultar(int id);
        bool Atualizar(Pizza pizza);
        bool Deletar(int id);
    }
}

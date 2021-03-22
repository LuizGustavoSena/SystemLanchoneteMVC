using System;

namespace Model
{
    public class Pizza : Refeicao
    {
        public const String INSERT = "INSERT INTO Refeicao (descricao, valor) output inserted.id VALUES ('{0}', {1})";
        public const String SELECT = "SELECT id, descricao, valor FROM Refeicao r JOIN Pizza p ON r.id = p.idRefeicao";
        public const String INSERTFK = "INSERT INTO Pizza (idRefeicao) values({0})";
        public const String SELECTUNIQ = "SELECT id, descricao, valor FROM Refeicao r JOIN Pizza p ON r.id = p.idRefeicao WHERE id = {0}";
        public const String UPDATE = "UPDATE Refeicao SET descricao = '{0}', valor = {1} WHERE id = {2}";
        public const String DELETAR = "DELETE from Pizza WHERE idRefeicao = {0} DELETE from Refeicao WHERE id = {0}";
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Agenda.ADO;
using System.Data.SqlClient;
using Dapper;
using System.Linq;


namespace Agenda.ADO.Repository
{
    public class AgendaRepository
    {
        public List<Contato> GetContatos()
        {
            List<Contato> contatos = new List<Contato>();

            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                var result = sqlConnection.Query<Contato>("Select * from Contato order by Nome");

                foreach (Contato contato in result)
                    contatos.Add(contato);
            }

            return contatos;
        }

        public Contato GetContatoById(int contatoId)
        {
            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                return sqlConnection.Query<Contato>("Select * from Contato where Id = @Id", new { Id = contatoId }).SingleOrDefault();
            }
        }

        public Contato GetContatoByNome(string nomeContato)
        {
            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                return sqlConnection.Query<Contato>("Select * from Contato where Nome = @Nome", new { Nome = nomeContato }).SingleOrDefault();
            }
        }

        public Contato GetContatoByTelefone(string telefoneContato)
        {
            if (string.IsNullOrEmpty(telefoneContato))
            {
                throw new Exception("Telefone do contato deve ser informado.");
            }
            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                return sqlConnection.Query<Contato>("Select * from Contato where Telefone = @Telefone", new { Telefone = telefoneContato }).SingleOrDefault();
            }
        }

        public Contato GetContatoByEmail(string EmailContato)
        {
            if (string.IsNullOrEmpty(EmailContato))
            {
                throw new Exception("Email do contato deve ser informado.");
            }

            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                return sqlConnection.Query<Contato>("Select * from Contato where Email = @Email", new { Email = EmailContato }).SingleOrDefault();
            }
        }

        public int Save(Contato model)
        {
            if (string.IsNullOrEmpty(model.Nome) || string.IsNullOrEmpty(model.Telefone) || string.IsNullOrEmpty(model.Email))
            {
                throw new Exception("Todos os campos devem ser informados.");
            }

            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                int id = sqlConnection.Query<int>("INSERT INTO CONTATO(Nome,Telefone, Email) VALUES (@Nome, @Telefone, @Email);SELECT CAST(SCOPE_IDENTITY() as int) ", model).Single();
                return id;
            }
        }

        public void Update(Contato model)
        {
            if (string.IsNullOrEmpty(model.Nome) || string.IsNullOrEmpty(model.Telefone) || string.IsNullOrEmpty(model.Email))
            {
                throw new Exception("Todos os campos devem ser informados.");
            }

            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                sqlConnection.Execute(@"UPDATE CONTATO
                                       SET Nome = @Nome, 
                                           Telefone = @Telefone,
                                           Email = @Email
                                       WHERE ID = @Id", model);
            }
        }

        public void Delete(int Id)
        {
            if (Id < 0)
            {
                throw new Exception("Campo ID não foi informado.");
            }

            using (var sqlConnection = new SqlConnection(Constantes.CONNECTION_STRING))
            {
                sqlConnection.Execute("DELETE FROM CONTATO WHERE ID = @Id", new { ID = Id });
            }
        }
    }
}

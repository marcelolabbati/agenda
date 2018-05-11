using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Agenda;
using Agenda.Controllers;
using Agenda.ADO.Repository;
using Agenda.ADO;

namespace Agenda.Tests.Controllers
{
    [TestClass]
    public class ContatoControllerTest
    {
        [TestMethod]
        public void Save()
        {
            AgendaRepository agendaRepository = new AgendaRepository();
            Contato contato = new Contato { Nome = "Nome Teste", Telefone = "41999999999", Email = "novo@novo.com" };
            int idGerado = agendaRepository.Save(contato);
            contato.ID = idGerado;
            agendaRepository.Delete(idGerado);
            Assert.IsTrue(idGerado > 0);
        }

        [TestMethod]
        public void SaveNomeTelefoneVazio()
        {
            AgendaRepository agendaRepository = new AgendaRepository();
            Contato contato = new Contato { Nome = "", Telefone = "", Email = "novo@novo.com" };
            int idGerado = agendaRepository.Save(contato);
            contato.ID = idGerado;
            agendaRepository.Delete(idGerado);
            Assert.IsTrue(idGerado > 0);
        }

        [TestMethod]
        public void UpdateNomeVazio()
        {
            AgendaRepository agendaRepository = new AgendaRepository();
            Contato contato = new Contato { Nome = "", Telefone = "41999999999", Email = "novo@novo.com" };
            int idGerado = agendaRepository.Save(contato);
            contato.ID = idGerado;

            contato.Nome += " alterado";
            agendaRepository.Update(contato);

            Contato contatoGerado = agendaRepository.GetContatoById(idGerado);
            agendaRepository.Delete(idGerado);
            Assert.IsTrue(contatoGerado.Nome.Equals("Nome Teste alterado"));
        }

        [TestMethod]
        public void Update()
        {
            AgendaRepository agendaRepository = new AgendaRepository();
            Contato contato = new Contato { Nome = "Nome Teste", Telefone = "41999999999", Email = "novo@novo.com" };
            int idGerado = agendaRepository.Save(contato);
            contato.ID = idGerado;

            contato.Nome += " alterado";
            agendaRepository.Update(contato);

            Contato contatoGerado = agendaRepository.GetContatoById(idGerado);
            agendaRepository.Delete(idGerado);
            Assert.IsTrue(contatoGerado.Nome.Equals("Nome Teste alterado"));
        }
        
        [TestMethod]
        public void Delete()
        {
            AgendaRepository agendaRepository = new AgendaRepository();
            Contato contato = new Contato { Nome = "Nome Teste", Telefone = "41999999999", Email = "novo@novo.com" };
            int idGerado = agendaRepository.Save(contato);
            contato.ID = idGerado;


            Contato contatoGerado = agendaRepository.GetContatoById(idGerado);
            agendaRepository.Delete(contato.ID);

            Contato contatoApagado = agendaRepository.GetContatoById(idGerado);

            Assert.IsTrue(contatoApagado == null);

        }

        [TestMethod]
        public void DeleteRegistroInvalido()
        {
            AgendaRepository agendaRepository = new AgendaRepository();
            Contato contato = new Contato { Nome = "Nome Teste", Telefone = "41999999999", Email = "novo@novo.com" };
            
            agendaRepository.Delete(0);
            Assert.IsTrue(contato.Equals("Nome Teste"));

        }
    }
}

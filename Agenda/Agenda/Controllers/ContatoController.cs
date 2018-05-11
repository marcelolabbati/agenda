using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Agenda.ADO;
using Agenda.ADO.Repository;


namespace Agenda.Controllers
{
    public class ContatoController : ApiController
    {
        AgendaRepository agendaRepository = new AgendaRepository();

        // GET: api/Contato
        public IEnumerable<Contato> Get()
        {
            List<Contato> contatos = agendaRepository.GetContatos();
            return contatos;
        }

        // GET: api/Contato/5
        public Contato Get(int id)
        {
            return agendaRepository.GetContatos().SingleOrDefault(x => x.ID == id);
        }

        // POST: api/Contato        
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Contato contato)
        {
            var contentType = Request.Content.Headers.ContentType;
            contato.ID = agendaRepository.Save(contato);
            
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, contato);            
            return response;            
        }

        // PUT: api/Contato/5
        public HttpResponseMessage Put(int id, [FromBody]Contato contato)
        {
            agendaRepository.Update(contato);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, contato);
            return response;
        }

        // DELETE: api/Contato/5
        public HttpResponseMessage Delete(int id)
        {
            agendaRepository.Delete(id);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
    }
}

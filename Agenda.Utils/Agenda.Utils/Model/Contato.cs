using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Agenda.ADO
{
    public class Contato : BaseVO
    {
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
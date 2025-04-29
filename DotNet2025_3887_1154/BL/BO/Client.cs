using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Client
    {
     public int clientId { get; init; }
     public string clientName { get; set; }
     public string clientAddress { get; set; }
     public string clientPhone { get; set; }
    public override string ToString() => this.ToStringProperty();

    }
}

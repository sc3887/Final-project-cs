using System;

namespace DO;

public record  Client
(
     int clientId,
     string clientName,
     string clientAddress,  
     string clientPhone 
 )
{
    public Client() : this(0, "", "", "")//בנאי ריק
    {

    }
}

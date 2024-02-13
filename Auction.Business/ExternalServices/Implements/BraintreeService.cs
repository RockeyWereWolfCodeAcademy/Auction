using Auction.Business.ExternalServices.Interfaces;
using Braintree;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.ExternalServices.Implements;

public class BraintreeService : IBraintreeService
{
    readonly IConfiguration _config;

    public BraintreeService(IConfiguration config)
    {
        _config = config;
    }


    public IBraintreeGateway CreateGateway()
    {
        var newGateway = new BraintreeGateway()
        {
            Environment = Braintree.Environment.SANDBOX,
            MerchantId = _config["BraintreeGateway:MerchantId"],
            PublicKey = _config["BraintreeGateway:PublicKey"],
            PrivateKey = _config["BraintreeGateway:PrivateKey"]
        };
        return newGateway;
    }
}

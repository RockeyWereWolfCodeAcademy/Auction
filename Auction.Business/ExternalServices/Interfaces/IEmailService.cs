using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.ExternalServices.Interfaces;

public interface IEmailService
{
    public void SendEmail(string toMail, string subject, string content, bool isHtml = true);
}

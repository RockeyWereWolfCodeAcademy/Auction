using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.ExternalServices.Interfaces;

public interface IFileService
{
    public Task<byte[]> GetFileData(IFormFile fileData);
    public IFormFile ByteArrayToIFormFile(byte[] byteArray);
}

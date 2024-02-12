using Auction.Business.ExternalServices.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction.Business.ExternalServices.Implements;

public class FileService : IFileService
{
    public IFormFile ByteArrayToIFormFile(byte[] byteArray)
    {
        using var stream = new MemoryStream(byteArray);
        var formFile = new FormFile(stream, 0, byteArray.Length, byteArray.ToString(), byteArray.ToString());
        return formFile;
    }

    public async Task<byte[]> GetFileData(IFormFile fileData)
    {
        using var stream = new MemoryStream();
        await fileData.CopyToAsync(stream);
        return stream.ToArray();
    }
}

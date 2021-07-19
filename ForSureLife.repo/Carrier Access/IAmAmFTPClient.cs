using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ForSureLife.repo.Carrier_Access
{
    public interface IAmAmFTPClient
    {
        Task UploadApplicationFile(string applicationPdfFileName);
    }
}

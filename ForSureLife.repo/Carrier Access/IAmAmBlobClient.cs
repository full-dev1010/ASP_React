using System.Threading.Tasks;

namespace ForSureLife.repo.Carrier_Access
{
    public interface IAmAmBlobClient
    {
        
        Task UploadApplicationFile(string FilePath, string ServerFileName);
    }
}

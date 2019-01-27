using RestWithAsp_NETUdemy.Business;
using RestWithAsp_NETUdemy.Data.VO;
using System.IO;
//using System.Security.Principal;

namespace RestWithAsp_NETUdemy.Services.Business
{
    public class FileBusiness : IFileBusiness
    {
        public byte[] GetPdfFile()
        {
            string path = Directory.GetCurrentDirectory();
            var fullPath = path + @"\Other\Comunic.pdf";
            return File.ReadAllBytes(fullPath);
        }
    }
}

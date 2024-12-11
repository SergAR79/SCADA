using ScadaBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Interfaces
{
    public interface IBackgroundImageService
    {
        Task<ImageModel> GetBackgroundImageAsync(int id);
        Task<List<ImageModel>> GetBackgroundImagesAsync();
        Task UploadImageAsync(MemoryStream stream);
        Task DeleteBackGroundImage(int id);
    }
}

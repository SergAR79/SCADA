using ScadaBLL.Interfaces;
using ScadaBLL.Models;
using ScadaCore.Entities;
using ScadaDAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScadaBLL.Services
{
    public class BackgroundImageService : IBackgroundImageService
    {
        private readonly ScadaDbContext context;

        public BackgroundImageService(ScadaDbContext context)
        {
            this.context = context;
        }

        public async Task<ImageModel> GetBackgroundImageAsync(int id)
        {
            var img = await context.BackgroundImages.FirstOrDefaultAsync(x=> x.Id == id) ??
                throw new Exception("Image with such id does not exist");

            var imageModel = new ImageModel()
            {
                Id = img.Id,
                Bytes = img.Bytes
            };

            return imageModel;            
        }

        public async Task DeleteBackGroundImage(int id)
        {
            var image = await context.BackgroundImages.FirstOrDefaultAsync(x => x.Id == id);

            if (image is null)
            {
                return;
            }

            context.Remove(image);

            await context.SaveChangesAsync();
        }

        public async Task<List<ImageModel>> GetBackgroundImagesAsync()
        {
            return await context.BackgroundImages.
                Select(b=>new ImageModel { Id = b.Id, Bytes = b.Bytes }).ToListAsync();
        }

        public async Task UploadImageAsync(MemoryStream stream)
        {
            var image = new BackgroundImage()
            {
                Bytes = stream.ToArray()
            };

            context.Add(image);
            await context.SaveChangesAsync();
        }
    }
}
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Google.Protobuf.Reflection;
using LibraRestaurant.Application.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibraRestaurant.Application.Services
{
    public class ImageService : IImageService
    {
        private Cloudinary _cloudinary;

        public ImageService(Cloudinary cloudinary)
        {
            _cloudinary = cloudinary;
        }

        //Send file to cloud and get url string
        public async Task<string> UploadFile(string base64, string fileName, string folder)
        {
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(fileName, base64),
                    Folder = folder
                };
                var uploadResult = await _cloudinary.UploadAsync(uploadParams);
                return uploadResult.Url.ToString();
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

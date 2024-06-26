﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ExercisingPlanAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ExercisingPlanAPI.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account
            {
                Cloud = config.Value.CloudName,
                ApiKey = config.Value.ApiKey,
                ApiSecret = config.Value.ApiSecret
            };

            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddPhotoAsync(IFormFile file)
        {
            var uploadResult = new ImageUploadResult();
            if (file.Length > 0)
            {
                using (var stream = file.OpenReadStream())
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        Transformation = new Transformation().Height(500).Width(500).Crop("fill").Gravity("face")
                    };
                    uploadResult = await _cloudinary.UploadAsync(uploadParams);
                }
            }
            return uploadResult;
        }

        public Task<ImageUploadResult> DeletePhotoAsync(string publicUrl)
        {
            throw new System.NotImplementedException();
        }
    }
}

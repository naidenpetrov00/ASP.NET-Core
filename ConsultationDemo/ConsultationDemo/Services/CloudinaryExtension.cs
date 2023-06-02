using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ConsultationDemo.Services
{
    public class CloudinaryExtension : ICloudinaryExtension
    {
        public async Task<IEnumerable<string>> Upload(Cloudinary cloudinary, ICollection<IFormFile> files)
        {
            var urls = new List<string>();

            foreach (var file in files)
            {
                byte[] destinationImage;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    destinationImage = memoryStream.ToArray();
                }

                using (var destinationStream = new MemoryStream(destinationImage))
                {
                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(file.FileName, destinationStream)
                    };

                    var result = await cloudinary.UploadAsync(uploadParams);

                    urls.Add(result.Uri.AbsoluteUri);
                }
            }

            return urls;
        }
    }
}

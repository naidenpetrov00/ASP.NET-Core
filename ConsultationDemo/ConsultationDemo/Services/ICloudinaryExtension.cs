using CloudinaryDotNet;

namespace ConsultationDemo.Services
{
    public interface ICloudinaryExtension
    {
        Task<IEnumerable<string>> Upload(Cloudinary cloudinary, ICollection<IFormFile> files);
    }
}

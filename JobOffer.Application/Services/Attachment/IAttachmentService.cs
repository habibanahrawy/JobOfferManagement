
namespace JobOffer.Application.Services.Attachment
{
    public interface IAttachmentService
    {
        string? Upload(string folderName , IFormFile file);
        bool Delete(string folderName , string fileName);
    }
}

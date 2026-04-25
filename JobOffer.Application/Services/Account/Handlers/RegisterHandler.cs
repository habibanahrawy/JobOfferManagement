
using JobOffer.Application.Services.Attachment;
using JobOffer.Core.Enums;


namespace JobOffer.Application.Services.Account.Handlers
{
    public class RegisterHandler : IRequestHandler<Register, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly IAttachmentService _attachmentService;

        public RegisterHandler(UserManager<User> userManager , IAttachmentService attachmentService)
        {
            _userManager = userManager;
            _attachmentService = attachmentService;
        }

        public async Task<string> Handle(Register request, CancellationToken cancellationToken)
        {

            var path = _attachmentService.Upload("Folders", request.RegisterDTO.CV);

            if (string.IsNullOrEmpty(path)) return null;

            var gender = (Gender)request.RegisterDTO.Gender;
            var user = new User
            {
                FullName = request.RegisterDTO.FullName,
                UserName = request.RegisterDTO.UserName,  
                Email = request.RegisterDTO.Email,
                Gender = gender,
                CityId = request.RegisterDTO.CityId,
                CVFile = path
            };

            
            var result = await _userManager.CreateAsync(user, request.RegisterDTO.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Succeeded ? $"{user.UserName} Is Created" : "Not Created";


        }
    }
}

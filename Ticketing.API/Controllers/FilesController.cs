using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Files.Parameters;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Security.Authentication.Model;
using Ticketing.Storage.Abstractions;
using Ticketing.Storage.Enum;

namespace Ticketing.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileStorage _fileStorage;
        private readonly IStorageValidation _storageValidation;
        private readonly IPathGenerator _pathGenerator;

        public FilesController(IFileStorage fileStorage, IStorageValidation storageValidation, IPathGenerator pathGenerator)
        {
            _fileStorage = fileStorage;
            _storageValidation = storageValidation;
            _pathGenerator = pathGenerator;
        }
        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff, UserType.Client })]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string authorization, int id)
        {
            var user = (TokenUser)HttpContext.Items["User"];

            if (!await _storageValidation.CanOpen(id, user.Id))
                return Ok(new byte[] { });
            var path = _pathGenerator.Generate(id);
            return Ok(await _fileStorage.Get(path));
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpGet("GetFace")]
        public async Task<IActionResult> GetFace(string authorization, int staffId)
        {
            return Ok(await _fileStorage.Get(_pathGenerator.Generate(staffId, FileType.Face)));
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpGet("GetVoice")]
        public async Task<IActionResult> GetVoice(string authorization, int staffId)
        {
            return Ok(await _fileStorage.Get(_pathGenerator.Generate(staffId, FileType.Voice)));
        }

        [Authorize(Rules = new[] { UserType.Manager, UserType.Staff })]
        [HttpPost("Upload")]
        public async Task Upload(string authorization, FileUploadParameters parameters)
        {
            var path = _pathGenerator.Generate(parameters.StaffId, parameters.Type);
            await _fileStorage.Save(path, parameters.Bytes);
        }
    }
}

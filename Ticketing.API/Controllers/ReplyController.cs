using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ticketing.Application.Services.Abstraction;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Reply.Results;
using Ticketing.Data.ActionModels.Storage.Parameters;
using Ticketing.Data.ActionModels.Storage.Result;
using Ticketing.Security.Authentication.Attributes;
using Ticketing.Security.Authentication.Enums;
using Ticketing.Storage.Abstractions;

namespace Ticketing.API.Controllers
{
    [Route("api/replies")]
    [ApiController]
    public class ReplyController : Controller
    {
        private readonly IReplyService _replyService;
        private readonly IPathGenerator _pathGenerator;
        private readonly IFileStorage _fileStorage;
        private readonly IStorageService _storageService;

        public ReplyController(IReplyService replyService,
            IPathGenerator pathGenerator,
            IFileStorage fileStorage,
            IStorageService storageService)
        {
            _replyService = replyService;
            _pathGenerator = pathGenerator;
            _fileStorage = fileStorage;
            _storageService = storageService;
        }

        [Authorize(Rules = new[] { UserType.Staff, UserType.Client })]
        [HttpGet("search")]
        public async Task<IActionResult> Get([FromQuery] string authorization, ReplySearchParameters parameters)
        {
            var replies = await _replyService.Get(parameters);
            if (replies == null || !replies.Any())
                return Ok(new List<ReplyViewResult>());
            foreach (var reply in replies)
            {
                reply.Files = new List<StorageViewResult>();
                var filesInformation = await _storageService.Get(new StorageSearchParameters
                {
                    TicketId = reply.TicketId,
                    ReplyId = reply.Id
                });
                if (filesInformation != null)
                {
                    foreach (var item in filesInformation)
                    {
                        reply.Files.Add(new StorageViewResult
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Extension = item.Extension,
                        });
                    }
                }
            }
            return Ok(replies);
        }

        [Authorize(Rules = new[] { UserType.Staff, UserType.Client })]
        [HttpPost("create")]
        public async Task<IActionResult> Post(string authorization, ReplyCreateParameters parameters)
        {
            var reply = await _replyService.Create(parameters);
            if (reply == null)
                return Ok(new ReplyCreateResult());

            if (parameters.Files != null)
            {
                reply.Files = new List<StorageViewResult>();

                foreach (var item in parameters.Files)
                {
                    item.TicketId = reply.TicketId;
                    var file = await _storageService.Create(reply.Id, item);
                    var path = _pathGenerator.Generate(file.Id);
                    await _fileStorage.Save(path, item.Bytes);
                    reply.Files.Add(file);

                }
            }
            return Ok(reply);
        }
    }
}

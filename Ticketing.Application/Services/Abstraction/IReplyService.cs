using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Reply.Results;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IReplyService
    {
        Task<List<ReplyViewResult>> Get(ReplySearchParameters parameters);
        Task<ReplyCreateResult> Create(ReplyCreateParameters parameters);
    }
}

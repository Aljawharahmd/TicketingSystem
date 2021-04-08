using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using Ticketing.Data.ActionModels.Reply.Parameters;
using Ticketing.Data.ActionModels.Reply.Results;
using Ticketing.Data.Enums;

namespace Ticketing.API.Proxies
{
    public interface IReplyProxy
    {
        [Get("/api/replies/search")]
        Task<List<ReplyViewResult>> Get([Header("Authorization")] string authorization, ReplySearchParameters parameters);

        [Post("/api/replies/create")]
        Task<ReplyCreateResult> Create([Header("Authorization")] string authorization, ReplyCreateParameters parameters);
    }
}

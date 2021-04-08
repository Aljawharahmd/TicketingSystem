using System;
using System.Collections.Generic;
using Ticketing.Data.ActionModels.Storage.Result;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Reply.Results
{
    public class ReplyViewResult : ReplyBaseResult
    {
         public SenderType SenderType { get; set; }
    }
}

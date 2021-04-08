using System;
using System.Collections.Generic;
using Ticketing.Data.ActionModels.Storage.Parameters;
using Ticketing.Data.Enums;

namespace Ticketing.Data.ActionModels.Reply.Parameters
{
    public class ReplyCreateParameters : ReplyBaseParameters
    {
        public SenderType SenderType { get; set; }
        public string Content { get; set; }
        public List<StorageCreateParameters> Files { get; set; }

    }

}

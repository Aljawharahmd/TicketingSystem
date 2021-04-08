using System;
using System.Collections.Generic;
using Ticketing.Data.Enums;

namespace Ticketing.Data.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public SenderType SenderType { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string Content { get; set; }
        public ReplyStatus ReplyStatus { get; set; }
        public Client Client { get; set; }
        public StaffMember Employee { get; set; }
        public Ticket Ticket { get; set; }
        public List<StorageFile> StorageFiles { get; set; }
    }
}

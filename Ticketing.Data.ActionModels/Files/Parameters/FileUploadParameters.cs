using Ticketing.Storage.Enum;

namespace Ticketing.Data.ActionModels.Files.Parameters
{
    public class FileUploadParameters
    {
        public int StaffId { get; set; }
        public byte[] Bytes { get; set; }
        public FileType Type { get; set; }
    }
}

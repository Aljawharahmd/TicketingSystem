namespace Ticketing.Data.ActionModels.Storage.Result
{
    public class StorageViewResult : FileInformation
    {
        public int Id { get; set; }

        /// <summary>
        /// <a href="DonwloadPath"></a>
        /// </summary>
        public string DonwloadPath { get; set; }
    }
}

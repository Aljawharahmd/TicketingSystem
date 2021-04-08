using System.Collections.Generic;
using System.Threading.Tasks;
using Ticketing.Data.ActionModels.Storage.Parameters;
using Ticketing.Data.ActionModels.Storage.Result;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IStorageService
    {
        /// <summary>
        /// Create file for reply
        /// </summary>
        /// <param name="id">reply id</param>
        /// <param name="parameters">file information, contains the ticket Id</param>
        /// <returns>return view result</returns>
        Task<StorageViewResult> Create(int id, StorageCreateParameters parameters);


        /// <summary>
        /// Create file for ticket
        /// </summary>
        /// <param name="parameters">file information, contains the ticket Id</param>
        /// <returns>return view result</returns>
        Task<StorageViewResult> Create(StorageCreateParameters parameters);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<List<StorageViewResult>> Get(StorageSearchParameters parameters);

        Task<List<StorageViewResult>> Get(int ticketId);
    }
}

using System.Threading.Tasks;
using Ticketing.Application.Services.Enums;
using Ticketing.Data.ActionModels.Client.Parameters;

namespace Ticketing.Application.Services.Abstraction
{
    public interface IClientValidation
    {
        Task<UserValidationStatus> ValidateCreateDuplicate(ClientCreateParameters parameters);
        Task<UserValidationStatus> ValidateUpdateDuplicate(int id, ClientCreateParameters parameters);
    }
}

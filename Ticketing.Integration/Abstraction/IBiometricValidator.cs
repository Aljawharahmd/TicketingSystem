using System.Threading.Tasks;

namespace Ticketing.Integration.Abstraction
{
    public interface IBiometricValidator
    {
        /// <summary>
        /// This method compares the login face with the registered one
        /// </summary>
        /// <param name="registered">The user face file which uploaded on the registration</param>
        /// <param name="login">The file sent to login method</param>
        /// <param name="userId">User id to detect face</param>
        /// <returns></returns>
        Task<bool> DetectFace(byte[] registered, byte[] login, int userId);

        /// <summary>
        /// This method compares the login voice with the registered voice
        /// </summary>
        /// <param name="registered">The user voice file which uploaded on the registration</param>
        /// <param name="login">The file sent to login method </param>
        /// <param name="userId">User id to detect voice</param>
        /// <returns></returns>
        Task<bool> DetectVoice(byte[] registered, byte[] login, int userId);
    }
}

namespace Ticketing.Protection.Services.Abstraction
{
    public interface IPasswordProtectionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        bool VerifyHashedPassword(string plainText, string hash);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        string ComputeHash(string plainText);
    }
}


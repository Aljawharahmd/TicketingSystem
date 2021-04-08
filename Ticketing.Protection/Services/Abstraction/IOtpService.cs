namespace Ticketing.Protection.Services.Abstraction
{
    public interface IOtpService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
          string Generate(int userId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
          string Validate(int userId);
    }
}

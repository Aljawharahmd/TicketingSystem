using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ticketing.Protection.Options;
using Ticketing.Protection.Services.Abstraction;

namespace Ticketing.Protection.Services
{
    public class OtpService : IOtpService
    {
        private readonly OtpOptions _options;
        private static IDictionary<int, string> _otpStorage = new Dictionary<int, string>();
        private readonly ILogger<OtpService> _logger;


        public OtpService(IOptions<OtpOptions> options, ILogger<OtpService> logger)
        {
            _options = options.Value;
            _logger = logger;
        }

        public string Generate(int userId)
        {
            try
            {
                int code;
                if (_options.TestMood)
                {
                    code = 1234;
                    _logger.LogDebug("OtpService, Generate, test mood", _options.TestMood);
                }
                else
                {
                    Random random = new Random();
                    code = random.Next(1000, 10000);
                }
                _otpStorage.Add(userId, code.ToString());
                return code.ToString();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to Send otp to: {userId}", userId);
                return string.Empty;
            }

        }

        public string Validate(int userId)
        {
            if (!_otpStorage.ContainsKey(userId))
                return null;
            var code = _otpStorage[userId].ToString();
            _otpStorage.Remove(userId);
            return code;
        }

    }
}

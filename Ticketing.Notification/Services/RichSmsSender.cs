using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Ticketing.Notification.Abstraction;
using Ticketing.Notification.Models;
using Ticketing.Notification.Options;
using Ticketing.Notification.Proxies;

namespace Ticketing.Notification.Services
{
    public class RichSmsSender : ISmsSender
    {
        private readonly ILogger<RichSmsSender> _logger;
        private readonly IRichProxy _richProxy;
        private readonly SmsOptions _options;

        public RichSmsSender(ILogger<RichSmsSender> logger, IOptions<SmsOptions> options, IRichProxy richProxy)
        {
            _logger = logger;
            _options = options.Value;
            _richProxy = richProxy;
        }
        public async Task<bool> Send(SmsSendParameter parameter)
        {
            try
            {
                if (_options.TestMood)
                {
                    _logger.LogDebug("RichSmsSender, Send, test mood", _options.TestMood);
                    return true;
                }
                _logger.LogDebug("RichSmsSender, Send, Parameters:{parameter}", JsonConvert.SerializeObject(parameter));
                var result = await _richProxy.Send(new RichParameter
                {
                    number = parameter.MobileNumber,
                    message = parameter.Text,
                    sender = _options.Sender,
                    username = _options.Username,
                    password = _options.Password,
                    referenceid = 0
                });

                _logger.LogDebug("RichSmsSender, Send, Rich Status code: {code}", result.ErrorCode);
                return result.ErrorCode == 0;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to Send Sms to mobile number: {MobileNumber}", parameter.MobileNumber);
                return false;
            }
        }
    }
}

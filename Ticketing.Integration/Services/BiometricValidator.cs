using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Ticketing.Integration.Abstraction;
using Ticketing.Integration.Enums;
using Ticketing.Integration.Models;
using Ticketing.Integration.Options;
using Ticketing.Integration.Proxies;

namespace Ticketing.Integration.Services
{
    public class BiometricValidator : IBiometricValidator
    {
        private readonly IBiometricsProxy _biometricsProxy;
        private readonly ILogger<BiometricValidator> _logger;
        private readonly BiometricOptions _options;

        public BiometricValidator(IBiometricsProxy biometricsProxy, ILogger<BiometricValidator> logger, IOptions<BiometricOptions> options)
        {
            _biometricsProxy = biometricsProxy;
            _logger = logger;
            _options = options.Value;
        }
        public async Task<bool> DetectFace(byte[] registered, byte[] login, int userId)
        {
            try
            {
                if (!registered.Any() || !login.Any())
                    return false;
                if (_options.TestMood)
                {
                    _logger.LogDebug("BiometricValidator, DetectVoice, test mood", _options.TestMood);
                    return true;
                }
                _logger.LogDebug("BiometricValidator, DetectFace, parameters: {userId}", userId);
                var parameter = new BiometricsDetectionParameter(_options, RecognizeDetectionMethod.Face)
                {
                    PrimaryFileBytes = registered,
                    SecondaryFileBytes = login,
                };
                var result = await _biometricsProxy.Detect(_options.AccountId.ToString(), parameter);

                _logger.LogDebug("BiometricValidator, DetectFace, Biometrics result: {result}", JsonConvert.SerializeObject(result));
                return result.Data.Status == 1;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to detect face! User Id:{userId}", userId);
                return false;
            }
        }
        public async Task<bool> DetectVoice(byte[] registered, byte[] login, int userId)
        {
            try
            {
                if (!registered.Any() || !login.Any())
                    return false;

                if (_options.TestMood)
                {
                    _logger.LogDebug("BiometricValidator, DetectVoice, test mood", _options.TestMood);
                    return true;
                }

                _logger.LogDebug("BiometricValidator, DetectVoice, parameters: {userId}", userId);
                var parameter = new BiometricsDetectionParameter(_options, RecognizeDetectionMethod.Voice)
                {
                    PrimaryFileBytes = registered,
                    SecondaryFileBytes = login,
                };
                var result = await _biometricsProxy.Detect(_options.AccountId.ToString(), parameter);
                _logger.LogDebug("BiometricValidator, DetectVoice, Biometrics result: {result}", JsonConvert.SerializeObject(result));
                return result.Data.Status == 1;
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Failed to detect voice! User Id:{userId}", userId);
                return false;
            }
        }
    }
}

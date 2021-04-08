using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ticketing.Storage.Abstractions;
using Ticketing.Storage.Enum;

namespace Ticketing.Storage
{
    public class PathGenerator : IPathGenerator
    {
        private readonly ILogger<PathGenerator> _logger;
        private readonly StorageOptions _options;
 
        public PathGenerator(ILogger<PathGenerator> logger, IOptions<StorageOptions> options)
        {
            _logger = logger;
            _options = options.Value;
        }

        public string Generate(int fileId)
        {
            _logger.LogDebug("PathGenerator, Generate, parameters:{fileId}", fileId);
            var basePath = _options.BasePath.ToString();
            return $"{basePath}\\AllFiles\\{fileId}";
        }

        public string Generate(int userId, FileType type)
        {
            var basePath = _options.BasePath.ToString();
            return $"{basePath}\\{type.ToString()}\\{userId}";
        }
    }
}

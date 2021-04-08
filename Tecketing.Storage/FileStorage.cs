using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Ticketing.Storage.Abstractions;

namespace Ticketing.Storage
{
    public class FileStorage : IFileStorage
    {
        private readonly ILogger<FileStorage> _logger;

        public FileStorage(ILogger<FileStorage> logger)
        {
            _logger = logger;
        }

        public async Task<byte[]> Get(string path)
        {
            _logger.LogDebug("FileStorage, Get, parameters:{path}", path);
            if (File.Exists(path))
                return await File.ReadAllBytesAsync(path);

            return new byte[] { };
        }

        public async Task Save(string path, byte[] file)
        {
            _logger.LogDebug("FileStorage, Save, parameters:{path}", path);
            await File.WriteAllBytesAsync(path, file);
        }
    }
}

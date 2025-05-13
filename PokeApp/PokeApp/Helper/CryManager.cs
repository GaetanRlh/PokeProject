using System.IO;
using System.Net.Http;

namespace PokeApp.Helper
{
    public static class CryManager
    {
        private static readonly string _cacheDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "PokeApp", "CryCache");

        private static readonly HttpClient _httpClient = new HttpClient();

        static CryManager()
        {
            Directory.CreateDirectory(_cacheDir);
        }

        public static async Task<string> GetCachedCryAsync(string url, string pokemonName)
        {
            string safeName = pokemonName.ToLowerInvariant().Replace(" ", "_");
            string filePath = Path.Combine(_cacheDir, $"{safeName}.ogg");

            if (!File.Exists(filePath))
            {
                try
                {
                    var data = await _httpClient.GetByteArrayAsync(url);
                    await File.WriteAllBytesAsync(filePath, data);
                    Console.WriteLine($"Downloaded: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error downloading cry: {ex.Message}");
                    return string.Empty;
                }
            }

            return filePath;
        }
    }
}
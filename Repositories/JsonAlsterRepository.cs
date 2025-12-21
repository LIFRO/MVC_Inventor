using System.Linq;
using System.Text.Json;
using MVC_Training.Models;

namespace MVC_Training.Repositories;

public class JsonAlsterRepository : IAlsterRepository
{
    private readonly ILogger<JsonAlsterRepository> _logger;
    private readonly string _filePath;
    private List<Alster> _cache = new();

    public JsonAlsterRepository(IWebHostEnvironment env, ILogger<JsonAlsterRepository> logger)
    {
        _logger = logger;
        _filePath = Path.Combine(env.ContentRootPath, "Data", "Alster.json");
        LoadFromFile();
    }

    private void LoadFromFile()
    {
        if (!File.Exists(_filePath))
        {
            _logger.LogWarning("JSON file not found: {path}", _filePath);
            return;
        }

        try
        {
            var json = File.ReadAllText(_filePath);
            _cache = JsonSerializer.Deserialize<List<Alster>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Alster>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load alster from {path}", _filePath);
            _cache = new List<Alster>();
        }
    }

    public Task<IEnumerable<Alster>> GetAllAsync(CancellationToken ct = default) =>
        Task.FromResult<IEnumerable<Alster>>(_cache);

    public Task<Alster?> GetByIdAsync(int id, CancellationToken ct = default) =>
        Task.FromResult(_cache.FirstOrDefault(a => a.Id == id));

    public Task<IEnumerable<Alster>> GetByCategoryAsync(int categoryId, CancellationToken ct = default) =>
        Task.FromResult(_cache.Where(a => a.CategoryId == categoryId).AsEnumerable());
}

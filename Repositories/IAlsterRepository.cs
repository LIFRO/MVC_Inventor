using MVC_Training.Models;

namespace MVC_Training.Repositories;

public interface IAlsterRepository
{
    Task<IEnumerable<Alster>> GetAllAsync(CancellationToken ct = default);
    Task<Alster?> GetByIdAsync(int id, CancellationToken ct = default);
}

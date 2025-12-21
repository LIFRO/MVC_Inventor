using Microsoft.EntityFrameworkCore;
using MVC_Training.Models;

namespace MVC_Training.Repositories;

public class EfAlsterRepository : IAlsterRepository
{
    private readonly AlsterDbContext _db;

    public EfAlsterRepository(AlsterDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Alster>> GetAllAsync(CancellationToken ct = default) =>
        await _db.Alsters.AsNoTracking().ToListAsync(ct);

    public async Task<Alster?> GetByIdAsync(int id, CancellationToken ct = default) =>
        await _db.Alsters.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id, ct);

    public async Task<IEnumerable<Alster>> GetByCategoryAsync(int categoryId, CancellationToken ct = default) =>
        await _db.Alsters.AsNoTracking().Where(a => a.CategoryId == categoryId).ToListAsync(ct);
}

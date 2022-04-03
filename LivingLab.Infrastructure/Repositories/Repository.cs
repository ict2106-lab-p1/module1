using LivingLab.Core.Repositories;
using LivingLab.Infrastructure.Data;

using Microsoft.EntityFrameworkCore;

namespace LivingLab.Infrastructure.Repositories;

/// <remarks>
/// Author: Team P1-1
/// </remarks>
public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        await IncludeReferencesForFindAsync(entity);
        return entity;
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await IncludeReferences(_context.Set<T>()).ToListAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> DeleteAsync(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        if (entity == null)
        {
            return entity;
        }

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    // Load referenced entities in query results.
    // Default implementation returns query result as-is without loading anything extra.
    protected virtual IQueryable<T> IncludeReferences(IQueryable<T> subset) => subset;

    // Same as IncludeReferences, but for DbSet.Find operations
    // Because for some reason, Entity Framework has a seperate API for it
    protected virtual Task IncludeReferencesForFindAsync(T entity) => Task.CompletedTask;
}

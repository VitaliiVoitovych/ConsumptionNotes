using ConsumptionNotes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsumptionNotes.Dal.Repositories.Base;

public abstract class BaseRepository<T>
    where T : BaseConsumption
{
    public ConsumptionNotesDbContext Context { get; }
    public DbSet<T> Table { get; }

    public BaseRepository(ConsumptionNotesDbContext context)
    {
        Context = context;
        Table = Context.Set<T>();
    }

    public virtual int Add(T entity)
    {
        Table.Add(entity);
        return SaveChanges();
    }

    public virtual int Remove(T entity)
    {
        Table.Remove(entity);
        return SaveChanges();
    }

    public virtual async Task<List<T>> GetAll()
    {
        return await Table.ToListAsync();
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }
}
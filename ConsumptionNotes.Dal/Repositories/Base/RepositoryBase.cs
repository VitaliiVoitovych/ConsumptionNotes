namespace ConsumptionNotes.Dal.Repositories.Base;

public abstract class RepositoryBase<T>
    where T : ConsumptionBase
{
    public ConsumptionNotesDbContext Context { get; }
    public DbSet<T> Table { get; }

    protected RepositoryBase(ConsumptionNotesDbContext context)
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

    public virtual int Update(T entity)
    {
        Table.Update(entity);
        return SaveChanges();
    }
    
    public virtual async Task<List<T>> GetAll()
    {
        return await Table.OrderBy(e => e.Date).ToListAsync();
    }

    public int SaveChanges()
    {
        return Context.SaveChanges();
    }
}
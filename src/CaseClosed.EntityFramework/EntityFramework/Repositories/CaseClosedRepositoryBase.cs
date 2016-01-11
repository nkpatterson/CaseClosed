using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace CaseClosed.EntityFramework.Repositories
{
    public abstract class CaseClosedRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<CaseClosedDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected CaseClosedRepositoryBase(IDbContextProvider<CaseClosedDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class CaseClosedRepositoryBase<TEntity> : CaseClosedRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected CaseClosedRepositoryBase(IDbContextProvider<CaseClosedDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}

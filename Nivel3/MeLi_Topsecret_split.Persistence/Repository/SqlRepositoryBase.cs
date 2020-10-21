using System.Collections.Generic;
using System.Linq;
using MeLi_Topsecret_split.Persistence;

namespace SchipService.Persistence.Sql.Repositories
{
    public abstract class SqlRepositoryBase
    {
        public SqlRepositoryBase(SqlUnitOfWork uow)
        {
            UnitOfWork = uow;
            Context = uow.Database;
        }

        protected SqlUnitOfWork UnitOfWork { get; set; }
        protected AlianzaRebeldeContext Context { get; set; }

        protected Dictionary<object, object> NewEntities { get; } = new Dictionary<object, object>();

        protected void RegisterNewEntity(object sqlEntity, object coreEntity)
        {
            NewEntities.Add(sqlEntity, coreEntity);
        }

        protected void UnregisterNewEntity(object sqlEntity)
        {
            NewEntities.Remove(sqlEntity);
        }

        public virtual void SyncCoreEntitiesWithSavedSqlEntities()
        {
            var keys = (from ne in NewEntities select ne.Key).ToList();

            foreach (var sqlEntity in keys)
            {
                var coreEntity = NewEntities[sqlEntity];
                UpdateCoreEntitiesFromSqlEntities(sqlEntity, coreEntity);
                UnregisterNewEntity(sqlEntity);
            }
        }

        public virtual void UpdateCoreEntitiesFromSqlEntities(object sqlEntity, object coreEntity)
        {
            // default to doing nothing 
            //  the repository will override if saving an entity 
            //  actually results in db generated values that need to 
            //  be reflected in the DTO provided from and / or returned
            //  to a caller
            return;
        }
    }
}

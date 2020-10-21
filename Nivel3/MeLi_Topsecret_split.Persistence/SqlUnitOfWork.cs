using System;
using System.Collections.Generic;
using MeLi_Topsecret_split.Domain;
using MeLi_Topsecret_split.Domain.Repository;
using MeLi_Topsecret_split.Persistence.Repository;
using Microsoft.Extensions.Configuration;
using SchipService.Persistence.Sql.Repositories;

namespace MeLi_Topsecret_split.Persistence
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly Dictionary<Type, SqlRepositoryBase> _Repositories = new Dictionary<Type, SqlRepositoryBase>();

        public SqlUnitOfWork(AlianzaRebeldeContext context)
        {
            Database = context;
        }

        internal AlianzaRebeldeContext Database { get; }

        public IAlianzaRebeldeRepository AlianzaRebeldeRepository
        {
            get { return GetRepository<SqlAlianzaRebeldeRepository>(uow => new SqlAlianzaRebeldeRepository(uow)); }
        }

        public void Commit()
        {
            Database.SaveChanges();

            foreach (var repository in _Repositories.Values)
            {
                repository.SyncCoreEntitiesWithSavedSqlEntities();
            }
        }

        private T GetRepository<T>(Func<SqlUnitOfWork, T> ctor) where T : SqlRepositoryBase
        {
            if (!_Repositories.ContainsKey(typeof(T)))
            {
                _Repositories.Add(typeof(T), ctor(this));
            }

            return (T)_Repositories[typeof(T)];
        }
    }
}

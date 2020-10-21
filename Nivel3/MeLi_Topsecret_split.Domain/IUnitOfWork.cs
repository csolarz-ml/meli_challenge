using MeLi_Topsecret_split.Domain.Repository;

namespace MeLi_Topsecret_split.Domain
{
    public interface IUnitOfWork : ICoreUnitOfWork
    {
        IAlianzaRebeldeRepository AlianzaRebeldeRepository { get; }
    }
}

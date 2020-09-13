using System.Data;

namespace CodeBase.Infrastructure
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }
}
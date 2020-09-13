using CodeBase.Common;
using CodeBase.Infrastructure;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBase.Repositories
{
    public class SampleRepository : GenericRepository<Sample>, ISampleRepository
    {
        private readonly ConnectionFactory _connection;

        public SampleRepository()
        {
            _connection = new ConnectionFactory();
        }

        public override async Task<bool> Delete(Sample sample)
        {
            var count = 0;

            try
            {
                var query = $"";

                using (var connection = _connection.GetConnection)
                {
                    count = await Task.Run(() => connection.Execute(query));
                }
            }
            catch
            {
                count = 0;
            }

            return count > 0;
        }

        public override async Task<IEnumerable<Sample>> Get(Sample sample)
        {
            var result = new List<Sample>();

            try
            {
                var query = $"";

                using (var connection = _connection.GetConnection)
                {
                    result = await Task.Run(() => connection.Query<Sample>(query).ToList());
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public override async Task<int> Insert(Sample sample)
        {
            var id = 0;

            try
            {
                var query = $"";

                using (var connection = _connection.GetConnection)
                {
                    id = await Task.Run(() => connection.Query<int>(query, sample).SingleOrDefault());
                }
            }
            catch
            {
                id = 0;
            }

            return id;
        }

        public override async Task<bool> Update(Sample sample)
        {
            var count = 0;

            try
            {
                var query = $"";

                using (var connection = _connection.GetConnection)
                {
                    count = await Task.Run(() => connection.Execute(query, sample));
                }
            }
            catch
            {
                count = 0;
            }

            return count > 0;
        }
    }
}

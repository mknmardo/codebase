using CodeBase.Common;
using CodeBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace CodeBase.Services
{
    public class SampleService : ISampleService
    {
        private readonly ISampleRepository _sampleRepository;

        public SampleService(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        public async Task<bool> Delete(Sample sample)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await Task.Run(() => _sampleRepository.Delete(sample));
                transactionScope.Complete();
                return result;
            }
        }

        public async Task<IEnumerable<Sample>> Get(Sample sample)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await Task.Run(() => _sampleRepository.Get(sample));
                transactionScope.Complete();
                return result;
            }
        }

        public async Task<int> Insert(Sample sample)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await Task.Run(() => _sampleRepository.Insert(sample));
                transactionScope.Complete();
                return result;
            }
        }

        public async Task<bool> Update(Sample sample)
        {
            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var result = await Task.Run(() => _sampleRepository.Update(sample));
                transactionScope.Complete();
                return result;
            }
        }
    }
}

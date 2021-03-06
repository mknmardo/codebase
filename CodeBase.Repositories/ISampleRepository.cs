﻿using CodeBase.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeBase.Repositories
{
    public interface ISampleRepository
    {
        Task<bool> Delete(Sample sample);
        Task<IEnumerable<Sample>> Get(Sample sample);
        Task<int> Insert(Sample sample);
        Task<bool> Update(Sample sample);
    }
}
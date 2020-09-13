using CodeBase.Api.Models;
using CodeBase.Api.Models.Enums;
using CodeBase.Cache;
using CodeBase.Common;
using CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CodeBase.Api.Controllers
{
    [RoutePrefix("api/v1/sample")]
    public class SampleController : ApiController
    {
        private readonly ISampleService _sampleService;
        private readonly IMemCache<Sample> _memCache;
        private readonly string _key;

        public SampleController(ISampleService sampleService, IMemCache<Sample> memCache)
        {
            _sampleService = sampleService;
            _memCache = memCache;
            _key = "sample";
        }

        [Route("add"), HttpPost]
        public async Task<IHttpActionResult> Add(Sample sample)
        {
            var result = await Task.Run(() => _sampleService.Insert(sample));
            _memCache.Delete(_key);

            if (result == 0)
            {
                return BadRequest();
            }

            return Ok(new BaseResponse<string>
            {
                IsSuccess = true,
                Message = HttpResponseCode.OK.GetDescription()
            });
        }

        [Route("{id:int}/update"), HttpPut]
        public async Task<IHttpActionResult> Update(int id, Sample sample)
        {
            sample.Id = id;
            var result = await Task.Run(() => _sampleService.Update(sample));
            _memCache.Delete(_key);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new BaseResponse<string>
            {
                IsSuccess = true,
                Message = HttpResponseCode.OK.GetDescription()
            });
        }

        [Route("{id:int}/delete"), HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var sample = new Sample()
            {
                Id = id
            };

            var result = await Task.Run(() => _sampleService.Delete(sample));
            _memCache.Delete(_key);

            if (!result)
            {
                return NotFound();
            }

            return Ok(new BaseResponse<string>
            {
                IsSuccess = true,
                Message = HttpResponseCode.OK.GetDescription()
            });
        }

        [Route("get/{id:int?}"), HttpGet]
        public async Task<IHttpActionResult> Get(int? id = null, string name = null)
        {
            var result = new List<Sample>();
            var cache = new List<Sample>();

            cache = _memCache.GetValue(_key);

            if (cache == null)
            {
                result = (List<Sample>)await Task.Run(() => _sampleService.Get(new Sample()));
                _memCache.Add(_key, result, DateTimeOffset.UtcNow.AddHours(1));

                result = new List<Sample>();
                cache = new List<Sample>();
                cache = _memCache.GetValue(_key);

                if (id != null || !string.IsNullOrEmpty(name))
                    result = cache.FindAll(x => x.Id == id || x.Name.ToLower().Contains(name.ToLower()));
                else
                    result = cache;
            }
            else
            {
                if (id != null || !string.IsNullOrEmpty(name))
                    result = cache.FindAll(x => x.Id == id || x.Name.ToLower().Contains(name.ToLower()));
                else
                    result = cache;
            }

            if (!result.Any())
            {
                return NotFound();
            }

            return Ok(new BaseResponse<IEnumerable<Sample>>
            {
                IsSuccess = true,
                Message = HttpResponseCode.OK.GetDescription(),
                Rows = result.Count(),
                Data = result
            });
        }
    }
}

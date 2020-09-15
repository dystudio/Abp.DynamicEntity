using System;
using System.Collections.Generic;
using System.Linq;
using EasyAbp.Abp.Dynamic.DynamicEntities.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.Abp.Dynamic.DynamicEntities
{
    public class DynamicEntityAppService  : CrudAppService<DynamicEntity, DynamicEntityDto, Guid, GetListInput, CreateUpdateDynamicEntityDto, CreateUpdateDynamicEntityDto>,
        IDynamicEntityAppService
    {
        private readonly IDynamicEntityRepository _repository;

        public DynamicEntityAppService(IDynamicEntityRepository repository) : base(repository)
        {
            _repository = repository;
        }

        protected override IQueryable<DynamicEntity> CreateFilteredQuery(GetListInput input)
        {
            if (input.FieldFilters != null && input.FieldFilters.Count > 0)
            {
                return _repository.GetQueryByFilter(ObjectMapper.Map<IList<Dtos.Filter>, IList<Filter>>(input.FieldFilters));
            }
            
            if (!input.Filter.IsNullOrEmpty())
            {
                return _repository.GetQueryByFilter(input.Filter);
            }
            
            return base.CreateFilteredQuery(input);
        }
    }
}
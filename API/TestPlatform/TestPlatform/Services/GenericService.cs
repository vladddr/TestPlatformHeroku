using AutoMapper;
using TestPlatform.Core.Base;
using TestPlatform.Core.Specifications;
using TestPlatform.DAL.Repositories;

namespace TestPlatform.API.Services
{
    public class GenericService<TEntity, TCreateEntity, TUpdateEntity, TReadEntity> 
        : IGenericService<TEntity, TCreateEntity, TUpdateEntity, TReadEntity> where TEntity : BaseEntity 
    {
        private readonly IGenericRepository<TEntity> _entityRepository;

        private readonly IMapper _mapper;

        public GenericService(IGenericRepository<TEntity> entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            _mapper = mapper;
        }

        public virtual async Task<TReadEntity> CreateAsync(TCreateEntity entityCreate)
        {
            // Map Entity acordinally to Database level
            var entity = _mapper.Map<TEntity>(entityCreate);

            // Execute entity adding
            var addedEntity = await _entityRepository.AddAsync(entity);

            // Map to the view level
            return _mapper.Map<TReadEntity>(addedEntity);
        }

        public virtual async Task<TReadEntity> UpdateAsync(int entityId, TUpdateEntity bodyUpdated)
        {
            // Map Entity acordinally to Database level
            var entity = _mapper.Map<TEntity>(bodyUpdated);
            entity.Id = entityId;
            entity.UpdateDatetime = DateTime.UtcNow;

            // Execute entity updating
            var updateEntity = await _entityRepository.UpdateAsync(entity);

            // Map to the view level
            return _mapper.Map<TReadEntity>(updateEntity);
        }

        public virtual async Task<IEnumerable<TReadEntity>> ReadAllAsync(
            ISpecification<TEntity> specification)
        {
            var readedEntities = await _entityRepository.GetListAsync(specification);

            return _mapper.Map<List<TReadEntity>>(readedEntities);
        }

        public virtual async Task<TReadEntity> ReadEntityAsync(ISpecification<TEntity> specification)
        {
            var readedEntity = await _entityRepository.GetEntityAsync(specification);

            return _mapper.Map<TReadEntity>(readedEntity);
        }
    }
}

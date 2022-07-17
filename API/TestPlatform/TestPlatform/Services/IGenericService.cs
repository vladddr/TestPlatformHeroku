using TestPlatform.Core.Base;
using TestPlatform.Core.Specifications;

namespace TestPlatform.API.Services
{
    public interface IGenericService<Entity, CreateEntity, UpdateEntity, ReadEntity> where Entity : BaseEntity
    {
        Task<IEnumerable<ReadEntity>> ReadAllAsync(ISpecification<Entity> specification);

        Task<ReadEntity> ReadEntityAsync(ISpecification<Entity> specification);

        Task<ReadEntity> CreateAsync(CreateEntity entity);

        Task<ReadEntity> UpdateAsync(int entityId, UpdateEntity body);
    }
}

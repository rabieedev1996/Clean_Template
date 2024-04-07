using Clean.Application.Contract.MongoDB;
using Clean.Domain.Entities.Mongo;
using Clean.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Clean.Infrastructure.MongoRepositories;

public class MongoSampleEntityRepository : BaseRepository<MongoSampleEntity>, IMongoSampleEntityRepository
{
    public MongoSampleEntityRepository(IConfiguration configuration) : base(configuration)
    {
    }
  
}
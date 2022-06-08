using MongoDB.Driver;
using SpotCli.Core.Entities;
using SpotCli.WebApi.Api.Common;
using SpotCli.WebApi.Api.Data;
using SpotCli.WebApi.Api.Data.Requests;
using SpotCli.WebApi.Api.Repositories;
using SpotCli.WebApi.Api.Settings;

public class MongoRatingRepository : IRatingRepository
{
    private readonly MongoClient _mongoClient;
    private readonly RatingCollectionSettings _settings;
    private IMongoDatabase Database => _mongoClient.GetDatabase(_settings.DatabaseName);
    private IMongoCollection<TrackRatingDto> Collection => Database.GetCollection<TrackRatingDto>(_settings.RatingCollectionName);
    public MongoRatingRepository(MongoClient mongoClient, RatingCollectionSettings settings)
    {
        _mongoClient = mongoClient;
        _settings = settings;
    }

    public async Task Create(CreateTrackRatingRequest request)
    {
        var dto = request.AsRatingDto();
        await Collection.InsertOneAsync(dto);
    }

    public async Task Delete(string id)
    {
        await Collection.DeleteOneAsync(dto => dto.Id == id);
    }

    public async Task<IEnumerable<TrackRatingDto>> GetAll()
    {
        var result = await Collection.FindAsync(_ => true);
        return result.ToEnumerable();
    }

    public async Task<TrackRatingDto> GetById(string id)
    {
        var result = await Collection.Find(dto => dto.Id == id).Limit(1).SingleAsync();
        return result;
    }

    public async Task Modify(ModifyTrackRatingRequest request, string id)
    {
        var dto = request.AsRatingDto();
        await Collection.ReplaceOneAsync(dto => dto.Id == id, dto);
    }
}
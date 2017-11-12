using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DailyPrice.API.Core;
using MongoDB.Driver;

namespace DailyPrice.API.Data
{
    /// <summary>
    /// Represents the Repository
    /// </summary>
    public class Repository : IRepository
    {
        #region Fields

        private const string ConnectionString = "mongodb://localhost:27017";
        private const string DatabaseName = "DailyPriceDev";

        private readonly IMongoDatabase _database;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public Repository()
        {
            _database = ConnectToMongoDB();
        }

        #region Utilities

        /// <summary>
        /// Get Collection from mongo db
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>Mongo Collection</returns>
        private IMongoCollection<T> GetCollection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

        /// <summary>
        /// Connect to mongo database
        /// </summary>
        /// <returns> Mongo Database</returns>
        private IMongoDatabase ConnectToMongoDB()
        {
            var client = new MongoClient(ConnectionString);
            //var credentials = new List<MongoCredential>();
            //credentials.Add(MongoCredential.CreateCredential("admin", "username", "password"));
            //var mongoClientSettings = new MongoClientSettings { MaxConnectionIdleTime = TimeSpan.FromMinutes(3), Server = new MongoServerAddress("server-ipaddress", 27017), Credentials = credentials };
            //var client = new MongoClient(mongoClientSettings);
            return client.GetDatabase(DatabaseName);
        }

        #endregion Utilities

        #region Methods

        /// <summary>
        /// Table
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public IQueryable<T> Table<T>() where T : BaseEntity
        {
            return GetCollection<T>().AsQueryable<T>();
        }

        /// <summary>
        /// Asynchronously find entity using identifier
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        async public Task<T> FindAsync<T>(string id) where T : BaseEntity, new()
        {
            return await GetCollection<T>().Find<T>(d => d.Id == id).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Asynchronously insert new entity
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        async public Task InsertAsync<T>(T entity) where T : BaseEntity, new()
        {
            await GetCollection<T>().InsertOneAsync(entity);
        }

        /// <summary>
        /// Asynchronously update entity
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns></returns>
        async public Task UpdateAsync<T>(T entity) where T : BaseEntity, new()
        {
            await GetCollection<T>().ReplaceOneAsync<T>(d => d.Id == entity.Id, entity);
        }

        /// <summary>
        /// Asynchronously update property
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="subEntities">Sub entities</param>
        /// <param name="property">Property</param>
        /// <returns></returns>
        async public Task UpdateProperty<T, Field>(T entity, IList<Field> subEntities, string property) where T : BaseEntity, new()
        {
            await GetCollection<T>().UpdateOneAsync<T>(d => d.Id == entity.Id, Builders<T>.Update.Set(property, subEntities));
        }

        /// <summary>
        /// Asynchronously delete entity
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="id">identifier</param>
        /// <returns></returns>
        async public Task<bool> DeleteAsync<T>(string id) where T : BaseEntity
        {
            var result = await GetCollection<T>().DeleteOneAsync<T>(d => d.Id == id);

            if (result != null)
                return result.IsAcknowledged;
            else
                return false;
        }

        #endregion Methods



    }
}
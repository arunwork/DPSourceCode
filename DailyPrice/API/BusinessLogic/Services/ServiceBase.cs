using DailyPrice.API.Data;

namespace DailyPrice.API.BusinessLogic.Services
{
    /// <summary>
    /// Base class for services
    /// </summary>
    public abstract class ServiceBase
    {
        protected readonly IRepository Repository;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository">Repository</param>
        public ServiceBase(IRepository repository)
        {
            Repository = repository;
        }
    }
}
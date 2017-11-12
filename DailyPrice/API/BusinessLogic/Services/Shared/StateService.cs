using System.Collections.Generic;
using DailyPrice.API.Core.Domain.Shared;
using DailyPrice.API.Data;
using System.Linq;

namespace DailyPrice.API.BusinessLogic.Services.Shared
{
    /// <summary>
    /// Represents the state service 
    /// </summary>
    public class StateService : ServiceBase, IStateService
    {
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="repository">Repository</param>
        public StateService(IRepository repository)
        : base(repository)
        {

        }

        #region Methods

        /// <summary>
        /// Get all states
        /// </summary>
        /// <returns></returns>
        public IList<State> GetStates()
        {
            return Repository.Table<State>().ToList();
        }

        #endregion Methods

    }
}
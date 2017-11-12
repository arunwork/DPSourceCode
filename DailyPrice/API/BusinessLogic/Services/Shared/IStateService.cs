using System.Collections.Generic;
using DailyPrice.API.Core.Domain.Shared;

namespace DailyPrice.API.BusinessLogic.Services.Shared
{
    /// <summary>
    /// Represents the state service interface
    /// </summary>
    public interface IStateService
    {
        /// <summary>
        /// Get all states
        /// </summary>
        /// <returns></returns>
         IList<State> GetStates();
    }
}
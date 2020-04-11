using System.Collections.Generic;
using System.Threading.Tasks;
using GoodsLogistics.Models.DTO;
using GoodsLogistics.Models.DTO.Objective;

namespace GoodsLogistics.Services.Data.Services.Interfaces
{
    public interface IObjectiveService
    {
        Task<ServiceResponseModel<List<ObjectiveModel>>> GetObjectives();

        Task<ServiceResponseModel<List<ObjectiveModel>>> GetObjectivesByFilter(ObjectiveFilteringModel filter);

        Task<ServiceResponseModel<ObjectiveModel>> GetObjectiveById(string id);

        Task<ServiceResponseModel<ObjectiveModel>> CreateObjective(ObjectiveModel createRequestModel);

        Task<ServiceResponseModel<ObjectiveModel>> UpdateObjective(
            string id,
            ObjectiveUpdateRequestModel updateRequestModel);

        Task DeleteObjective(string id);

        Task<ServiceResponseModel<decimal>> GetObjectivesMinPrice();

        Task<ServiceResponseModel<decimal>> GetObjectivesMaxPrice();
    }
}

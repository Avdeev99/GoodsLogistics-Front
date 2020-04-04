using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GoodsLogistics.Models.DTO.Objective;
using GoodsLogistics.Services.Data.Services.Interfaces;
using GoodsLogistics.ViewModels.DTO;
using GoodsLogistics.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GoodsLogistics.Web.Controllers
{
    public class ObjectiveController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IObjectiveService _objectiveService;

        public ObjectiveController(
            IMapper mapper, 
            IObjectiveService objectiveService)
        {
            _mapper = mapper;
            _objectiveService = objectiveService;
        }

        public async Task<IActionResult> GetObjectives(ObjectiveListViewModel filteringModel)
        {
            var serviceResponse = await _objectiveService.GetObjectives();
            var objectiveViewModels = _mapper.Map<List<ObjectiveViewModel>>(serviceResponse.Data);

            var objectiveList = new ObjectiveListViewModel(objectiveViewModels);
            return View("Index", objectiveList);
        }

        public async Task<IActionResult> Create(ObjectiveViewModel objectiveViewModel)
        {
            ModelState.Remove("ObjectiveId");

            if (!ModelState.IsValid)
            {
                
            }

            var objective = _mapper.Map<ObjectiveModel>(objectiveViewModel);
            var companyId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            objective.ReceiverCompanyId = companyId;

            var serviceResponse = await _objectiveService.CreateObjective(objective);
            if (!serviceResponse.IsSuccess)
            {
                ModelState.AddModelErrors(serviceResponse.Errors);
                //return View("Edit", officeViewModel);
            }

            return RedirectToAction("GetObjectives");
        }

        public async Task<IActionResult> GetObjectiveById(string objectiveId)
        {
            var serviceResponse = await _objectiveService.GetObjectiveById(objectiveId);
            var objectiveViewModel = _mapper.Map<ObjectiveViewModel>(serviceResponse.Data);
            return PartialView("_ObjectiveDetailsPartial", objectiveViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string objectiveId)
        {
            await _objectiveService.DeleteObjective(objectiveId);

            return RedirectToAction("GetObjectives");
        }
    }
}
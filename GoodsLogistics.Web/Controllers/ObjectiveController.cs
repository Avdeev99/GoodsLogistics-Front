using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GoodsLogistics.Models.DTO.Location;
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
        private readonly IOfficeService _officeService;

        public ObjectiveController(
            IMapper mapper, 
            IObjectiveService objectiveService, 
            IOfficeService officeService)
        {
            _mapper = mapper;
            _objectiveService = objectiveService;
            _officeService = officeService;
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

            if (!string.IsNullOrEmpty(objectiveViewModel.Location?.OfficeKey))
            {
                var response = await _officeService.GetOfficeByKey(objectiveViewModel.Location.OfficeKey);
                var location = _mapper.Map<LocationModel>(response.Data);
                location.City = null;
                objective.Location = location;
            }

            var companyId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            objective.ReceiverCompanyId = companyId;

            var serviceResponse = await _objectiveService.CreateObjective(objective);
            if (!serviceResponse.IsSuccess)
            {
                ModelState.AddModelErrors(serviceResponse.Errors);
                //return View("Edit", officeViewModel);
            }

            return RedirectToAction("GetAllSorted", new ObjectiveListViewModel());
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

            return RedirectToAction("GetAllSorted", new ObjectiveListViewModel());
        }

        [HttpGet]
        public async  Task<IActionResult> GetAllSorted(ObjectiveListViewModel listViewModel)
        {
            var result = await GetSortedResult(listViewModel);
            return View("Index", result);
        }

        [HttpPost]
        public async Task<IActionResult> AllSorted(ObjectiveListViewModel listViewModel)
        {
            var result = await GetSortedResult(listViewModel);
            return PartialView("_ObjectiveListPartial", result);
        }

        private async Task<ObjectiveListViewModel> GetSortedResult(ObjectiveListViewModel listViewModel)
        {
            var filter = _mapper.Map<ObjectiveFilteringModel>(listViewModel.Filter);
            var email = User.FindFirst(ClaimTypes.Email).Value;
            filter.ReceiverCompanyEmail = email;

            var serviceResponse = await _objectiveService.GetObjectivesByFilter(filter);
            if (!serviceResponse.IsSuccess)
            {

            }

            var objectivesViewModel = _mapper.Map<List<ObjectiveViewModel>>(serviceResponse.Data);
            listViewModel.Objectives = objectivesViewModel;

            if (listViewModel.Filter.PriceFrom == null)
            {
                var response = await _objectiveService.GetObjectivesMinPrice();
                listViewModel.Filter.PriceFrom = response.Data;
            }

            if (listViewModel.Filter.PriceTo == null)
            {
                var response = await _objectiveService.GetObjectivesMaxPrice();
                listViewModel.Filter.PriceTo = response.Data;
            }

            return listViewModel;
        }
    }
}
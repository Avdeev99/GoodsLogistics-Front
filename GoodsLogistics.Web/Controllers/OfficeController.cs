using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GoodsLogistics.Models.DTO.Office;
using GoodsLogistics.Services.Data.Services.Interfaces;
using GoodsLogistics.ViewModels.DTO;
using GoodsLogistics.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoodsLogistics.Web.Controllers
{
    public class OfficeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOfficeService _officeService;

        public OfficeController(
            IMapper mapper, 
            IOfficeService officeService)
        {
            _mapper = mapper;
            _officeService = officeService;
        }

        public async Task<IActionResult> GetAll()
        {
            var serviceResponse = await _officeService.GetOffices();
            var officeViewModels = _mapper.Map<List<OfficeViewModel>>(serviceResponse.Data);
            return View("Offices", officeViewModels);
        }

        public IActionResult Create()
        {
            return View("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> Create(OfficeViewModel officeViewModel)
        {
            ModelState.Remove("OfficeId");

            if (!ModelState.IsValid)
            {
                return View("Edit", officeViewModel);
            }

            var office = _mapper.Map<OfficeModel>(officeViewModel);
            var companyId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            office.CompanyId = companyId;

            var serviceResponse = await _officeService.CreateOffice(office);
            if (!serviceResponse.IsSuccess)
            {
                ModelState.AddModelErrors(serviceResponse.Errors);
                return View("Edit", officeViewModel);
            }

            return RedirectToAction("GetAllByCompanyIdViewResult");
        }

        public async Task<IActionResult> Details(string key)
        {
            var serviceResponse = await _officeService.GetOfficeByKey(key);
            var officeViewModel = _mapper.Map<OfficeViewModel>(serviceResponse.Data);
            return View(officeViewModel);
        }

        public async Task<IActionResult> Update(string key)
        {
            var serviceResponse = await _officeService.GetOfficeByKey(key);
            var officeViewModel = _mapper.Map<OfficeViewModel>(serviceResponse.Data);
            return View("Edit", officeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OfficeViewModel officeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", officeViewModel);
            }

            var office = _mapper.Map<OfficeUpdateRequestModel>(officeViewModel);

            var serviceResponse = await _officeService.UpdateOffice(officeViewModel.Key, office);
            if (!serviceResponse.IsSuccess)
            {
                ModelState.AddModelErrors(serviceResponse.Errors);
                return View("Edit", officeViewModel);
            }

            return RedirectToAction("GetAllByCompanyIdViewResult");
        }

        public async Task<IActionResult> Delete(string key)
        {
            await _officeService.DeleteOffice(key);

            return RedirectToAction("GetAllByCompanyIdViewResult");
        }

        public async Task<string> GetAllByCompanyId(string companyId)
        {
            var serviceResponse = await _officeService.GetOfficesByCompanyId(companyId);
            if (!serviceResponse.IsSuccess)
            {
                return null;
            }

            var result = JsonConvert.SerializeObject(serviceResponse.Data);
            return result;
        }

        public async Task<IActionResult> GetAllByCompanyIdViewResult(string companyId)
        {
            var requestId = companyId ?? User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var serviceResponse = await _officeService.GetOfficesByCompanyId(requestId);
            if (!serviceResponse.IsSuccess)
            {
                return null;
            }

            var officeViewModels = _mapper.Map<List<OfficeViewModel>>(serviceResponse.Data);
            return View("Offices", officeViewModels);
        }
    }
}
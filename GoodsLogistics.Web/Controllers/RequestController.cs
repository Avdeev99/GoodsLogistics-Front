using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GoodsLogistics.Models.DTO.Office;
using GoodsLogistics.Models.DTO.Request;
using GoodsLogistics.Services.Data.Services.Interfaces;
using GoodsLogistics.ViewModels.DTO;
using GoodsLogistics.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace GoodsLogistics.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRequestService _requestService;

        public RequestController(
            IRequestService requestService, 
            IMapper mapper)
        {
            _requestService = requestService;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetAllByCompanyId(string companyId)
        {
            var serviceResponse = await _requestService.GetRequestsByCompanyId(companyId);
            if (!serviceResponse.IsSuccess)
            {
                return null;
            }

            var requestsViewModels = _mapper.Map<List<RequestViewModel>>(serviceResponse.Data);
            return View("Requests", requestsViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RequestViewModel requestViewModel)
        {
            ModelState.Remove("RequestId");

            if (!ModelState.IsValid)
            {
                
            }

            var request = _mapper.Map<RequestModel>(requestViewModel);
            var userCompanyId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            request.CompanyId = userCompanyId;

            var serviceResponse = await _requestService.CreateRequest(request);
            if (!serviceResponse.IsSuccess)
            {
                ModelState.AddModelErrors(serviceResponse.Errors);
                
            }

            return RedirectToAction("GetAllByCompanyId", new {companyId = userCompanyId });
        }
    }
}
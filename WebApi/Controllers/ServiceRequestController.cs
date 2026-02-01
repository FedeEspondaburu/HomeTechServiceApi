using Application.DTO;
using Application.Interfaces;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("service-requests")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly IServiceRequestService _serviceRequestService;
        public ServiceRequestController(IServiceRequestService serviceRequestService)
        {
            _serviceRequestService = serviceRequestService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateServiceRequestDto serviceRequestDto)
        {
            try
            {
                _serviceRequestService.CreateServiceRequest(serviceRequestDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error while creating the Service Request: " + ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] RequestStatus? requestStatus)
        {
            try
            {
                List<ServiceRequestListItemDto> serviceRequests;
                if (requestStatus.HasValue)
                {
                    serviceRequests = await _serviceRequestService.GetByStatus(requestStatus.Value);
                }
                else
                {
                    serviceRequests = await _serviceRequestService.GetAll();
                }
                return Ok(serviceRequests);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while retrieving Service Requests: " + ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var serviceRequest = await _serviceRequestService.GetById(id);
                if (serviceRequest == null)
                {
                    return NotFound("Service Request not found.");
                }
                return Ok(serviceRequest);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while retrieving the Service Request: " + ex.Message);
            }
        }

        [HttpGet("status/{status:required}/technicianId/{technicianId:int}")]
        public async Task<IActionResult> GetByStatusAndTechnician(RequestStatus status, int technicianId)
        {
            try
            {
                var serviceRequests = await _serviceRequestService.GetByStatusAndTechnician(status, technicianId);
                return Ok(serviceRequests);
            }
            catch (Exception ex)
            {
                return BadRequest("Error while retrieving Service Sequests by status and technician: " + ex.Message);
            }
        }

        [HttpPut("{id:int}/assign")]
        public IActionResult AssignTechnician(int id, [FromBody] AssignTechnicianDto dto)
        {
            try
            {
                _serviceRequestService.AssignTechnician(id, dto.TechnicianId);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest("Error while Assigning a Service Requests: " + ex.Message);
            }
        }

        [HttpPut("{id:int}/status")]
        public IActionResult ChangeRequestState(int id, [FromBody] ChangeStatusDto dto)
        {
            try
            {
                _serviceRequestService.ChangeRequestState(dto.Status, dto.Reason, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Error while changing the Service Request state: " + ex.Message);
            }
        }
    }
}

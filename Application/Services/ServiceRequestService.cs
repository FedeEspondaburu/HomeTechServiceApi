using Application.DTO;
using Application.Interfaces;
using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Shared.Exceptions;

namespace Application.Services
{
    public class ServiceRequestService : IServiceRequestService
    {
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IUserService _userService;
        public ServiceRequestService(IServiceRequestRepository serviceRequestRepository, IUserService user)
        {
            _serviceRequestRepository = serviceRequestRepository;
            _userService = user;
        }

        public async void AssignTechnician(int requestId, int technicianId)
        {
            bool isTechnicianValid = await _userService.CheckExistingUserById(technicianId);

            if (!isTechnicianValid)
            {
                throw new DataNotFoundException("Technician");
            }
            _serviceRequestRepository.AssignTechnician(requestId, technicianId);
        }

        public void ChangeRequestState(RequestStatus status, string? reason, int requestId)
        {
            if (status == RequestStatus.Cancelled && string.IsNullOrEmpty(reason))
            {
                throw new ArgumentException("Cancellation reason must be provided when cancelling a request.");
            }
            _serviceRequestRepository.ChangeRequestState(status, reason, requestId);
        }

        public void CreateServiceRequest(CreateServiceRequestDto serviceRequestDto)
        {
            var user = _userService.GetUserEntityByEMail(serviceRequestDto.ClientEmail).Result ?? throw new DataNotFoundException("User");
            var serviceRequest = new ServiceRequest
            { 
                RequestType = serviceRequestDto.RequestType,
                CreatedByUser = user,
                Status = RequestStatus.New,
                CreationTime = DateTime.UtcNow,
                Observation = serviceRequestDto.Observations,
                ScheduledAt = serviceRequestDto.ScheduledAt 
            };
            _serviceRequestRepository.CreateServiceRequest(serviceRequest);
        }

        public async Task<List<ServiceRequestListItemDto>> GetAll()
        {
            var requests = await _serviceRequestRepository.GetAll();
            return MapToDto(requests);
        }

        public async Task<ServiceRequestListItemDto?> GetById(int id)
        {
            var requests = await _serviceRequestRepository.GetRequestById(id);
            return MapToDto(requests);
        }

        public async Task<List<ServiceRequestListItemDto>> GetByStatus(RequestStatus status)
        {
            var requests = await _serviceRequestRepository.GetRequestsByStatus(status);
            return MapToDto(requests);
        }

        public async Task<List<ServiceRequestListItemDto>> GetByStatusAndTechnician(RequestStatus status, int technicianId)
        {
            bool isTechnicianValid = await _userService.CheckExistingUserById(technicianId);

            if (!isTechnicianValid)
            {
                throw new DataNotFoundException("Technician");
            }

            var requests = await _serviceRequestRepository.GetRequestsByStatus(status);
            var filteredRequests = requests.Where(t => t.Technician?.Id == technicianId).ToList();

            return MapToDto(filteredRequests);
        }

        private List<ServiceRequestListItemDto> MapToDto(List<ServiceRequest> request)
        {
            var mappedRequests = new List<ServiceRequestListItemDto>();
            request.ForEach(r =>
            {
                var rDto = MapToDto(r);
                mappedRequests.Add(rDto!);
            });
            return mappedRequests;
        }

        private ServiceRequestListItemDto? MapToDto(ServiceRequest? r)
        {
            if (r == null) return null;
            var rDto = new ServiceRequestListItemDto
            {
                Id = r.Id,
                Status = r.Status.ToString(),
                ClientName = r.CreatedByUser.ToString(),
                TechnicianName = r.Technician != null ? r.Technician!.ToString() : null,
                ScheduledAt = r.ScheduledAt
            };
            return rDto;
        }
    }
}

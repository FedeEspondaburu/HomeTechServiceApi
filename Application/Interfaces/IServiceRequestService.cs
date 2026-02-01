using Application.DTO;
using Domain.Enums;

namespace Application.Interfaces
{
    public interface IServiceRequestService
    {
        void AssignTechnician(int requestId, int technicianId);
        void ChangeRequestState(RequestStatus status, string? reason, int requestId);
        void CreateServiceRequest(CreateServiceRequestDto serviceRequestDto);
        Task<List<ServiceRequestListItemDto>> GetAll();
        Task<List<ServiceRequestListItemDto>> GetByStatus(RequestStatus status);
        Task<ServiceRequestListItemDto?> GetById(int id);
        Task<List<ServiceRequestListItemDto>> GetByStatusAndTechnician(RequestStatus status, int technicianId);

    }
}

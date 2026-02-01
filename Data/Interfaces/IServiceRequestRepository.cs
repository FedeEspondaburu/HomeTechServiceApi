using Domain.Entities;
using Domain.Enums;

namespace Data.Interfaces
{
    public interface IServiceRequestRepository
    {
        void AssignTechnician(int requestId, int technicianId);
        void ChangeRequestState(RequestStatus status, string? reason, int requestId);
        void CreateServiceRequest(ServiceRequest serviceRequest);
        Task<List<ServiceRequest>> GetAll();
        Task<ServiceRequest?> GetRequestById(int id);
        Task<List<ServiceRequest>> GetRequestsByStatus(RequestStatus status);
    }
}

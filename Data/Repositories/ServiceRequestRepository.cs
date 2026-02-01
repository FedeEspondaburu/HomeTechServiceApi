using Data.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

namespace Data.Repositories
{
    public class ServiceRequestRepository : IServiceRequestRepository
    {
        private readonly HomeTechServiceDBContext _context;

        public ServiceRequestRepository(HomeTechServiceDBContext context)
        {
            _context = context;
        }

        public void AssignTechnician(int requestId, int technicianId)
        {
            var serviceRequest = _context.ServiceRequests.FirstOrDefault(x => x.Id == requestId);
            if (serviceRequest == null)
            {
                throw new DataNotFoundException("Service Request");
            }
            var technician = _context.Users.Find(technicianId);
            serviceRequest.Technician = technician;
            _context.SaveChanges();
        }

        public void ChangeRequestState(RequestStatus status, string? reason, int requestId)
        {
            var serviceRequest = 
                _context.ServiceRequests.FirstOrDefault(x => x.Id == requestId) ?? 
                throw new DataNotFoundException("Service Request");

            serviceRequest.Status = status;
            serviceRequest.Observation = string.IsNullOrEmpty(reason) ? null : reason;
            _context.SaveChanges();
        }

        public void CreateServiceRequest(ServiceRequest serviceRequest)
        {
            _context.ServiceRequests.Add(serviceRequest);
            _context.SaveChanges();
        }

        public async Task<List<ServiceRequest>> GetAll()
        {
            return await _context.ServiceRequests
                .Include(us => us.CreatedByUser)
                .Include(us => us.Technician).ToListAsync();
        }

        public async Task<ServiceRequest?> GetRequestById(int id)
        {
            return await _context.ServiceRequests
                .Include(us => us.CreatedByUser)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ServiceRequest>> GetRequestsByStatus(RequestStatus status)
        {
            return await _context.ServiceRequests
                .Include(us => us.CreatedByUser)
                .Where(x => x.Status == status).ToListAsync();
        }
    }
}

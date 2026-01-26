using Data.Interfaces;
using Domain.Entities;

namespace Data.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly HomeTechServiceDBContext _context;
        public AddressRepository(HomeTechServiceDBContext context) => _context = context;

        public void SaveAddress(Address address)
        {
            try
            {
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Address? GetAddressById(int id)
        {
            return _context.Addresses.Find(id);
        }
    }
}

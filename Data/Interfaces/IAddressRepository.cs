using Domain.Entities;

namespace Data.Interfaces
{
    public interface IAddressRepository
    {
        Address? GetAddressById(int id);
        void SaveAddress(Address address);
    }
}
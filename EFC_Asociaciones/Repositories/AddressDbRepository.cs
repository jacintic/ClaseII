using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC_Asociaciones.Repositories;

public class AddressDbRepository : IAddressRepository
{
    // attrs
    // attr
    private AppDbContext Context;
    public AddressDbRepository(AppDbContext context)
    {
        Context = context;
    }

    // methods
    public Address FindById(int id)
    {
        return Context.Address.Find(id);
    }

    public List<Address> FindAll()
    {
        return Context.Address.ToList();
    }
    public Address Create(Address address)
    {
        Context.Address.Add(address);
        Context.SaveChanges();
        return address;
    }

}

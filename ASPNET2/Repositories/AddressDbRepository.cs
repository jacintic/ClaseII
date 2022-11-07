//using EFC_Asociaciones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNET2.Repositories;

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
        return Context.Addresses.Find(id);
    }

    public List<Address> FindAll()
    {
        return Context.Addresses.ToList();
    }
    public Address Create(Address address)
    {
        Context.Addresses.Add(address);
        Context.SaveChanges();
        return address;
    }

    public bool RemoveById(int id)
    {
        Address address = FindById(id);
        if (address == null)
            return false;
        Context.Addresses.Remove(address);
        Context.SaveChanges();
        return true;
    }


}

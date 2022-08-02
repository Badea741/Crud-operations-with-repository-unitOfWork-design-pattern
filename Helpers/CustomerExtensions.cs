using Project.Models;

namespace Project.Helpers;
public static class CustomerExtensions
{
    public static void GetUpdate(this Customer c, Customer customer)
    {
        c.Name = customer.Name;
        c.Email = customer.Email;
        c.PhoneNumber = customer.PhoneNumber;
        c.Latitude = customer.Latitude;
        c.Longitude = customer.Longitude;
    }
}


using Microsoft.AspNetCore.Mvc;
using Project.Repositories;
using Project.Models;
namespace Project.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CustomerController : ControllerBase
{
    readonly UnitOfWork _unitOfWork;
    public CustomerController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpPost]
    public IActionResult Add(Customer customer)
    {
        _unitOfWork.customerRepository.Add(customer);
        return Ok(_unitOfWork.Save());
    }
    [HttpGet]
    public IActionResult Get()
    {

        return Ok(_unitOfWork.customerRepository.GetAll());
    }
    [HttpPut("update")]
    public IActionResult Update([FromBody] Customer customer)
    {
        _unitOfWork.customerRepository.Update(customer);
        return Ok(_unitOfWork.Save());
    }
    [HttpDelete("delete")]
    public IActionResult Delete([FromQuery] string phoneNumber)
    {
        _unitOfWork.customerRepository.DeleteByPhoneNumber(phoneNumber);
        return Ok(_unitOfWork.Save());
    }
}
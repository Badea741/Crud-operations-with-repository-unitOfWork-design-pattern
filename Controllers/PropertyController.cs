using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Repositories;

namespace Project.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class PropertyController : ControllerBase
{
    readonly UnitOfWork _unitOfWork;
    public PropertyController(UnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_unitOfWork.propertyRepository.GetAll());
    }
    [HttpPost]
    public IActionResult Post([FromBody] Property property)
    {
        _unitOfWork.propertyRepository.Add(property);
        return Ok(_unitOfWork.Save());
    }
    [HttpGet("id")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        return Ok(_unitOfWork.propertyRepository.GetById(id));
    }
}
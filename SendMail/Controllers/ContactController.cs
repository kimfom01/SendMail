using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SendMail.Models;
using SendMail.Repository;

namespace SendMail.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContactController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PostContact(ContactDto? contactDto)
    {
        if (contactDto is null)
        {
            return BadRequest();
        }
        
        var contactToSave = _mapper.Map<Contact>(contactDto);

        var contact = await _unitOfWork.Contacts.AddItem(contactToSave);

        return CreatedAtAction(nameof(GetContact), new { id = contact.Id }, contact);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetContact(int id)
    {
        var contact = await _unitOfWork.Contacts.GetItem(id);

        if (contact is null)
        {
            return NotFound();
        }

        var contactDto = _mapper.Map<ContactDto>(contact);

        return Ok(contact);
    }
}
using ContactManager.Api.ApiResponses;
using ContactManager.Api.DTOs;
using ContactManager.Api.Validators;
using ContactManager.Domain.Entities;
using ContactManager.Domain.Repositories.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactManager.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        public ContactController([FromServices] IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> Get()
        {
            List<ContactDTO> contacts = new List<ContactDTO>();
            (await _contactRepository.All()).ToList().ForEach(c => contacts.Add(new ContactDTO(c)));
            return Ok(new ApiOk($"{contacts.Count()} contact(s) found", contacts));
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDTO>> Get(int id)
        {
            Contact? contact = await _contactRepository.Find(id);
            if(contact == null) return NotFound(new ApiNotFound("Contact not found"));
            return Ok(new ApiOk("Contact found",new ContactDTO(contact)));
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<ActionResult<ContactDTO>> Post([FromBody] ContactDTO contactDTO)
        {
            ContactValidator validator = new ContactValidator();
            ValidationResult result = validator.Validate(contactDTO);

            if(!result.IsValid) return UnprocessableEntity(new ApiUnprocessableEntity("Validation errors ocurred", result.Errors));

            Contact contact = new Contact(
                contactDTO.Name,
                contactDTO.Nickname,
                contactDTO.DateOfBirth != null ? DateOnly.Parse(contactDTO.DateOfBirth) : null
            );

            return Created("/wtf", new ApiCreated("Contact created", new ContactDTO(await _contactRepository.Create(contact))));

        }

        // Patch api/<ContactController>/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<ContactDTO>> Patch(int id, [FromBody] ContactDTO contactDTO)
        {
            Contact? contact = await _contactRepository.Find(id);
            if(contact == null) return NotFound(new ApiNotFound("Contact not found"));

            ContactValidator validator = new ContactValidator();
            ValidationResult result = validator.Validate(contactDTO);

            if(!result.IsValid) return UnprocessableEntity(new ApiUnprocessableEntity("Validation errors ocurred", result.Errors));
            
            contact.Name = contactDTO.Name;
            contact.Nickname = contactDTO.Nickname;
            contact.DateOfBirth = contactDTO.DateOfBirth != null ? DateOnly.Parse(contactDTO.DateOfBirth) : null;

            contactDTO.Id = contact.Id;

            await _contactRepository.Update(contact);
            return Ok(new ApiOk("Contact updated", contactDTO));
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool destroyed = await _contactRepository.Destroy(id);
            if(destroyed) return Ok(new ApiOk("Contact deleted"));
            else return Ok(new ApiOk($"Could not delete contact of id {id}"));
        }

        // POST api/<ContactController>/5/restore
        [HttpPost("{id}/restore")]
        public async Task<ActionResult<ContactDTO>> Restore(int id)
        {
            Contact? contact = await _contactRepository.FindWithTrashed(id);
            if(contact == null) return NotFound(new ApiNotFound("Contact not found"));
            
            if(contact.DeletedAt == null) return UnprocessableEntity(new ApiUnprocessableEntity("Contact is not deleted", new ContactDTO(contact)));
            
            ContactDTO contactDTO = new ContactDTO(await _contactRepository.Restore(contact));

            return Ok(new ApiOk("Contact restored", contactDTO));
        }

        // GET api/<ContactController>/trashed
        [HttpGet("trashed")]
        public async Task<ActionResult<IEnumerable<ContactDTO>>> GetTrashed()
        {
            IEnumerable<Contact> contacts = await _contactRepository.AllWithTrashed();
            List<ContactDTO> contactDTOs = new List<ContactDTO>();
            contacts.ToList().ForEach(c => contactDTOs.Add(new ContactDTO(c)));

            return Ok(new ApiOk($"{contactDTOs.Count()} contact(s) found", contactDTOs));
        }
    }
}

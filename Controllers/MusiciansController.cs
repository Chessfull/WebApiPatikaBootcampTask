using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApiPatikaBootcampTask.Models;
using WebApiPatikaBootcampTask.Repositories;

namespace WebApiPatikaBootcampTask.Controllers
{
    [Route("api/v1/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        // ▼ Dependency Injection of my repository that includes sample data ▼
        private readonly IMusicianRepository _musicianRepository;
        public MusiciansController(IMusicianRepository musicianRepository)
        {
            _musicianRepository = musicianRepository;
        }

        // api/v1/musicians 
        [HttpGet]
        public IActionResult GetAllMusician()
        {
            return Ok(_musicianRepository.GetAll());// ← Getting all values from repository, ← Status Code:200 
        }

        // api/v1/musicians/{id}
        [HttpGet("{id:int:min(1)}")]
        public IActionResult GetMusicianById(int id)
        {

            Musician getMusician = _musicianRepository.GetById(id); // ← Getting value from repository with id parameter
            if (getMusician == null)
            {
                return NotFound(new { errorMessage = $"Unfortunately the musician you are looking for with {id} is not found." }); // ← Status Code:404
            }
            return Ok(getMusician); // ← Status Code:200
        }

        

        // api/v1/musicians
        [HttpPost]
        public IActionResult CreateMusician([FromBody] Musician musician)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // ← Status Code:400
            }

            _musicianRepository.Add(musician); // ← Adding with repository

            return CreatedAtAction(nameof(GetMusicianById), new { id = musician.MusicianId }, musician); // ← Status Code:201
        }

        // api/v1/musicians/{id}
        [HttpPut("{id:int:min(1)}")]
        public IActionResult UpdateMusician(int id, [FromBody] Musician musician)
        {

            if (id != musician.MusicianId || musician is null) // ← Managing match and null conditions
            {
                return BadRequest(); // ← Status Code:400
            }

            var updatedMusician = _musicianRepository.GetById(id); // ← Finding by id with repository

            if (updatedMusician == null)
            {
                return NotFound(new { errorMessage = $"Unfortunately the musician you are looking update for with {id} is not found." }); // ← Status Code:404
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // ← Status Code:400
            }

            _musicianRepository.Update(updatedMusician); // ← Update with repository

            return Ok(new { updateMessage = $"With {id} musician updated successfully." });
        }

        // api/v1/musicians/{id}
        [HttpPatch("{id:int:min(1)}")]
        public IActionResult PatchMusician(int id, [FromBody] JsonPatchDocument<Musician> patchMusician)
        {
            if (patchMusician == null) // ← Managing null condition
            {
                return BadRequest(); // ← Status Code:400
            }

            var musician = _musicianRepository.GetById(id);

            if (musician == null)
            {
                return NotFound(new { errorMessage = $"Unfortunately the musician you are looking for patching with {id} is not found." }); // ← Status Code:404
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // ← Status Code:400
            }

            patchMusician.ApplyTo(musician); // ← Applying JsonPatchDocument

            return NoContent(); // ← Status Code:204

        }

        // api/v1/musicians/{id}
        [HttpDelete("{id:int:min(1)}")]
        public IActionResult DeleteMusician(int id)
        {
            var deletedMusician = _musicianRepository.GetById(id);

            if (deletedMusician == null) // ← Managing null condition
            {
                return NotFound(new { errorMessage = $"Unfortunately the musician you are looking for delete with {id} is not found." }); // ← Status Code:404
            }

            _musicianRepository.Delete(id); // ← Deleting with repository, hard delete

            return NoContent(); // ← Status Code:204
        }

        // api/v1/musicians/name&proficiency?search='searchtext'
        [HttpGet("name&proficiency")]
        public IActionResult SearchMusician([FromQuery]string search)
        {
            var musiciansSearched = _musicianRepository.Search(search); // ← Searching name and proficinecy with noncase sensitive and out results as list

            if (!musiciansSearched.Any()) // ← If not found with search text 
            {
                return NotFound(new { errorMessage = $"Unfortunately we cant find any musician with searcing {search}." }); // ← Status Code:404
            }

            return Ok(musiciansSearched); // ← Status Code:200
        }


    }
}


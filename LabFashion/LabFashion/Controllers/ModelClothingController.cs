using AutoMapper;
using LabFashion.Context;
using LabFashion.DTOs;
using LabFashion.Enums;
using LabFashion.Models;
using LabFashion.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabFashion.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ModelClothingController : Controller
    {
        private readonly LCCContext _context;
        private readonly IModelClothingRepository _modelRepository;
        private readonly IMapper _mapper;

        public ModelClothingController(LCCContext context, IModelClothingRepository modelRepository, IMapper mapper)
        {
            _context = context;
            _modelRepository = modelRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Return a list of models
        /// </summary>
        /// <param name="layoutModel"></param>
        /// <returns>Returns a list of models successfully</returns>
        /// <response code=200>Returns a list of models successfully</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelClothing>>> GetModelsClothing(LayoutModel? layoutModel)
        {
            IQueryable<ModelClothing> query = _context.Models.Include(x => x.ClothingCollection).Include(x => x.ClothingCollection.Person);

            if (layoutModel != null)
            {
                query = query.Where(e => e.LayoutModel == layoutModel);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Return a specific model
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a specific model successfully</returns>
        /// <response code=200>Return a specific model successfully</response>
        /// <response code=404>Model not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetModelsClothingById(int id)
        {
            var modelClothing = await _modelRepository.GetModelsClothingById(id);
            if (modelClothing == null)
            {
                return NotFound("User not found.");
            }
            var modelClothingDTO = _mapper.Map<ModelClothingDTO>(modelClothing);
            return Ok(modelClothingDTO);
        }

        /// <summary>
        /// Create a model
        /// </summary>
        /// <param name="modelClothingDTO"></param>
        /// <returns>Create a model successfully</returns>
        /// <response code=201>Create a model successfully</response>
        /// <response code=400>Bad Request</response>
        /// <response code=409>Model name already exists</response>
        [HttpPost("createModelo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult> PostModelsClothing([FromBody] ModelClothingDTO modelClothingDTO)
        {
            var modelClothing = _mapper.Map<ModelClothing>(modelClothingDTO);
            _modelRepository.CreateModelsClothing(modelClothing);

            if (modelClothing.NameModel == _context.Models.First().NameModel)
            {
                return Conflict();
            }

            if (await _modelRepository.SaveAllAsync())
            {
                return CreatedAtAction(nameof(GetModelsClothingById), new { id = modelClothingDTO.IdModel}, modelClothing);
            }
            return BadRequest();
        }

        /// <summary>
        /// Update a specific model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="modelClothingDTO"></param>
        /// <returns>Update a specific model successfully</returns>
        /// <response code=200>Update a specific model successfully</response>
        /// <response code=400>Bad Request</response>
        /// <response code=404>Model Not Found</response>
        [HttpPut("updateModelo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutModelsClothing([FromRoute] int id, [FromBody] ModelClothingDTO modelClothingDTO)
        {
            if (modelClothingDTO.IdModel == 0)
            {
                return BadRequest();
            }

            var clothingCollection = _mapper.Map<ModelClothing>(modelClothingDTO);
            _modelRepository.UpdateModelsClothingn(clothingCollection);
            if (modelClothingDTO.IdModel == null)
            {
                return NotFound("Collection not found.");
            }

            if (await _modelRepository.SaveAllAsync())
            {
                return Ok("Update collection successfully.");
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a specific model
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete a specific model successfully</returns>
        /// <response code=204>Delete a specific model successfully</response>
        /// <response code=400>Bad Request</response>
        /// <response code=404>Model not found</response>
        [HttpDelete("deleteModelo/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteModelsClothing(int id)
        {
            var modelClothing = await _modelRepository.GetModelsClothingById(id);
            if (modelClothing == null)
            {
                return NotFound("Collection not found");
            }

            _modelRepository.DeleteModelsClothing(modelClothing);
            if (await _modelRepository.SaveAllAsync())
            {
                return NoContent();
            }
            return BadRequest();
        }
    }
}

﻿using AutoMapper;
using LabFashion.Context;
using LabFashion.DTOs;
using LabFashion.Enums;
using LabFashion.Models;
using LabFashion.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabFashion.Controllers
{
    [Route("api/v{version:apiVersion}/")]
    [ApiController]
    public class ClothingCollectionController : Controller
    {
        private readonly LCCContext _context;
        private readonly IClothingCollectionRepository _collectionRepository;
        private readonly IMapper _mapper;

        public ClothingCollectionController(LCCContext context, IClothingCollectionRepository collectionRepository, IMapper mapper)
        {
            _context = context;
            _collectionRepository = collectionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Return a list of collections
        /// </summary>
        /// <returns>Returns a list of collections successfully</returns>
        /// <response code=200>Returns a list of collections successfully</response>
        [HttpGet("colecoes")]
        public async Task<ActionResult<IEnumerable<ClothingCollection>>> GetClothingCollections(SystemStatus? systemStatus)
        {
            IQueryable<ClothingCollection> query = _context.Collections;

            if (systemStatus != null)
            {
                query = query.Where(e => e.SystemStatus == systemStatus);
            }

            return await query.ToListAsync();
        }

        /// <summary>
        /// Return a specific collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Return a specific user successfully</returns>
        /// <response code=200>Return a specific collection successfully</response>
        /// <response code=404>Collection not found</response>
        [HttpGet("colecoes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetClothingCollectionById(int id)
        {
            var clothingCollection = await _collectionRepository.GetClothingCollectionById(id);
            if (clothingCollection == null)
            {
                return NotFound("User not found.");
            }
            var clothingCollectionDTO = _mapper.Map<ClothingCollectionDTO>(clothingCollection);
            return Ok(clothingCollectionDTO);
        }

        /// <summary>
        /// Create a collection
        /// </summary>
        /// <returns>Create a collection successfully</returns>
        /// <response code=201>Create a collection successfully</response>
        /// <response code=400>Bad Request</response>
        [HttpPost("createClothingCollection")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostClothingCollection([FromBody] ClothingCollectionDTO clothingCollectionDTO)
        {
            var clothingCollection = _mapper.Map<ClothingCollection>(clothingCollectionDTO);
            _collectionRepository.CreateClothingCollection(clothingCollection);
            if (await _collectionRepository.SaveAllAsync())
            {
                return Ok("Collection created successfully.");
            }
            return BadRequest();
        }

        /// <summary>
        /// Update a specific collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Update a specific collection successfully</returns>
        /// <response code=200>Update a specific collection successfully</response>
        /// <response code=400>Bad Request</response>
        /// <response code=404>Collection Not Found</response>
        [HttpPut("collection/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PutClothingCollection([FromRoute] int id, [FromBody] ClothingCollectionDTO clothingCollectionDTO)
        {
            if (clothingCollectionDTO.IdCollection == 0)
            {
                return BadRequest();
            }

            var clothingCollection = _mapper.Map<ClothingCollection>(clothingCollectionDTO);
            _collectionRepository.UpdateClothingCollection(clothingCollection);
            if (clothingCollectionDTO.IdCollection == null)
            {
                return NotFound("Collection not found.");
            }

            if (await _collectionRepository.SaveAllAsync())
            {
                return Ok("Update collection successfully.");
            }
            return BadRequest();
        }

        /// <summary>
        /// Delete a specific collection
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete a specific collection successfully</returns>
        /// <response code=200>Delete a specific collection successfully</response>
        /// <response code=404>Collection not found</response>
        [HttpDelete("deleteClothingCollection/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteClothingCollection(int id)
        {
            var clothingCollection = await _collectionRepository.GetClothingCollectionById(id);
            if (clothingCollection == null)
            {
                return NotFound("Collection not found");
            }

            _collectionRepository.DeleteClothingCollection(clothingCollection);
            if (await _collectionRepository.SaveAllAsync())
            {
                return Ok("Collection deleted successfully.");
            }
            return BadRequest();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfileManagementApi.DBContext;
using ProfileManagementApi.Models;
using ProfileManagementApi.Models.ViewModels;

namespace ProfileManagementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        
        
        public ProfileController(IMapper  mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileResponse>>> Get()
        {
            try
            {
                var profile = await _context.Profiles.ToListAsync();

                return _mapper.Map<List<ProfileResponse>>(profile);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetSingleProfile")]
        public async Task<ActionResult<ProfileResponse>> Get(int id)
        {
            try
            {
                var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == id);
                
                if (profile  == null)
                    return NotFound();

                return _mapper.Map<ProfileResponse>(profile);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ProfileCreate profileCreate)
        {
            try
            {
                var profile = profileCreate;
                profile.CreatedAt = DateTime.Now;
                profile.UpdatedAt = DateTime.Now;

                var profileMapped = _mapper.Map<Profiles>(profile);

                _context.Add(profileMapped);
                await _context.SaveChangesAsync();
                
                return new CreatedAtRouteResult("GetSingleProfile", new {id = profileMapped.Id});
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
        }
    }
}
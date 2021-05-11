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
    public class ProjectController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        
        public ProjectController(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProjectsResponse>>> Get()
        {
            try
            {
                return _mapper.Map<List<ProjectsResponse>>(await _context.Projects.ToListAsync());
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}", Name = "GetSingleProject")]
        public async Task<ActionResult<ProjectsResponse>> Get(int id)
        {
            try
            {
                var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
                if (project == null)
                    return NotFound();

                return _mapper.Map<ProjectsResponse>(project);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ProjectsCreate projectsCreate)
        {
            try
            {
                var project = projectsCreate;
                project.CreatedAt = DateTime.Now;
                project.UpdateAt = DateTime.Now;

                var entityMapped = _mapper.Map<Projects>(project);

                _context.Add(entityMapped);
                await _context.SaveChangesAsync();

                var projectMapped = _mapper.Map<ProjectsResponse>(entityMapped);
                
                return new CreatedAtRouteResult("GetSingleProject", new { id = entityMapped.Id }, projectMapped);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromForm] ProfileCreate projectCreate, int id)
        {
            try
            {
                var entity = _mapper.Map<Profiles>(projectCreate);
                entity.Id = id;
                entity.UpdatedAt = DateTime.Now;

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
                
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            if (project == null)
                return NotFound();

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
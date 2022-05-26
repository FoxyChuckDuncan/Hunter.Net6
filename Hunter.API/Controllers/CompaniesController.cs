using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hunter.API.Data;
using AutoMapper;
using Hunter.API.DTOs;

namespace Hunter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly HunterDbContext _context;
        private readonly IMapper _mapper;

        public CompaniesController(HunterDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCompanyDto>>> GetCompanys()
        {
            var countries = await _context.Companys.ToListAsync();
            var records = _mapper.Map<List<GetCompanyDto>>(countries);
            return Ok(records);
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var company = await _context.Companys.Include(p => p.Projects).FirstOrDefaultAsync(q => q.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, UpdateCompanyDto updateCompanyDto)
        {
            if (id != updateCompanyDto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(company).State = EntityState.Modified;
            var company = await _context.Companys.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCompanyDto, company);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CreateCompanyDto createCompanyDto)
        {
            var company = _mapper.Map<Company>(createCompanyDto);

            _context.Companys.Add(company);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.Id }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var company = await _context.Companys.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Companys.Remove(company);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CompanyExists(int id)
        {
            return _context.Companys.Any(e => e.Id == id);
        }
    }
}

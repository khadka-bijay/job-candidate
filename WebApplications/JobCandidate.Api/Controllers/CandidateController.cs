using AutoMapper;
using JobCandidate.Api.Models;
using JobCandidate.Data.Entities;
using JobCandidate.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobCandidate.Api.Controllers
{
    public class CandidateController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICandidateService _candidateService;

        public CandidateController(
            IMapper mapper, 
            ICandidateService candidateService)
        {
            _mapper = mapper;
            _candidateService = candidateService;
        }

        [Route("candidate/save")]
        [HttpPost]
        public async Task<IActionResult> SaveCandidateAsync([FromBody] CandidateModel candidate)
        {
            try
            {
                if (!ModelState.IsValid) //FluentValidation
                {
                    return BadRequest(ModelState);
                }
                Candidate mCandidate = _mapper.Map<Candidate>(candidate);

                Candidate _candidate = await _candidateService.GetCandidateByEmailAsync(mCandidate.Email);
                if (candidate.CandidateId != 0 && _candidate is not null)
                {
                    await _candidateService.UpdateAsync(mCandidate);
                }
                else
                {
                    await _candidateService.AddAsync(mCandidate);
                }
                return Ok("Saved successfully");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}

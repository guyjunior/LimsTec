using LimsDetec.Models;
using Limstec.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Limstec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SamplesController : ControllerBase
    {

        private ISampleService _sampleService;

        public SamplesController(ISampleService sampleService)
        {
            _sampleService = sampleService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Sample>>> GetSamples()
        {
            try
            {
                var samples = await _sampleService.GetSamples();
                return Ok(samples);

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter amostras");
            }
        }

        [HttpGet("SamplePorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Sample>>> GetSamplesByNome([FromQuery] string nome)
        {
            try
            {
                var samples = await _sampleService.GetSamplesByNome(nome);

                if (samples == null)
                    return NotFound($"Não existem amostras com o criterio {nome}");

                return Ok(samples);

            }
            catch
            {
                return BadRequest("Request Invalid");
            }
        }

        [HttpGet("{id:int}", Name="GetSample")]

        public async Task<ActionResult<Sample>> GetSample(int id)
        {
            try
            {
                var sample = await _sampleService.GetSample(id);
                if (sample == null)
                    return NotFound($"Não existem amostras com o id = {id}");

                return Ok(sample);
            }
            catch 
            {

                return BadRequest("Request Invalido");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Create(Sample sample)
        {
            try
            {
                await _sampleService.CreateSample(sample);
                return CreatedAtRoute(nameof(GetSample), new {id = sample.Id}, sample);
            }
            catch
            {

                return BadRequest("Request Invalido");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Edit(int id,[FromBody] Sample sample)
        {
            try
            {
                if(sample == null)
                {
                    await _sampleService.UpdateSample(sample);

                    return Ok($"Amostra com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados Inconsistentes");
                }
            }
            catch
            {

                return BadRequest("Request Invalido");
            }

        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var sample = await _sampleService.GetSample(id);

                if (sample != null)
                {
                    await _sampleService.DeleteSample(sample);

                    return Ok("Aluno Encontrado");
                }
                else
                {
                    return NotFound($"Aluno nao encontrados");
                }
            }
            catch
            {

                return BadRequest("Request Invalido");
            }

        }




    }
}
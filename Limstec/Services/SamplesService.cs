using LimsDetec.Data;
using LimsDetec.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Limstec.Services
{
    public class SamplesService : ISampleService
    {

        private readonly AppDbContext _context; 

        public SamplesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Sample>> GetSamples()
        {
            try
            {
                return await _context.Samples.AsNoTracking().ToListAsync();
            }
            catch 
            {

                throw;
            }
           
        }


        public async Task<IEnumerable<Sample>> GetSamplesByNome(string nome)
        {
            IEnumerable<Sample> samples;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                samples = await _context.Samples.Where(n => n.CodInterno.Contains(nome)).ToListAsync();
            }
            else
            {
                samples = await GetSamples();
            }

            return samples;
        }


        public async Task<Sample> GetSample(int id)
        {
           var sample = await _context.Samples.FindAsync(id);
            return sample;
        }

        public async Task CreateSample(Sample sample)
        {
            _context.Samples.Add(sample);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSample(Sample sample)
        {
            _context.Entry(sample).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSample(Sample sample)
        {
            _context.Samples.Remove(sample);
            await _context.SaveChangesAsync();
        }
    }
}

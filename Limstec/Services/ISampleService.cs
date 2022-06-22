using LimsDetec.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Limstec.Services
{
    public interface ISampleService
    {
        Task<IEnumerable<Sample>> GetSamples();
        Task<Sample> GetSample(int id);

        Task<IEnumerable<Sample>> GetSamplesByNome(string nome);

        Task CreateSample(Sample sample);
        Task UpdateSample(Sample sample);
        Task DeleteSample(Sample sample);
    }
}

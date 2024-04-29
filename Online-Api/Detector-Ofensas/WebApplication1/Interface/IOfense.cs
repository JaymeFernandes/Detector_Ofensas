using WebApplication1.Models;

namespace Detector_Ofensas.Api.Interface
{
    public interface IOfense
    {
        Task<List<Ofensa>> GetAll();

        Task<List<string>> ToCheck(string text);

        Task<double> CheckPercentage(string text);

        Task<bool> Add(string word, int value);

		Task<double> GetPercentage(string text);

	}
}
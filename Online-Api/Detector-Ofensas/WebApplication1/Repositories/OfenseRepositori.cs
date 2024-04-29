using Detector_Ofensas.Api.Interface;
using Detector_Ofensas.API;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace Detector_Ofensas.Api.Repositories
{
	public class OfenseRepository : IOfense
	{

		private readonly DetectorContext _context;

		public OfenseRepository(DetectorContext context)
		{
			_context = context;
		}


		public async Task<bool> Add(string word, int value)
		{
			if(word == null)  return false;

			bool exist = await _context.Ofensas.AnyAsync(x => x.SOfensa == word);

			if (exist) return false;

			await _context.Ofensas.AddAsync(new Ofensa { SOfensa = word, NNivel = value });

			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<double> CheckPercentage(string text)
		{
			var result = await RespectFilter.GetPercentage(text, _context.Ofensas.ToList());

			return result;
		}

		public async Task<List<Ofensa>> GetAll()
		{
			return _context.Ofensas.ToList();
		}

		public async Task<List<string>> ToCheck(string text)
		{
			var result = await RespectFilter.CheckText(text, _context.Ofensas.ToList());

			return result;
		}

		public async Task<double> GetPercentage(string text)
		{
			var result = await RespectFilter.GetPercentage(text, _context.Ofensas.ToList());

			return result;
		}
	}
}

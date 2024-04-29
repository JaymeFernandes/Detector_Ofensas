using Detector_Ofensas.Api.Interface;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace Detector_Ofensas.Api.Controllers
{
	public class RespectFilterController : Controller
	{
		private readonly IOfense _ofense;

		public RespectFilterController(IOfense ofense)
		{
			_ofense = ofense;
		}


		[HttpPost]
		[Route("[controller]/AddOfense")]
		public async Task<ActionResult<bool>> AddOfense(string word, int value)
		{
			if (word == null || value < 0 || value > 100)
			{
				throw new ArgumentNullException($"{nameof(word)} ou {nameof(value)} tem parametros invalidos o word não pode ser null e o value tem que ser um numero de 1 a 100");
			}

			var result = await _ofense.Add(word, value);

			return result;
		}

		[HttpGet]
		[Route("[controller]/GetAll")]
		public async Task<ActionResult<List<Ofensa>>> GetAll()
		{
			var result = await _ofense.GetAll();

			if(result == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(result);
			}
		}

		[HttpGet]
		[Route("[controller]/Check")]
		public async Task<ActionResult<List<string>>> CheckText(string text)
		{
			var result = await _ofense.ToCheck(text);

			if(result == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(result);
			}

		}

		[HttpGet]
		[Route("[controller]/GetPercentage")]
		public async Task<ActionResult<List<string>>> Percentage(string text)
		{
			var result = await _ofense.GetPercentage(text);

			if (result == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(result);
			}

		}
	}
}

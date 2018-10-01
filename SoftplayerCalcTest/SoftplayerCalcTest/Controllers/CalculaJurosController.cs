using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SoftplayerCalcTest.Controllers
{
	[Route("api/[controller]")]
	public class CalculaJurosController : ControllerBase
	{
		// GET api/values
		[HttpGet]
		public ActionResult<string> Get()
		{
			return "Olá";
		}

		[HttpGet, Route("/calculaJuros")]
		public ActionResult<decimal> GetCalculaJuros(double ValorInicial, int meses)
		{
			return Math.Round(Convert.ToDecimal(ValorInicial * Math.Pow(1.01, Convert.ToDouble(meses))),2, MidpointRounding.AwayFromZero);
		}

		[HttpGet, Route("/showmethecode")]
		public ActionResult<string> GetShowmeTheCode()
		{
			string repoPath = LibGit2Sharp.Repository.Discover(System.Environment.CurrentDirectory);
			var repository = new LibGit2Sharp.Repository(repoPath);
			var remote = repository.Network.Remotes.FirstOrDefault(r => r.Name == "origin");

			string remoteUrl = remote.Url;
			remoteUrl = Regex.Replace(remoteUrl, @"\.git$", "");

			// 2. Normalize git@ and https:git@ urls
			remoteUrl = Regex.Replace(remoteUrl, "^git@", "https://");
			remoteUrl = Regex.Replace(remoteUrl, "^https:git@", "https://");
			remoteUrl = Regex.Replace(remoteUrl, ".com:", ".com/");
			Uri remoteUri = new Uri(remoteUrl);
			return remoteUri.ToString();
		}
	}
}




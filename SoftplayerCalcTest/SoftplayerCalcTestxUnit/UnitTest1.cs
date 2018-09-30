using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SoftplayerCalcTest.Controllers;
using System;
using System.Net;
using System.Net.Http;
using Xunit;


namespace SoftplayerCalcTestxUnit
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{
			HttpClient _client = new HttpClient();

			CalculaJurosController Controller = new CalculaJurosController();
			decimal valor = Controller.GetCalculaJuros(100, 5).Value;
			decimal valorEsperado = Convert.ToDecimal(105.10);
			// Assert
			Assert.Equal<decimal>(valorEsperado, valor);

			valor = Controller.GetCalculaJuros(40, 7).Value;
			valorEsperado = Convert.ToDecimal(42.89);

			// Assert
			Assert.Equal<decimal>(valorEsperado, valor);

			valor = Controller.GetCalculaJuros(60, 3).Value;
			valorEsperado = Convert.ToDecimal(61.82);

			// Assert
			Assert.Equal<decimal>(valorEsperado, valor);
		}

	}
}


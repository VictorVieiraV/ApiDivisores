using Microsoft.AspNetCore.Mvc;

namespace Momento_mao_na_massa.Controllers
{
    [ApiController]
    [Route("api/CalculaDivisores")]
    public class Calculo : ControllerBase
    {
        // POST api/<Calculo>
        [HttpPost]
        [Route("{numero}")]
        public IActionResult Post(int numero = 1)
        {
            string DivisoresPrimos = "";
            string Divisores = "";

            for (int i = 1; i <= numero; i++)
            {
                var resultado = numero % i;

                if (resultado == 0)
                {
                    Divisores += (Divisores == "" ? "" : ", ") + i.ToString();
                    var quantDiv = 0;

                    for (int x = 1; x <= i; x++)
                    {
                        if (VerificaPrimo(i, x))
                        {
                            quantDiv++;
                        }
                    }
                    if (quantDiv == 2)
                    {
                        DivisoresPrimos += (DivisoresPrimos == "" ? "" : ", ") + i.ToString();
                    }
                }
            }
            return Ok($"Divisores: {Divisores} \nDivisores Primos: {DivisoresPrimos}");
        }

        public bool VerificaPrimo(int dividendo, int divisor)
        {
            if (dividendo % divisor == 0)
            {
                return true;
            }
            return false;
        } 
    }
}

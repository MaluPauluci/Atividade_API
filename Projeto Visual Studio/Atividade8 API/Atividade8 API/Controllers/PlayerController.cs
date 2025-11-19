using Atividade8_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Atividade8_API.Controllers
{
    public class PlayerController : Controller
    {
        public static List<Jogador> Jogadores = new()
        {
            new Jogador { id = 1, Vida = 20, QuantidadeDeItens = 3, PosicaoX = 0, PosicaoY = 0, PosicaoZ = 0 },
            new Jogador { id = 2, Vida = 20, QuantidadeDeItens = 3, PosicaoX = 1, PosicaoY = 1, PosicaoZ = 1 }
        };

        [HttpGet]
        [Route("api/jogador")]
        public IActionResult GetJogadores()
        {
            return Ok(Jogadores);
        }

        [HttpGet]
        [Route("api/jogador/id")]
        public IActionResult GetJogador(int id)
        {
            var jogador = Jogadores.FirstOrDefault(a => a.id == id);
            if (jogador == null)
            {
                return NotFound();
            }
            return Ok(jogador);
        }


        [HttpPost]
        [Route("api/jogador")]
        public IActionResult AddJogador([FromBody] Jogador novoJogador)
        {
            Jogadores.Add(novoJogador);
            return Ok(novoJogador);
        }
        [HttpPut]
        [Route("api/jogador/{id}")]
        public IActionResult UpdateJogador(int id, [FromBody] Jogador jogadorAtualizado)
        {
            var jogador = Jogadores.FirstOrDefault(a => a.id == id);
            if (jogador == null)
            {
                return NotFound();
            }
            jogador.Vida = jogadorAtualizado.Vida;
            jogador.QuantidadeDeItens = jogadorAtualizado.QuantidadeDeItens;
            jogador.PosicaoX = jogadorAtualizado.PosicaoX;
            jogador.PosicaoY = jogadorAtualizado.PosicaoY;
            jogador.PosicaoZ = jogadorAtualizado.PosicaoZ;
            return Ok(jogador);
        }
        [HttpDelete]
        [Route("api/jogador/{id}")]
        public IActionResult DeleteJogador(int id)
        {
            var jogador = Jogadores.FirstOrDefault(a => a.id == id);
            if (jogador == null)
            {
                return NotFound();
            }
            Jogadores.Remove(jogador);
            return Ok();
        }
    }
}

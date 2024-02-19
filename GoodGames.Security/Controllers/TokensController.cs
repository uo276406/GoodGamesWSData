using GoodGames.Security.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoodGames.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        // GET: api/Tokens/ASHYT656YT56
        [HttpGet("{token}")]
        public ActionResult<string> Get([FromRoute] string token)
        {
            try
            {
                var securityToken = JsonConvert.DeserializeObject<dynamic>(AESManager.Decrypt(token));
                if (securityToken == null)
                {
                    return NotFound();
                }
                else if (DateTime.Parse(securityToken.ExpirationDate.ToString()) > DateTime.Now)
                {
                    return Ok();
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception) { return BadRequest(); }
        }


        // POST: api/Tokens
        [HttpPost]
        public IActionResult Post([FromBody] dynamic tokenRequest)
        {
            try
            {
                var userName = JsonConvert.DeserializeObject<dynamic>(tokenRequest.ToString()).UserName.ToString();
                var token = AESManager.Encrypt(JsonConvert.SerializeObject(new { UserName = userName, ExpirationDate = DateTime.Now.AddDays(30) }));
                return CreatedAtAction("Get", new { token }, new { Token = token });
            }
            catch (Exception) { return BadRequest(); }
        }

    }
}

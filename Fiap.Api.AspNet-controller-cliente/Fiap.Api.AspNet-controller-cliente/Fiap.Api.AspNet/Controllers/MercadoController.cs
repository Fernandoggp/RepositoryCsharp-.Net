using Fiap.Api.AspNet.Repository.Context;
using Fiap.Api.AspNet.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

[Route("api/[controller]")]
[ApiController]
public class MercadoController : ControllerBase
{ 
    private readonly MercadoRepository mercadoRepository;

	public MercadoController(DataBaseContext context)
    {
        mercadoRepository = new MercadoRepository(context);
    }
    
    [HttpGet]
    public ActionResult<List<MercadoModel>> Get()
    {
        try
        {
            var lista = mercadoRepository.Listar();

            if (lista != null)
            {
                return Ok(lista);
            }
            else
            {
                return NotFound();
            }

        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
       
    }

    [HttpGet("{id:int}")]
    public ActionResult<MercadoModel> Get([FromRoute] int id)
    {
        try
        {
            var mercadoModel = mercadoRepository.Consultar(id);

            if (mercadoModel != null)
            {
                return Ok(mercadoModel);
            }
            else
            {
                return NotFound();
            }

        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost]
    public ActionResult<MercadoModel> Post([FromBody] MercadoModel mercadoModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            mercadoRepository.Inserir(mercadoModel);
            var location = new Uri(Request.GetEncodedUrl() + mercadoModel.MercadoId);
            return Created(location, mercadoModel);
        }
        catch (Exception error)
        {
            return BadRequest(new { message = $"Não foi possível inserir um novo mercado. Detalhes: {error.Message}" });
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<MercadoModel> Put([FromRoute] int id, [FromBody] MercadoModel MercadoModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (MercadoModel.MercadoId != id)
        {
            return NotFound();
        }


        try
        {
            mercadoRepository.Alterar(MercadoModel);
            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(new { message = $"Não foi possível alterar o mercado. Detalhes: {error.Message}" });
        }
    }


    [HttpDelete("{id:int}")]
    public ActionResult<MercadoModel> Delete([FromRoute] int id)
    {
        try
        {
            var mercadoModel = mercadoRepository.Consultar(id);

            if (mercadoModel != null)
            {
                mercadoRepository.Excluir(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception e)
        {
            return BadRequest();
        }
    }
}


using Fiap.Api.AspNet.Repository.Context;
using Fiap.Api.AspNet.Repository;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{

    private readonly ProdutoRepository produtoRepository; 

    public ProdutoController(DataBaseContext context)
	{
        produtoRepository = new ProdutoRepository(context);
    }

    [HttpGet]
    public ActionResult<List<ProdutoModel>> Get()
    {
        try
        {
            var lista = produtoRepository.Listar();

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
    public ActionResult<ProdutoModel> Get([FromRoute] int id)
    {
        try
        {
            var produtoModel = produtoRepository.Consultar(id);

            if (produtoModel != null)
            {
                return Ok(produtoModel);
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

    [HttpGet("{nome}")]
    public ActionResult<ProdutoModel> Get([FromRoute] string nome)
    {
        try
        {
            var produtoModel = produtoRepository.ConsultarPorPreco(nome);

            if (produtoModel != null)
            {
                return Ok(produtoModel);
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
    public ActionResult<ProdutoModel> Post([FromBody] ProdutoModel produtoModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            produtoRepository.Inserir(produtoModel);
            var location = new Uri(Request.GetEncodedUrl() + produtoModel.ProdutoId);
            return Created(location, produtoModel);
        }
        catch (Exception error)
        {
            return BadRequest(new { message = $"Não foi possível inserir novo produto. Detalhes: {error.Message}" });
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult<ProdutoModel> Put([FromRoute] int id, [FromBody] ProdutoModel produtoModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (produtoModel.ProdutoId != id)
        {
            return NotFound();
        }


        try
        {
            produtoRepository.Alterar(produtoModel);
            return NoContent();
        }
        catch (Exception error)
        {
            return BadRequest(new { message = $"Não foi possível alterar o produto. Detalhes: {error.Message}" });
        }
    }


    [HttpDelete("{id:int}")]
    public ActionResult<ProdutoModel> Delete([FromRoute] int id)
    {
        try
        {
            var produtoModel = produtoRepository.Consultar(id);

            if (produtoModel != null)
            {
                produtoRepository.Excluir(id);
                // Retorno Sucesso.
                // Efetuou a exclusão, porém sem necessidade de informar os dados.
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

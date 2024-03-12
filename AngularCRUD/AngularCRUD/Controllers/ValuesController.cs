using AngularCRUD.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AngularCRUD.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        AppDbContext context = new AppDbContext();

        [HttpGet]
        public IEnumerable<ProductEntity> GetAll()
        {
            return context.ProductEntities.ToList();
        }

        [HttpGet("{id}")]
        public ProductEntity GetById(int id)
        {
            return context.ProductEntities.FirstOrDefault(x => x.ID == id);
        }

        [HttpPost()]
        public IActionResult PostAddProduct([FromBody]ProductEntity entity)
        {
            if(entity is not null)
            {
                context.ProductEntities.Add(entity);
                context.SaveChanges();
                return Ok(entity);
            }

            return BadRequest();
        }

        [HttpPut()]
        public IActionResult PutProduct([FromBody]ProductEntity entity)
        {
            if(entity is not null)
            {
                ProductEntity updateEntity = context.ProductEntities.FirstOrDefault(x => x.ID == entity.ID);
                updateEntity.Name = entity.Name;
                updateEntity.Price = entity.Price;
                updateEntity.Description = entity.Description;
                updateEntity.IsStock = entity.IsStock;
                updateEntity.Stock = entity.Stock;

                context.Attach(updateEntity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();

                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            ProductEntity selectedEntity = context.ProductEntities.FirstOrDefault(x => x.ID == id);

            context.ProductEntities.Remove(selectedEntity);
            context.SaveChanges();
            return Ok();
        }

    }
}

using Api.Models;
using Api.Repositories.Data;
using Api.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Repository, Entity> : ControllerBase
        where Repository : class, IRepository<Entity, int>
        where Entity : class
    {
        Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            /*var data = repository.Get();
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has been retrieved",
                Data = data
            });*/
            try
            {
                var data = repository.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak ditemukan!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data has been retrieved!",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            /*var data = repository.GetById(id);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has been retrieved",
                Data = data
            });*/
            try
            {
                var data = repository.GetById(id);
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak ditemukan!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data has been retrieved!",
                        Data = data
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
        [HttpPost]
        public IActionResult Create(Entity entity)
        {
            /*var result = repository.Create(entity);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has been created",
            });*/
            try
            {
                var result = repository.Create(entity);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data gagal disimpan!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data has been created!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
        [HttpPut]
        public IActionResult Update(Entity entity)
        {
            /*var result = repository.Update(entity);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has been updated",
            });*/
            try
            {
                var result = repository.Update(entity);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data gagal diupdate!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data has been updated!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            /*var result = repository.Delete(id);
            return Ok(new
            {
                StatusCode = 200,
                Message = "Data has been deleted",
            });*/
            try
            {
                var result = repository.Delete(id);
                if (result == 0)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data gagal dihapus!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data has been deleted!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = ex.Message
                });
            }
        }
    }
}

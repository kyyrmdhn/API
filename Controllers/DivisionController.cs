using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionController : ControllerBase
    {
        private DivisionRepository divisionRepository;
        public DivisionController(DivisionRepository divisionRepository)
        {
            this.divisionRepository = divisionRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = divisionRepository.Get();
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
                        Message = "Data ditemukan!",
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
        public ActionResult GetById(int id)
        {
            try
            {
                var data = divisionRepository.GetById(id);
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
                        Message = "Data ditemukan!",
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
        public ActionResult Create(Division division)
        {
            try
            {
                var result = divisionRepository.Create(division);
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
                        Message = "Data berhasil disimpan!"
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
        public ActionResult Update(Division division)
        {
            try
            {
                var result = divisionRepository.Update(division);
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
                        Message = "Data berhasil diupdate!"
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
        public ActionResult Delete(int id)
        {
            try
            {
                var result = divisionRepository.Delete(id);
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
                        Message = "Data berhasil dihapus!"
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

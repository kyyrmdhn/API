using Api.Models;
using Api.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private DepartmentRepository departmentRepository;
        public DepartmentController(DepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }

        //StatusCode? 200/400/401/500
        //Message = data berhasil didapat dsb
        //Data/Output
        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                var data = departmentRepository.Get();
                if (data == null)
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data tidak ditemukan1"
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
                var data = departmentRepository.GetById(id);
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
        public ActionResult Create(Department department)
        {
            try
            {
                var result = departmentRepository.Create(department);
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
                        Message = "Data berhasil disimpan!",
                        Data = result
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
        public ActionResult Update(Department department)
        {
            try
            {
                var result = departmentRepository.Update(department);
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
                var result = departmentRepository.Delete(id);
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

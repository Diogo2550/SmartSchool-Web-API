using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool_WebAPI.Data;
using SmartSchool_WebAPI.Models;

namespace SmartSchool_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly IRepository _repository;

        public TeacherController(IRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var result = await _repository.GetAllTeachersAsync(false);

                return Ok(result);
            } catch (Exception ex) {
                return BadRequest(new { message = $"Error: {ex.Message}" });
            }
        }

        [HttpGet("{teacherId}")]
        public async Task<IActionResult> GetById(int teacherId) {
            try {
                var result = await _repository.GetTeacherAsyncById(teacherId, true);

                if(result == null) {
                    return NotFound(new { message = "Professor não encontrado!" });
                }

                return Ok(result);
            } catch(Exception ex) {
                return BadRequest(new { message = $"Error: {ex.Message}" });
            }
        }

        [HttpGet("ByStudent/{studentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId) {
            try {
                var result = await _repository.GetTeachersAsyncByStudentId(studentId, false);

                if(result == null) {
                    return NotFound(new { message = "Professores não encontrado!" });
                }

                return Ok(result);
            } catch(Exception ex) {
                return BadRequest(new { message = $"Error: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Teacher model) {
            try {
                _repository.Add(model);

                if(await _repository.SaveChangesAsync()) {
                    return Ok(model);
                }
            } catch(Exception ex) {
                return BadRequest(new { message = $"Error: {ex.Message}" });
            }

            return BadRequest();
        }

        [HttpPut("{teacherId}")]
        public async Task<IActionResult> Put(int teacherId, Teacher model) {
            try {
                var result = await _repository.GetTeacherAsyncById(teacherId, false);

                if(result == null) {
                    return NotFound(new { message = "Professores não encontrado!" });
                }

                _repository.Update(model);

                if(await _repository.SaveChangesAsync()) {
                    return Ok(result);
                }
            } catch(Exception ex) {
                return BadRequest(new { message = $"Error: {ex.Message}" });
            }

            return BadRequest();
        }

        [HttpDelete("{teacherId}")]
        public async Task<IActionResult> Delete(int teacherId) {
            try {
                var result = await _repository.GetTeacherAsyncById(teacherId, false);

                if(result == null) {
                    return NotFound(new { message = "Professores não encontrado!" });
                }

                _repository.Delete(result);

                if(await _repository.SaveChangesAsync()) {
                    return Ok(result);
                }
            } catch(Exception ex) {
                return BadRequest(new { message = $"Error: {ex.Message}" });
            }

            return BadRequest();
        }

    }
}
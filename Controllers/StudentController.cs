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
    public class StudentController : ControllerBase
    {

        private readonly IRepository _repository;

        public StudentController(IRepository repository) {
            _repository = repository;    
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            try {
                var result = await _repository.GetAllStudentsAsync(true);
                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{StudentId}")]
        public async Task<IActionResult> GetByStudentId(int studentId) {
            try {
                var result = await _repository.GetStudentAsyncById(studentId, true);
                return Ok(result);
            } catch(Exception ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("BySubject/{subjectId}")]
        public async Task<IActionResult> GetBySubjectId(int subjectId) {
            try {
                var result = await _repository.GetStudentsAsyncBySubjectId(subjectId, false);

                return Ok(result);
            } catch (Exception ex) {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Student model) {
            try {
                _repository.Add(model);

                if(await _repository.SaveChangesAsync()) {
                    return Ok($"Aluno adicionado com sucesso: {model}");
                }
            } catch(Exception ex) {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut("{studentId}")]
        public async Task<IActionResult> Put(int studentId, Student model) {
            try {
                var student = await _repository.GetStudentAsyncById(studentId, false);
                
                if(student == null) {
                    return NotFound("Studante não encontrado!");
                }

                _repository.Update(model);

                if(await _repository.SaveChangesAsync()) {
                    return Ok($"Aluno atualizado com sucesso: {model}");
                }
            } catch(Exception ex) {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> Delete(int studentId) {
            try {
                var student = await _repository.GetStudentAsyncById(studentId, false);

                if(student == null) {
                    return NotFound("Studante não encontrado!");
                }

                _repository.Delete(student);

                if(await _repository.SaveChangesAsync()) {
                    return Ok($"Aluno removido com sucesso: {student}");
                }
            } catch(Exception ex) {
                return BadRequest($"Error: {ex.Message}");
            }

            return BadRequest();
        }

    }
}
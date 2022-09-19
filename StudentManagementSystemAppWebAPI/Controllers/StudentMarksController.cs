using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManagementDomainLayer.Models;
using StudentManagementServiceLayer.Services;
using System;
using System.Threading.Tasks;

namespace StudentManagementSystemAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarksController : ControllerBase
    {
        private readonly IStudentMarksService _stuService;
        private readonly ILogger<StudentMarksController> _Logger;
        public StudentMarksController(IStudentMarksService appContext, ILogger<StudentMarksController> Logger)
        {
            _Logger = Logger;
            _stuService = appContext;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllStudentsMarks()
        {
            _Logger.LogInformation("student endpoint starts");
            var student = await _stuService.GetStudentMarksList();
            try
            {

                if (student == null) return NotFound();

                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
            return Ok(student);
        }

        [HttpPost(nameof(AddStudentMarksById))]
        public ActionResult AddStudentMarksById(StudentMarks stuMarks)
        {
            _Logger.LogInformation("student endpoint starts");
            try
            {

                _stuService.AddStudentMarks(stuMarks);

                _Logger.LogInformation("student endpoint completed");
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
            }
            return Ok("Student Marks Added");
        }


        [HttpGet]
        [Route("[action]")]
        public ActionResult SearchStudent(int stuid)
        {
            _Logger.LogInformation("student endpoint starts");
            StudentMarks stud;
            try
            {
                stud = _stuService.SearchStudentMarks(stuid);
                _Logger.LogInformation("student endpoint completed");
            }

            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest("Not Found");
            }
            return Ok(stud);
        }

        [HttpPut(nameof(UpdateStudentMarks))]
        public ActionResult UpdateStudentMarks(StudentMarks course)
        {
            _Logger.LogInformation("student endpoint starts");
            bool stu;
            try
            {
                stu = _stuService.UpdateStudent(course);
                _Logger.LogInformation("student endpoint completed");
                return Ok(stu);
            }
            catch(Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }


        [HttpDelete]

        [Route("[action]")]
        public IActionResult DeleteStudentByStuID(int stuid)
        {
            _Logger.LogInformation("student endpoint starts");

            try
            {

                var responseModel = _stuService.DeleteStudentMarks(stuid);
                if (responseModel == null) return NotFound();
                _Logger.LogInformation("student endpoint completed");

                return Ok(responseModel);
            }
            catch (Exception ex)
            {
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.Message);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex.InnerException);
                _Logger.LogError("exception occured;ExceptionDetail:" + ex);
                return BadRequest();
            }
        }
    }
}
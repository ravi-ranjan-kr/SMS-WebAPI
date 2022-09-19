using StudentManagementDomainLayer.Models;
using StudentManagementRepositoryLayer;
using StudentManagementServiceLayer.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementServiceLayer.Services
{
    public class StudentService : IStudentService
    {
        public ApplicationContext _appContext;
        public StudentService(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<IList<Student>> GetStudentList()
        {
            IList<Student> stud;

            try
            {
                await Task.Delay(1000);
                stud = _appContext.Set<Student>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return stud;
        }


        public Student SearchStudent(int stuId)
        {

            Student stud;

            try
            {
                stud = _appContext.Find<Student>(stuId);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return stud;
        }



        public ResponseModel DeleteStudent(int stuid)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                var stu = SearchStudent(stuid);
                _appContext.Remove<Student>(stu);

                _appContext.SaveChanges();
                model.ISuccess = true;
                model.Message = " Employee records removed succesfully";
            }

            catch (Exception ex)
            {
                model.ISuccess = false;
                model.Message = " Error:" + ex.Message;
            }
            return model;
        }


            public void AddStudent(Student stu)
        {
            _appContext.Add<Student>(stu);
            _appContext.SaveChanges();
        }


        public  bool EditStudent(Student stu)
        {
            var student = SearchStudent(stu.StudentID);

            if(student != null)
            {
                student.StudentCourse = stu.StudentCourse;
                _appContext.Update<Student>(stu);
            }
            
            if (_appContext.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
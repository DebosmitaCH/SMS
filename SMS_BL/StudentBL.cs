using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS_Exception;
using SMS_Entities;
using SMS_DAL;

namespace SMS_BL
{
    public class StudentBL
    {
        StudentDAO sDao = null;
        public StudentBL()
        {
            sDao = new StudentDAO();      
        }
        public bool ValidateAll()
        {
            return true;
        }
        public List<Student> ShowAllStudent()
        {
            return sDao.ShowAllStudent();

        }
        public List<Student> SearchStudentByID(int id)

        {
            return sDao.SearchStudentByID(id);
        }

        /// <summary>
        /// Method used to Add Students in underlying DB using DAO Layer Method
        /// </summary>
        /// <param name="s1">Object of Student Class</param>
        /// <returns></returns>
        public bool AddStudent(Student s1)
        {
            return sDao.AddStudent(s1);
        }
        public bool UpdateStudent(Student s1)
        {
            bool flag = false;

            if (ValidateAll())
            {
                flag= sDao.UpdateStudent(s1);
            }
            return flag;
        }
        public bool DropStudent(Student s1)
        {
            return sDao.DropStudent(s1);
        }
        public List<Student> DropDownList()
        {
            return sDao.ShowAllStudent();
        }
    }

}

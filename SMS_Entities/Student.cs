using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Entities
{
    public class Student
    {
        //for proper coding standard
        #region Variables
            int rollNo;
            string name;
            string addr;
         #endregion

        #region Properties
        public int RollNo { get => rollNo; set => rollNo = value; }
        public string Name { get => name; set => name = value; }
        public string Addr { get => addr; set => addr = value; }
        #endregion

        #region Constructors
        public Student()
        {

        }  //default constructor
        /// <summary>
        /// Param Constructor for Student Entity
        /// </summary>
        /// <param name="rno">Roll Number</param>
        /// <param name="nm">Name of the Candidate</param>
        /// <param name="adr">Permanent Address</param>
        public Student(int rno, string nm, string adr)  //parameterized constructor
        {
            rollNo = rno;
            name = nm;
            addr = adr;
                
        }
        #endregion


    }
}

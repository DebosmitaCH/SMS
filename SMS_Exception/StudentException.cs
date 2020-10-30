using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Exception
    //ghg
{
    /// <summary>
    ///   //CUSTOM EXCEPTION CLASS CREATED FOR STUDENT 
        //MANAGEMENT SYSTEM
    /// </summary>
    public class StudentException:ApplicationException //inherited an exception class
    {
        public StudentException()   //created a default construtor
        {

        }
        public StudentException(string errorMsg): base(errorMsg)
        {
          
        }
    }
}

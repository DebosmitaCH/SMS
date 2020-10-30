using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//ADDING REFERENCES

using System.Data;
using System.Data.SqlClient;
using SMS_Entities;
using SMS_Exception;


namespace SMS_DAL
{
    public class StudentDAO
    {
        //instance of classes
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;


        List<Student> myStudents = null;
        DataTable mydt = null;

        //DEFINING THE  DEFAULT CONSTRUCTOR
        public StudentDAO()
        {
            //INITIALIZE CONNECTION
            con = new SqlConnection();
            con.ConnectionString = "Server=.;Integrated Security=true;Database=SEP23DB";

        }
        public List<Student> ShowAllStudent()
        {
            
            try
            {
                con.Open();  //opened the connection
                cmd = new SqlCommand();  //initialized the command statement
                cmd.CommandText = "usp_ShowAllStudents";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                //RUN THE COMMAND
                sdr = cmd.ExecuteReader();
               

                //CREATING TEMPORARY TABLE
               mydt = new DataTable();
                mydt.Load(sdr);
                if(mydt.Rows.Count>0)
                {
                    myStudents = new List<Student>();
                    foreach(DataRow dr in mydt.Rows)
                    {
                       Student s1 = new Student();
                        s1.RollNo = Int32.Parse(dr[0].ToString());
                        s1.Name = dr[1].ToString();
                        s1.Addr = dr[2].ToString();
                        myStudents.Add(s1);

                    }
                }
               
                
            }
            catch (SqlException se)
            {
                throw new StudentException(se.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return myStudents;
        }
        public List<Student> SearchStudentByID(int id)
        {
            try
            {
               
                con.Open(); //opened the connnection
                cmd = new SqlCommand(); //initialized command statement

                //initialized parameters
                SqlParameter p1 = new SqlParameter("@rno", id);

                cmd.CommandText = "select * from Student where RollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;


                cmd.Parameters.Add(p1);


                sdr = cmd.ExecuteReader(); //run the command
                mydt = new DataTable();
                mydt.Load(sdr);
                if (mydt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow dr in mydt.Rows)
                    {
                        Student s1 = new Student();
                        s1.RollNo = Int32.Parse(dr[0].ToString());
                        s1.Name = dr[1].ToString();
                        s1.Addr = dr[2].ToString();
                        myStudents.Add(s1);

                    }
                }
            }
            catch (SqlException se)
            {
                throw new StudentException(se.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return myStudents;
        }
        public bool AddStudent(Student s1)
        {
            int reCount = 0;
            bool flag = false;
            try
            {
                //opening connection
                con.Open();

                //Initialize Command Parameter
                SqlParameter P1, P2, P3;

                P1 = new SqlParameter("@rno", s1.RollNo);
                P2 = new SqlParameter("@name", s1.Name);
                P3 = new SqlParameter("@addr", s1.Addr);

                //INITIALIZE COMMAND OBJECT
                cmd = new SqlCommand();
                cmd.CommandText = " Insert into Student(RollNo, Name, Address) values(@rno,@name,@addr)";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //ADDING PARAMETER TO COMMAND
                cmd.Parameters.Add(P1);
                cmd.Parameters.Add(P2);
                cmd.Parameters.Add(P3);

                //EXECUTE THE COMMAND
                reCount = cmd.ExecuteNonQuery();
                if(reCount>=1)
                {
                    flag = true;
                }
            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch(Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if(con.State==ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
         }
        public bool UpdateStudent(Student s1)
            {
            int reCount = 0;
            bool flag = false;
            try
            {
                //opening connection
                con.Open();

                //Initialize Command Parameter
                SqlParameter P1, P2, P3;

                P1 = new SqlParameter("@rno", s1.RollNo);
                P2 = new SqlParameter("@name", s1.Name);
                P3 = new SqlParameter("@addr", s1.Addr);

                //INITIALIZE COMMAND OBJECT
                cmd = new SqlCommand();
                cmd.CommandText = " Update Student set Name=@name, Address=@addr where RollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //ADDING PARAMETER TO COMMAND
                cmd.Parameters.Add(P1);
                cmd.Parameters.Add(P2);
                cmd.Parameters.Add(P3);

                //EXECUTE THE COMMAND
                reCount = cmd.ExecuteNonQuery();
                if (reCount >= 1)
                {
                    flag = true;
                }
            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;
        }
        public bool DropStudent(Student s1)
            {
            int reCount = 0;
            bool flag = false;
            try
            {
                //opening connection
                con.Open();

                //Initialize Command Parameter
                SqlParameter P1;

                P1 = new SqlParameter("@rno", s1.RollNo);
               

                //INITIALIZE COMMAND OBJECT
                cmd = new SqlCommand();
                cmd.CommandText = " Delete from Student where RollNo=@rno";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //ADDING PARAMETER TO COMMAND
                cmd.Parameters.Add(P1);
               

                //EXECUTE THE COMMAND
                reCount = cmd.ExecuteNonQuery();
                if (reCount >= 1)
                {
                    flag = true;
                }
            }
            catch (SqlException e)
            {
                throw new StudentException(e.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            return flag;

        }
        public List<Student> DropDownList()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "select Name from Student";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                //RUN THE COMMAND
                sdr = cmd.ExecuteReader();

                //CREATING TEMPORARY TABLE
                DataTable dt = new DataTable();
                dt.Load(sdr);
                if (dt.Rows.Count > 0)
                {
                    myStudents = new List<Student>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Student s1 = new Student();
                        s1.Name = dr[1].ToString();
                        myStudents.Add(s1);

                    }
                }
            }

            catch (SqlException se)
            {
                throw new StudentException(se.Message);
            }
            catch (Exception e)
            {
                throw new StudentException(e.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return myStudents;
        }

    }
}

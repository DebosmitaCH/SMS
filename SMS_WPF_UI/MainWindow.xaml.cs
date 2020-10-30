using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SMS_Entities;
using SMS_Exception;
using SMS_BL;


namespace SMS_WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StudentBL sbl = null;
        Student sObj = null;
        public MainWindow()
        {
            InitializeComponent();
            sbl = new StudentBL();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //INITIALIZE ENTITY OBJECT
                sObj = new Student();
                //ASSIGNING DATA TO sObj PROPERTIES
                sObj.RollNo = Convert.ToInt32(txtRollNo.Text);
                sObj.Name = txtName.Text;
                sObj.Addr = txtAddr.Text;

                //calling business layer
                bool res = sbl.AddStudent(sObj);
                if (res)
                {
                    System.Windows.Forms.MessageBox.Show(" Record Added Successfully ");
                }
            }
            catch(StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
            catch(Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }

        }

        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //INITIALIZE ENTITY OBJECT
                sObj = new Student();
                //ASSIGNING DATA TO sObj PROPERTIES
                sObj.RollNo = Convert.ToInt32(txtRollNo.Text);
                sObj.Name = txtName.Text;
                sObj.Addr = txtAddr.Text;

                //calling business layer
                bool res = sbl.UpdateStudent(sObj);
                if (res)
                {
                    System.Windows.Forms.MessageBox.Show(" Record Updated Successfully ");
                }
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }

        }
   

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
        try
        {
            //INITIALIZE ENTITY OBJECT
            sObj = new Student();
            //ASSIGNING DATA TO sObj PROPERTIES
            sObj.RollNo = Convert.ToInt32(txtRollNo.Text);
                sObj.Name = txtName.Text;
                sObj.Addr = txtAddr.Text;


                //calling business layer
                bool res = sbl.DropStudent(sObj);
            if (res)
            {
                System.Windows.Forms.MessageBox.Show(" Record Deleted Successfully ");
            }
        }
        catch (StudentException se)
        {
            System.Windows.Forms.MessageBox.Show(se.Message);
        }
        catch (Exception e1)
        {
            System.Windows.Forms.MessageBox.Show(e1.Message);
        }

    }



        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //INITIALIZE ENTITY OBJECT
                List<Student> myStudents;
                sObj = new Student();
                //ASSIGNING DATA TO sObj PROPERTIES
                sObj.RollNo = Convert.ToInt32(txtRollNo.Text);

                //calling business layer
                myStudents = sbl.SearchStudentByID(sObj.RollNo);
                dgStudent.ItemsSource = myStudents;
                System.Windows.Forms.MessageBox.Show(" Record Serached Successfully ");
               
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }

        }



        private void btnShowAllStudents_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //INITIALIZE ENTITY OBJECT
                List<Student> myStudents;
                myStudents = sbl.ShowAllStudent();

                //calling business layer
                dgStudent.ItemsSource = myStudents;  
                System.Windows.Forms.MessageBox.Show(" Record Shown Successfully ");
                
            }
            catch (StudentException se)
            {
                System.Windows.Forms.MessageBox.Show(se.Message);
            }
            catch (Exception e1)
            {
                System.Windows.Forms.MessageBox.Show(e1.Message);
            }

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            List<Student> myStudents;
            myStudents = sbl.DropDownList();
            ComboBox.DisplayMemberPath = "Name";
            ComboBox.ItemsSource = myStudents;

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgStudent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
   }


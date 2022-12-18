using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_pro_ds_semA
{
    class Student : IComparable<Student>
    {

        private string name;
        Node<Course> courses;




        public Student(string name, Node<Course> courses)
        {
            this.name = name;
            this.courses = courses;
        }
        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }


        public void SetCourses(Node<Course> courses)
        {
            this.courses = courses;
        }

        public Node<Course> GetCourses()
        {
            return this.courses;
        }



        public override string ToString()
        {
            string str = "Name: " + this.name + "\n " + this.courses ;
            return str;
        }





        public int CompareTo(Student obj)

        {
            return name.CompareTo(obj.name);

        }














    }
}

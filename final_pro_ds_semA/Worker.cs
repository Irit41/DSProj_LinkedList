using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_pro_ds_semA
{
    class Worker : IComparable<Worker>
    {

        private string name;
        private double salary;

        public Worker(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetSalary(double salary)
        {
            this.salary = salary;
        }

        public double GetSalary()
        {
            return this.salary;
        }

        public override string ToString()
        {
            string str = "Name: " + this.name + " Salary: " + this.salary;
            return str;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)//w1.Equals(null);
                return false;

            if (this == obj)//w1.Equals(w1);
                return true;

            if (!(obj is Worker))//w1.Equals("Irit");
                return false;

            Worker w1 = (Worker)obj;

            if (this.name == w1.name && this.salary == w1.salary)//w1.Equals(w2);
            {
                return true;
            }

            return false;
        }





        public int CompareTo(Worker obj)

        {
            return name.CompareTo(obj.name);

        }










    }
}

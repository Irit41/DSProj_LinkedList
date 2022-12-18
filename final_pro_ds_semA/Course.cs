using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_pro_ds_semA
{
    class Course
    {
        public ulong code;
        public byte mark;



        public Course(ulong code , byte mark)
        {
            this.code = code;
            this.mark = mark;
        }


        public void SetCode(ulong code)
        {
            this.code = code;
        }

        public ulong GetCode()
        {
            return this.code;
        }

        public void SetMark(byte mark)
        {
            this.mark = mark;
        }

        public byte GetMark()
        {
            return this.mark;
        }

        public override string ToString()
        {
            string str = "Course Code: " + this.code + " Mark: " + this.mark;
            return str;
        }




    }
}

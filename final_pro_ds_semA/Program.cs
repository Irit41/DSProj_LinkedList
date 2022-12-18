using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_pro_ds_semA
{
    class Program
    {
        public static LinkedList<T> LinkedListClone<T>(LinkedList<T> list)
        {
            if (list == null)
            {
                return list;
            }

            LinkedList<T> newList = new LinkedList<T>();

            Node<T> tempNode = list.GetHead();

            T value;

            while (tempNode != null)
            {
                value = tempNode.GetValue();
                newList.AddLast(value);
                tempNode = tempNode.GetNext();


            }

            return newList;



        }




        /* Returns true if linked lists
        a and b are identical,
        otherwise false */
        public static bool areIdentical<T>(LinkedList<T> firstList, LinkedList<T> secondList)
        {

            if (firstList.getCount() != secondList.getCount()) return false;

            Node<T> firstListNode = firstList.GetHead(), secondListNode = secondList.GetHead();
            while (firstListNode != null && secondListNode != null)
            {
                if (!firstListNode.GetValue().Equals(secondListNode.GetValue()))
                    return false;

                /* If we reach here, then a and b are not null
                and their data is same, so move to next nodes
                in both lists */
                firstListNode = firstListNode.GetNext();
                secondListNode = secondListNode.GetNext();
            }

            // If linked lists are identical,
            // then 'a' and 'b' must
            // be null at this point.
            return (firstListNode == null && secondListNode == null);
        }


        public static LinkedList<T> Merge<T>(LinkedList<T> firstList, LinkedList<T> secondList)
        {
            Node<T> firstListNode = firstList.GetHead();
            Node<T> secondListNode = secondList.GetHead();
            LinkedList<T> MergedList = new LinkedList<T>();
            while (firstListNode != null)
            {
                MergedList.AddLast(firstListNode.GetValue());
                firstListNode = firstListNode.GetNext();
            }
            while (secondListNode != null)
            {
                MergedList.AddLast(secondListNode.GetValue());
                secondListNode = secondListNode.GetNext();
            }

            return MergedList;
        }





        public static LinkedList<T> MergeLinkedListNoDuplicates<T>(LinkedList<T> firstList, LinkedList<T> secondList)
        {

            LinkedList<T> MergedListNoDuplicates = Merge(firstList, secondList);
            MergedListNoDuplicates.ListNoDuplicates();
            return MergedListNoDuplicates;


        }




        public static LinkedList<T> MergeLinkedListCommonNodesOnly<T>(LinkedList<T> firstList, LinkedList<T> secondList)
        {

            LinkedList<T> CommonNodesOnlyList = new LinkedList<T>();
            Node<T> tempNode = firstList.GetHead();
            T value;
            while (tempNode != null)
            {
                value = tempNode.GetValue();
                if (secondList.Contains(value))
                {
                    CommonNodesOnlyList.AddLast(value);
                }
                tempNode = tempNode.GetNext();
            }
            CommonNodesOnlyList.ListNoDuplicates();
            return CommonNodesOnlyList;

        }

        public static void PrintStudentAverage(LinkedList<Student> list)
        {
            Node<Student> studentsList = list.GetHead();
            Student student = null;
            int index = 1;
            while (studentsList != null)
            {
                student = studentsList.GetValue();
                Console.WriteLine("The average is " + calcAvg(student.GetCourses()) + " of student" + index);
                studentsList = studentsList.GetNext();
                index++;

            }




        }


        public static double calcAvg(Node<Course> courses)
        {
            int sum = 0;
            int index = 0;
            while (courses != null)
            {
                sum += courses.GetValue().mark;

                courses = courses.GetNext();
                index++;
            }

            return (double)sum / index;
        }


        ///// הפונקציה מקבלת רשימה שכל חוליה בה מכילה מערך של סטודנטים
        public static LinkedList<Student> ReturnExcellentStudents(LinkedList<Student[]> ClassesList)
        {
            Node<Student[]> tempClass = ClassesList.GetHead();
            LinkedList<Student> ExcellentStudentsList = new LinkedList<Student>();

            Student student = null;
            double max = 0;
            double studentAverage;



            while (tempClass != null)
            {
                Student[] students = tempClass.GetValue();

                for (int i = 0; i < students.Length; i++)
                {

                    studentAverage = calcAvg(students[i].GetCourses());
                    if (studentAverage > max)
                    {
                        max = studentAverage;
                        student = students[i];
                    }

                }
                // הוספה של הסטודנט המצטיין לרשימה המוחזרת
                ExcellentStudentsList.AddLast(student);
                tempClass = tempClass.GetNext();


            }

            return ExcellentStudentsList;


        }

        /// הפונקציה מקבלת מערך שכל איבר מכיל רשימה של סטודנטים
        public static Student[] ReturnFailStudents(LinkedList<Student>[] arrOfClassesList)
        {


            Student tempStudent;
            Student failStudent = null;
            Node<Student> studentsList;
            //כמות הסטודנטים הנכשלים ככמות הכיתות
            Student[] FailStudents = new Student[arrOfClassesList.Length] ;
            double studentAverage;

            double min;
          
            for (int i = 0; i < arrOfClassesList.Length; i++)
            {
                studentsList = arrOfClassesList[i].GetHead();
                min = 101;
                while (studentsList != null)
                {

                    tempStudent = studentsList.GetValue();
                    studentAverage = calcAvg(tempStudent.GetCourses());
                    if (studentAverage < min)
                    {
                        min = studentAverage;
                        failStudent = tempStudent;
                    }
                    studentsList = studentsList.GetNext();

                }

                // השמה של הסטונדט עם הציון הנמוך ביותר במערך נכשלים
                // אפשר להניח שיש סטודנט 1 שנכשל בכל כיתה ולכן בהכרח הוא יהיה הסטודנט עם הציון הנמוך ביותר
                FailStudents[i] = failStudent;
              



            }

            return FailStudents;


        }

        static void Main(string[] args)
        {


            Node<int> n1 = new Node<int>(10);
            Node<int> n2 = new Node<int>(30);
            Node<int> n3 = new Node<int>(5);
            n1.SetNext(n2);
            n2.SetNext(n3);



            LinkedList<int> linkedList = new LinkedList<int>(n1);

            linkedList.Sort();
            Console.WriteLine(linkedList);

            Console.WriteLine(linkedList);
            Console.WriteLine("-----------------------------------------");
            //Console.WriteLine(listOfWorkers.GetFirstNode());

            Console.WriteLine("first value in LinkedList : " + linkedList.GetFirst());





            //Console.WriteLine(listOfWorkers.GetFirstNode());

            Console.WriteLine("last value in LinkedList : " + linkedList.GetLast());

            Console.WriteLine("-----------------------------------------");





            Console.WriteLine(linkedList.getCount());
            Node<int> n4 = new Node<int>(4);
            linkedList.AddFirst(4);
            linkedList.AddFirst(88);

            Console.WriteLine(linkedList);

            linkedList.AddLast(6);
            Console.WriteLine(linkedList);
            Console.WriteLine(linkedList.Contains(20));

            Console.WriteLine(linkedList.GetValByIndex(3));




            Console.WriteLine(linkedList);
            linkedList.DeleteFirst();
            Console.WriteLine(linkedList);
            linkedList.DeleteLast();
            Console.WriteLine(linkedList);

            linkedList.DeleteFirst();
            Console.WriteLine(linkedList);
            linkedList.GetLast();

            LinkedList<int> linkedList2 = new LinkedList<int>(n1);



            linkedList2.AddLast(2);
            linkedList2.AddLast(6);
            linkedList2.AddLast(6);

            linkedList2.AddFirst(7);
            linkedList2.AddLast(5);
            linkedList2.AddLast(7);
            linkedList2.AddLast(7);
            linkedList2.AddLast(89);
            linkedList2.AddLast(23);
            linkedList2.AddLast(11);
            linkedList2.AddLast(7);
            linkedList2.AddLast(31);

            Console.WriteLine(linkedList2);
            Console.WriteLine("is contained ? " + linkedList2.Contains(3));
            Console.WriteLine("is contained ? " + linkedList2.Contains(2));
            linkedList2.ListNoDuplicates();
            Console.WriteLine(linkedList2);
            linkedList2.AddLast(77);
            Console.WriteLine(linkedList2);
            linkedList2.ReverseList();
            Console.WriteLine(linkedList2);
            LinkedList<int> linkedList3 = linkedList2;
            LinkedList<int> linkedList4 = new LinkedList<int>(LinkedListClone(linkedList2));
            linkedList4.AddLast(555);
            linkedList4.AddLast(555);
            linkedList4.AddLast(4);
            linkedList4.AddLast(1);
            linkedList4.AddLast(9);
            linkedList4.AddFirst(77);
            Console.WriteLine(linkedList3);
            Console.WriteLine(linkedList2);
            Console.WriteLine(linkedList4);
            linkedList2.ListNoDuplicates();
            // Console.WriteLine(linkedList2);
            Console.WriteLine(linkedList2);

            linkedList2.ReverseList();
            Console.WriteLine(linkedList2);
            linkedList2.AddLast(222);
            Console.WriteLine(LinkedListClone(linkedList2) == linkedList2);
            Console.WriteLine(linkedList3 == linkedList2);
            Console.WriteLine(linkedList4 == linkedList2);
            Console.WriteLine(linkedList2);

            Console.WriteLine(areIdentical(linkedList3, linkedList2));



            Console.WriteLine(Merge(linkedList2, linkedList3));

            Console.WriteLine(MergeLinkedListNoDuplicates(linkedList2, linkedList3));
            Console.WriteLine(MergeLinkedListCommonNodesOnly(linkedList2, linkedList3));





            Console.WriteLine("******************Worker******************");


            Node<Worker> w1 = new Node<Worker>(new Worker("Koro", 10000));
            Node<Worker> w2 = new Node<Worker>(new Worker("Maor", 11000));
            Node<Worker> w3 = new Node<Worker>(new Worker("Irit", 12000));
   
            w1.SetNext(w2);
            w2.SetNext(w3);
            LinkedList<Worker> listOfWorkers = new LinkedList<Worker>(w1);





            Worker w6 = new Worker("Jhon", 12);
            listOfWorkers.AddLast(w6);
            Console.WriteLine(listOfWorkers);
            Console.WriteLine(listOfWorkers.GetValByIndex(0));
            Console.WriteLine(listOfWorkers.Contains(new Worker("Kori", 10000)));






            Console.WriteLine("-----------------------------------------");
           

            Console.WriteLine(listOfWorkers.GetFirst());

            Console.WriteLine("-----------------------------------------");








            Console.WriteLine(listOfWorkers);
            Console.WriteLine(listOfWorkers.getCount());
            Worker w4 = new Worker("im worker", 50);
            listOfWorkers.AddFirst(w4);
            Console.WriteLine(listOfWorkers);
            listOfWorkers.DeleteFirst();
            Console.WriteLine(listOfWorkers);
            listOfWorkers.DeleteLast();
            Console.WriteLine(listOfWorkers);

            listOfWorkers.DeleteFirst();
            Console.WriteLine(listOfWorkers);


            Node<Worker> w10 = new Node<Worker>(new Worker("Kori", 10000));

            LinkedList<Worker> list2OfWorkers = new LinkedList<Worker>(w10);
            list2OfWorkers.AddLast(new Worker("Maor", 11000));
            list2OfWorkers.AddLast(new Worker("Irit", 12000));
            list2OfWorkers.AddLast(new Worker("Irit", 12000));
            list2OfWorkers.Sort();
            Console.WriteLine(list2OfWorkers);

           
            Console.WriteLine("Contains=" + list2OfWorkers.Contains(new Worker("Irit", 14000)));


            Course course = new Course(719, 74);

            Node<Course> course1 = new Node<Course>(new Course(789, 64));

            Node<Course> course2 = new Node<Course>(new Course(777, 81));
            Node<Course> course3 = new Node<Course>(new Course(1220, 96));
            Node<Course> course4 = new Node<Course>(new Course(8810, 67));

            course1.SetNext(course3);
            course2.SetNext(course3);
            course2.SetNext(course4);
            Node<Student> student1 = new Node<Student>(new Student("tami", course1));
            Student student2 = new Student("yarin", course2);
            Student student3 = new Student("noa", course4);
            Student student4 = new Student("yarin", course2);
            //student1.SetNext(student2);
            //student2.SetNext(student3);


            LinkedList<Student> listOfStudents = new LinkedList<Student>(student1);
            listOfStudents.AddLast(student2);
            listOfStudents.AddLast(student3);
            listOfStudents.AddLast(student4);

            listOfStudents.ListNoDuplicates();
            Console.WriteLine(listOfStudents);



            PrintStudentAverage(listOfStudents);



            Student[] studentsarr1 = { new Student("tomer", course4), new Student("lili", course1), new Student("gal", course3) };
            Student[] studentsarr2 = { new Student("noa", course1), new Student("eva", course3), new Student("gal", course2) };
            Student[] studentsarr3 = { new Student("rami", course2), new Student("yarin", course4), new Student("ben", course1) };

          Node<Student[]> arr1 = new Node<Student[]>(studentsarr1);




            LinkedList<Student[]> ClassesList = new LinkedList<Student[]>(arr1);
            ClassesList.AddLast(studentsarr2);
            ClassesList.AddLast(studentsarr3);


            LinkedList<Student> ExcellentStudents = ReturnExcellentStudents(ClassesList);
            Console.WriteLine(ExcellentStudents);


            Node<Student> s1 = new Node<Student>(new Student("noa", course1));

            LinkedList<Student> studentsList = new LinkedList<Student>(s1);
            studentsList.AddLast(new Student("eva", course3));

            studentsList.AddLast(new Student("gal", course2));

            LinkedList<Student>[] arrOfClassesList = new LinkedList<Student>[] { studentsList, listOfStudents };
            foreach (LinkedList<Student> student in arrOfClassesList)
            {
                Console.WriteLine(student);
            }




            Student[] FailStudents = ReturnFailStudents(arrOfClassesList);
            foreach (Student FailStudent in FailStudents)
            {
                Console.WriteLine(FailStudent);
            }








        }
    }
}







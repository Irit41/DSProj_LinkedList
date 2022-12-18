using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_pro_ds_semA
{
    class LinkedList<T>
    {

        private Node<T> head;
        private int listCount;
        public LinkedList() { }

        public LinkedList(Node<T> value)
        {
            this.head = value;
        }
        public LinkedList(LinkedList<T> list)
        {
            this.head = list.head;
        }



        public int getCount()
        {
            Node<T> temp = head;
            int count = 0;
            while (temp != null)
            {
                count++;
                temp = temp.GetNext();
            }
            return count;
        }


        public int ListCount
        {
            get => listCount;
            set => listCount = getCount();
        }

        public override string ToString()
        {

            Node<T> temp = head;
            if (temp.GetNext() == null) return temp.GetValue() + " ";

            return temp.GetValue() + " --> " + temp.GetNext();
        }




        public Node<T> AddFirst(T value)
        {

            Node<T> newNode = new Node<T>(value);
            newNode.SetNext(head);
            head = newNode;
            return head;//list is sent by value so we need to return it or to get it by reference
        }


        public Node<T> DeleteFirst()
        {
            Node<T> list = head;
            if (list == null)
                return list;


            head = head.GetNext();
            list.SetNext(null);
            return list;//list is sent by value so we need to return it or to get it by reference
        }

        public Node<T> DeleteLast()
        {
            Node<T> list = head;
            if (list == null || !list.HasNext())
            {
                return null;
            }

            Node<T> lastNode = list;
            Node<T> prevNode = null;
            while (lastNode.HasNext())
            {
                prevNode = lastNode;
                lastNode = lastNode.GetNext();
            }

            prevNode.SetNext(null);
            return list;
        }




        public T GetFirst()
        {
            return this.head.GetValue();
        }


        public T GetLast()
        {
            Node<T> tempNode = head;
            while (tempNode.HasNext())
            {
                tempNode = tempNode.GetNext();
            }
            return tempNode.GetValue();

        }


        public T GetValByIndex(byte index)
        {
            //if list is empty, return with null

            Node<T> current = head;
            int count = 0; /* index of Node we are
                        currently looking at */
            while (current != null)
            {
                if (count == index)
                    return current.GetValue();
                count++;
                current = current.GetNext();
            }

            return default;
        }





        public void ListNoDuplicates()
        {
            if (this.head == null)
            {
                return;
            }

            LinkedList<T> newListNoDuplicates = new LinkedList<T>();
            Node<T> temp = head;
            T value;

            while (temp != null)
            {
                value = temp.GetValue();
                if (!newListNoDuplicates.Contains(value))
                {
                    newListNoDuplicates.AddLast(value);
                }
                temp = temp.GetNext();
            }

            head = newListNoDuplicates.GetHead();







        }






        public void Sort()
        {


            if (this.head == null)
            {
                return;
            }

            IComparable<T> currentValue;
            Node<T> currentNode = head;
            Node<T> nextNode;
            T temp;
            while (currentNode != null)
            {
                //// השמה של החוליה הבאה 
                nextNode = currentNode.GetNext();
               
                while (nextNode != null)
                {//עושה קאסטינג לערך של החוליה הנוכחית
                    currentValue = (IComparable<T>)currentNode.GetValue();
                    ///אם החוליה הנוכחית "גדולה" מהבאה בתור
                    if (currentValue.CompareTo(nextNode.GetValue()) == 1)


                    ///// תהליך החלפה

                    {/// שמירה של הערך במשתנה
                        temp = currentNode.GetValue();
                        // השמה של הערך של החוליה הבאה לערך של הנוכחית
                        currentNode.SetValue(nextNode.GetValue());
                        // השמה של הערך של הוליה הנוכחית ששמרתי בטמפ בערך של החוליה הבאה 
                        nextNode.SetValue(temp);
                    }
                    nextNode = nextNode.GetNext();
                }
                //קידום של הנוד הראשי
                currentNode = currentNode.GetNext();

            }











        }











        public void AddLast(T value)
        {
            //create a new node
            Node<T> newNode = new Node<T>(value);


            //if head is NULL, it is an empty list
            if (head == null)
                head = newNode;
            //Otherwise, find the last node and add the newNode
            else
            {
                Node<T> lastNode = head;


                //last node's next address will be NULL.
                while (lastNode.HasNext())
                {
                    lastNode = lastNode.GetNext();
                }

                //add the newNode at the end of the linked list
                lastNode.SetNext(newNode);


            }

        }








        public bool Contains(T value)
        {
            Node<T> list = head;
            while (list != null)
            {
                if (list.GetValue().Equals(value))
                {
                    return true;
                }
                list = list.GetNext();
            }

            return false;
        }





        public Node<T> GetNextNode()
        {
            return head.GetNext();
        }

        public bool HasNext()
        {
            return this.head != null;
        }

        public void SetHead(Node<T> value)
        {
            this.head = value;
        }

        public Node<T> GetHead()
        {
            return this.head;
        }


        public void ReverseList()
        {

            Node<T> prev = null, current = head, next;
            while (current != null)
            {//כל פעם מבצעים השמה למשתנה נקסט לנקסט של החולי הנוכחית
                /// ומנתקים אותה 
                next = current.GetNext();
                current.SetNext(prev);///---> null
                prev = current;
                current = next;

            }
            head = prev;
        }













    }
}
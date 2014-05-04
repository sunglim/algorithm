using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace counting_inversion
{
    class Program
    {
        public int InversionCounting  = 0;
        private int[] unordered;
        public Program(int[] list)
        {
            unordered = list;
        }
        public void MergeSort(int from, int to) {
            if ( (to - from) > 0) {
                Console.WriteLine("FROM: " + from + "  TO: " + to);
                List<int> tempList = new List<int>();

                int mid = (to + from) / 2;
                MergeSort(from, mid);
                MergeSort(mid + 1, to);

                int leftPivot = from;
                int rightPivot = mid + 1;
                while (leftPivot < mid+1 && rightPivot < to +1)
                {
                    if (unordered[leftPivot] < unordered[rightPivot])
                    {
                        tempList.Add(unordered[leftPivot++]);
                    }
                    else
                    {
                        this.InversionCounting += (mid - (leftPivot-1));
                        tempList.Add(unordered[rightPivot++]);
                    }
                }
                while((leftPivot < mid+1))
                {
                    tempList.Add(unordered[leftPivot++]);
                }
                while (rightPivot < to + 1)
                {
                    tempList.Add(unordered[rightPivot++]);
                }
                int index = from;
                foreach(int i in tempList) {
                    unordered[index++] = i;
                }
            }
        }
        public void Print()
        {
            foreach (int ni in unordered)
            {
                Console.WriteLine(ni);
            }
        }

        static void Main(string[] args)
        {
            List<int> mylist = new List<int>();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("IntegerArray.txt");
            //System.IO.StreamReader file = new System.IO.StreamReader("small.txt");
            while ((line = file.ReadLine()) != null) {
                mylist.Add(Convert.ToInt32(line.Trim()));
            }
            file.Close();
            
            Program program = new Program(mylist.ToArray<int>());
            program.MergeSort(0, mylist.Count -1 /*index*/);
            program.Print();

            Console.WriteLine("Inversion Count : " + program.InversionCounting);
        }
    }
}

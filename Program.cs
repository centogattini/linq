using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
//Кабанов Степан. 109 группа. Домашнее задание на тему "LINQ"
namespace Linqt
{
    class Program
    {
        static void Main(string[] args)
        {
            //N_1();
            //N_2();
            //N_3();
            //N_4();
            //N_5();
            //N_7();
            //N_8();
            N_10();
        }
        private static void N_1()
        {
            int[] arr = new int[] { 0, 0, 0, 1, 2, 3, 4, 5, 5, 6, 7, 8, 9, 10 };
            IEnumerable<int> inx = Enumerable.Range(0, arr.Length);
            var d = arr.Distinct();
            var nn = from num in d
                     where num % 2 != 0 select num;
            foreach(int a in nn)
            {
                Console.Write(a.ToString() + ' ');
            }
            Console.WriteLine();
        }
        private static void N_2()
        {
            int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 12, 13 };
            var ans = from num in arr where num / 10 >= 1 select num;
            ans = ans.OrderBy(a => a);
            foreach(int a in ans)
            {
                Console.WriteLine(a);
            }
        }
        private static void N_3()
        {
            List<String> lst = new List<String>() {"ABBA", "GABBQ", "ARFE", "AWER","PAI" };
            var srt = lst.OrderBy(a => a.Length);

            var lenl = from s in srt select s.Length;
            lenl = lenl.Distinct();
            List<String> ans = new List<String>();
            foreach(int a in lenl)
            {
                var butch = from s in srt where s.Length == a select s;
                butch = butch.OrderByDescending(a => a.ToString());
                foreach(String s in butch)
                {
                    Console.WriteLine(s);
                }
            }
        }
        private static void N_4()
        {
            List<String> lst = new List<String>() { "ABBA", "GABBQ", "ARFE", "AWER", "PAI" };
            var cl = from s in lst select s[0];
            cl = cl.Reverse();
            foreach (char s in cl)
            {
                Console.Write(s);
            }
        }
        private static void N_5()
        {
            List<int> arr = new List<int>() { 0, 1, -2, 3, 4, -5, -6, 7, -8, -9, 10, 11, 12};
            var nn = from n in arr where n > 0 select n % 10;
            nn = nn.Distinct();
            foreach(int n in nn)
            {
                Console.WriteLine(n);
            }
        }
        private static void N_6()
        {
            int[] arr = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            IEnumerable<int> indx = Enumerable.Range(0, arr.Length);
            var nn = from ind in indx
                     where ind % 3 == 1 || ind % 3 == 2
                     select ind % 3 == 2 ? arr[ind] : 2 * arr[ind];
            foreach (int n in nn)
            {
                Console.Write(n);
                Console.Write(" ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
        private static void N_7()
        {
            int k1 = 5;
            int k2 = 10;
            int[] arr_a = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            int[] arr_b = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
            var ans_a = from n in arr_a where n > k1 select n;
            var ans_b = from n in arr_b where n < k2 select n;
            var ans = ans_a.Concat(ans_b).OrderBy(a => a);
            foreach (int a in ans)
            {
                Console.WriteLine(a);
            }
        }
        private static void N_8()
        {
            int[] numA = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int[] numB = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            foreach(int n in numA)
            {
                var modn = from m in numB where m % 10 == n % 10 select m;
                String a = "";
                foreach (int m in modn)
                {
                    a += n.ToString() + "-" + m.ToString() + " ";
                }
                Console.Write(a);
            }
        }
        private static void N_9()
        {
            int[] A = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            int[] B = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
            var N = from n in A from m in B select n+m;
            N = N.OrderBy(n => n);
            foreach(int n in N)
            {
                Console.Write(n + " ");
            }
        }

        private class Client : IComparable, IEquatable<Client>
        {
            Random r = new Random();
            int code;
            int year;
            int mounth;
            int duration;
            public Client()
            {
                code = r.Next(0, 1000);
                year = r.Next(1900, 2005);
                mounth = r.Next(0, 12);
                duration = r.Next(1, 6);
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                Client other = obj as Client;
                if (other != null)
                    return this.duration.CompareTo(other.duration);
                else
                    throw new ArgumentException("Object is not a Client");
            }

            public bool Equals([AllowNull] Client obj)
            {
                if (obj == null) return false;
                Client objAsPart = obj as Client;
                if (objAsPart == null) return false;
                else return Equals(objAsPart);
            }

            public override string ToString()
            {
                return "code: " + this.code + " year: " + this.year + " mounth: " + this.mounth + " duration: " + this.duration;
            }
        }
        private static void N_10()
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < 10; i++)
            {
                clients.Add(new Client());
            }
            clients.Sort();
            Console.WriteLine(clients[0]);
        }
    }
}

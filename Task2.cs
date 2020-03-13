using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Student
    {
        public string name;
        public int age;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
    }
   public class Program
    {
       public static void Main(string[] args)
        {
            

            
		   //1) Написать функцию поиска n-члена последовательности Фибоначи.
		   //0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765...
		      
		   
		     Console.WriteLine("Функция, которая ищет n-й член последовательности Фибоначи:");
             Console.WriteLine("Введите число:");
             int j = Convert.ToInt32(Console.ReadLine());
             int[] mas = new int[j];
			 if(j==1)
		      Console.WriteLine("Значение 1-го члена последовательности Фибоначи 0");
		      else if(j==2)
		      Console.WriteLine("Значение 2-го члена последовательности Фибоначи 1");
		      else 
			  {
             mas[0] = 0;
             mas[1] = 1;
             
             for (int i = 2; i < j; i++)
             {
                 mas[i] = mas[i - 1] + mas[i - 2];
             }
             Console.WriteLine("Значение {0} члена последовательности Фибоначи: {1}",j,mas[j-1]);
			  }
             Console.WriteLine("--------------\n");
             
		   
		   
		    //2)Написать функцию вычисления факториала для n.

            Console.WriteLine("Функция вычисляет факториал для введенного числа.");
            Console.WriteLine("Введите число, факториал которого необходимо вычислить.");
            int k = Convert.ToInt32(Console.ReadLine());
            int factorial =1;
            for (int n = 1; n <= k; n++)
                factorial = factorial * n;
            Console.WriteLine("Факториал числа {0} равен: {1}",k,factorial);
            Console.WriteLine("--------------\n");
            
        
              //3)Придумать модель с перичеслением, наполнить какую-либо коллекцию этими моделями с различными данными
			  //и сгрупировать с помощью LINQ;	
		  
		   List<Student> group34 = new List<Student>()
            {
                new Student("Vasja",18),
                new Student("Igor",22),
                new Student("Lena",23),
                new Student("Masha",25),
                new Student("Lera",20),
                new Student("Vova",21),
                new Student("Ivan",19),
                new Student("Ignat",20),
                new Student("Irina",20)
            };
		   
		    Console.WriteLine("Запрос выбирает всех студентов у которых имя начинается на 'I' и сортирует по возрасту");

            List<Student> someStudents1 =( from t in group34
                                         where t.name[0]=='I'
                                         orderby t.age
                                         select t).ToList();

            foreach (Student i in someStudents1)
                Console.WriteLine(i.age + ","+ i.name);
            Console.WriteLine("-----------");
		   
            Console.WriteLine("Запрос выбирает всех студентов старше 20 и чье имя состоит из четырех букв, сортирует по именам.");
		   
            List<Student> someStudents2 = group34.Where(t=>t.age>20 && t.name.Length==4).OrderBy(t=>t.name).ToList();

            foreach (Student i in someStudents2)
                Console.WriteLine(i.age + "," + i.name);
            Console.WriteLine("-----------");
		   
           Console.WriteLine("Запрос выбирает всех студентов чьи имена содержат букву 'a' и сортирует по возрасту."); 
		   
            Student[] someStudents3 = group34.Where(t => t.name.Contains("a")).OrderBy(t=>t.age).ToArray();

            foreach (Student i in someStudents3)
                Console.WriteLine(i.age + "," + i.name);
		   
		   Console.WriteLine("--------------\n");
		   
		   
		   //4)Сгрупировать массив чисел по четности (разделить на две группы- четные и нечетные).
		   
		   int[] numbers={0,-21,11,17,22,-5,8,14,17,19,-22,13,33,1,5,7,14,17}; 
		   Console.Write("Исходный массив:");
		   foreach (var i in numbers)
                Console.Write(i + ",");
		   Console.WriteLine("\n");
		   
		   Console.Write("Массив с четными числами: ");
		   IEnumerable<int> num1 = from i in numbers
                                   where i % 2 == 0
                                   select i;
            foreach (var i in num1)
                Console.Write(i + ",");
		        Console.WriteLine("\n");
		   
		    Console.Write("Массив с нечетными числами: ");
		   IEnumerable<int> num2 = from i in numbers
                                   where i % 2 != 0
                                   select i;
            foreach (var i in num2)
                Console.Write(i + ",");
		  


            Console.ReadLine();
        }
    }
}

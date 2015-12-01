using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            // F1();
            // F2();
            F3();
        }

        static void F1()
        {
            int i;
            double d;
            object obj;

            obj = 125;
            i = (int)obj;
            // d = (double)obj; // Это приведение терпит компилятор/
            // Но при выполнении приложения возникает исключение, недопустимое приведение

            d = (double)((int)obj);
            obj = 3.14;

            d = (double)obj;
            i = (int)((double)obj);
        }

        static void F2()
        {
            var v00 = 125;
            // var v0; // Неявно типизированная локальняа переменная var должна быть явным образом проинициализирована
            var v0 = new Int32(); // Неявно типизированная локальная переменная var проинициализирована объектом типа Int(32). По умолчанию ему присваивается значение 0

            Console.WriteLine("the type of v0 is: {0}, value is: {1}", v0.GetType(), v0);
            var v1 = 125; Console.WriteLine("the type of v1 is: {0}, value is: {1}", v1.GetType(), v1);
            var v2 = new float(); Console.WriteLine("the type of v2 is: {0}, value is: {1}", v2.GetType(), v2);
            var v3 = Math.PI; Console.WriteLine("the type of v3 is: {0}, value is: {1}", v3.GetType(), v3);
            var v4 = "qwerty"; Console.WriteLine("the type of v4 is: {0}, value is: {1}", v4.GetType(), v4);
            // Объявление массива также требует явной инициализации
            var v5 = new int[] { }; // Пустой целочисленный массив
            Console.WriteLine("the type of v5 is: {0}", v5.GetType());
            var v6 = new int[] { 1, 2, 3, 4, 5 }; // Целочисленный массив с набором значений.
            Console.WriteLine("the type of v6 is: {0}", v6.GetType());
            var v7 = new[] { 1.1, 2.2, 3.3, 4.4 }; // Массив типа double с набором значений
            Console.WriteLine("the type of v7 is: {0}", v7.GetType());

            // Переменная типа var - применение в цикле
            for(var v = 0; v < 10; v++)
            {
                Console.WriteLine(v);
            }

            // Неявно типизированные даныне var возможны только для локальных переменных методах и свойствах.
            // Переменные var не могут использоваться в качестве возвращаемого значения, параметра метода или члена класса/структуры.
        }

        // Анонимные классы/ Приведение/
        static void F3()
        {
            var v0 = 125;
            var v1 = new { x = 0.0, y = 0.0 }; // Анонимный класс/ Тип объекта определяет
            Console.WriteLine("the type of v1 is: {0}, value is: {1}", v1.GetType(), v1);

            // v1.x = Math.PI; // Доступ к полю объекта-представителя анонимного класса для изменения значения невозможен. Поле открыто только для чтения/
            // v1 = "qwerty"; // Присовение значений других типов недопустимо.
            v1 = new { x = Math.PI, y = 0.0 }; // Изменение значений полей возможно только при создании нового объекта.
            v1 = new { x = Math.PI, y = Math.E };

            double x = 0, y = 0, z = 0;
            var v2 = new { x, y, z, name = "qwerty" }; // Анонимный класс. Объявлен именемами проиницилизированных переменных/ и парой имя поля-значение.
            Console.WriteLine("the type of v2 is: {0}, value is: {1}", v2.GetType(), v2);

            // v3 и v4 являются переменными одного и того же анонимного типа.
            var v3 = new { name = "Spectra", power = 125 };
            var v4 = new { name = "Condor", power = 35 };

            if(Type.Equals(v3.GetType(), v4.GetType()))
            {
                Console.WriteLine("{0} is equivalent to {1}", v3.GetType(), v4.GetType());
            }
            else
            {
                Console.WriteLine("{0} is NOT equivalent to {1}", v3.GetType(), v4.GetType());
            }

            v3 = v4;
            Console.WriteLine("the type of v3 is: {0}, value is: {1}", v3.GetType(), v3);

            // var v5 = new { v3.name, v4.name }; // Анонимный тип не может содержать несколько свойств с одинаковым именем
            var v5 = new { v3.name, v4.power };

            // Взаимодействие с классами (Point2D, Point3D).
            Point2D p2d = new Point2D(0, 0);
            // Присвоение значения посредством неявного приведения типа.
            v0 = p2d; // Транслятор по присвоенному значению (неявно) определил тип переменной v0.

            // Определена как ссылка на объект-представитель класса массив типа double
            var v6 = new double[] { };
            /*  Инициализация массивом значенй, которые получаются при неявном привидении объекта Point2D.
                Важно? что соответсвующий оператор implicit должен быть к этому моменту определ>н в классе Point2D. 
            */
            v6 = p2d;

            // v1 представляет анонимный класс с полями x и y.
            // Мы имеем объект p2d. Можно ли изменить значения полей в v1 (конечно, создавая новый объект v1)
            // v1 = new { v1.x, v1.y }; // Так можно, но не интересно.
            // v1 = new { v1.x * 10, v1.y };// Так нельзя. Инициализатор должен быть либо простым именем, либо 
            v1 = new { x = v1.x * 10, v1.y }; // Member access expression
            // v1 = new { p2d.X, v1.y };// Попытка присвоения нового значения объекту v1 - представителю анонимного класса. Проблема в несоответсвии имён полей (и свойств в классе Point2D).
            // Возможные решения:
            // 1. Явно указать имя поля объекта v1. То есть сделать member access expression
            v1 = new { x = p2d.X, v1.y };
            // 2. Объявить поле x в классе Point2D public
            v1 = new { p2d.x, v1.y };
            // 3. Объявить новый анонимный класс с названиями полей, соответсвующих названиям свойств класса Point2D
            var v7 = new { X = 0.0, Y = 0.0 };
            v7 = new { p2d.X, v7.Y };

            var v8 = new { v0, v7.Y };
        }

        // Статическая и динамическая типизация
        static void F4()
        {

        }

        static void F5()
        {

        }
    }
}

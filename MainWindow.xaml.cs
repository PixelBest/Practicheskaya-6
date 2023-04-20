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
using System.Xml.Serialization;
using System.IO;
using System.Linq.Expressions;
using System.Data;
using System.Xml;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;

namespace Practicheskaya_6
{
    public partial class MainWindow : Window
    {
        string path = Directory.GetCurrentDirectory();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> employee = new List<Employee>();//создание работников
            for(int i = 0; i < 200; i++)
            {
                employee.Add(new Employee(i + 1));
            }

            XmlSerializer xml = new XmlSerializer(typeof(List<Employee>));//указание типа

            FileStream fs = new FileStream($@"{path}/depart1.xml", FileMode.OpenOrCreate);//указание пути до xml файла
            xml.Serialize(fs, employee);//сериализация
            fs.Close();

            MessageBox.Show("Файл xml создан", "Успех", MessageBoxButton.OK);
        }

        private void doubleClick1(object sender, RoutedEventArgs e) { DepartNum(4); }//вызов класса по поиску нужных работников двойным кликом
        private void doubleClick2(object sender, RoutedEventArgs e) { DepartNum(5); }
        private void doubleClick3(object sender, RoutedEventArgs e) { DepartNum(6); }
        private void doubleClick4(object sender, RoutedEventArgs e) { DepartNum(7); }
        private void doubleClick5(object sender, RoutedEventArgs e) { DepartNum(8); }
        private void doubleClick6(object sender, RoutedEventArgs e) { DepartNum(9); }
        private void doubleClick7(object sender, RoutedEventArgs e) { DepartNum(10); }
        private void doubleClick8(object sender, RoutedEventArgs e) { DepartNum(11); }
        private void doubleClick9(object sender, RoutedEventArgs e) { DepartNum(12); }
        private void DepartNum(int a)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Employee[]));//Указание типа
            FileStream fs = new FileStream($@"{path}/depart1.xml", FileMode.OpenOrCreate);//указание пути до xml файла

            Employee[] emp1 = xml.Deserialize(fs) as Employee[];//создание массива для всех работников
            List<Employee> test = new List<Employee>();
            foreach (Employee emp in emp1)//запись всех работников в List
            {
                if (emp.NumDep == a)//проверка нужного отдела
                    test.Add(emp);//добавление каждого работника в List
            }
            dataGrid1.ItemsSource = test;//вывод данных в dataGried
            fs.Close();//закрытие файлового потока
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)//выводит работников с нужным номером отдела
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Employee>));//Указание типа
            FileStream fs = new FileStream($@"{path}/depart1.xml", FileMode.OpenOrCreate);//указание пути до xml файла

            List<Employee> emp1 = xml.Deserialize(fs) as List<Employee>;//создание массива для всех работников
            List<Employee> test = new List<Employee>();
            foreach (Employee emp in emp1)//запись всех работников в List
                    test.Add(emp);//добавление каждого работника в List
            dataGrid1.ItemsSource = test;//вывод данных в dataGried
            fs.Close();//закрытие файлового потока
        }

        private void RaiseSalary_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.ShowDialog();
        }
    }
    public class Employee//создание класса работника
    {
        static Random rnd = new Random();
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int NumDep { get; set; }
        public int Salary { get; set; }
        public Employee() { }
        public Employee(string name, int age, string position, int numDep, int salary)
        {
            if (name == "1")
                Name = "Начальник Начальниковов Начальникович" + rnd.Next(1,1000);
            else if (name == "2")
                Name = "Работник Работников Работникович" + rnd.Next(1, 1000);
            else if(name == "3")
                Name = "Интерн Интернов Интернович" + rnd.Next(1, 1000);

            Age = age;

            if (name == "1")
                Position = "Nachalnik";
            else if (name == "2")
                Position = "Employee";
            else if(name=="3")
                Position = "Intern";

            NumDep = numDep;

            if (name == "1")
                Salary = rnd.Next(3000, 5000);
            else if (name == "3")
                Salary = 500;
            else
                Salary = salary;
        }
        public Employee(int id) : this((string)Convert.ToString(rnd.Next(1, 4)), (int)rnd.Next(20, 60), (string)Convert.ToString(rnd.Next(1,4)), (int)rnd.Next(4,13), (int)rnd.Next(1300, 2000))
        {
            ID = id;
        }
    }
}

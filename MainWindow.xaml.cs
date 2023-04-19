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
            Employee[] employee = new Employee[] //создание работников
            {
                new Employee(1,"Никита Порошин Сергеевич", 18, "Admin", 10, 20000),
                new Employee(2,"Работник Работников Работникович1", 30, "Employee", 11, 1300),
                new Employee(3,"Работник Работников Работникович2", 41, "Employee", 12, 1400),
                new Employee(4,"Интерн Интернов Интернович1", 20, "Intern", 4, 500),
                new Employee(5,"Работник Работников Работникович3", 34, "Employee", 5, 1350),
                new Employee(6,"Работник Работников Работникович4", 29, "Employee", 6, 1500),
                new Employee(7,"Интерн Интернов Интернович2", 19, "Intern", 7, 500),
                new Employee(8,"Работник Работников Работникович5", 42, "Employee", 8, 1600),
                new Employee(9,"Начальник Начальников Начальникович1", 51, "Nachalnik", 9, 3000),
                new Employee(10,"Работник Работников Работникович6", 27, "Employee", 10, 1700),
                new Employee(11,"Работник Работников Работникович7", 34, "Employee", 11, 1400),
                new Employee(12,"Работник Работников Работникович8", 24, "Employee", 12, 1540),
                new Employee(13,"Работник Работников Работникович9", 22, "Employee", 4, 1900),
                new Employee(14,"Работник Работников Работникович10", 37, "Employee", 4, 1800),
                new Employee(15,"Начальник Начальников Начальникович2", 46, "Nachalnik", 5, 4200),
                new Employee(16,"Начальник Начальников Начальникович3", 52, "Nachalnik", 6, 3900),
                new Employee(17,"Работник Работников Работникович11", 29, "Employee", 7, 1950),
                new Employee(18,"Начальник Начальников Начальникович4", 38, "Nachalnik", 8, 3100),
                new Employee(19,"Интерн Интернов Интернович3", 18, "Intern", 9, 500),
                new Employee(20,"Работник Работников Работникович12", 32, "Employee", 10, 1750),
            };

            XmlSerializer xml = new XmlSerializer(typeof(Employee[]));//указание типа

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
            XmlSerializer xml = new XmlSerializer(typeof(Employee[]));//Указание типа
            FileStream fs = new FileStream($@"{path}/depart1.xml", FileMode.OpenOrCreate);//указание пути до xml файла

            Employee[] emp1 = xml.Deserialize(fs) as Employee[];//создание массива для всех работников
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
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int NumDep { get; set; }
        public int Salary { get; set; }
        public Employee() { }
        public Employee(int id, string name, int age, string position, int numDep, int salary)
        {
            ID = id;
            Name = name;
            Age = age;
            Position = position;
            NumDep = numDep;
            Salary = salary;
        }
    }
}

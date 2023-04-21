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
using System.Windows.Media.Animation;
using System.Text.RegularExpressions;

namespace Practicheskaya_6
{
    public partial class MainWindow : Window
    {
        ObservableCollection<Department> depList = new ObservableCollection<Department>();
        ObservableCollection<Employee> emp = new ObservableCollection<Employee>();
        int check = 1;
        
        public MainWindow()
        {
            InitializeComponent();
        }
        public void CreateEmployee()
        {
            Random rnd = new Random();
            for (int i = 0; i < 9; i++)
            {
                Department dep = new Department();
                for (int j = 0; j < 100; j++)
                {
                    int a = rnd.Next(1, 4);
                    if (a == 1)
                    {
                        dep.employees.Add(new Intern("Интерн" + rnd.Next(1, 500).ToString()));
                        emp.Add(new Intern { Age = dep.employees[j].Age, ID = dep.employees[j].ID, Name = dep.employees[j].Name, Position = dep.employees[j].Position, Salary = dep.employees[j].Salary });
                    }
                    else if (a == 2)
                    {
                        dep.employees.Add(new Manager("Менеджер" + rnd.Next(1, 500).ToString()));
                        emp.Add(new Manager { Age = dep.employees[j].Age, ID = dep.employees[j].ID, Name = dep.employees[j].Name, Position = dep.employees[j].Position, Salary = dep.employees[j].Salary });
                    }
                        
                    else if (a == 3)
                    {
                        dep.employees.Add(new Admin("Менеджер" + rnd.Next(1, 500).ToString()));
                        emp.Add(new Admin { Age = dep.employees[j].Age, ID = dep.employees[j].ID, Name = dep.employees[j].Name, Position = dep.employees[j].Position, Salary = dep.employees[j].Salary });
                    }
                    check++;
                }
                depList.Add(dep);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateEmployee();
            
            dataGrid1.ItemsSource = emp;    
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void treeView1_Initialized(object sender, EventArgs e)
        {
            Random rnd = new Random();
            TreeViewItem bestHacker = new TreeViewItem();
            TreeViewItem dep1 = new TreeViewItem();
            TreeViewItem dep2 = new TreeViewItem();
            TreeViewItem dep3 = new TreeViewItem();
            int d1 = rnd.Next(1, 5);
            int d2 = rnd.Next(1, 5);
            int d3;
            int check = 4;

            treeView1.Items.Add(bestHacker);
            bestHacker.Header = "Лучшие программисты";
            bestHacker.Items.Add(dep1);
            bestHacker.Items.Add(dep2);
            bestHacker.Items.Add(dep3);
            bestHacker.FontSize = 14;

            dep1.Header = "dep1";
            for (int i = 0; i < d1; i++)
            {
                dep1.Items.Add("dep" + check);
                check++;
            }

            dep2.Header = "dep2";
            for (int i = 0; i < d2; i++)
            {
                dep2.Items.Add("dep" + check);
                check++;
            }

            dep3.Header = "dep3";
            d3 = 9 - (d1 + d2);
            for (int i = 0; i < d3; i++)
            {
                dep3.Items.Add("dep" + check);
                check++;
            }
        }

        private void treeView1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            for (int i = 0; i < depList.Count; i++)
            {
                if (depList[i].Dep == treeView1.SelectedItem.ToString())
                    dataGrid1.ItemsSource = depList[i].employees;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dataGrid1.ItemsSource = emp;
        }
    }
    public abstract class Employee//создание класса работника
    {
        static Random rnd = new Random();
        public float ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public abstract string Position { get; set; }
        public abstract int Salary { get; set; }
        public static float count = 0;
        public Employee(string name, int age)
        {
            ID = ++count;
            count = count - 0.5f;
            Name = name;
            Age = age;
        }
        public Employee() : this("", 0) { }
        public Employee(string name) : this(name, (int)rnd.Next(20, 60)) { }
    }
    public class Department
    {
        static Random rnd = new Random();
        public string Dep { get; set; }
        public int ID { get; set; }
        public ObservableCollection<Employee> employees { get; set; }
        public static int count1 = 4;
        public Department(string dep)
        {
            Dep = dep;
            employees = new ObservableCollection<Employee>();
            ID = count1++;
        }
        public Department() : this($"dep{count1}") { }
    }
    public class Intern : Employee
    {
        static Random rnd = new Random();
        public override int Salary { get; set; }
        public override string Position { get; set; }
        public Intern(string name) : base(name, (int)rnd.Next(20, 60))
        {
            Salary = 500;
            Position = "Intern";
        }
        public Intern() : base("", 0) { }
    }
    public class Manager : Employee
    {
        static Random rnd = new Random();
        public override int Salary { get; set; }
        public override string Position { get; set; }
        public Manager(string name) : base(name, (int)rnd.Next(20, 60))
        {
            Salary = 2500;
            Position = "Manager";
        }
        public Manager() : base("", 0) { }
    }
    public class Admin : Employee
    {
        static Random rnd = new Random();
        public override int Salary { get; set; }
        public override string Position { get; set; }
        public Admin(string name) : base(name, (int)rnd.Next(20, 60))
        {
            Salary = 5000;
            Position = "Admin";
        }
        public Admin() : base("", 0) { }
    }
}

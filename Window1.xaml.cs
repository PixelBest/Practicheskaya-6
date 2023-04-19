using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Practicheskaya_6
{
    interface IRaise
    {
        void RaiseSalary(int a);
    }
    public partial class Window1 : Window, IRaise
    {
        string path = Directory.GetCurrentDirectory();
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(textBox1.Text);
            RaiseSalary(a);
        }

        public void RaiseSalary(int a)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Employee[]));//Указание типа
            FileStream fs = new FileStream($@"{path}/depart1.xml", FileMode.OpenOrCreate);//указание пути до xml файла

            Employee[] emp1 = xml.Deserialize(fs) as Employee[];//создание массива для всех работников
            Employee[] emp2 = new Employee[] {};
            List<Employee> test = new List<Employee>();
            foreach (Employee emp in emp1)//запись всех работников в List
            {
                if (emp.ID == a)//проверка нужного отдела
                {
                    emp.Salary = emp.Salary * 115 / 100;//добавление каждого работника в List
                    MessageBox.Show($"Зарплата работника {emp.Name} повышена на 15% и теперь составляет {emp.Salary}");
                }
            }
            emp2 = test.ToArray();
            fs.Close();
            CreateXml(emp1);
        }

        public void CreateXml(Employee[] emp)
        {
            File.Delete($@"{path}/depart1.xml");
            XmlSerializer xml = new XmlSerializer(typeof(Employee[]));//Указание типа
            FileStream fs = new FileStream($@"{path}/depart1.xml", FileMode.OpenOrCreate);//указание пути до xml файла
            xml.Serialize(fs, emp);
            fs.Close();
            this.Hide();
        }
    }
}

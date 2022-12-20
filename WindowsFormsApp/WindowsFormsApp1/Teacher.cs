/*using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Xml;
using System.Xml.Linq;


namespace WindowsFormsAppUrupaBohdan
{
    public enum Discipline
    { Programming, Physics, Mathematics, Ukrainian_language, English_language, General_methodology, Mathematical_analysis };
    public class Teacher : Human
    {

        private Discipline _discipline;
        private int _salary;
        private List<Student> _lStudents = new List<Student>();

        public Teacher() : base()
        {
            this._discipline = Discipline.Programming;
            this._salary = 0;

            _lStudents = new List<Student>(10);
        }

        public Teacher(
            string name, string surname, string email, string photo, int age, 
            Nation nation, Adress_Class adress, Discipline discipline, int salary)
            : base(name, surname, email, photo, age, nation, adress)
        {
            this._discipline = discipline;
            this._salary = salary;

            _lStudents = new List<Student>(10);
        }
        public Teacher(
            Human h,
            Discipline discipline, int salary)
            : base(h)
        {
            this._discipline = discipline;
            this._salary = salary;

            _lStudents = new List<Student>(10);
        }
        public Teacher(Teacher Tr) : base(Tr.Name, Tr.Surname, Tr.Email, Tr.Photo, Tr.Age, Tr.Nation, Tr.Adress)
        {
            this._discipline = Tr.Discipline;
            this._salary = Tr.Salary;

            this._lStudents = Tr.LStudents;
        }

        //  +-------function-------+
        public void add(Student student)
        {
            _lStudents.Add(student);
        }
        public void clear()
        {
            _lStudents.Clear();
        }
        public void RemoveStudent(Student st)
        {
            if (_lStudents.Contains(st))
            {
                _lStudents.Remove(st);
            }
        }

        public override void inputData()
        {
            base.inputData();

            Console.WriteLine("Discipline: "); this.Discipline = (Discipline)Enum.Parse(typeof(Discipline), Console.ReadLine(), true);
            Console.WriteLine("Salary: "); this.Salary = int.Parse(Console.ReadLine());
        }
        public override string toStr()
        {
            return
                (base.toStr() + "\n" +
                "Salary: " + this.Salary);
        }

        public override void printInfo() => this.toStr();

        public void writetojson(Student st, string name)
        {
            string filePath = $"{name}_St.json";

            if (File.Exists(filePath) == false)
            {
                var file = File.Create(filePath);
                file.Close();
            }

            List<Student> alreadyInFile = readfromjson(name);
            if (!alreadyInFile.Contains(st))
            {
                File.WriteAllText(filePath, string.Empty);
                alreadyInFile.Add(st);
                string serializedDBUsers = JsonConvert.SerializeObject(alreadyInFile, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, serializedDBUsers);
            }
        }
        public List<Student> readfromjson(string name)
        {
            string filePath = $"{name}_St.json";

            string jsonText = File.ReadAllText(filePath);
            List<Student> alreadyInFile = JsonConvert.DeserializeObject<List<Student>>(jsonText); 
            if( alreadyInFile == null) { alreadyInFile = new List<Student>(); }

            return alreadyInFile;
        }

        //  +-------get/set-------
        public Discipline Discipline
        {
            get { return _discipline; }
            set { _discipline = value; }
        }
        public int Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }
        public List<Student> LStudents
        {
            get { return _lStudents; }
            set { _lStudents = value; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppUrupaBohdan
{
    public enum Nation { Ukranian, French, Polish, American, British };
    public class Human
    {
        private string _name;
        private string _surname;
        private string _email;
        private string _photo;
        private int _age;
        private Nation _nation;
        private Adress_Class _adress;


        public Human()
        {
            this._name = "My_name";
            this._surname = "My_surname";
            this._email = "myemail@humail.hum";
            //this._photo = "..";
            this._age = 18;
            this._nation = Nation.Ukranian;
            this._adress = new Adress_Class();
        }
        public Human(string name, string surname, string email, string photo, int age, Nation nation, Adress_Class adress)
        {
            this._name = name;
            this._surname = surname;
            this._email = email;
            this._photo = photo;
            this._age = age;
            this._nation = nation;
            this._adress = adress;
        }
        public Human(Human H)
        {
            this._name = H._name;
            this._surname = H._surname;
            this._email = H._email;
            this._photo = H._photo;
            this._age = H._age;
            this._nation = H._nation;
            this._adress = H._adress;
        }

        //  +-------function-------+
        public virtual void inputData()
        {
            Console.WriteLine("Name: "); this.Name = Console.ReadLine();
            Console.WriteLine("Surname: "); this.Surname = Console.ReadLine();
            Console.WriteLine("Age: "); this.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Nation: "); this.Nation = (Nation)Enum.Parse(typeof(Nation), Console.ReadLine(), true);
            this.Adress = (new Adress_Class()).inputAdress();
        }
        public virtual string toStr()
        {
            return
                ("Name: " + this.Name + "\n" +
                "Surname: " + this.Surname + "\n" +
                "Age: " + this.Age.ToString() + "\n" +
                "Nation: " + this.Nation.ToString() + "\n" +
                this.Adress.toStr());
        }
        public virtual void printInfo() => this.toStr();

        //  +-------get/set-------+
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Photo
        {
            get { return _photo; }
            set { _photo = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public Nation Nation
        {
            get { return _nation; }
            set { _nation = value; }
        }
        public Adress_Class Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
    }
}

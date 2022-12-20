using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppUrupaBohdan
{
    public class TeacherList
    {
        private List<Teacher> _tList;
        public TeacherList()
        {
            _tList = new List<Teacher>();
        }

        public void add(Teacher t)
        {
            _tList.Add(t);
        }
        public void RemoveTeacher(Teacher t)
        {
            if (_tList.Contains(t))
            {
                _tList.Remove(t);
            }
        }
        public void show()
        {
            int i = 0;
            for (i = 0; i < _tList.Count(); i++)
            { _tList[i].printInfo(); }
        }
        public void check_json()
        {
            if (File.Exists("Teachers.json") == false)
            {
                var file = File.Create("Teachers.json");
                file.Close();
            }
        }
        public void writetojson(Teacher teacher)
        {
            string filePath = $"TeacherList.json";

            if (File.Exists(filePath) == false)
            {
                var file = File.Create(filePath);
                file.Close();
            }

            List<Teacher> alreadyInFile = readfromjson();
            if (!alreadyInFile.Contains(teacher))
            {
                File.WriteAllText(filePath, string.Empty);
                alreadyInFile.Add(teacher);
                string serializedDBUsers = JsonConvert.SerializeObject(alreadyInFile, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(filePath, serializedDBUsers);
            }

        }
        public List<Teacher> readfromjson()
        {
            string filePath = $"TeacherList.json";
            string jsonText = File.ReadAllText(filePath);

            List<Teacher> alreadyInFile = JsonConvert.DeserializeObject<List<Teacher>>(jsonText);
            if (alreadyInFile == null) { alreadyInFile = new List<Teacher>(); }

            return alreadyInFile;
        }
        
        public List<Teacher> TList
        {
            get { return _tList; }
            set { this._tList = value; }
        }
    }
}

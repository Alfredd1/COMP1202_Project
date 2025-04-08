using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assign2_Mudit_Navarro
{
    internal class Student
    {
        private static int IdGenerator = 0;
        private int id;
        private string name;
        private string email;

        public Student()
        {
            this.id = ++IdGenerator;
            this.name = "Unknown";
            this.email = "Unknown";
        }
        public Student(string name, string email)
        {
            this.id = ++IdGenerator;
            this.name = name;
            this.email = email;
        }
        public int Id
        {
            get { return this.id; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public override string? ToString()
        {
            return $"Student ID: {this.Id} | Name: {Name} | Email: {email}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Employee
    {
        public string Name { get; private set; }
        private string email;
        private int phone;

       public Employee(string name, string email, int phone)
        {
            this.Name = name;
            this.email = email;
            this.phone = phone;
        }
        public int getPhone() {return phone;}
        public void setPhone(int phone) {this.phone = phone;}
        public string getName() {return Name;}
        public void setName(string name) {this.Name = name;}
        public string getEmail() {return email;}
        public void setEmail(string email) {this.email = email;}

    }
}

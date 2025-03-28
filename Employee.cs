using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil
{
    public class Employee
    {
        private string name;
        private string email;
        private int phone;

       public Employee(string name, string email, int phone)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
        }
        public int getPhone() {return phone;}
        public void setPhone(int phone) {this.phone = phone;}
        public string getName() {return name;}
        public void setName(string name) {this.name = name;}
        public string getEmail() {return email;}
        public void setEmail(string email) {this.email = email;}

    }
}

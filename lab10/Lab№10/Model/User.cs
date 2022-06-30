using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_10.Model
{
    public class User
    {
        private int id;
        private string name;
        private string surname;
        private string avatar;

        public User(int id, string name, string surname, string avatar)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.avatar = avatar;
        }

        public int Id { get => id; }
        public string Name { get => name; }
        public string Surname { get => surname; }
        public string Avatar { get => avatar; }
    }
}

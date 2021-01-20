using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManager.Entities
{
    public class User
    {
        //for EF
        public User(){}

        public User(string name, string email)
        {
            this.Name = name;
            this.Email = email;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public ICollection<BookUser> BookUsers{ get; set; }
}

}

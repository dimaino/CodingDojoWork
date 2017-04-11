using System;

namespace Quoting_Dojo
{
    public class User
    {
        public int id;
        public string name;
        public string quote;
        public DateTime created;

        public DateTime updated;

        public User(int id, string name, string quote, DateTime created, DateTime updated)
        {
            this.id = id;
            this.name = name;
            this.quote = quote;
            this.created = created;
            this.updated = updated;
        }
    }
}
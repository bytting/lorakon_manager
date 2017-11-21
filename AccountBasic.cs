using System;

namespace lorakon_manager
{
    public class AccountBasic
    {
        public AccountBasic()
        {
            ID = Guid.Empty;
            Username = String.Empty;
        }

        public AccountBasic(Guid id, string username)
        {
            ID = id;
            Username = username;
        }

        public Guid ID { get; set; }
        public string Username { get; set; }
    }
}
using System;

namespace lorakon_manager
{
    public class AccountName
    {
        public AccountName()
        {
            Name = String.Empty;
        }

        public AccountName(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
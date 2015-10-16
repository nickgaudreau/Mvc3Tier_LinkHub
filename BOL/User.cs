namespace BOL
{
    public sealed class User
    {
        public static readonly User RoleAdmin = new User("A");
        public static readonly User RoleAuthorizedUser = new User("U");

        private User(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}

namespace BOL
{
    public sealed class Url
    {
        public static readonly Url StatusPending = new Url("P");
        public static readonly Url StatusAuthorized = new Url("A");
        public static readonly Url StatusRejected = new Url("R");

        private Url(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}

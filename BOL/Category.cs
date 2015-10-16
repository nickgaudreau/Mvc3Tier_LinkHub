namespace BOL
{
    public sealed class Category
    {
        public static readonly Category Id = new Category("i_CategoryId");
        public static readonly Category Name = new Category("c_CategoryName");
        public static readonly Category Desc = new Category("c_CategoryDesc");

        private Category(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
    }
}

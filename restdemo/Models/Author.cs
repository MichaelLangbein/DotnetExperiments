namespace Models
{
    public class Author
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Book> Books { get; set; }
    }
}
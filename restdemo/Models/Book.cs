namespace Models
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Author Author { get; set; }
    }
}
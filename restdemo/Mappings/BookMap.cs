using FluentNHibernate.Mapping;
using Models;

namespace Mappings
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Id(b => b.Id);
            Map(b => b.Name);
            References(b => b.Author).Column("AuthorId");
            Table("Books");
        }
    }
}
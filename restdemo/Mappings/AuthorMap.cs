using FluentNHibernate.Mapping;
using Models;

namespace Mappings
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Id(a => a.Id);
            Map(a => a.Name);
            HasMany(a => a.Books)
                .Cascade.All().Inverse().KeyColumn("AuthorId");
            Table("Authors");

        }
    }
}
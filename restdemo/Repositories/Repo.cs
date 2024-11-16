using Models;
using NHibernate.Linq;
using ISession = NHibernate.ISession;

namespace Repositories
{

    public class CreateAuthorDto
    {
        public string Name { get; set; }
        public List<CreateBookDto> Books { get; set; }
    }


    public class CreateBookDto
    {
        public string Name { get; set; }
    }

    public class AuthorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BookDto> Books { get; set; }
    }

    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class Repository(ISession session)
    {

        private readonly ISession _session = session;

        public IList<Author> GetAuthors()
        {
            return _session.Query<Author>().Fetch(a => a.Books).ToList();
        }

        public Author? GetAuthor(int id)
        {
            return _session.Query<Author>()
            .Fetch(a => a.Books)
            .FirstOrDefault(a => a.Id == id);
        }

        public Author CreateAuthor(CreateAuthorDto author)
        {
            // check if author already exists
            if (_session.Query<Author>().Any(a => a.Name == author.Name))
            {
                // if so, return this author
                return _session.Query<Author>()
                    .FirstOrDefault(a => a.Name == author.Name)!;
            }

            var a = new Author { Name = author.Name };
            var id = (int)_session.Save(a);
            foreach (var b in author.Books)
            {
                var book = new Book { Name = b.Name, Author = a };
                _session.Save(book);
            }
            var savedAuthor = GetAuthor(id);
            return savedAuthor;
        }
    }
}
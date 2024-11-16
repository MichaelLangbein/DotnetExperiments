using Models;
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

    public class Repository
    {

        private readonly ISession _session;
        public Repository(ISession session)
        {
            _session = session;
        }

        public IList<Author> GetAuthors()
        {
            return _session.Query<Author>().ToList();
        }

        public Author GetAuthor(int id)
        {
            return _session.Get<Author>(id);
        }

        public Author CreateAuthor(CreateAuthorDto author)
        {
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
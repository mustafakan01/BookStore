using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers{

[ApiController]
[Route("[controller]s")]

    public class BookController : ControllerBase
    {
        private static List<Book> BookList=new List<Book>()
        {
            new Book{
                Id=1,
                Title="Beyaz Diş",
                GenreId=1, // Personal Groutw
                PageCount=200,
                PublishDate=new DateTime(2001,06,12)
            },
            new Book{
                Id=2,
                Title="İnsan Ne İle Yaşar",
                GenreId=2, // Bilim Kutgu
                PageCount=300,
                PublishDate=new DateTime(1998,08,02)
            },
            new Book{
                Id=3,
                Title="Gölün Hanımı",
                GenreId=3, // Fantastik
                PageCount=250,
                PublishDate=new DateTime(2009,01,12)
            }
        };

        [HttpGet]
        public List<Book> GetBooks()
        {
            var bookList=BookList.OrderBy(x=>x.Id).ToList<Book>();
            
            return bookList;
        }

        [HttpGet("{id}")]
         public Book GetById(int id)
        {
            var book=BookList.Where(book=>book.Id==id).SingleOrDefault();
            
            return book;
        }

        //  [HttpGet]
        //  public Book Get([FromQuery] string id)
        // {
        //     var book=BookList.Where(book=>book.Id==Convert.ToInt32(id)d).SingleOrDefault();
            
        //     return book;
        // }

    }
}
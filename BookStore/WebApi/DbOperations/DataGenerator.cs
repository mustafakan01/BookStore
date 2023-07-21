using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace WebApi.DbOperations


{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context=new BookDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookDbContext>>()))
            {
                        if (context.Books.Any())
                        {
                            return;
                        }
                        else
                        context.Books.AddRange(
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
                );
            
            context.SaveChanges();
            }
        }
    }
}
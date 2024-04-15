using AutoMapper;
using BooksProject.API.Data;
using BooksProject.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksProject.API.repository
{
    public class BooksRepository : IBookRepository
    {
        private readonly BookStoreContext _context;
        private readonly IMapper _mapper;

        public BooksRepository(BookStoreContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
           /*var records = await _context.Books.Select(x=> new BookModel()
           {
               Id = x.Id,
               Title = x.Title,
               Description = x.Description,
           }).ToListAsync();*/
           //Second method of calling Using Auto Mapper
           var records = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookModel>>(records);
        }

        public async Task<BookModel> GetAllBooksByIDAsync(int bookID)
        {
            /*  var records = await _context.Books.Where(x=> x.Id == bookID).Select(x => new BookModel()
              {
                  Id = x.Id,
                  Title = x.Title,
                  Description = x.Description,
              }).FirstOrDefaultAsync();
              return records;*/

            var book = await _context.Books.FindAsync(bookID);
            return _mapper.Map<BookModel>(book);    
        }

        public async Task<int> AddbooksAsync(BookModel bookModel)
        {
            var book = new Books()
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task UpdateBookAsync(int bookID, BookModel bookModel)
        {
            // var books = await _context.Books.FindAsync(bookID);
            // if(books != null)
            // {
            //    books.Title = bookModel.Title;
            //   books.Description = bookModel.Description;

            //                await _context.SaveChangesAsync();
            //          }

            var book = new Books()
            {
                Id = bookID,
                Title = bookModel.Title,
                Description = bookModel.Description,
            };

            _context.Books.Update(book);
            await _context.SaveChangesAsync();

        }


        public async Task UpdateBooksPatch(int bookID, JsonPatchDocument bookModel)
        {
            var book = await _context.Books.FindAsync(bookID);
            if(book != null)
            {
                bookModel.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }


        public async Task DeleteBooksRecord(int bookID)
        {
            //if you want to  remove it with finding the name 
            //  var book = _context.Books.Where(x=> x.Title == "").FirstOrDefault();

            var book = new Books()
            {
                Id = bookID,
            };
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

        }
    }

    
}

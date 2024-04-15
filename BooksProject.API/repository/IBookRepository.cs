using BooksProject.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksProject.API.repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetAllBooksByIDAsync(int bookID);

        Task<int> AddbooksAsync(BookModel bookModel);

        Task UpdateBookAsync(int bookID, BookModel bookModel);

        Task UpdateBooksPatch(int bookID, JsonPatchDocument bookModel);

        Task DeleteBooksRecord(int bookID);
    }
}

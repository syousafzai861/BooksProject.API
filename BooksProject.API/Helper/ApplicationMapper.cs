using AutoMapper;
using BooksProject.API.Data;
using BooksProject.API.Models;

namespace BooksProject.API.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Books, BookModel>().ReverseMap();
        }
    }
}

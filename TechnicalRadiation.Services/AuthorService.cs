using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;

namespace TechnicalRadiation.Services
{
    public class AuthorService
    {
        private AuthorRepo _authorRepo;

        public AuthorService(IMapper mapper)
        {
            _authorRepo = new AuthorRepo(mapper);
        }

        public IEnumerable<AuthorDto> GetAllRentals(bool containUnavailable)
        {
            return _authorRepo.GetAllAuthors(containUnavailable);
        }
    }
}
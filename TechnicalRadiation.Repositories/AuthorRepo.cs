using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using AutoMapper;

namespace TechnicalRadiation.Repositories
{
    public class AuthorRepo
    {
        private IMapper _mapper;
        public AuthorRepo(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAllAuthors()
        {
            return _mapper.Map<IEnumerable<AuthorDto>>(FakeDatabase.Authors);
        }

        public AuthorDetailDto GetAuthorById(int id)
        {
            return _mapper.Map<AuthorDetailDto>(FakeDatabase.Authors.Where(a => a.Id == id).SingleOrDefault());
        }
    }
}
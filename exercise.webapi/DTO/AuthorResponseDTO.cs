﻿using exercise.webapi.Models;

namespace exercise.webapi.DTO
{
    public class AuthorResponseDTO
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<BookPublisherDTO> Books { get; set; } = new List<BookPublisherDTO>();

        public AuthorResponseDTO(Author author)
        {
            Id = author.Id;
            FirstName = author.FirstName;
            LastName = author.LastName;
            Email = author.Email;

            Books = new List<BookPublisherDTO>();
            foreach (var item in author.Books)
            {
                Books.Add(new BookPublisherDTO(item));
            }
        }

        public static List<AuthorResponseDTO> FromRepository(IEnumerable<Author> authors)
        {
            var res = new List<AuthorResponseDTO>();
            foreach (var author in authors)
            {
                res.Add(new AuthorResponseDTO(author));
            }

            return res;
        }
    }
}
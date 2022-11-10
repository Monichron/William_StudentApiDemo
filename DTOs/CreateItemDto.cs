using System;
using System.ComponentModel.DataAnnotations;

namespace ApiNew.DTOs
{
    public record CreatedStudentDto
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        [Range (1,1000)]
        public string Subject { get; init; }
    }
}
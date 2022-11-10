using System;
namespace ApiNew.DTOs
{
    public record StudentDto
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public DateTime DateTime { get; set; }
    }
}
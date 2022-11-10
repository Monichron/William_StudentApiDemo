using System;
namespace ApiNew.Entities
{
    public record Student
    {
        public Guid  ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }
        public DateTime DateTime { get; set; }
    }

}
using ApiNew.DTOs;
using ApiNew.Entities;
using System;
namespace ApiNew
{
    public static class Extentions
    {
        public static StudentDto asDto(this Student student)
        {
            return new StudentDto
            {
                ID = student.ID,
                LastName = student.LastName,
                FirstName = student.FirstName,
                Subject = student.Subject
            };
        }
    }
}
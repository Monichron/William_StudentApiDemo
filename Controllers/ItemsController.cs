using Microsoft.AspNetCore.Mvc;
using System;
using ApiNew.Repository;
using System.Collections.Generic;
using ApiNew.Entities;
using System.Linq;
using ApiNew.DTOs;
using System.Data.SqlClient;
using System.Data;

namespace ApiNew.Controller
{
   
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        public string Con = @"Data Source=DESKTOP-OJ9JERU\SQLEXPRESS;Database=Students;Trusted_Connection=True;";
        private readonly IItemRepository repository;

        public ItemsController(IItemRepository repository)
        {
            this.repository = repository;
        }
        //Doesnt Do anything
        [HttpGet]
        public IEnumerable<StudentDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.asDto());
            return items;
        }
        //Test
        [HttpGet("{id}")]
        public ActionResult<StudentDto> Getitem( Guid id)
        {
            var item = repository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return item.asDto();
        }
        //Done
        [HttpPost]
        public ActionResult<StudentDto> CreateItemDto(CreatedStudentDto studentDto)
        {
            using ( var sqlCon = new SqlConnection(Con))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("spCreate", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = studentDto.FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = studentDto.LastName;
                sql_cmnd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = studentDto.Subject;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return NoContent();
        }
        //Done
        [HttpPut("{id}")]
        public ActionResult UpdateItemDto(Guid id, UpdatedStudentDto studentDto)
        {

            using (var sqlCon = new SqlConnection(Con))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("spUPDATETable", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@FirstName", SqlDbType.NVarChar).Value = studentDto.FirstName;
                sql_cmnd.Parameters.AddWithValue("@LastName", SqlDbType.NVarChar).Value = studentDto.LastName;
                sql_cmnd.Parameters.AddWithValue("@Subject", SqlDbType.NVarChar).Value = studentDto.Subject;
                sql_cmnd.Parameters.AddWithValue("@DateTime", SqlDbType.SmallDateTime).Value = studentDto.DateTime;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.UniqueIdentifier).Value = id;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
           
            return NoContent(); 
        }
        //Done
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            using (var sqlCon = new SqlConnection(Con))
            {
                sqlCon.Open();
                SqlCommand sql_cmnd = new SqlCommand("spDELETEfromTable", sqlCon);
                sql_cmnd.CommandType = CommandType.StoredProcedure;
                sql_cmnd.Parameters.AddWithValue("@ID", SqlDbType.UniqueIdentifier).Value = id;
                sql_cmnd.ExecuteNonQuery();
                sqlCon.Close();
            }
            return NoContent();
        }
    }
}
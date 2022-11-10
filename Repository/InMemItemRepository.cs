using System;
using System.Collections.Generic;
using ApiNew.Entities;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace ApiNew.Repository
{
    public class InMemItemRepository : IItemRepository
    {

        public List<Student> studentList = new List<Student>();
        public List<Student> GetDataTable()
        {
            
            string Con = @"Data Source=DESKTOP-OJ9JERU\SQLEXPRESS;Database=Students;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(Con);
            conn.Open();
            string query = "SELECT * FROM Repository ";
            
            SqlCommand cmd = new SqlCommand(query, conn);

            DataTable StudentTable = new DataTable();
            using (SqlDataAdapter a = new SqlDataAdapter(cmd))
            {
                a.Fill(StudentTable);
            }

            conn.Close();

            if (studentList != null)
            {
                studentList.Clear();
            }
            for (int i = 0; i < StudentTable.Rows.Count; i++)
            {
                Student student = new Student();
                student.ID = (Guid)StudentTable.Rows[i]["ID"];
                student.LastName = StudentTable.Rows[i]["LastName"].ToString();
                student.FirstName = StudentTable.Rows[i]["FirstName"].ToString();
                student.Subject = StudentTable.Rows[i]["Subject"].ToString();
                student.DateTime = (DateTime)StudentTable.Rows[i]["Date Time"];
                studentList.Add(student);
            }
            return studentList;
        }
         
       

        public IEnumerable<Student> GetItems()
        {
            
            GetDataTable();
            return studentList;
        }

        public Student GetItem(Guid id)
        {
            return studentList.Where(student => student.ID == id).SingleOrDefault();
        }

        public void CreateItem(Student student)
        {
            studentList.Add(student);
        }

        public void UpdateItem(Student student)
        {
            var index = studentList.FindIndex(existingStudent => existingStudent.ID == student.ID);
            studentList[index] = student;
        }

        public void DeleteItem(Guid id)
        {
            var index = studentList.FindIndex(existingItem => existingItem.ID == id);
            studentList.RemoveAt(index);
        }

        Student IItemRepository.GetItem(Guid Id)
        {
            return studentList.Where(student => student.ID == Id).SingleOrDefault();
        }

        IEnumerable<Student> IItemRepository.GetItems()
        {
            
            GetDataTable();
            return studentList;
        }

       
    }
}
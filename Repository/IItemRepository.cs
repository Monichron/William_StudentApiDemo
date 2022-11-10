using ApiNew.Entities;
using System;
using System.Collections.Generic;

namespace ApiNew.Repository
{
    public interface IItemRepository
    {
        Student GetItem(Guid id);
        IEnumerable<Student> GetItems();
        void CreateItem(Student student);

        void UpdateItem(Student student);
        public void DeleteItem(Guid id);
        
    }
}
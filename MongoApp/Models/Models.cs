using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace MongoApp.Models {
    public class Employee {
        public string _id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string DepartmentId { get; set; }
    }

    public class Department {
        public ObjectId _id { get; set; }
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string HeadOfDepartmentId { get; set; }
    }
}
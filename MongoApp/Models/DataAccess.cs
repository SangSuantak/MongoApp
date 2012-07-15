using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Configuration;

namespace MongoApp.Models {
    public class DataAccess {

        MongoServer mServer = MongoServer.Create(ConfigurationManager.AppSettings["connectionString"]);
        MongoDatabase mDatabase;

        public DataAccess() {
            mDatabase = mServer.GetDatabase("test");
        }

        public void CreateDepartment(Department objDept) {                        
            MongoCollection<BsonDocument> departments = mDatabase.GetCollection<BsonDocument>("Departments");
            BsonDocument department = new BsonDocument { 
                { "DepartmentName", objDept.DepartmentName },
                { "HeadOfDepartmentId", objDept.HeadOfDepartmentId }
            };
            departments.Insert(department);
        }

        public void CreateEmployee(Employee objEmp) {            
            MongoCollection<BsonDocument> employees = mDatabase.GetCollection<BsonDocument>("Employees");

            BsonDocument employee = new BsonDocument { 
                { "FirstName", objEmp.FirstName },
                { "LastName", objEmp.LastName },
                { "Address", objEmp.Address },
                { "City", objEmp.City },
                { "DepartmentId", objEmp.DepartmentId }
            };

            employees.Insert(employee);

        }

        public List<Department> GetDepartments() {
            List<Department> lstDept = new List<Department>();            
            MongoCollection<Department> departments = mDatabase.GetCollection<Department>("Departments");

            foreach (Department item in departments.FindAll()) {
                lstDept.Add(item);
            }

            return lstDept;

        }

    }
}
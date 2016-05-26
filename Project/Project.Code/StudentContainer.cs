using System;
using System.Collections.Generic;
using System.Linq;

/*klasa StudentContainer sadrzi listu u koju se spremaju
 * studenti koje je korisnik unio, unos se vrsi preko funkcije
 * addStudent, preko objekta klase StudentContainer mogu se ispisati
 * objekti iz liste nesortirano i sortirano*/
namespace Project.Code
{
    public class StudentContainer
    {
        private List<Student> StudentList = new List<Student>();


        public void AddStudent(Student student)
        {
            this.StudentList.Add(student);
        }
        public List<Student> GetStudents()
        {
            return this.StudentList;
        }
        //stara f za sortiranje preko delegate
        /*public List<Student> GetSortedStudents()
        {
            studentList.Sort(delegate(Student x, Student y)
            { 
                return x.lastName.CompareTo(y.lastName); }
            );
            return studentList;
        }*/
        //nova f za sortiranje preko lambda expressiona
        public List<Student> GetSortedStudents()
        {
            StudentList = StudentList.OrderBy(s => s.LastName).ToList();
            return StudentList;
        }

    }
}
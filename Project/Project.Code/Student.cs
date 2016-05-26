using System;

/*klasa Student nasljeduje klasu Person i njene atribute i metode
 * uz id, firstName i lastName koji su nasljeđeni dodan je i atribut
 * gpa koji je unikatan za studenta*/
namespace Project.Code
{
    public class Student : Person
    {
        public Student() : base() { }

        public Student(int id, string firstName, string lastName, float gpa)
        {
            this.ID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Gpa = gpa;
        }
        public float Gpa { set; get; }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using Project.Code;

namespace Project.App
{
    class Program
    {
        static void Main()
        {
            //deklaracija varijabli i objekata
            string operationInput;
            string firstName;
            string lastName;
            string unformatedGpaInput;
            float gpa;
            bool isGpaFloat; 
            int id;
            Student Student;
            StudentIdGenerator IdGenerator = StudentIdGenerator.GetGenerator();
            StudentContainer StudentContainer = new StudentContainer();
            List<Student> ListStudent;
            //ove 2 linije koda omogucuju unos gpa preko float vrijednosti s "."
            var Culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            Culture.NumberFormat.NumberDecimalSeparator = ".";
           
            //program se vrti dok korisnik ne upise display, omoguceno preko do-while
            do
            {
                //unos i provjera operacije
                while (true)
                {
                    Console.Write("Operation: ");
                    operationInput = Console.ReadLine().ToUpper();
                    if (!InputCheck.OperationCheck(operationInput))
                    {
                        Console.WriteLine("Operation non-existing, please use appropriate operation.");
                        continue;
                    }
                    else
                        break;
                }
                //ovisno o isEnlist i isDisplay izvode se blokovi
                if (operationInput == Operations.Enlist)
                {
                    //unos i provjera imena studenta
                    Console.WriteLine("Student");
                    while (true)
                    {
                        Console.Write("First name: ");
                        firstName = Console.ReadLine();
                        if (!InputCheck.FirstNameCheck(firstName))
                        {
                            Console.WriteLine("You need to insert value.");
                            continue;
                        }
                        else
                            break;
                    } 
                    //unos i provjera prezimena studenta
                    while (true)
                    {
                        Console.Write("Last name: ");
                        lastName = Console.ReadLine();
                        if (!InputCheck.LastNameCheck(lastName))
                        {
                            Console.WriteLine("You need to insert value.");
                            continue;
                        }
                        else
                            break;
                    }
                    //unos i provjera gpa studenta, potreban unos u obliku 00.0 
                    while (true)
                    {
                        Console.Write("GPA: ");
                        unformatedGpaInput = Console.ReadLine();
                        InputCheck.IsFloat(unformatedGpaInput, Culture, out isGpaFloat, out gpa);
                        if (!isGpaFloat)
                        {
                            Console.WriteLine("You need to insert numerical value.");
                            continue;
                        }
                        else
                            break;
                    }
                    id = IdGenerator.NextId();
                    //kreiranje novog objekta preko parametarskog konstruktora i dodavanje u listu
                    Student = new Student(id, firstName, lastName, gpa);
                    StudentContainer.AddStudent(Student); 
                } 
                if (operationInput == Operations.Display) 
                {
                    //u slucaju odabira operacije display u novi objekt se kopira lista iz
                    //klase StudentContainer, ako je prazna daje poruku ako nije ispisuje ju
                    Console.WriteLine("Students in system:");
                    ListStudent = StudentContainer.GetSortedStudents();
                    if (ListStudent.Count == 0)
                    {
                        Console.WriteLine("There are no students in system.");
                    }
                    else
                    {
                        foreach (Student student in ListStudent)
                        {
                            Student sList = student;
                            Console.WriteLine(sList.ID + ". " + sList.LastName + ", " + sList.FirstName + " - " + sList.Gpa.ToString(Culture));
                        }
                    }
                }
            } while (operationInput != Operations.Display);
        }
    }
}
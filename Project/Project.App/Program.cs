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
            //inicijalizacija varijabli i objekata
            string operationInput;
            string firstName;
            string lastName;
            string unformatedGpaInput = "";
            float gpa = 0.0F;
            bool isGpaFloat = false;
            bool isOperationTrue = false;
            bool isLastNameEmpty = false;
            bool isFirstNameEmpty = false;
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
                //unos operacije se vrti dok korisnik ne unese ispravnu operaciju, provjera se vrsi
                //preko objekta klase Inputcheck
                do
                {
                    Console.Write("Operation: ");
                    operationInput = Console.ReadLine().ToUpper();
                    isOperationTrue = InputCheck.OperationCheck(operationInput);
                    if (!isOperationTrue)
                        Console.WriteLine("Operation non-existing, please use appropriate operation.");
                } while (InputCheck.OperationCheck(operationInput) != true);
                //ovisno o izabranoj operaciji izvest ce se dio koda, ako je uneseno enlist
                //inda se izvodi kod za enlist i obrnuto
                switch (operationInput == Operations.Enlist)
                {
                    case true:
                        //provjera unosta imena i preziname, preko objekta klase Inputcheck
                        //program provjerava je li uneseno ista
                        Console.WriteLine("Student");
                        do
                        {
                            Console.Write("First name: ");
                            firstName = Console.ReadLine();
                            isFirstNameEmpty = InputCheck.FirstNameCheck(firstName);
                            if (!isFirstNameEmpty)
                                Console.WriteLine("You need to insert value.");
                        } while (InputCheck.FirstNameCheck(firstName) != true);
                        do
                        {
                            Console.Write("Last name: ");
                            lastName = Console.ReadLine();
                            isLastNameEmpty = InputCheck.LastNameCheck(lastName);
                            if (!isLastNameEmpty)
                                Console.WriteLine("You need to insert value.");
                        } while (InputCheck.LastNameCheck(lastName) != true);
                        //provjera unosa gpa, sve dok korisnik ne unese ista drugo osim
                        //dec broja s tockom program zahtijeva novi unos
                        //provjera preko objekta klase Inputcheck koji vraca true ili false
                        //za provjeru je li broj float, slicno kao u zakomentiranom try-catch
                        do
                        {
                            Console.Write("GPA: ");
                            unformatedGpaInput = Console.ReadLine();
                            isGpaFloat = InputCheck.IsFloat(unformatedGpaInput, Culture);
                            if (!isGpaFloat)
                                Console.WriteLine("You need to insert numerical value.");
                        } while (isGpaFloat != true);
                        //dodijeljivanje vrijednost gpa i id, kreiranje novog studenta preko
                        //parametarskog konstruktora i dodavanje u listu
                        gpa = float.Parse(unformatedGpaInput, Culture);
                        id = IdGenerator.NextId();
                        Student = new Student(id, firstName, lastName, gpa);
                        StudentContainer.AddStudent(Student);
                        break;
                    case false:
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
                        break;
                }
            } while (operationInput != Operations.Display);
            //Console.ReadLine();
        }
    }
}
using System;

/*klasa StudentIdGenerator sluzi kako bi objekt ove klase
 * mogao studentu pridodijeliti random id, za najvecu mogucu vrijednost
 * id-a postavljen je broj 100*/

//--izmjena

/* koristen je singleton pattern za generiranje ID-a
 * u klasi StudentIdGenerator kreira se novi objekt te klase - instance
 * prilikom kreiranja objekta u def konstruktoru(nextID ovdje sluzi kao brojac)
 * nextID se postavlja na 1 te se na pozivu metode nextId  ID u klasi Program.cs povecava za 1
 * kada se implementira singleton pattern to znaci da se moze postojati samo jedan
 * objekt te klase a on je vec napravljen u roditeljskoj klasi, zato postoji ova metoda
 * getGenerator i ona se poziva u Program.cs umjesto da se kreira novi objekt*/
namespace Project.Code
{

    public class StudentIdGenerator
    {
        private static StudentIdGenerator Instance;


        private int nextID;

        private StudentIdGenerator()
        {
            nextID = 1;
        }

        public static StudentIdGenerator GetGenerator()
        {
            if (Instance == null)
            {
                Instance = new StudentIdGenerator();
            }
            return Instance;
        }

        public int NextId()
        {
            return nextID++;
        }

    }
}

using System;

/**klasa person sadrzi
 *atribute i metode koji su potrebni
 *za opis neke osobe, u cjelokupnom projektu
 nije kreiran nijedan objekt klase Person
 ali se defaultni konstruktor poziva pri kreiranju
 objekta klase Student*/
namespace Project.Code
{
    public abstract class Person
    {
        public int ID { set; get; }

        public string FirstName { set; get; }

        public string LastName { set; get; }
    }
}
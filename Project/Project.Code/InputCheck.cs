﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

/*
 *klasa Inputcheck služi za provjeru korisnikovog unosa
 *sadrzi 4 funkcije koje vracaju bool vrijednost ovisno
  o provjeri korisnikovog unosa*/

namespace Project.Code
{
    public class InputCheck
    {
        //vraca false ako je uneseno ista drugo osim ENLIST ili DISPLAY
        public static bool OperationCheck(string operation)
        {
            if (operation != Operations.Enlist && operation != Operations.Display)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //vraca true ako je unos prazan string
        public static bool FirstNameCheck(string firstName)
        {
            if (firstName == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static bool LastNameCheck(string lastName)
        {
            if (lastName == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //vraca false ako nije unesen float odnostno ako ga ne uspije parsirati
        public static bool IsFloat(string unformatedGPA, CultureInfo Culture)
        {
            float F;
            try
            {
                return float.TryParse(unformatedGPA, NumberStyles.AllowDecimalPoint, Culture, out F);
            }
            catch (FormatException e)
            {
                return false;
            }
        }
    }
}
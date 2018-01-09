using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneDirectory
{
    class Program
    {
        static void Main(string[] args)
        {
            string dr = "/+1-541-754-3010 156 Alphand_St. <J Steeve>\n 133, Green, Rd. <E Kustur> NY-56423 ;+1-541-914-3010\n"
                + "+1-541-984-3012 <P Reed> /PO Box 530; Pollocksville, NC-28573\n :+1-321-512-2222 <Paul Dive> Sequoia Alley PQ-67209\n"
                + "+1-741-984-3090 <Peter Reedgrave> _Chicago\n :+1-921-333-2222 <Anna Stevens> Haramburu_Street AA-67209\n"
                + "+1-111-544-8973 <Peter Pan> LA\n +1-921-512-2222 <Wilfrid Stevens> Wild Street AA-67209\n"
                + "<Peter Gone> LA ?+1-121-544-8974 \n <R Steell> Quora Street AB-47209 +1-481-512-2222\n"
                + "<Arthur Clarke> San Antonio $+1-121-504-8974 TT-45120\n <Ray Chandler> Teliman Pk. !+1-681-512-2222! AB-47209,\n"
                + "<Sophia Loren> +1-421-674-8974 Bern TP-46017\n <Peter O'Brien> High Street +1-908-512-2222; CC-47209\n"
                + "<Anastasia> +48-421-674-8974 Via Quirinal Roma\n <P Salinger> Main Street, +1-098-512-2222, Denver\n"
                + "<C Powel> *+19-421-674-8974 Chateau des Fosses Strasbourg F-68000\n <Bernard Deltheil> +1-498-512-2222; Mount Av.  Eldorado\n"
                + "+1-099-500-8000 <Peter Crush> Labrador Bd.\n +1-931-512-4855 <William Saurin> Bison Street CQ-23071\n"
                + "<P Salinge> Main Street, +1-098-512-2222, Denve\n" + "<P Salinge> Main Street, +1-098-512-2222, Denve\n";

<<<<<<< HEAD
            Console.WriteLine(Phone(dr, "48-421-674-8974"));
            Console.WriteLine(Phone(dr, "1-921-512-2222"));
            Console.WriteLine(Phone(dr, "1-908-512-2222"));
            Console.WriteLine(Phone(dr, "1-541-754-3010"));
            Console.WriteLine(Phone(dr, "1-121-504-8974"));
            Console.WriteLine(Phone(dr, "1-498-512-2222"));
=======
            //Phone(dr, "48-421-674-8974");
            //Phone(dr, "1-921-512-2222");
            //Phone(dr, "1-908-512-2222");
            //Phone(dr, "1-541-754-3010");
            //Phone(dr, "1-121-504-8974");
            //Phone(dr, "1-498-512-2222");
>>>>>>> origin/master
            Console.WriteLine(Phone(dr, "1-098-512-2222"));
            Console.WriteLine(Phone(dr, "5-555-555-5555"));
        }

        public static string Phone(string strng, string num)
        {
            string returnedContact = "";
            List<string> contacts = Contacts(strng);
            bool contactFound = true;
            foreach (string contact in contacts)
            {
                if (!contact.Contains(num))
<<<<<<< HEAD
                    contactFound = false;
                else
                {
                    contactFound = true;
                    if (returnedContact != "" && returnedContact != "Error => Not found: nb")
                        returnedContact = "Error => Too many people: " + num;
                    else
                    {
                        string name = contact.Substring(contact.IndexOf('<') + 1, LengthOfName(contact) - 1);
                        changedContactString.Replace("<" + name + ">", "");
                        changedContactString.Replace("+" + num, "");

                        string address = Regex.Replace(changedContactString.ToString().Replace(";", "").Replace("?", "").Replace(",", "").Replace("$", "").Replace("/", "").Replace(":", "").Replace("*", "").Replace("!", "").Replace("_", ""), @"\s+", " ");
                        returnedContact = "Phone => " + num + ", Name => "  + name + ", Address => " + address;
=======
                {
                    returnedContact = "Error => Not found: nb";
                }
                else
                {
                    if (returnedContact != "")
                    {
                        returnedContact = "Error => Too many people: nb";
                    }
                    else
                    {
                        bool count = false;
                        foreach(char c in contact)
                        {
                            if (c == '<')
                            {

                            }
                        }
                        string name = "";
                        for (int i = 0; i < contact.Length; i++)
                        {
                            if (name.Substring(name.IndexOf('<'), name.Length - ))
                            {

                            }
                        }
>>>>>>> origin/master
                    }
                }
            }
            if (!contactFound && returnedContact == "")
                returnedContact = "Error => Not Found: " + num;

            return returnedContact;
        }

        public static List<string> Contacts(string contacts)
        {
            bool done = false;
            List<string> contactsList = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            char c = contacts[0];
            int counter = 0;

            while (!done)
            {
                stringBuilder.Append(c);
                if (c == '\n')
                {
                    stringBuilder.Remove(stringBuilder.Length - 1, 1);
                    contactsList.Add(stringBuilder.ToString());
                }

                counter++;
                c = contacts[counter];
                if (counter == contacts.Length - 1)
                    done = true; 
            }

            return contactsList;
        }

<<<<<<< HEAD
        private static int LengthOfName(string contact)
        {
            bool count = false;
            int counter = 0;
            foreach (char c in contact)
            {
                if (c == '<')
                    count = true;
                if (c == '>')
                    count = false;

                if (count)
                    counter++;

            }
            return counter;
        }
=======
        //private string example()
        //{
        //    string pattern = "@\\d+";
        //    string text = "My favorite number is 8, while yours is 24.";

        //    Regex regex = new Regex(pattern);

        //    return regex.Match(text).ToString();
        //}


>>>>>>> origin/master
    }
}

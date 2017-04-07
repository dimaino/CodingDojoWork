using System;
using DbConnection;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool doingStuff = true;
            while(doingStuff)
            {
                System.Console.WriteLine("Select what you would like to do. Type of of these commands: ('View', 'Insert', 'Update', 'Delete', 'Everything else will exit')");
                string command = Console.ReadLine();
                switch(command)
                {
                    case "View":
                        ViewDataBase();
                        break;
                    case "Insert":
                        insertQuery();
                        break;
                    case "Update":
                        updateQuery();
                        break;
                    case "Delete":
                        deleteQuery();
                        break;
                    default:
                        doingStuff = false;
                        break;
                }       
            }
        }

        public static void deleteQuery()
        {
            int idEntered = checkForANumber();
            string deleteQuery = "DELETE FROM users WHERE id = " + idEntered;
            DbConnector.Execute(deleteQuery);
        }
        public static string[] userInput()
        {
            string[] usersInformation = new string[2];
            System.Console.Write("Please enter in your First Name: ");
            string first_name = Console.ReadLine();
            usersInformation[0] = first_name;
            while(first_name.Length == 0)
            {
                System.Console.Write("Please enter in your First Name: ");
                first_name = Console.ReadLine();
                usersInformation[0] = first_name;
            }
            System.Console.Write("Please enter in your Last Name: ");
            string last_name = Console.ReadLine();
            usersInformation[1] = last_name;
            while(last_name.Length == 0)
            {
                System.Console.Write("Please enter in your Last Name: ");
                last_name = Console.ReadLine();
                usersInformation[1] = last_name;
            }
            return usersInformation;
        }
        public static void ViewDataBase()
        {
            List<Dictionary<string, object>> query = DbConnector.Query("SELECT * FROM users");
            foreach(Dictionary<string, object> i in query)
            {
                System.Console.WriteLine(i["id"] + " " + i["FirstName"] + " " + i["LastName"] + " " + i["FavoriteNumber"] + " " + i["created_at"] + " " + i["updated_at"]);
            }
        }
        public static int checkForANumber()
        {
            System.Console.Write("Please enter in a Number: ");
            string str = Console.ReadLine();
            int number = 0;
            try
            {
                number = Convert.ToInt32(str);
            }
            catch(FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            while(number == 0)
            {
                System.Console.Write("Please enter in a Number: ");
                str = Console.ReadLine();
                try
                {
                    number = Convert.ToInt32(str);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return number;
        }
        public static void insertQuery()
        {
            string[] str = userInput();
            int favNumber = checkForANumber();
            //System.Console.WriteLine("INSERT INTO users (FirstName, LastName, FavoriteNumber, created_at, updated_at) VALUES ('" + str[0] + "', '" + str[1] + "', '" + favNumber + "', NOW(), NOW())");
            DbConnector.Execute("INSERT INTO users (FirstName, LastName, FavoriteNumber, created_at, updated_at) VALUES ('" + str[0] + "', '" + str[1] + "', " + favNumber + ", NOW(), NOW())");
        }
        public static void updateQuery()
        {
            string[] str = userInput();
            int favNumber = checkForANumber();
            int idEntered = checkForANumber();
            DbConnector.Execute("UPDATE users SET FirstName ='" + str[0] + "', LastName ='" + str[1] + "', FavoriteNumber ='" + favNumber + ", updated_at = NOW() WHERE id = " + idEntered);
        }
    }
}

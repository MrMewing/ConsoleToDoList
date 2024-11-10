using System.Collections.Generic;
using System;
using ConsoleApp4;

namespace code
{

    class Code
    {
        static void Main(String[] args)
        {

            String UserName = Start();
            List<ListSys> list = new List<ListSys>();

            Options(UserName, list);


        }

        static string Start()
        {

            String UserName = "user";


            Console.WriteLine($"Welcome to the To-Do-List! {UserName}");

            while (true)
            {
                if (UserName == "user")
                {
                    while (true)
                    {
                        Console.Write("What's your name? ");
                        UserName = Console.ReadLine();
                        Console.WriteLine($"Ok, set user as {UserName}? ");
                        String input = Console.ReadLine().ToLower();

                        if (input == "yes" || input == "y")
                        {
                            break;
                        }
                        else if (input == "no" || input == "n")
                        {
                            Console.WriteLine("Ok, going again! ");
                        }
                        else
                        {
                            Console.WriteLine("Insert a valid answer! ");
                        }
                    }




                }
                return UserName;
                Console.Clear();
                break;


            }
        }
        static void ReorganizeList(List<ListSys> List)
        {
            
            for (int i = 0; i < List.Count; i++) 
            {
                List[i].index = i;  
            }

        }
        static void Options(String UserName, List<ListSys> list)
        {
            Console.WriteLine($"Ok {UserName}, what you want to do?");
            while (true)
            {
                Console.WriteLine("\tOptions: \n 1.See current To-Do's \n 2.Create a new To-Do \n 3.Delete a To-Do \n 4.Modify my To-Do's\n 5.Exit\n");
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            if (list.Any())
                            {
                                foreach (ListSys item in list)
                                {

                                    Console.WriteLine($"{item.ObjectiveName} \n {item.ObjectiveDesc} \n Created: {item.CreationDateAndTime} \n Is done? {UtilityChars.DoneASCII(item.IsDone)} ID: {item.index}\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Theres no items on the list.");

                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Set the name to \"/*\" cancel this operation!");

                            Console.WriteLine("Set the name of your To-Do");
                            String ObjName = Console.ReadLine();
                            if (ObjName == "/*")
                            {
                                Console.Clear();
                                break;
                            }
                            Console.WriteLine("Now, set the description of your To-Do");
                            String ObjDesc = Console.ReadLine();


                            DateTime today = DateTime.Now;
                            ListSys Item = new ListSys(ObjName, ObjDesc, Convert.ToString(DateTime.Now), ListSys.GlobalIndexCounter);
                            int Amount = ListSys.GlobalIndexCounter - 1;
                            list.Add(Item);
                            Console.Clear();
                            Console.WriteLine($"Name: {list[Amount].ObjectiveName} \n Desc: {list[Amount].ObjectiveDesc}\n");
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Insert the ID of the Objective that you want to delete or type \"E\" to exit");
                            string ObjChoice = Console.ReadLine();

                            if (ObjChoice.ToLower() != "e")
                            {

                                list.Remove(list[Convert.ToInt32(ObjChoice)]);
                                Console.Clear();
                                Console.WriteLine("Item removed successfully");
                                ListSys.GlobalIndexCounter--;
                                ReorganizeList(list);
                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }

                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("Type the ID of the To-Do to toggle the checkmark. Type \"E\" to cancel.");
                            String ChoosenID = Console.ReadLine();
                            if (ChoosenID.ToLower() != "e")
                            {
                                if (list[Convert.ToInt32(ChoosenID)].IsDone)
                                {
                                    list[Convert.ToInt32(ChoosenID)].IsDone = false;
                                }
                                else
                                {
                                    list[Convert.ToInt32(ChoosenID)].IsDone = true;
                                }

                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Insert valid option\n");
                            Console.Clear();

                            break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();   
                    Console.WriteLine("Insert valid digit!");

                   
                    
                }
                
            }


        }
    }
}
    

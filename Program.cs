using System;
using System.Collections.Generic;
using System.Linq;
namespace CRUDAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Title: C# Introduction Assignment – CRUD
                Purpose: Allows user to Add, Edit, Delete and Display dataset.
                Author: Oleg Eremeev
                Last Modified: August 16, 2020
            */
			
			//Declair variables and Generate List
			List<int> myNumbers = new List<int>();
			int numInput = -1;

			//While loop to facilitate EXIT point for program
			while (numInput != 0)
			{
				Console.WriteLine("Menu\n------\n1. Add \n2. Edit \n3. Delete \n4. Display \n5. Display By Descending Order \n0. Exit");

				Console.Write("Please select your menu option: ");
				numInput = int.Parse(Console.ReadLine().Trim()); // Trim feature in every ReadLine method
				//Switch to accomodate 5 MENU options (Add, Edit, Delete, Read, Display in Descenting order, and Exit)
				switch (numInput)
				{
					case 1:	//method calls Add function
						Console.WriteLine("Menu / ADD\n----------\n This Array takes maximum 10 entries");				
						PopulateList(myNumbers);
						break;

					case 2: //method calls Edit function
						Console.WriteLine("Menu / EDIT\n----------\n1. Return to Main MENU press 0 \n ");
						EditList(myNumbers);
						break;

					case 3: //method calls Delete function
						Console.WriteLine("Menu / DELETE\n----------\n Auto returns to main MENU when you deleted your number");
					    DeleteValue(myNumbers);
						break;

					case 4: //for loop to Display Array list
						Console.WriteLine("Menu / DISPLAY\n-----------\n This is latest Array");
						for (int i = 0; i < myNumbers.Count; i++)
						{
							Console.WriteLine($"#{i + 1} => " + myNumbers[i]);
						}
						break;

					case 5: //for loop to Display Array list in descending order
						Console.WriteLine("Menu / DISPLAY DSC Order\n-----------\n This is Dsc Order Array");
						var sortedValues = myNumbers.OrderByDescending(v => v).ToList(); 
						 for (int i = 0; i < myNumbers.Count; i++)
						{
							Console.WriteLine($"#{i + 1} => " + sortedValues[i]);
						} 
						break;
					
					/* case 6:
					int x;
						Console.WriteLine("Menu / DISPLAY Only Ligal Ages \n-----------\n Legal Ages Array");
						
						 
							//myNumbers.Sort();
							foreach (int x in myNumbers)
							{	
								var cutValues = myNumbers.Where(v => v.x >= 18); 
								
								for (int i = 0; i < myNumbers.Count; i++)
									{
											
											Console.WriteLine($"#{i + 1} => " + cutValues[i]);
									} 
									Console.WriteLine(x);
							} 
						
						
						
						break; */

					default:
						Console.WriteLine("DONE...");
						break;
				}

			}
            //EXIT
        }
		static void EditList(List<int> altList)
        {			
			bool  i;
			bool valid = false;
			do           // do loop: step 1 - check if chosen number is present inside the list
			{
				Console.Write("2. What number you want to Replace or press 0: ");
				int x = int.Parse(Console.ReadLine().Trim());
				i = altList.Contains(x);
				if (i == true)
				{
					altList.Remove(x);  // step 2 - if the numbers exists then delete it

						 if (i == true)
					{                   // step 3 - offer user to insert different value at the beggining of list
						Console.Write("3. What number you want to Insert or type 0: ");
						int y = int.Parse(Console.ReadLine().Trim());
						altList.Insert(0, y); //tried to insert new value in to erased index but it didn't work -> 
						//altList.Insert(altList.FindIndex(x), y); 1503 error
					}
				}
				else                 // step 4 - if entered value from step 1 doesn't exist, then exit Edit(sub menu)
				{
					Console.WriteLine("No such data");
					valid = true;
				}
				
			} while (!valid);

		}
		static void DeleteValue(List<int> newList)
			{
					// find the value that user wants to erase and delete it, just one attempt
			 	Console.Write("Type what number you want to delete: ");
				
					for (int i = 0; i < 1; i++) 
					{	//just 1 attempt to delete value, if need more then user can come back here do it again
						newList.Remove(int.Parse(Console.ReadLine().Trim()));
					}
			}
			
		static void PopulateList(List<int> theList)
		{   // for loop to Add entered values by user to a list one by one. Values are asking for Age( from 1  -100)
			for (int i = 0; i < 10; i++) //Limit user to enter only 10 values
			{	// Code borrowed from class . Written by James Grieve. Modified by Oleg Eremeev for List usage
				theList.Add(GetValidInt($"Enter the AGE of a customer #{i + 1}: ", 1, 100));
			}
		}

		static int GetValidInt(string prompt, int min, int max)
		{   // static int Access Modifier because it returns value myInt
			bool valid = false;
			int myInt = -1;
			// do loop to hold Try Catch technique to throw Exceptions during value entry procedure 
			do
			{
				Console.Write(prompt);
				try
				{	
					myInt = int.Parse(Console.ReadLine().Trim());
					//check if each value is within range (1-100)
					if (myInt < min || myInt > max)
					{
						// throw an exception when IF Statment is true
						throw new Exception("Provided integer was outside of the bounds specified.");
						
					}
					// 1 Scenario - When user enters good value and above IF Statment is not activated(false), 
					// then skip this line and jump to while(ivalid) bool statment and continue to record value
					// 2 Scenario - When user enters a string it goes all the way to catch Excemption and prints
					// a warrning message
					// 3. Scenario - When user enters value out or range, then above IF Statment will catch it and
					// pass it to catch (Exception ex) line and would print another warrning message
					
					valid = true;
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Parse failed: {ex.Message}");
				}
			} while (!valid);
			// return value to the PopulateMethod for storage only when its a good value. 
			return myInt;
		}
    }
}
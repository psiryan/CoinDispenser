using System;
using System.Linq.Expressions;

namespace CoinDispenser{
    class CoinDispenser{
        static void Main(String[] args){
            bool cont = true; // Main loop condition
            while(cont){ // Main Loop
                cont = Menu();
            } //When cont is false, then exit the program         
        }
    
        static bool Menu(){
            string choice;
            
            Console.Clear();
            Console.WriteLine("######## Coin Dispenser ########");
            Console.WriteLine("1. Make Change using division method");
            Console.WriteLine("2. Make Change using Subtraction method");
            Console.WriteLine("3. Exit");
            Console.WriteLine("################################");
            choice = Console.ReadLine()!; //using ! operator at the end of the method call in this case will forgive if the input is a null value (https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/compiler-messages/nullable-warnings?f1url=%3FappId%3Droslyn%26k%3Dk(CS8600)#possible-null-assigned-to-a-nonnullable-reference)

            if(choice == "1"){ // Option 1
                double amount, tender, changeDue, remainder;
                int quarters, dimes, nickles, pennies;

                Console.Write("Please enter cost of item: ");
                amount = Convert.ToDouble(Console.ReadLine()!);
                Console.WriteLine("Please enter the payment amount:");
                tender = Convert.ToDouble(Console.ReadLine()!);

                // Determine changeDue
                changeDue = tender - amount;
                
                // is changeDue > 0.25?
                quarters = ((int)Double.Truncate(changeDue/0.25)); // The (int) is type casting (aka converting) the double value to an integer
                remainder = changeDue%0.25; // getting the initial remainder, but keeping the changeDue so that we can report it later

                // is changeDue > 0.10?
                dimes = ((int)Double.Truncate(remainder/.10));
                remainder %= 0.10; // same as remainder = remainder % 0.10

                // is changeDue > 0.05?
                nickles = ((int)Double.Truncate(remainder/0.05));
                remainder %= 0.05; // same as remainder = remainder % 0.05

                // is changeDue > 0.01?
                pennies = ((int)Double.Truncate(remainder/.01));
                remainder %= 0.01; // same as remainder = remainder % 0.01

                showReport(changeDue, quarters, dimes, nickles, pennies); // gets it own method since I will report no matter how I approach the problem

                return true; // Return to Menu
            } 
            else if(choice == "2"){ // Option 2            
                const double q = 0.25;
                const double d = 0.10;
                const double n = 0.05;
                const double p = 0.01;
                double cost, paid, changeDue, remainder;
                int quarters, dimes, nickles, pennies;

                quarters = 0;
                dimes = 0;
                nickles = 0;
                pennies = 0;

                Console.Write("Please enter cost of item: ");
                cost = Convert.ToDouble(Console.ReadLine()!);
                Console.WriteLine("Please enter the payment amount:");
                paid = Convert.ToDouble(Console.ReadLine()!);

                changeDue = paid - cost;
                remainder = changeDue;
                while (remainder > q){ //using a while loop
                    quarters++;
                    remainder -= q; // same as amount = amount - 0.25
                }
                while (remainder > d){ //using a while loop
                    dimes++;
                    remainder -= d; // same as amount = amount - 0.10
                }
                while (remainder > n){ //using a while loop
                    nickles++;
                    remainder -= n; // same as amount = amount - 0.05
                }
                while (remainder > p){ //using a while loop
                    pennies++;
                    remainder -= p; // same as amount = amount - 0.01
                }
                
                // changeDue = Quarters(changeDue, ref quarters);

                showReport(changeDue, quarters, dimes, nickles, pennies);

                return true;
            }
            else if(choice == "3"){ // Option 3
                return false; // Leave Menu
            }
            else{ //Handle undefined Input
                Console.WriteLine("Please enter a value from one of the menu choices.");
                Console.ReadLine();
                return true; // Return to Menu
            }
        }

        static void showReport(double changeDue, int quarters, int dimes, int nickles, int pennies){
            // Show changeDue Report
            Console.WriteLine("Report:");
            Console.WriteLine("Change Due: " + changeDue);
            if(quarters ==  1){
                Console.WriteLine(quarters + " Quarter");                
            } else {
                Console.WriteLine(quarters + " Quarters");
            }
            if(dimes == 1){
                Console.WriteLine(dimes + " Dime");
            }else{
                Console.WriteLine(dimes + " Dimes");
            }
            if(nickles == 1){
                Console.WriteLine(nickles + " Nickle");
            }else{
                Console.WriteLine(nickles + " Nickles");
            }
            if(pennies == 1){
                Console.WriteLine(pennies + " Penny");
            }else{
                Console.WriteLine(pennies + " Pennies");
            }
            Console.ReadLine();
        }



    }
}
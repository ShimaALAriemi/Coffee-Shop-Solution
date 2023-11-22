using System.Drawing;

namespace Coffee_Shop
{
    internal class Program
    {
        static List<string> coffee = new List<string>() {"Americano", "Latte" , "Cappuccino"};
        static List<double> price = new List<double>() { 2.50, 3.00, 3.50 };
        static List<string> size = new List<string>() { "Small", "Medium", "Large" };
        static List<double> sizePrice = new List<double>() { 0.50 ,0.70, 1.0};

        static void display_menu()
        {

            Console.WriteLine("Welcome to the Coffee Shop!\n" +
                "Menu:" +
                $"\n\t1.{coffee[0]} - ${price[0]}" +
                $"\n\t2.{coffee[1]} - ${price[1]}" +
                $"\n\t3.{coffee[2]} - ${price[2]}");

            //Calling place_order() that will return value pass it to display_order_summaryy() function
            display_order_summaryy(place_order());
        }

        static List<string> place_order()
        {
            List<string> userOrder = new List<string>();

            
            int coffeeNumber;
            do { 

            Console.WriteLine("\nSelect a coffee (1-3):");
            }while(!int.TryParse(Console.ReadLine(), out coffeeNumber) || coffeeNumber > coffee.Count);
            userOrder.Add(coffee[coffeeNumber-1]);


            int coffeeSize;
            do
            {

             Console.WriteLine("\nSelect a size (1-3):"
                 + $"\nCustomizations:" +
                 $"\n\t1.{size[0]} - ${sizePrice[0]}" +
                 $"\n\t2.{size[1]} - ${sizePrice[1]}" +
                 $"\n\t3.{size[2]} - ${sizePrice[2]}");
            } while (!int.TryParse(Console.ReadLine(), out coffeeSize) || coffeeSize > size.Count);
            userOrder.Add(size[coffeeSize-1]);

            String sugar;
            String sugarWanted;
            do {
                Console.WriteLine("Do you want sugar? (yes/no): ");
                 sugar = Console.ReadLine().ToLower().Trim();
                 sugarWanted = (sugar == "yes" || sugar == "y") ? " with sugar" : " without sugar";
            } while (!(sugar == "yes" || sugar =="no" || sugar == "n" || sugar == "y")); 
            userOrder.Add(sugarWanted);

            String milk;
            String milkWanted;
            do {
                Console.WriteLine("Do you want milk? (yes/no): ");
                milk = Console.ReadLine().ToLower().Trim();
                milkWanted = (milk == "yes" || milk == "y") ? " with milk" : " without milk";
            } while (!(milk == "yes" || milk == "no" || milk == "n" || milk == "y"));
            userOrder.Add(milkWanted);


            //Calling calculate_cost() function
            double totalCost = calculate_cost(coffee[coffeeNumber-1], size[coffeeSize - 1]);

            userOrder.Add(totalCost.ToString());

            return userOrder;
        }

        static double calculate_cost(string selected_coffee, string sizee)
        {
            double cost = price[coffee.IndexOf(selected_coffee)] + sizePrice[size.IndexOf(sizee)];
            return cost;
        }

        static void display_order_summaryy(List<string> userOrder)
        {
            Console.Write("\nYour Order Summary: ");
            for (int i = 0; i < userOrder.Count-1; i++) Console.Write($"{userOrder[i]}  ");
            Console.WriteLine();
            Console.WriteLine($"\nTotal Cost:${price[coffee.IndexOf(userOrder[0])]}" +
                $" + ${sizePrice[size.IndexOf(userOrder[1])]} =  ${userOrder[userOrder.Count-1]}");
            Console.WriteLine("\nThank you for ordering!");

        }

        static void Main(string[] args)
        {
            // calling display_menu() to start ordering
            display_menu();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotQuickbooks
{
    class Program
    {
        static void Main(string[] args)
        {
            store MyStore = new store();
            MyStore.RunMenu();
        }


    }

    abstract class Item
    {
        public Item(string n, double p, int q)
        {
            Name = n;
            Price = p;
            Quantity = q;
        }
        protected string Name { get; set; }
        protected string MyType { get; set; }
        protected double Price { get; set; }
        protected int Quantity { get; set; }

        abstract public void Sell(int n);
        abstract public void Restock(int n);
        abstract public void Info();
        public int GetQuantity()
        {
            return Quantity;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetType()
        {
            return MyType;
        }

        public double GetPrice()
        {
            return Price;
        }


    }

    class Book : Item
    {
        public Book(string n, double p, int q ) : base(n, p, q)
        {
            MyType = "book";
        }
        public override void Info()
        {
            Console.WriteLine($"A book by the name of {Name}");
        }

        public override void Restock(int n)
        {
            if (n >= 0)
            {
                Quantity += n;
            }
            else
            {
                Console.WriteLine("Invalid number used. No action taken.");
            }

        }

        public override void Sell(int n)
        {
            if (n <= Quantity && n >= 0)
            {
                Quantity -= n;
                Console.WriteLine($"The total is {n * Price}");
            }
            else
            {
                Console.WriteLine("Invalid number used. No action taken.");
            }
        }
    }

    class Fruit : Item
    {
        public Fruit(string n, double p, int q) : base(n, p, q)
        {
            MyType = "fruit";
        }
        public override void Info()
        {
            Console.WriteLine($"A fruit by the name of {Name}");
        }

        public override void Restock(int n)
        {
            if (n >= 0)
            {
                Quantity += n;
            }
            else
            {
                Console.WriteLine("Invalid number used. No action taken.");
            }
        }

        public override void Sell(int n)
        {
            if (n <= Quantity && n >=0)
            {
                Quantity -= n;
                Console.WriteLine($"The total is {n * Price}");
            }
            else
            {
                Console.WriteLine("Invalid number used. No action taken.");
            }
        }
    }

    class Ambrosia : Item
    {
        public Ambrosia(string n, double p, int q) : base(n, p, q)
        {
            MyType = "ambrosia";
        }
        public override void Info()
        {
            Console.WriteLine($"Ambrosia by the name of {Name}");
        }

        public override void Restock(int n)
        {
            if (n >= 0)
            {
                Quantity += n;
            }
            else
            {
                Console.WriteLine("Invalid number used. No action taken.");
            }
        }

        public override void Sell(int n)
        {
            if (n <= Quantity && n >= 0)
            {
                Quantity -= n;
                Console.WriteLine($"The total is {n * Price}");
            }
            else
            {
                Console.WriteLine("Invalid number used. No action taken.");
            }
        }
    }

    class store
    {
        List<Item> Items;
        string command;
        string n;
        double p;
        int q;
        int counter;

        public store()
        {
            Items = new List<Item>();
        }
        public void RunMenu()
        {
            Console.WriteLine("Welcome to the store!");

            do
            {
                Console.WriteLine("Pick the number of one of the following actions below: ");
                Console.WriteLine("1. Add an item.");
                Console.WriteLine("2. Sell an item.");
                Console.WriteLine("3. Restock an item.");
                Console.WriteLine("4. See info on all items.");
                Console.WriteLine("5. Quit");
                command = Console.ReadLine();

                if (command == "1")
                {
                    AddItem();
                }
                else if (command == "2")
                {
                    SellItem();
                }
                else if (command == "3")
                {
                    RestockItem();
                }
                else if (command == "4")
                {
                    Console.WriteLine();
                    PrintInfo();
                }
                else if (command == "5")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid command try again.");
                }
                Console.WriteLine();

            } while (true);
        }

        void AddItem()
        {
            Console.WriteLine("What kind of item do you want to add?");
            Console.Write("1.Book, 2.Fruit, or 3.Ambrosia: ");
            command = Console.ReadLine();
            Console.Write("What is the name of the item: ");
            n = Console.ReadLine();
            Console.Write("What is the price of the item: ");
            p = Convert.ToDouble(Console.ReadLine());
            Console.Write("How many do you have: ");
            q = Convert.ToInt32(Console.ReadLine());

            if (command == "1")
            {
                Items.Add(new Book(n,p,q));

            }
            else if (command == "2")
            {
                Items.Add(new Fruit(n, p, q));
            }
            else if (command == "3")
            {
                Items.Add(new Ambrosia(n, p, q));
            }
            else
            {
                Console.WriteLine("Invalid command entered, please try again.");
            }
        }

        void SellItem()
        {
            int ItemPosition = -1;
            int NumToSell = 0;
            if (Items.Count == 0)
            {
                Console.WriteLine("There are no items in stock to sell.");
                return;
            }
            
            
            Console.WriteLine();
            PrintInfo();
            Console.WriteLine("What item do you want to sell:");
            ItemPosition += Convert.ToInt32(Console.ReadLine());

            if(Items[ItemPosition].GetQuantity() == 0)
            {
                Console.WriteLine("There were none to sell.");
                return;
            }
            Console.Write($"You have {Items[ItemPosition].GetQuantity()}. How many do you want to sell: ");
            NumToSell = Convert.ToInt32(Console.ReadLine());

            Items[ItemPosition].Sell(NumToSell);

        }

        void RestockItem()
        {
            int ItemPosition = -1;
            int NumToAdd = 0;

            Console.WriteLine();
            PrintInfo();
            Console.WriteLine("What item do you want to restock:");
            ItemPosition += Convert.ToInt32(Console.ReadLine());

            Console.Write($"You have {Items[ItemPosition].GetQuantity()}. How many are you adding: ");
            NumToAdd = Convert.ToInt32(Console.ReadLine());

            Items[ItemPosition].Restock(NumToAdd);
        }

        void PrintInfo()
        {
            counter = 1;
            foreach (var item in Items)
            {
                Console.Write($"{counter}. ");
                item.Info();
                counter += 1;
            }
        }
    }
}

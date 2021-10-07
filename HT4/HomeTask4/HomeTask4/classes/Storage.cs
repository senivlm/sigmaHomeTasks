using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HomeTask2.classes
{
    public class Storage
    {
        private Product[] products;
        (int, int, int) Koefs;
        bool IsInitialised = false;

        public Storage() { }

        public void ChangePrices(double _percentage)
        {
            foreach (var product in products)
            {
                product.ChangePrice(Percentage: _percentage, Koefs);
            }
        }


        public Product this[int Index]
        {
            get { return products[Index]; }
            set { products[Index] = value; }
        }

        public void GetFullInfo()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product + "\n");
            }
        }

        public Product[] GetAllMeatProducts()
        {
            Product[] meat;
            int CountOfMeatProducts = 0;

            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] is Meat)
                {
                    CountOfMeatProducts++;
                }
            }

            meat = new Product[CountOfMeatProducts];
            CountOfMeatProducts = 0;

            for (int i = 0; i < products.Length; i++)
            {
                if (products[i] is Meat)
                {
                    meat[CountOfMeatProducts++] = products[i];
                }
            }

            return meat;
        }

        public void GetBadDairyProducts(string filePath) 
        {
            string result = "";
            Dairy_products dairy = null;

            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    for (int i = 0; i < products.Length; i++)
                    {
                        if ((dairy = products[i] as Dairy_products) != null)
                        {
                            if ((DateTime.Today - dairy.CreationTime).TotalDays > dairy.ExpirationDate)
                            {
                                result += $"{dairy.Name} {dairy.Weight} {dairy.Price} {dairy.ExpirationDate} {dairy.CreationTime}\n";
                                products[i] = null;
                            }
                        }
                    }

                    sw.Write(result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to get bad dairy products: " + ex.Message);
            }
        }

        public void StartFileInitialisation(string filePath) 
        {
            string[] initialisationParameters = null;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    initialisationParameters = sr.ReadToEnd().Split('\n');

                    products = new Product[initialisationParameters.Length - 1];
                    try
                    {
                        string[] koefs = initialisationParameters[0].Split();

                        Koefs.Item1 = Convert.ToInt32(koefs[0]);
                        Koefs.Item2 = Convert.ToInt32(koefs[1]);
                        Koefs.Item3 = Convert.ToInt32(koefs[2]);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Impossible to start initialisation of storage - invalid koefs");
                    }

                    string[] productInitialisationParameters = null;

                    try
                    {
                        for (int i = 1; i < initialisationParameters.Length; i++)
                        {
                            productInitialisationParameters = initialisationParameters[i].Split('|');

                            switch (productInitialisationParameters[0])
                            {
                                case ("Meat"):
                                    products[i - 1] = new Meat();
                                    //products[i - 1].Parse(productInitialisationParameters[1]);
                                    break;
                                case ("Dairy"):
                                    products[i - 1] = new Dairy_products();
                                    //products[i - 1].Parse(productInitialisationParameters[1]);
                                    break;
                                case ("Classic"):
                                    products[i - 1] = new Product();
                                    break;

                                default:
                                    throw new Exception("Impossible to start initialisation of instance in storage - invalid product type");
                                    break;
                            }

                            products[i - 1].Parse(productInitialisationParameters[1]);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error occured on units initialisation stage: " + ex.Message);
                    }

                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Storage initialisation from file failed: " + ex.Message);
            }

            IsInitialised = true;
        }



        public void StartFastInitialisation(int k1, int k2, int k3, params Product[] _paramsProducts)
        {
            if (IsInitialised)
            {
                return;
            }

            products = new Product[_paramsProducts.Length];
            IsInitialised = true;
            for (int i = 0; i < _paramsProducts.Length; i++)
            {
                products[i] = _paramsProducts[i].Copy();
            }

            Koefs = (k1, k2, k3);
        }

        public void StartSlowInitialisation()
        {
            if (IsInitialised)
            {
                return;
            }

            Console.WriteLine("How much elemests shoud your storage have?");
            int Count = Convert.ToInt32(Console.ReadLine());
            this.products = new Product[Count];
            IsInitialised = true;

            for (int i = 0; i < Count; i++)
            {
                Console.WriteLine($"Prod #{i + 1}");
                Console.WriteLine("Which type of product do you want to insert?\n1.Classic\n2.Meat\n3.Dairy\n");
                string choice = Console.ReadLine();

                string name;
                int weight;
                double price;
                int expirationDate;
                DateTime creationTime;

                switch (choice)
                {
                    case ("Classic"):
                        try
                        {
                            Console.WriteLine("Input name");
                            name = Console.ReadLine();
                            Console.WriteLine("Input weight");
                            weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input price");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expiration date");
                            expirationDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input creation time");
                            creationTime = DateTime.Parse(Console.ReadLine());

                            products[i] = new Product(_name: name, _weight: weight, _price: price, _expirationDate: expirationDate, _creationTime: creationTime);
                        }
                        catch (Exception exx)
                        {
                            throw new Exception("Impossible to initialise 'Product' object: " + exx.Message);
                        }

                        break;


                    case ("Meat"):
                        try
                        {
                            Console.WriteLine("Input name");
                            name = Console.ReadLine();
                            Console.WriteLine("Input weight");
                            weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input price");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expiration date");
                            expirationDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input creation time");
                            creationTime = DateTime.Parse(Console.ReadLine());

                            Type t = 0;
                            Console.WriteLine("\nChoose type\nLamb\nVeal\nPork\nChicken\n");

                            switch (Console.ReadLine())
                            {
                                case ("Lamb"):
                                    t = Type.Lamb;
                                    break;
                                case ("Veal"):
                                    t = Type.Veal;
                                    break;
                                case ("Pork"):
                                    t = Type.Pork;
                                    break;
                                case ("Chicken"):
                                    t = Type.Chicken;
                                    break;
                            }
                            Console.WriteLine("\nChoose type\nGreatest\nFirst\nSecond\n");
                            Sort s = 0;
                            switch (Console.ReadLine())
                            {
                                case ("Greatest"):
                                    s = Sort.Greatest;
                                    break;
                                case ("First"):
                                    s = Sort.First;
                                    break;
                                case ("Second"):
                                    s = Sort.Second;
                                    break;
                            }

                            products[i] = new Meat(_name: name, _weight: weight, _price: price, _sort: s, _type: t, _expirationDate: expirationDate, _creationTime: creationTime);
                        }
                        catch (Exception exx)
                        {
                            throw new Exception("Impossible to initialise 'meat' object: " + exx.Message);
                        }
                        break;

                    case ("Dairy"):
                        try
                        {
                            Console.WriteLine("Input name");
                            name = Console.ReadLine();
                            Console.WriteLine("Input weight");
                            weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input price");
                            price = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expire date");
                            int ex = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input expiration date");
                            expirationDate = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Input creation time");
                            creationTime = DateTime.Parse(Console.ReadLine());

                            products[i] = new Dairy_products(_name: name, _weight: weight, _price: price, _expirationDate: expirationDate, _creationTime: creationTime);
                        }
                        catch (Exception exx)
                        {
                            throw new Exception("Impossible to initialise 'dairy' object: " + exx.Message);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid input!");
                        i--;
                        continue;
                }
            }

            int koef1, koef2, koef3;
            Console.WriteLine("\nInput koef #1:");
            koef1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nInput koef #2:");
            koef2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nInput koef #3:");
            koef3 = Convert.ToInt32(Console.ReadLine());

            Koefs = (koef1, koef2, koef3);
        }
    }
}

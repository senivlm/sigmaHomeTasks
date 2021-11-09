using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;

namespace StorageUPD
{
    public class Storage: IEnumerable<Product>
    {
        private List<Product> products;
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

//GПеремістити в стрічку 14. Події іменуюьб з великої літери.
        public event GetBadDairyProductsHandler getBadDairyProductsEvent;
        public event InvalidProductInitialisation invalidProductInitialisation;

        public static void UserInitialisation(object sender, string problemDescription)
        {//This method reinitialise last 'List<Product>' element
            if (problemDescription != null)
            {
                Console.WriteLine($"Impossible to create product object - {problemDescription}. Please initialise now");                
            }
            Storage thisObject = (Storage)sender;

            string typeOfNewProduct = null;
            Console.WriteLine("Enter type of the Product:");
            while (true)
            {
                typeOfNewProduct = Console.ReadLine();
                if (typeOfNewProduct == "Meat")
                {
                    thisObject.products[thisObject.products.Count - 1] = new MeatProduct();
                    break;
                }
                else if (typeOfNewProduct == "Dairy")
                {
                    thisObject.products[thisObject.products.Count - 1] = new DairyProduct();
                    break;
                }
                else if (typeOfNewProduct == "Classic")
                {
                    thisObject.products[thisObject.products.Count - 1] = new Product();
                    break;
                }
                else
                {
                    Console.WriteLine("Can't find this type. Try again.");
                }
            }

                        
            Console.WriteLine("Enter name of the product");
            string nameOfNewProduct = Console.ReadLine();

            Console.WriteLine("Enter weight on the product");
            int weightOfNewProduct = 0;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out weightOfNewProduct))
                {
                    break;
                }

                Console.WriteLine("Invalid input - try again");
            }


            Console.WriteLine("Enter price of the product");
            double priceOfNewProduct = 0;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out priceOfNewProduct))
                {
                    break;
                }

                Console.WriteLine("Invalid input - try again");
            }

            
            Console.WriteLine("Enter expirationDate of the product");
            int expirationDateOfNewProduct = 0;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out expirationDateOfNewProduct))
                {
                    break;
                }

                Console.WriteLine("Invalid input - try again");
            }


            Console.WriteLine("Enter creation date");
            string creationDateOfNewProduct = "";
            DateTime time;
            while (true)
            {
                creationDateOfNewProduct = Console.ReadLine();
                if (DateTime.TryParse(creationDateOfNewProduct, out time))
                {
                    break;
                }

                Console.WriteLine("Invalid input - try again");

            }


            if (typeOfNewProduct == "Classic" || typeOfNewProduct == "Dairy")
            {
                thisObject.products[thisObject.products.Count - 1].Parse($"{nameOfNewProduct} {weightOfNewProduct}" +
                    $" {priceOfNewProduct} {expirationDateOfNewProduct} {creationDateOfNewProduct}");
            }
            else
            {
                Console.WriteLine("Enter type of meat product: ");
                string typeOfMeat = Console.ReadLine();
                while (typeOfMeat != "Lamb" && typeOfMeat != "Veal" && typeOfMeat != "Pork" && typeOfMeat != "Chicken") 
                {
                    Console.WriteLine("Invalid input - try again");
                    typeOfMeat = Console.ReadLine();
                }


                Console.WriteLine("Enter sort of meat product: ");
                string sortOfMeat = Console.ReadLine();
                while (sortOfMeat != "Greatest" && sortOfMeat != "First" && sortOfMeat != "Second")
                {
                    Console.WriteLine("Invalid input - try again");
                    sortOfMeat = Console.ReadLine();
                }

                thisObject.products[thisObject.products.Count - 1].Parse($"{nameOfNewProduct} {weightOfNewProduct}" +
                    $" {priceOfNewProduct} {expirationDateOfNewProduct} {creationDateOfNewProduct} {sortOfMeat} {typeOfMeat}");
            }
        }



        public Product SearchProduct(string searchingParameter, string keyWord) //Returns null if element not found
        {
            Product searchResult = null;

            try
            {
                switch (searchingParameter)
                {
                    case ("Name"):
                        searchResult = products.Find((p) => (p.Name == keyWord));
                        break;
                    case ("Weight"):
                        searchResult = products.Find((p) => (p.Weight == Int32.Parse(keyWord)));
                        break;
                    case ("Price"):
                        searchResult = products.Find((p) => (p.Price == double.Parse(keyWord)));
                        break;

                    default:
                        break;
                }
            }
            catch { }

            return searchResult;
        }

        public void DeleteProductByName(string productToDelete) 
        {
            List<Product> prods = products.FindAll(product => (product.Name == productToDelete));
            if (prods == null)
            {
                Console.WriteLine($"No {productToDelete} in collection - can't delete it");
            }
            else
            {
                products.RemoveAll((prod) => prods.Contains(prod));
            }
        }

        #region AddProductMethods
        public void AddRange(Product[] productArray)
        {
            foreach (Product product in productArray)
            {
                if (product != null)
                {
                    products.Add(product);
                }
                else
                {
                    products.Add(null);
                    invalidProductInitialisation?.Invoke(this, "Impossible to add unexisting product to the list");                    
                }//This method reinitialise last element of collection
            }
        }

        public void AddProduct(Product product) 
        {
            products.Add(product);

            if (product == null)
            {
                invalidProductInitialisation?.Invoke(this, "Impossible to add unexisting product to the list");
                return;
            }                    
        }

        public void AddNewProduct() 
        {
            products.Add(null);
            Storage.UserInitialisation(this, null);
        }
        #endregion


        public void DeleteBadDairyProducts()
        {
            List<DairyProduct> badDairyProducts = new List<DairyProduct>();
            DairyProduct currentProduct = null;
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < products.Capacity; i++)
            {
                if ((currentProduct = products[i] as DairyProduct) != null)
                {
                    if ((DateTime.Today - currentProduct.CreationTime).TotalDays > currentProduct.ExpirationDate)
                    {
                        badDairyProducts.Add(currentProduct);
                        resultString.Append(currentProduct.Name + ", ");
                    }
                }
            }

            foreach (DairyProduct dairyProduct in badDairyProducts)
            {
                products.Remove(dairyProduct);
            }

            getBadDairyProductsEvent?.Invoke(this, resultString.ToString());
        }

        //public void GetBadDairyProductsInFile(string filePath) 
        //{//Old version of deleting bad dairy products
        //    string result = "";
        //    DairyProduct dairy = null;

        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(filePath))
        //        {
        //            for (int i = 0; i < products.Capacity; i++)
        //            {
        //                if ((dairy = products[i] as DairyProduct) != null)
        //                {
        //                    if ((DateTime.Today - dairy.CreationTime).TotalDays > dairy.ExpirationDate)
        //                    {
        //                        result += $"{dairy.Name} {dairy.Weight} {dairy.Price} {dairy.ExpirationDate} {dairy.CreationTime}\n";
        //                        products[i] = null;
        //                    }
        //                }
        //            }

        //            sw.Write(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Failed to get bad dairy products: " + ex.Message);
        //    }
        //}


        //Read from file method -> added events!

        #region FileInitialissation

        public void StartFileInitialisation(string filePath) 
        {
            string[] initialisationParameters = null;

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    initialisationParameters = sr.ReadToEnd().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    products = new List<Product>(initialisationParameters.Length - 1);
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
                    

                    for (int i = 1; i < initialisationParameters.Length; i++)
                    {
                        try
                        {
                            productInitialisationParameters = initialisationParameters[i].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                            switch (productInitialisationParameters[0])
                            {
                                case ("Meat"):
                                    products.Add(new MeatProduct());
                                    break;
                                case ("Dairy"):
                                    products.Add(new DairyProduct());
                                    break;
                                case ("Classic"):
                                    products.Add(new Product());
                                    break;

                                default:
                                    products.Add(new Product());
                                    throw new Exception("Impossible to start initialisation of instance in storage - invalid product type");
                            }

                            products[i - 1].Parse(productInitialisationParameters[1]);
                        }
                        catch (Exception ex)
                        {//Event invoke !!!
                            invalidProductInitialisation?.Invoke(this, $"Impossible to parse product data({productInitialisationParameters[1].Substring(0, productInitialisationParameters[1].Length - 1)})");
                        }
                    }



                }
            }
            catch (Exception ex) 
            {
                throw new Exception("Storage initialisation from file failed: " + ex.Message);
            }

            IsInitialised = true;
        }
        #endregion




        public string GetFullInfo()
        {
            StringBuilder resultString = new StringBuilder();

            foreach (var product in products)
            {
                resultString.Append(product + "\n");
            }

            return resultString.ToString();
        }

        public List<Product> GetAllMeatProducts()
        {
            List<Product> meat;
            int CountOfMeatProducts = 0;

            for (int i = 0; i < products.Capacity; i++)
            {
                if (products[i] is MeatProduct)
                {
                    CountOfMeatProducts++;
                }
            }

            meat = new List<Product>(CountOfMeatProducts);
            CountOfMeatProducts = 0;

            for (int i = 0; i < products.Capacity; i++)
            {
                if (products[i] is MeatProduct)
                {
                    meat[CountOfMeatProducts++] = products[i];
                }
            }

            return meat;
        }

        public void StartFastInitialisation(int k1, int k2, int k3, params Product[] _paramsProducts)
        {
            if (IsInitialised)
            {
                return;
            }

            products = new List<Product>(_paramsProducts.Length);
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
            this.products = new List<Product>();
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

                            products[i] = new MeatProduct(_name: name, _weight: weight, _price: price, _sort: s, _type: t, _expirationDate: expirationDate, _creationTime: creationTime);
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

                            products[i] = new DairyProduct(_name: name, _weight: weight, _price: price, _expirationDate: expirationDate, _creationTime: creationTime);
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



        IEnumerator IEnumerable.GetEnumerator()
        {
            return products.GetEnumerator();
        }

        public IEnumerator<Product> GetEnumerator()
        {
            return new StorageEnumerator(products);
        }

        class StorageEnumerator : IEnumerator<Product>
        {
            private List<Product> listOfProducts = null;
            private int currentPosition = -1;

            public StorageEnumerator(List<Product> products)
            {
                listOfProducts = products;
            }

            public Product Current => listOfProducts[currentPosition];

            object IEnumerator.Current => listOfProducts[currentPosition];

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                currentPosition++;

                return currentPosition < listOfProducts.Count;
            }

            public void Reset()
            {
                currentPosition = 0;
            }
        }
    }
}

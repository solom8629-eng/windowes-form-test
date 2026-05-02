using System;

// IMPORTANT: namespace must match your project
namespace windowes_form_test
{
    public enum ProductStatus { Fresh, NearExpiry, Expired }

    public class Product
    {
        private string _id;
        private string _name;
        private int _quantity;
        private double _price;

        public string ID
        {
            get { return _id; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _id = value;
                else throw new Exception("ID cannot be empty");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value)) _name = value;
                else throw new Exception("Name cannot be empty");
            }
        }
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value >= 0) _quantity = value;
                else throw new Exception("Quantity cannot be negative");
            }
        }
        public double Price
        {
            get { return _price; }
            set
            {
                if (value >= 0) _price = value;
                else throw new Exception("Price cannot be negative");
            }
        }

        protected Product(string id, string name, int quantity, double price)
        {
            ID = id; Name = name; Quantity = quantity; Price = price;
        }

        public virtual string GetProductStatus() { return "Fresh"; }
        public virtual string GetOfferSuggestion() { return "No offer"; }

        public override string ToString()
        {
            return "ID: " + ID + " | Name: " + Name + " | Qty: " + Quantity + " | Price: " + Price + " | Status: " + GetProductStatus();
        }
    }

    public class PerishableProduct : Product
    {
        private DateTime expiryDate;
        public DateTime ExpiryDate
        {
            get { return expiryDate; }
            set { expiryDate = value; }
        }

        public PerishableProduct(string id, string name, int quantity, double price, DateTime expiryDate)
            : base(id, name, quantity, price)
        {
            ExpiryDate = expiryDate;
        }

        private int GetDaysUntilExpiry()
        {
            return (expiryDate - DateTime.Today).Days;
        }

        public override string GetProductStatus()
        {
            int daysLeft = GetDaysUntilExpiry();
            if (daysLeft < 0) return "Expired";
            else if (daysLeft <= 5) return "Near Expiry";
            else return "Fresh";
        }

        public override string GetOfferSuggestion()
        {
            int daysLeft = GetDaysUntilExpiry();
            if (daysLeft <= 2) return "Apply 40% discount";
            else if (daysLeft <= 5) return "Apply 20% discount";
            else return "No offer";
        }

        public override string ToString()
        {
            return base.ToString() + " | Expiry: " + expiryDate.ToShortDateString();
        }
    }

    public class NonPerishableProduct : Product
    {
        public NonPerishableProduct(string id, string name, int quantity, double price)
            : base(id, name, quantity, price) { }

        public override string GetProductStatus() { return "Stable"; }
        public override string GetOfferSuggestion() { return "No offer"; }
        public override string ToString() { return base.ToString(); }
    }

    public class Inventory
    {
        private Product[] products;
        private int count;
        private const int ResizeAmount = 5;

        public Inventory()
        {
            products = new Product[5];
            count = 0;
        }

        private void ResizeArray()
        {
            Product[] biggerArray = new Product[products.Length + ResizeAmount];
            for (int i = 0; i < count; i++)
                biggerArray[i] = products[i];
            products = biggerArray;
        }

        public void AddProduct(Product p)
        {
            if (count == products.Length) ResizeArray();
            products[count] = p;
            count++;
        }

        public bool RemoveProduct(string id)
        {
            int indexToRemove = -1;
            for (int i = 0; i < count; i++)
            {
                if (products[i].ID == id) { indexToRemove = i; break; }
            }
            if (indexToRemove == -1) return false;

            for (int i = indexToRemove; i < count - 1; i++)
                products[i] = products[i + 1];

            products[count - 1] = null;
            count--;
            return true;
        }

        public Product FindProduct(string id)
        {
            for (int i = 0; i < count; i++)
                if (products[i].ID == id) return products[i];
            return null;
        }

        public Product[] GetAllProducts()
        {
            Product[] result = new Product[count];
            for (int i = 0; i < count; i++) result[i] = products[i];
            return result;
        }

        public Product[] GetExpiredProducts()
        {
            int c = 0;
            for (int i = 0; i < count; i++)
                if (products[i].GetProductStatus() == "Expired") c++;

            Product[] result = new Product[c];
            int idx = 0;
            for (int i = 0; i < count; i++)
                if (products[i].GetProductStatus() == "Expired") result[idx++] = products[i];
            return result;
        }

        public Product[] GetNearExpiryProducts()
        {
            int c = 0;
            for (int i = 0; i < count; i++)
                if (products[i].GetProductStatus() == "Near Expiry") c++;

            Product[] result = new Product[c];
            int idx = 0;
            for (int i = 0; i < count; i++)
                if (products[i].GetProductStatus() == "Near Expiry") result[idx++] = products[i];
            return result;
        }

        public Product[] GetLowStockProducts()
        {
            int c = 0;
            for (int i = 0; i < count; i++)
                if (products[i].Quantity < 10) c++;

            Product[] result = new Product[c];
            int idx = 0;
            for (int i = 0; i < count; i++)
                if (products[i].Quantity < 10) result[idx++] = products[i];
            return result;
        }
    }
}
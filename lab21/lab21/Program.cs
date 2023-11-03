using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Specialized;

namespace lab21
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("DbConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public ICollection<Product> Products { get; set; }
        public Order()
        {
            Products = new List<Product>();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Orders = new List<Order>();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (AppDbContext db = new AppDbContext())
            {
                while (true)
                {
                    Console.WriteLine("Выберите действие:");
                    Console.WriteLine("1. Просмотреть информацию о пользователях");
                    Console.WriteLine("11. Изменить информацию о пользователях");
                    Console.WriteLine("2. Добавить пользователя");
                    Console.WriteLine("3. Удалить пользователя");
                    Console.WriteLine("4. Просмотреть информацию о заказах");
                    Console.WriteLine("44. Изменить информацию о заказах");
                    Console.WriteLine("5. Добавить заказ");
                    Console.WriteLine("6. Удалить заказ");
                    Console.WriteLine("7. Просмотреть информацию о товарах");
                    Console.WriteLine("77. Изменить информацию о товарах");
                    Console.WriteLine("8. Добавить товар");
                    Console.WriteLine("9. Удалить товар");
                    Console.WriteLine("0. Выход\n");

                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            // просмотр информации о пользователях
                            List<User> users = db.Users.Include(o => o.Orders).ToList();
                            foreach (User user in users)
                            {
                                Console.WriteLine("\nID: {0} | NAME: {1} | Email: {2}",user.Id, user.Name, user.Email);
                                if (user.Orders != null)
                                {
                                    if (user.Orders.Count > 0)
                                        Console.WriteLine("Orders:");
                                    foreach (Order order in user.Orders)
                                    {
                                            Console.WriteLine("ID: {0} | Name: {1} | Date: {2} | Status: {3}", order.Id, order.Name, order.Date, order.Status);
                                    }
                                }
                            }
                            break;
                        case "11":
                            // изменение полей пользователя
                            Console.WriteLine("Введите ID пользователя:");
                            int userToChangeId = int.Parse(Console.ReadLine());
                            User userToChange = db.Users.FirstOrDefault(u => u.Id == userToChangeId);
                            if (userToChange != null)
                            {
                                Console.WriteLine("Выберите поле для изменения:");
                                Console.WriteLine("1. Имя");
                                Console.WriteLine("2. Email");
                                //Console.WriteLine("3. Удалить заказ");
                                string fieldChoice = Console.ReadLine();
                                switch (fieldChoice)
                                {
                                    case "1":
                                        Console.WriteLine("Введите новое имя:");
                                        string newUserName = Console.ReadLine();
                                        userToChange.Name = newUserName;
                                        db.SaveChanges();
                                        Console.WriteLine("Имя успешно изменено.");
                                        break;
                                    case "2":
                                        Console.WriteLine("Введите новый Email:");
                                        string newUserEmail = Console.ReadLine();
                                        userToChange.Email = newUserEmail;
                                        db.SaveChanges();
                                        Console.WriteLine("Email успешно изменен.");
                                        break;
                                    //case "3":
                                    //    Console.WriteLine("Введите ID заказа:");
                                    //    int userOrderId = int.Parse(Console.ReadLine());

                                    //    if (userToChange.Orders != null)
                                    //    {
                                    //        Order userOrderToDelete = db.Orders.FirstOrDefault(o => o.Id == userOrderId);
                                    //        if (userOrderToDelete != null)
                                    //        {

                                    //        }
                                    //    }
                                    //    db.SaveChanges();
                                    //    break;
                                    default:
                                        Console.WriteLine("Неверный выбор.");
                                        break;
                                }
                            }
                            break;
                        case "2":
                            // добавление пользователя
                            Console.WriteLine("Введите имя пользователя:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите email пользователя:");
                            string email = Console.ReadLine();
                            User newUser = new User { Name = name, Email = email };
                            db.Users.Add(newUser);
                            db.SaveChanges();
                            break;
                        case "3":
                            // удаление пользователя
                            Console.WriteLine("Введите ID пользователя:");
                            int id = int.Parse(Console.ReadLine());
                            User userToDelete = db.Users.FirstOrDefault(u => u.Id == id);
                            if (userToDelete != null)
                            {
                                db.Users.Remove(userToDelete);
                                db.SaveChanges();
                                Console.WriteLine("Пользователь успешно удален");
                            }
                            else
                            {
                                Console.WriteLine("Пользователь с таким ID не найден");
                            }
                            break;
                        case "4":
                            // просмотр информации о заказах
                            List<Order> orders = db.Orders.Include(o => o.Products).ToList();
                            foreach (Order order in orders)
                            {
                                Console.WriteLine("\nID: {0} | Name: {1} | Date: {2} | Status: {3}", order.Id, order.Name, order.Date, order.Status);
                                if (order.Products != null)
                                {
                                    if (order.Products.Count > 0)
                                        Console.WriteLine("Products:");
                                    foreach (Product product in order.Products)
                                    {
                                        Console.WriteLine("ID: {0} | Name: {1} | Price: {2}", product.Id, product.Name, product.Price);
                                    }
                                }
                            }
                            break;
                        case "44":
                            // изменение полей заказа
                            Console.WriteLine("Введите ID Заказа:");
                            int orderToChangeId = int.Parse(Console.ReadLine());
                            Order orderToChange = db.Orders.FirstOrDefault(u => u.Id == orderToChangeId);
                            if (orderToChange != null)
                            {
                                Console.WriteLine("Выберите поле для изменения:");
                                Console.WriteLine("1. Имя");
                                Console.WriteLine("2. Дата");
                                Console.WriteLine("3. Статус");
                                Console.WriteLine("4. Пользователь");
                                Console.WriteLine("5. Добавить товар");
                                Console.WriteLine("6. Удалить товар");
                                string fieldChoice = Console.ReadLine();
                                switch (fieldChoice)
                                {
                                    case "1":
                                        Console.WriteLine("Введите новое имя:");
                                        string newOrderName = Console.ReadLine();
                                        orderToChange.Name = newOrderName;
                                        db.SaveChanges();
                                        Console.WriteLine("Имя успешно изменено.");
                                        break;
                                    case "2":
                                        Console.WriteLine("Введите новую дату:");
                                        string newOrderDate = Console.ReadLine();
                                        orderToChange.Date = newOrderDate;
                                        db.SaveChanges();
                                        Console.WriteLine("Дата успешно изменена.");
                                        break;
                                    case "3":
                                        Console.WriteLine("Введите новый статус:");
                                        string newOrderStatus = Console.ReadLine();
                                        orderToChange.Status = newOrderStatus;
                                        db.SaveChanges();
                                        Console.WriteLine("Статус успешно изменен.");
                                        break;
                                    case "4":
                                        Console.WriteLine("Введите ID пользователя:");
                                        int userOrderId = int.Parse(Console.ReadLine());
                                        User userOrderToChange = db.Users.FirstOrDefault(o => o.Id == userOrderId);
                                        if (userOrderToChange != null)
                                        {
                                            userOrderToChange.Orders.Add(orderToChange);
                                            db.SaveChanges();
                                            Console.WriteLine("Пользователь успешно изменен.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Пользователь не найден.");
                                        }
                                        break;
                                    case "5":
                                        Console.WriteLine("Введите ID товара:");
                                        int productToAddId = int.Parse(Console.ReadLine());
                                        Product productToAdd = db.Products.FirstOrDefault(p => p.Id == productToAddId);
                                        if (productToAdd != null)
                                        {
                                            orderToChange.Products.Add(productToAdd);
                                            db.SaveChanges();
                                            Console.WriteLine("Товар успешно добавлен.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Товар не найден.");
                                        }
                                        break;
                                    case "6":
                                        Console.WriteLine("Введите ID товара:");
                                        int productToDeleteId = int.Parse(Console.ReadLine());
                                        Product productToRemove = db.Products.FirstOrDefault(p => p.Id == productToDeleteId);
                                        if (productToRemove != null)
                                        {
                                            orderToChange.Products.Remove(productToRemove);
                                            db.SaveChanges();
                                            Console.WriteLine("Товар успешно удалён.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Товар не найден.");
                                        }
                                        break;
                                    default:
                                        Console.WriteLine("Неверный выбор.");
                                        break;
                                }
                            }
                            break;
                        case "5":
                            // добавление заказа
                            Console.WriteLine("Введите ID пользователя, которому принадлежит заказ:");
                            int orderUserId = int.Parse(Console.ReadLine());
                            User userToAdd = db.Users.FirstOrDefault(u => u.Id == orderUserId);
                            if (userToAdd != null)
                            {
                                Console.WriteLine("Введите название заказа:");
                                string orderName = Console.ReadLine();
                                Console.WriteLine("Введите дату заказа:");
                                string orderDate = Console.ReadLine();
                                Console.WriteLine("Введите статус заказа:");
                                string orderStatus = Console.ReadLine();
                                Order newOrder = new Order { Name = orderName, Date = orderDate, Status = orderStatus, User = userToAdd };
                                db.Orders.Add(newOrder);
                                db.SaveChanges();
                                Console.WriteLine("Заказ успешно добавлен.");
                            }
                            else
                            {
                                Console.WriteLine("Пользователь с указанным ID не найден.");
                            }
                            break;
                        case "6":
                            // удаление заказа
                            Console.WriteLine("Введите ID заказа:");
                            int orderId = int.Parse(Console.ReadLine());
                            Order orderToDelete = db.Orders.FirstOrDefault(o => o.Id == orderId);
                            if (orderToDelete != null)
                            {
                                db.Orders.Remove(orderToDelete);
                                db.SaveChanges();
                                Console.WriteLine("Заказ успешно удален");
                            }
                            else
                            {
                                Console.WriteLine("Заказ с указанным ID не найден");
                            }
                            break;
                        case "7":
                            // просмотр информации о товарах
                            List<Product> products = db.Products.ToList();
                            foreach (Product product in products)
                            {
                                Console.WriteLine("\nID: {0} | Name: {1} | Price: {2}", product.Id, product.Name, product.Price);
                            }
                            break;
                        case "77":
                            // изменение полей товара
                            Console.WriteLine("Введите ID Товара:");
                            int productToChangeId = int.Parse(Console.ReadLine());
                            Product productToChange = db.Products.FirstOrDefault(p => p.Id == productToChangeId);
                            if (productToChange != null)
                            {
                                Console.WriteLine("Выберите поле для изменения:");
                                Console.WriteLine("1. Имя");
                                Console.WriteLine("2. Цена");
                                string fieldChoice = Console.ReadLine();
                                switch (fieldChoice)
                                {
                                    case "1":
                                        Console.WriteLine("Введите новое имя:");
                                        string newProductName = Console.ReadLine();
                                        productToChange.Name = newProductName;
                                        db.SaveChanges();
                                        Console.WriteLine("Имя успешно изменено.");
                                        break;
                                    case "2":
                                        Console.WriteLine("Введите новую дату:");
                                        double newProductPrice = double.Parse(Console.ReadLine());
                                        productToChange.Price = newProductPrice;
                                        db.SaveChanges();
                                        Console.WriteLine("Цена успешно изменена.");
                                        break;
                                }
                            }
                            break;
                        case "8":
                            // добавление товара
                            Console.WriteLine("Введите название товара:");
                            string productName = Console.ReadLine();
                            Console.WriteLine("Введите цену товара:");
                            double productPrice = double.Parse(Console.ReadLine());
                            Product newProduct = new Product { Name = productName, Price = productPrice };
                            db.Products.Add(newProduct);
                            Console.WriteLine("Введите ID заказа:");
                            int orderID = int.Parse(Console.ReadLine());
                            Order orderToAdd = db.Orders.FirstOrDefault(o => o.Id == orderID);
                            if (orderToAdd != null)
                            {
                                orderToAdd.Products.Add(newProduct);
                                db.SaveChanges();
                                Console.WriteLine("Товар успешно добавлен");
                            }
                            else
                            {
                                Console.WriteLine("Заказ с указанным ID не найден");
                            }
                            break;
                        case "9":
                            // удаление товара
                            Console.WriteLine("Введите ID товара:");
                            int productId = int.Parse(Console.ReadLine());
                            Product productToDelete = db.Products.FirstOrDefault(p => p.Id == productId);
                            if (productToDelete != null)
                            {
                                db.Products.Remove(productToDelete);
                                db.SaveChanges();
                                Console.WriteLine("Товар успешно удален");
                            }
                            else
                            {
                                Console.WriteLine("Товар с таким ID не найден");    
                            }
                            break;
                        case "0":
                            // выход из приложения
                            return;
                        default:
                            Console.WriteLine("Неверный ввод");
                            break;
                    }
                    Console.WriteLine("\n");
                }
            }
        }
    }

}
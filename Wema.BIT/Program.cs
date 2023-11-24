using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Wema.BIT.User
{
    public class User
    {

        static void Main(string[] args)
        {

            // Create an array of 10 students
            Student[] students = new Student[10];
            for (int i = 0; i < 10; i++)
            {
                students[i] = new Student { Name = $"Student{i + 1}", Age = i + 17 }; // Ages range from 17 to 26
            }

            // Create a list of student ages
            List<int> studentAges = students.Select(s => s.Age).ToList();

            // Query if a student whose age is 18 is in the list
            bool isStudent18 = studentAges.Contains(18);

            // Display the result
            if (isStudent18)
            {
                Console.WriteLine("There is a student whose age is 18 in the list.");
            }
            else
            {
                Console.WriteLine("There is no student whose age is 18 in the list.");
            }


            List<Payment> payments = new List<Payment>()
            {
                new Payment() {Id = 1, UserId = 1, Amount = 1233},
                // ... other payments
            };

            List<Account> accounts = new List<Account>()
            {
                new Account() {Id = 1, AccountNumber = "123456789", BVN = "12345678901", AccountName = "Aluh Johnson", PhoneNumber = "1234567890"},
                // ... other accounts
            };

            List<Users> users = new List<Users>()
            {
                new Users() {Id = 1, FirstName="Aluh", LastName="Johnson", Email="johnson@email.com", Payments = payments.Where(x => x.UserId == 1).ToList(), Accounts = accounts.Where(x => x.Id == 1).ToList()},
                // ... other users
            };

            var userPayments = users.Where(x => x.Id == 1);

            var json = JsonConvert.SerializeObject(userPayments, Formatting.Indented);

            foreach (var user in userPayments)
            {
                if (user.FirstName == "Tomi" || user.LastName == "Johnson")
                {
                    Console.WriteLine("First Name : " + user.FirstName + " Last Name : " + user.LastName);
                }
            }
        }


        public class Users
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public List<Payment> Payments { get; set; }
            public List<Account> Accounts { get; set; }
        }

        public class Payment
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public decimal Amount { get; set; }
        }

        public class Account
        {
            public int Id { get; set; }
            public string AccountNumber { get; set; }
            public string BVN { get; set; }
            public string AccountName { get; set; }
            public string PhoneNumber { get; set; }
        }

        class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }

}




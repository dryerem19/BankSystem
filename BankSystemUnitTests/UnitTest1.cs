using BankSystem;

namespace BankSystemUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        // Тест авторизации
        [TestMethod]
        public void TestAuth()
        {
            var email = "admin@example.com";
            var password = "password";

            var form = new AuthForm();
            var status = form.Auth(email, password);

            Assert.IsTrue(status);
        }

        // Добавление нового кредита
        [TestMethod]
        public void TestAddNewCreditToDatabase()
        {
            // Arrange
            var dbContext = new BankSystemContext();
            var borrower = dbContext.Borrowers.FirstOrDefault(b => b.FirstName == "John");
            var credit = new Credit
            {
                Borrower = borrower,
                ContractNumber = "123",
                LoanTerm = 12,
                LoanAmount = 100000,
                InterestRate = 10,
                PaidAmount = 0
            };

            // Act
            dbContext.Credits.Add(credit);
            dbContext.SaveChanges();

            // Assert
            Assert.IsTrue(dbContext.Credits.Any(c => c.ContractNumber == "123"));
        }


        // Тест на удаление
        [TestMethod]
        public void TestDeleteBorrowerFromDatabase()
        {
            // Arrange
            var dbContext = new BankSystemContext();
            var borrower = dbContext.Borrowers.FirstOrDefault(b => b.FirstName == "John");

            // Act
            dbContext.Borrowers.Remove(borrower);
            dbContext.SaveChanges();

            // Assert
            Assert.IsFalse(dbContext.Borrowers.Any(b => b.FirstName == "John"));
        }


        // Тест на обнову
        [TestMethod]
        public void TestUpdateBorrowerDataInDatabase()
        {
            // Arrange
            var dbContext = new BankSystemContext();
            var borrower = dbContext.Borrowers.FirstOrDefault(b => b.FirstName == "John");

            // Act
            borrower.PassportData = "654321";
            dbContext.SaveChanges();

            // Assert
            Assert.AreEqual("654321", dbContext.Borrowers.FirstOrDefault(b => b.FirstName == "John").PassportData);
        }


        // Тест на то, что заёмщики есть
        [TestMethod]
        public void TestGetAllBorrowersFromDatabase()
        {
            // Arrange
            var dbContext = new BankSystemContext();

            // Act
            var borrowers = dbContext.Borrowers.ToList();

            // Assert
            Assert.IsTrue(borrowers.Count > 0);
        }


        // Тест на добавление нового заёмщика
        [TestMethod]
        public void TestAddNewBorrowerToDatabase()
        {
            // Arrange
            var dbContext = new BankSystemContext();
            var borrower = new Borrower
            {
                FirstName = "John",
                LastName = "Doe",
                MiddleName = "Smith",
                Gender = new Gender {ID = 0, Title = "Male"},
                DateOfBirth = new DateTime(1990, 1, 1),
                PassportData = "123456",
                INN = "1234567890"
            };

            // Act
            dbContext.Borrowers.Add(borrower);
            dbContext.SaveChanges();

            // Assert
            Assert.IsTrue(dbContext.Borrowers.Any(b => b.FirstName == "John"));
        }

    }
}
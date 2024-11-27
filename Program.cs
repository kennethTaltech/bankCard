
public class BankCard
{
    // Private fields
    private double _accountBalance;
    private string _cardType;
    private string _cardNumber;

    // Default constructor
    public BankCard()
    {
        _accountBalance = 0;
        _cardType = "Visa";
    }

    // Constructor with parameters
    public BankCard(int balance, string cardType)
    {
        _accountBalance = balance;
        SetCardType(cardType); // Validate card type during construction.
    }

    // Method for setting the card type with simple validation
    private void SetCardType(string cardType)
    {
        // Foolproof validation: convert to lowercase for comparison
        string typeLower = cardType.ToLower();
        if (typeLower == "visa" || typeLower == "maestro")
        {
            _cardType = cardType;
        }
        else
        {
            _cardType = "Visa"; // Default to "Visa" if an invalid card type is provided.
            Console.WriteLine("Invalid card type! Defaulting to 'Visa'.");
        }
    }

    // Method for setting the card number
    public void SetCardNumber(string cardNumber)
    {
        // Check if the card number length is 8
        bool isCorrectLength = cardNumber.Length == 8;

        // Check if the card number is numeric
        bool isNumeric = long.TryParse(cardNumber, out _);

        // Validate both conditions
        if (!isCorrectLength || !isNumeric)
        {
            Console.WriteLine("Invalid value. The card number must be exactly 8 digits and numeric.");
        }
        else
        {
            _cardNumber = cardNumber;
            Console.WriteLine($"Card number set to {_cardNumber}");
        }
    }

    // Method for printing out card type
    public void PrintCardType()
    {
        Console.WriteLine($"Card type: {_cardType}");
    }

    // Method for printing out account balance
    public void PrintAccountBalance()
    {
        Console.WriteLine($"Account balance: {_accountBalance}");
    }

    // Method for returning account balance (without printing)
    public double GetAccountBalance()
    {
        return _accountBalance;
    }

    // Method for adding money to the account
    public void AddMoney(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount to add must be greater than 0.");
        }
        else
        {
            _accountBalance += amount;
            Console.WriteLine($"Added {amount}. New account balance: {_accountBalance}");
        }
    }

    // Method for subtracting money from the account
    public void SubtractMoney(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Amount to subtract must be greater than 0.");
        }
        else if (_accountBalance - amount < 0)
        {
            Console.WriteLine("Cannot do this operation, insufficient funds");
        }
        else
        {
            _accountBalance -= amount;
            Console.WriteLine($"Subtracted {amount}. New account balance: {_accountBalance}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        // Case 1: Using the default constructor
        BankCard card1 = new BankCard();
        Console.WriteLine("Case 1: Default Constructor");
        card1.PrintCardType(); // Expected: Card type: Visa
        card1.PrintAccountBalance(); // Expected: Account balance: 0
        card1.SetCardNumber("12345678"); // Expected: Card number set to 12345678
        card1.SetCardNumber("1hxu23"); // Expected: Invalid value. The card number must be exactly 8 digits and numeric.

        // Adding and subtracting money
        card1.AddMoney(50); // Expected: Added 50. New account balance: 50
        card1.PrintAccountBalance(); // Expected: Account balance: 50
        card1.SubtractMoney(30); // Expected: Subtracted 30. New account balance: 20
        card1.SubtractMoney(25); // Expected: Cannot do this operation, insufficient funds
        card1.PrintAccountBalance(); // Expected: Account balance: 20

        // Case 2: Using the parameterized constructor
        BankCard card2 = new BankCard(100, "Maestro");
        Console.WriteLine("\nCase 2: Parameterized Constructor");
        card2.PrintCardType(); // Expected: Card type: Maestro
        card2.PrintAccountBalance(); // Expected: Account balance: 100
        card2.SetCardNumber("87654321"); // Expected: Card number set to 87654321
        card2.SetCardNumber("87654bdf432"); // Expected: Invalid value. The card number must be exactly 8 digits and numeric.

        // Adding and subtracting money
        card2.AddMoney(150); // Expected: Added 150. New account balance: 250
        card2.PrintAccountBalance(); // Expected: Account balance: 250
        card2.SubtractMoney(100); // Expected: Subtracted 100. New account balance: 150
        card2.SubtractMoney(200); // Expected: Cannot do this operation, insufficient funds
        card2.PrintAccountBalance(); // Expected: Account balance: 150
    }
}

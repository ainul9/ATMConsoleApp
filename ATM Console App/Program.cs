using System;

public class cardHolder
{
    string cardNum;
    int pin;
    string firstName;
    string lastName;
    double balance;
    

    public cardHolder(string cardNum, int pin, string firstName, string LastName, double balance)
    {
        this.cardNum = cardNum; 
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = LastName;
        this.balance = balance;
    } //constructor

    public string getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public string getFirstName()
    {
        return firstName;
    }

    public string getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    public void setNum(string newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose 1 from the following options.");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much RM would you like to deposit?: ");
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much RM would you like to withdraw?: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check if the user has enough money in account.
            if (currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance, sorry.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Withdrawal succeed!You able to withdraw RM " + withdrawal);
            }
        }
            void balance(cardHolder currentUser)
            {
                Console.WriteLine("Your current balance is: " + currentUser.getBalance());
            }

            List<cardHolder> cardHolders = new List<cardHolder>();
            cardHolders.Add(new cardHolder("433221199887766", 1234, "Ahmad", "Farid", 150.31));
            cardHolders.Add(new cardHolder("446655778899123", 4321, "Tasha", "Shila", 321.13));
            cardHolders.Add(new cardHolder("554433221166778", 9999, "Nurul", "Aliah", 400.19));
            cardHolders.Add(new cardHolder("532144667788912", 2468, "hila", "Amzah", 871.09));
            cardHolders.Add(new cardHolder("334166778899112", 6612, "Rania", "Ilham", 50.91));

            //prompt user
            Console.WriteLine("Welcome to MyATM");
            Console.WriteLine("Please insert your debit card: ");
            String debitCardNum = "";
            cardHolder currentUser;

            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    //check against our database
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if(currentUser  != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Card not recognized. Please try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Card not recognized. Please try again");
                }
            }

            Console.WriteLine("Please enter your pin: ");
            int userPin = 0;
            while (true)
            {
                try
                {
                    userPin = int.Parse(Console.ReadLine());
                    if (currentUser.getPin() == userPin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect pin number. Please try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Incorrect pin number. Please try again");
                }
            }

            Console.WriteLine("Welcome " + currentUser.getFirstName());
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch { }
                if (option == 1)
                {
                    deposit(currentUser);
                }
                else if (option == 2)
                {
                    withdraw(currentUser);
                }
                else if (option == 3)
                {
                    balance(currentUser);
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    option = 0;
                }
            }
            while (option != 4);
            Console.WriteLine("Thank you! Have a nice day.");
        }
    }
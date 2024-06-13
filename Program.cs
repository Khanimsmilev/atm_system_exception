using System;

class IncorrectAmountException : Exception
{
    public string? Message { get; set; }
    public IncorrectAmountException(string message)
    {
        Message = message;
    }
}

class PinException : Exception
{
    public string? Message1 { get; set; }

    public PinException(string message)
    {
        Message1 = message;
    }
}
class ATM
{
    int PIN;
    double balance;

    public ATM()
    {
        PIN = 3589;
        balance = 1000;
    }

    public double CheckBalance()
    {
        return balance;
    }

    public void setPin(int pin)
    {
        if (pin > 9999)
        {
            throw new PinException("Pin must be 4 digits number!");
        }
        PIN = pin;
    }
    public bool CheckPin(int pin)
    {

        if (pin != PIN)
        {
            return false;
        }
        else if (pin == PIN)
        {
            return true;
        }
        return false;
    }

    public bool Withdraw(double amount)
    {
        if (amount > balance)
        {
            throw new IncorrectAmountException("Not Enough money!");
/*            return false;*/
        }

        balance -= amount;
        return true;

    }
    public void Increase(double amount)
    {
        balance += amount;

    }

}

class Program
{
    static void Main(string[] args)
    {
        ATM aTM = new ATM();

        int Pin;
        int Choice;
        int Try = 3;
        double Amount;
        do
        {
            Console.WriteLine("Enter PIN: ");
            Pin = Convert.ToInt32(Console.ReadLine());
            bool check = aTM.CheckPin(Pin);

            if (check == true)
            {
                Console.WriteLine("Welcome!");
                do
                {
                    Console.WriteLine("Enter your choice: ");
                    Console.WriteLine("1. Show balance;");
                    Console.WriteLine("2. Withdraw money from balance;");
                    Console.WriteLine("3. Increase the balance;");
                    Console.WriteLine("4. Change the Pin.");
                    Console.WriteLine("5. Exit");

                    Choice = Convert.ToInt32(Console.ReadLine());

                    switch (Choice)
                    {
                        case 1:
                            Console.WriteLine("Your current balance is: " + aTM.CheckBalance());
                            break;
                        case 2:
                            Console.WriteLine("Enter amount: ");
                            try
                            {
                                Amount = Convert.ToDouble(Console.ReadLine());
                                check = aTM.Withdraw(Amount);
                                if(check != true)
                                {
                                    throw new IncorrectAmountException("Not Enough money!");
                                }
                            }catch(IncorrectAmountException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
/*                            Amount = Convert.ToDouble(Console.ReadLine());
                            check = aTM.Withdraw(Amount);
                            if (check == true)
                            {
                                Console.WriteLine("Amount withdrawn: " + Amount);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient balance!");
                            }*/
                            break;
                        case 3:
                            Console.WriteLine("Enter amount: ");
                            Amount = Convert.ToDouble(Console.ReadLine());
                            aTM.Increase(Amount);
                            Console.WriteLine("Balance increased successfully!");

                            break;
                        case 4:
                            Console.WriteLine("Enter new Pin: ");
                            try
                            {
                                Pin = Convert.ToInt32(Console.ReadLine());
                                if (Pin > 9999)
                                {
                                    throw new PinException("Pin must be 4 digits number!");
                                }
                                else
                                {
                                    aTM.setPin(Pin);
                                    Console.WriteLine("Pin changed successfully!");
                                }

                            }
                            catch (PinException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            break;
                        case 5:
                            Console.WriteLine("Exited successfully!");
                            break;
                        default:
                            Console.WriteLine("Incorrect input!");
                            break;

                    }
                } while (Choice != 5);

            }

            else if (check == false)
            {
                Console.WriteLine("Incorrect Pin!");
                --Try;
            }


        } while (Try != 0);
        Console.WriteLine("You have run out of attempts!");
    }

}

namespace CaixaEletronico;

public class CashMachine
{
    private static int _balance = 5000;

    public static void Load()
    {
        Console.WriteLine("Bem vindo!");
        Console.WriteLine("---------------");
        Console.WriteLine($"Seu Saldo: {_balance}");
        Console.WriteLine("Quantos voce deseja sacar?");
        Console.Write("R$ ");
        var amount = int.Parse(Console.ReadLine()!);

        try
        {
            var moneyBills = Withdraw(amount);
            Console.WriteLine("---------------");
            Console.WriteLine($"Valor de Saque: R$ {amount},00");
            Console.WriteLine($"Notas:");

            var counts = moneyBills.GroupBy(x => x);
            foreach (var count in counts)        
            {
                Console.Write($"{count.Count()} notas de ");
                Console.WriteLine(count.Key);
            }
        }
        catch (OverdraftException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static List<int> Withdraw(int amount)
    {
        if (amount > _balance)
            throw new OverdraftException(
                $"Desculpe, o valor que você está tentando sacar excedeu seu valor de saldo R${_balance}");

        var moneyBills = new List<int>() { 100, 50, 30, 20, 10 };
        var moneyDelivered = new List<int>();

        foreach (var moneyBill in moneyBills)
            while (amount >= moneyBill)
            {
                amount -= moneyBill;
                moneyDelivered.Add(moneyBill);
            }

        return moneyDelivered;
    }
}
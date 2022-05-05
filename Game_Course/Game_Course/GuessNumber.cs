namespace Game_Course;

public class GuessNumber
{
    private readonly int max;
    private readonly int maxTries;
    public GuessNumber(int max = 100, int maxTries = 5)
    {
        this.max = max;
        this.maxTries = maxTries;
    }
    public void Start()
    {
        Console.WriteLine("Оберіть режим гри (1 - ви загадуєте число, 2 - машина загадує число):");
        int mode = Int32.Parse(Console.ReadLine());
        if (mode == 1) 
            UserGame();
        else
            AutoGame();
    }
    public void AutoGame()
    {
        var rand = new Random();
        int number = rand.Next(0, max+1);
        Console.WriteLine("Я загадав число, спробуй вгадати!");
        Console.WriteLine(number);
        int tries = 0;
        while (tries < maxTries)
        {
            int input = Int32.Parse(Console.ReadLine());
            if (input < number)
                NumberGreater();
            else if(input > number)
                NumberLess();
            else
            {
                NumberGuessed(number);
                break;
            }
            tries++;
            if(tries == maxTries)
                Console.WriteLine("Ти використав всі спроби( Спробуй зіграти ще раз!");
        }
    }
    
    public void NumberGreater()
    {
        Console.WriteLine($"Загадане число більше(");
    }
    public void NumberLess()
    {
        Console.WriteLine($"Загадане число менше(");
    }
    public void NumberGuessed(int number)
    {
        Console.WriteLine($"Ти виграв!!! Я загадав число {number}");
    }
    
    public void UserGame()
    {
        int number = 50;
        Console.WriteLine("Загадай число від 0 до 100, а я спробую його вгадати:)\n Постав плюс(+) - якщо загадане тобою число більше,\nмінус(-) - якщо менше, \nзнак дорівнює(=) - якщо я вгадав. ");
        List<int> list = new List<int>();
        list.Add(max);
        list.Add(0);
        list.Add(number);
        
        int tries = 0;
        while (tries < maxTries)
        {
            Console.WriteLine($"Це число - {number}?");
            string input = Console.ReadLine();
            list.Sort();
            if (input == "+")
                number = UserNumberGreater(list, number);
            else if(input == "-")
                number = UserNumberLess(list, number);
            else if(input == "=")
            {
                UserNumberGuessed();
                break;
            }
            else
                Console.WriteLine("Введи правильні позначення.");
            tries++;
            if(tries == maxTries)
                Console.WriteLine("Я не знаю, яке число(");
                
        }
    }
    
    public int UserNumberLess(List<int> list, int number)
    {
        int indexNum = list.IndexOf(number);
        number = list[indexNum] - ((list[indexNum] - list[indexNum-1])/2);
       
        list.Add(number);
        return number;
    }

    public int UserNumberGreater(List<int> list, int number)
    {
        int indexNum = list.IndexOf(number);
        number = (list[indexNum + 1] - (list[indexNum + 1] - list[indexNum]) / 2);
       
        list.Add(number);
        return number;
    }
    public void UserNumberGuessed()
    {
        Console.WriteLine("Ура! Я виграв!");
    }
    
}
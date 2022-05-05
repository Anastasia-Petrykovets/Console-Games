using System.Linq.Expressions;

namespace SticksGame;

public class StickGame
{
    private readonly int startSticks;

    public StickGame(int startSticks = 10)
    {
        this.startSticks = startSticks;
    }
    
    public void Start()
    {
        int curSticks = startSticks;
        UserTurn(curSticks);
    }

    public void UserTurn(int curSticks)
    {
        try
        {
            Console.WriteLine("You should get from 1 to 3 sticks. Please, choose: ");
            int userTry = int.Parse(Console.ReadLine()) ;
            if (userTry == 1 || userTry == 2 || userTry == 3)
            {
                curSticks -= userTry;
                Console.WriteLine($"{curSticks} sticks left");
                MachineTurn(curSticks);
            }
            else
            {
                throw new ArgumentException("Input correct value!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
        finally
        {
            UserTurn(curSticks);
        }
        
        
       
    }

    public int MachineTurn(int curSticks)
    {
        Random rand = new Random();
        int machineTry = rand.Next(1, 3);
        Console.WriteLine("It`s my turn!");
        if (curSticks >= 3)
        {
            curSticks -= machineTry;
            Console.WriteLine($"I take {machineTry}\n{curSticks} sticks left");
            UserTurn(curSticks);
        }
        else if (curSticks == 2)
        {
            curSticks -= - 1;
            Console.WriteLine("1 sticks left. You lose(");
        }
        else if (curSticks == 1 || curSticks == 0)
        {
            Console.WriteLine("You won!");
        }

        return curSticks;
    }
}

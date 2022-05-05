namespace Game_Course;

public class GallowsGame
{
    private readonly int maxTries;
    private bool openAny;

    public GallowsGame(int maxTries = 6, bool openAny = false)
    {
        this.maxTries = maxTries;
        this.openAny = openAny;
    }
    public void ChooseWord()
    {
        var rand = new Random();
        int indexRandStr = rand.Next(0, 11650) ;
        string randStr = File.ReadAllLines("WordsStockRus.txt")[indexRandStr].Trim();
        Console.WriteLine(randStr);
        char[] newArrChar = new char[randStr.Length];
        for (int i = 0; i < newArrChar.Length; i++)
        {
            newArrChar[i] = '_';
        }
        UserLettersTries(randStr, newArrChar);
        

    }

    public void UserLettersTries(string randStr, char[] newCharArr)
    {
        try
        {
            int tries = 0;
            while (tries < maxTries)
            {
                Console.WriteLine("Введіть букву, яка на вашу думку є у слові:");
                char letter = Convert.ToChar(Console.ReadLine());
                string outputStr = IsInWord(letter, randStr, newCharArr);
                if (!openAny)
                {
                    tries++;
                }
                Console.WriteLine($"{outputStr}\nУ вас лишилось {maxTries - tries} з {maxTries} спроб");
                if (outputStr == randStr)
                {
                    Console.WriteLine($"Ви виграли! Це слово - {outputStr}");
                    break;
                }
            }

           
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Помилка: {ex.Message} \n Почнемо гру знову)");
        }

    }
    public string IsInWord(char letter, string randStr, char[] charArr)
    {
        openAny = false;
        for (int i = 0; i < randStr.Length; i++)
        {
            if (randStr[i] == letter)
            {
                charArr[i] = letter;
                openAny = true;
            }
        }

        if (!openAny)
            return $"Ви використали одну спробу, в слові немає такої букви. {new string(charArr)}";
        else
            return new string(charArr);
    }

}
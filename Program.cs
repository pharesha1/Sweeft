class SweeftClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("sPalindrome Tests:");
        Console.WriteLine(sPalindrome("racecar"));
        Console.WriteLine(sPalindrome("dotnet"));

        Console.WriteLine();

        Console.WriteLine("MinSplit Test:");
        Console.WriteLine(MinSplit(174));

        Console.WriteLine();

        Console.WriteLine("NotContains Tests:");
        int[] numbers = { 1, 3, 6, 5, 4, 2, 7};
        Console.WriteLine(NotContains(numbers));
        int[] numbersTwo = { 1, 31, 6, 2, 4, 12, 3};
        Console.WriteLine(NotContains(numbersTwo));

        Console.WriteLine();

        Console.WriteLine("IsProperly Tests:");
        Console.WriteLine(IsProperly("(()((())))"));
        Console.WriteLine(IsProperly("(()))((()))"));

        Console.WriteLine();

        Console.WriteLine("CountVariants Tests:");
        Console.WriteLine(CountVariants(4));
        Console.WriteLine(CountVariants(5));
    }

    // Check if given string(text) is a Palindrome
    static bool sPalindrome(string text)
    {
        string reverseText = "";

        for (int i = text.Length; i > 0; i--)
        {
            reverseText += text[i-1];
        }

        return reverseText.Equals(text) ? true : false;
    }
    // Return the minumum coins to make a given amount(amount)
    static int MinSplit (int amount)
    {
        int result = 0;
        while (amount > 0)
        {
            if (amount > 50)
            {
                result += amount / 50;
                amount %= 50;
            }
            else if (amount > 20)
            {
                result += amount / 20;
                amount %= 20;
            }
            else if (amount > 10)
            {
                result += amount / 10;
                amount %= 10;
            }
            else if (amount > 5)
            {
                result += amount / 5;
                amount %= 5;
            }
            else if (amount > 1)
            {
                result += amount / 1;
                amount %= 1;
            }
        }
        return result;
    }
    // Check and return the smallest integer that is not in the array(numbersArray) and is bigger than zero
    static int NotContains(int[] numbersArray)
    {
        Array.Sort(numbersArray);
        int result = 0;
        for (int i = 0; i < numbersArray.Length; i++)
        {
            if(i == numbersArray.Length - 1)
            {
                result = numbersArray[i] + 1;
            }
            else if (numbersArray[i+1] - numbersArray[i] > 1)
            {
                result = numbersArray[i] + 1;
                break;
            }
        }
        return result;
    }
    // Check if brackets are in a correct sequence
    static bool IsProperly(string sequence)
    {
        sequence.ToCharArray();
        bool result = false;
        int rightFacingBrackets = 0;
        int leftFacingBrackets = 0;
        
        if (sequence[0] == ')')
        {
            return false;
        }
        
        for (int i = 0; i < sequence.Length; i++)
        {
            if (sequence[i].Equals('('))
            {
                rightFacingBrackets++;
            }
            else if (sequence[i].Equals(')'))
            {
                leftFacingBrackets++;
            }
        }

        return rightFacingBrackets == leftFacingBrackets ? true : false;
    }
    // Return how many variants are available to go up N stairs
    static int CountVariants(int stairCount)
    {
        return Fibonacci(stairCount + 1);
    }
    //I am using fibonacci to easily fix the problem
    static int Fibonacci(int stairs)
    {
        if (stairs <= 1)
            return stairs;
        return Fibonacci(stairs - 1) + Fibonacci(stairs - 2);
    }

}
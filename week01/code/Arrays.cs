using System.Runtime.CompilerServices;

public static class Arrays
{
    public static void Run()
    {
        Console.WriteLine("\n======================\nArrays\n======================");
        Console.WriteLine("MultiplesOf(7, 5) = {0}", string.Join(", ", MultiplesOf(7, 5)));

        RotateListRight(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }, 1);

    }
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {   //define the array of doubles called result
        var result = new double[length];
        //loop n times to fill the array with multiples of the number
        for (int i = 0; i < length; i++)
        {
            //multiply the number by the index and assign it to the array at that index
            result[i] = number * (i + 1);
        }
        //return the array of doubles
        return result;

    }   

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        int count = data.Count;  
        
        //ensure amount is within the bounds of the list size
        amount = amount % count;

        //copy the last 'amount' elements
        List<int> temp = data.GetRange(count - amount, amount);

        //remove the last 'amount' elements from the list
        data.RemoveRange(count - amount, amount);

        //insert the copied elements at the beginning of the list
        data.InsertRange(0, temp);

        
        Console.WriteLine("Rotated List: {0}", string.Join(", ", data));
        

    }
}

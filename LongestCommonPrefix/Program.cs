// See https://aka.ms/new-console-template for more information
public class Solution 
{
    public static void Main()
    {
        var names = new string[] { "ab", "a" };

        Console.WriteLine(new Solution().LongestCommonPrefix(names));
    }

    public string LongestCommonPrefix(string[] strs)
    {
        var strsCharArrays = new List<char[]>();
        string emptyString = "";
        string firstStringIndex = strs[0];
        bool similarTest = true;

        // Zero-sized array returns empty string
        if (strs.Length == 0) return emptyString;
        // Singular string entry returns itself
        if (strs.Length == 1) return firstStringIndex;

        // Check if all index strings are the same word; returns first index string if true
        for (int i = 0; i < strs.Length; i++)
        {
            if (similarTest == true && strs[0] == strs[i])
            {
                similarTest = true;
            }
            else similarTest = false;
        }
        if (similarTest) return strs[0];

        // Conversion of each string in strs array to a char array that is added to a list of char arrays called strsCharArrays
        foreach (var word in strs)
        {
            var strsConverted = word.ToCharArray();
            strsCharArrays.Add(strsConverted);
        }

        // Initialise charCount to the first indexed entry character count
        int charCount = strsCharArrays[0].Count();
        // Compare charCount to subsequent indexed element counts in strsCharArrays. Obtain and set charCount as smallest value
        for (int i = 1; i < strsCharArrays.Count; i++)
        {
            if (strsCharArrays[i].Count() < charCount) charCount = strsCharArrays[i].Count();
            else continue;
        }

        // charPosition initialised and declared to keep track of common prefix check position
        int charPosition = default;
        // Nested for loop checking equivalence of every element in first index to subsequent indexes' elements absolute position.
        // Returns previous position at point of failure.
        // If successful, return completed string
        for (int i = 0; i < charCount; i++)
        {
            for (int j = 1; j < strsCharArrays.Count(); j++)
            {
                if (strsCharArrays[0][i] == strsCharArrays[j][i]) { charPosition = i + 1; continue; }
                else { charPosition = i ; return new string (strsCharArrays[0][..charPosition]); }
            }
        }

        return new string(strsCharArrays[0][..charPosition]);
    }
}
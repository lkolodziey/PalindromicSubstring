namespace PalindromicSubstring;

public static class Comparer
{
    public static string LongestPalindromicSubstring(string text)
    {
        if (text.Length < 2)
        {
            return text;
        }

        var start = 0;
        var maxLength = 0;

        for (var i = 0; i < text.Length; i++)
        {
            var oddPalindrome = ExpandAroundCenter(text, i, i);
            var evenPalindrome = ExpandAroundCenter(text, i, i + 1);

            if (oddPalindrome.Length > maxLength)
            {
                maxLength = oddPalindrome.Length;
                start = i - (maxLength - 1) / 2;
            }

            if (evenPalindrome.Length <= maxLength) continue;
            maxLength = evenPalindrome.Length;
            start = i - maxLength / 2 + 1;
        }

        return text.Substring(start, maxLength);
    }
    
    private static string ExpandAroundCenter(string text, int left, int right)
    {
        while (left >= 0 && right < text.Length && text[left] == text[right])
        {
            left--;
            right++;
        }
        return text.Substring(left + 1, right - left - 1);
    }
}
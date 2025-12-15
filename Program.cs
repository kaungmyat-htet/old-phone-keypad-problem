using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public class Program
{
	private static readonly Dictionary<char, String> numpad = new Dictionary<char, String> {
		{ '0', " " },
		{ '1', "&'(" },
		{ '2', "abc" },
		{ '3', "def" },
		{ '4', "ghi" },
		{ '5', "jkl" },
		{ '6', "mno" },
		{ '7', "pqrs" },
		{ '8', "tuv" },
		{ '9', "wxyz" },
	};
	
	public static String OldPhonePad(String input) {
		StringBuilder output = new StringBuilder();
		int pressCount = 0;
		char prevButton = '.';
		
		foreach (char c in input) {
			if (c == '#') {
				break;
			}
			
			if (c == ' ') {
				pressCount = 0;
				prevButton = '.';
				continue;
			}
			
			if (c == '*') {
				if (output.Length > 0) {
					output.Length--;
				}
				pressCount = 0;
				prevButton = '.';
				continue;
			}
			
			if (numpad.ContainsKey(c)) {
				if (c == prevButton) {
					pressCount++;
					output[output.Length - 1] = numpad[c][pressCount % numpad[c].Length];
				} else {
			    	pressCount = 0;
					output.Append(numpad[c][pressCount]);
				}
			}
			prevButton = c;
		}
		return output.ToString();
	}
	
	public static Boolean Test(String input, String expected) {
		string result = OldPhonePad(input);
		
		if (result == expected) {
            Console.WriteLine($"Test Passed: Input: {input}, Expected: {expected}, Got: {result}");
			return true;
		}
        Console.WriteLine($"Test Failed: Input: {input}, Expected: {expected}, Got: {result}");
		return false;
	}

    public static void RunAllTests()
    {
        var testCases = new Dictionary<string, string>
        {
            { "96667775553#", "world" },
            { "222 2 22#", "cab" },
            { "4433555 555666#", "hello" },
            { "8 88777444666*664#", "turing" }
        };

        foreach (var testCase in testCases)
        {
			Test(testCase.Key, testCase.Value);
        }
    }

	public static void Main()
	{
		RunAllTests();
	}
}

using System.Text;

namespace Keypad.Services;

public class KeypadService
{
    private static readonly Dictionary<char, string> numpad = new Dictionary<char, string>
    {
        { '0', " " },
        { '1', "&'(" },
        { '2', "abc" },
        { '3', "def" },
        { '4', "ghi" },
        { '5', "jkl" },
        { '6', "mno" },
        { '7', "pqrs" },
        { '8', "tuv" },
        { '9', "wxyz" }
    };

    public static string OldPhonePad(string input) {
		if (string.IsNullOrEmpty(input) || !input.Contains('#'))
		{
			return "";
		}
		
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
			} else {
				pressCount = 0;
				prevButton = '.';
				continue;
			}
			prevButton = c;
		}
		return output.ToString();
	}
}

# Iron Software Coding Challenge

### Problem Approach 
As an AI Engineer with experience in Python programming, I first solved the problem using Python. Then, I converted my Python solution to C# using C# documentation and my experience with C# in Unity Game Development.

I implemented cycling behavior for the numpad keys. When a key is pressed more times than its characters, it wraps back to the start.  
- Example: `"2222"` → `"a"` (cycles through a→b→c→a)

### Solutions
- [Python Solution](main.py)
- [C# Solution](Program.cs)

### Running & Testing the code

#### Python
You can easily run and test the python code using the test cases files as below
```bash
# To run the 1.in test case under test folder
python main.py < test/1.in
```

#### C#
For C#, compile and run the file (test cases are already in the file)
```bash
# Compile the C# code
csc Program.cs

# Run the compiled executable
Program.exe
```

### AI Prompts

I use `Gemini` CLI Tool to see whether I can improve my base solution in term of time and space complexity. Based on the answer, we can conclude that this problem cannot be improved further than O(N) for both time and space complexity.

#### Prompt
```
Please read the @C\#\ Coding\ Challenge.pdf and check @Program.cs. You are a senior software engineer and find the area that can be improve in term of time and space complexity and calculate the Big O notation. Is there any other methods or techniques to solve this problem?
```

#### Answer

```
Of course. I've analyzed the C# code in Program.cs in the context of the coding challenge described in the PDF. Here is my assessment:

  Analysis of the Existing Program.cs Solution

  The current implementation in Program.cs is a very strong and efficient solution to the "Old Phone Pad" problem. It correctly translates the keypad input string into the
  expected text output.

  Time and Space Complexity

   * Time Complexity: O(N)
      The algorithm iterates through the input string of length N a single time. Inside the loop, all operations—such as dictionary lookups, character appends, and character
  updates on the StringBuilder—are performed in constant time on average. This makes the overall time complexity linear, which is optimal. You cannot solve the problem without
  examining each character of the input at least once.

   * Space Complexity: O(N)
      The primary use of memory that scales with the input is the StringBuilder output. In the worst-case scenario, the length of the output string is proportional to the input
  string's length N. Therefore, the space complexity is also linear. This is the best achievable space complexity, as the final output string itself requires O(N) space.

  Areas for Improvement

  From a complexity standpoint, the current solution is already optimal. There are no algorithmic changes that would result in a better Big O notation for time or space.

  The code is also clear, readable, and effectively uses a StringBuilder to avoid inefficient string concatenations in a loop. The logic for handling repeated key presses by
  updating the last character is direct and clever.

  Alternative Methods and Techniques

  While the existing solution is excellent, it's worth considering other theoretical approaches to understand why the current one is so effective:

   1. Pre-computation by Grouping:
      One could imagine an approach where you first parse the input string to group consecutive identical key presses (e.g., "44", "555"). After grouping, you would iterate
  through these groups to generate the output characters.

       * Why it's not better: This method adds a layer of pre-processing complexity. More importantly, it becomes very difficult to handle the backspace (*) and pause ( )
         operators elegantly. A backspace would require unwinding the last processed group, and pauses would act as group delimiters. This makes the logic more convoluted
         compared to the straightforward, single-pass stream processing approach used in Program.cs.

   2. State Machine Pattern:
      The problem can be formally modeled as a state machine where the "state" consists of the previousButton pressed and the pressCount. The current implementation is already
  an implicit and effective implementation of this state machine pattern. Making it more formal (e.g., creating a state class) would be a stylistic choice and would likely add
  verbosity without providing any performance or clarity benefits for a problem of this scale.

  Conclusion

  The provided C# solution in Program.cs is an exemplary answer to the coding challenge. It is:
   * Optimal: with O(N) time and O(N) space complexity.
   * Robust: correctly handling all specified cases including repeated presses, pauses, and backspaces.
   * Well-crafted: demonstrating good C# practices by using a Dictionary for fast lookups and a StringBuilder for efficient string manipulation.

  In short, it is a professional-quality solution that does not have significant room for improvement in terms of performance or core logic.
```
# Unit Testing


## Testing Framework & Research

For unit testing in C#, I found out that **[xUnit](https://xunit.net/?tabs=cs)** and **[NUnit](https://nunit.org/)** are being used in the industry. 

I implemented unit testing using **xUnit**. I have added **60 test cases** covering: 
- Individual key mappings
- Edge cases (excessive backspace, multiplace spaces, invalid characters)
- Wrap-around behavior (pressing a key more than available letters)
- Complex scenarios combining multiple features

### Changes

**Project Structure Restructuring:**

I restructured the project from a single C# file into a proper multi-project solution:

**Before:**
- Single `Program.cs` file with all logic

**After:**
- `PhonePad/` - Class library containing the core `KeypadService` logic
- `PhonePad.Tests/` - Dedicated test project with unit tests
- `PhonePadSolution.sln` - Solution file organizing both projects

This separation of concerns allows for:
- Clean isolation of business logic from tests
- Better code organization and maintainability
- Proper project dependencies and references
- Industry-standard testing practices with xUnit

### Issues Discovered & Fixed

Through comprehensive testing, I identified critical issues and hardened the code:

### 1. Missing Terminator Validation
**Issue:**: Input without the '#' terminator was being processed instead of rejected.

**Fix:**: Added validation to check for the terminator and null or empty string:
```csharp
if (string.IsNullOrEmpty(input) || !input.Contains('#'))
{
    return "";
}
```
**Test Case**:
```csharp
[Fact]
public void OldPhonePad_ShouldHandleInputWithoutTerminator()
{
    var result = KeypadService.OldPhonePad("222");
    Assert.Equal("", result);
}
```
### 2. Invalid Character Handling
**Issue:**: Invalid characters (non-numeric) weren't properly handled.

**Fix:**: Invalid characters reset the key press counter, acting as separators (pauses).

**Test Case**:

```cs
[Fact]
public void OldPhonePad_ShouldHandleMixedInvalidAndValidChars()
{
    var result = KeypadService.OldPhonePad("a2b2c2#");

    Assert.Equal("bbb", result);
}
```
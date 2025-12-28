using Keypad.Services;

namespace PhonePad.Tests;

public class OldPhonePadTests
{

    [Fact]
    public void OldPhonePad_ShouldReturnEmptyString_ForEmptyInput()
    {
        var result = KeypadService.OldPhonePad("");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldReturnEmptyString_ForInputWithOnlyHash()
    {
        var result = KeypadService.OldPhonePad("#");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleBackspace()
    {
        var result = KeypadService.OldPhonePad("22*#");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleMultipleBackspace()
    {
        var result = KeypadService.OldPhonePad("222**#");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleExcessiveBackspaces()
    {
        var result = KeypadService.OldPhonePad("2*****#");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleOnlyBackspaces()
    {
        var result = KeypadService.OldPhonePad("***#");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleMultipleSpaces()
    {
        var result = KeypadService.OldPhonePad("22  222#");

        Assert.Equal("bc", result);
    }


    [Fact]
    public void OldPhonePad_ShouldHandleBackspaceAtBeginning()
    {
        var result = KeypadService.OldPhonePad("*22#");

        Assert.Equal("b", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleBackspaceInMiddle()
    {
        var result = KeypadService.OldPhonePad("222 33*2#");

        Assert.Equal("ca", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleAlternatingKeys()
    {
        var result = KeypadService.OldPhonePad("2 3 4 5#");

        Assert.Equal("adgj", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleOnlySpaces()
    {
        var result = KeypadService.OldPhonePad("   #");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandlePauses()
    {
        var result = KeypadService.OldPhonePad("2 2#");

        Assert.Equal("aa", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleInvalidCharacter()
    {
        var result = KeypadService.OldPhonePad("abc22#");

        Assert.Equal("b", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleLongInput()
    {
        var result = KeypadService.OldPhonePad("844330778844422255022777666966033366699#");

        Assert.Equal("the quick brown fox", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleInputWithoutTerminator()
    {
        var result = KeypadService.OldPhonePad("222");

        Assert.Equal("", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleMultipleTerminators()
    {
        var result = KeypadService.OldPhonePad("22##");

        Assert.Equal("b", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleSpaceInMiddle()
    {
        var result = KeypadService.OldPhonePad("22 222#");

        Assert.Equal("bc", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleSpaceAtEnd()
    {
        var result = KeypadService.OldPhonePad("22 #");

        Assert.Equal("b", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleMixedInvalidAndValidChars()
    {
        var result = KeypadService.OldPhonePad("a2b2c2#");

        Assert.Equal("aaa", result);
    }

    [Fact]
    public void OldPhonePad_ShouldHandleVeryLongSequence()
    {
        var result = KeypadService.OldPhonePad("22222222222222222222#");

        Assert.Equal("b", result);
    }

    [Theory]
    [InlineData("2#", "a")]
    [InlineData("22#", "b")]
    [InlineData("222#", "c")]
    [InlineData("2222#", "a")]
    [InlineData("3#", "d")]
    [InlineData("33#", "e")]
    [InlineData("333#", "f")]
    [InlineData("3333#", "d")]
    [InlineData("4#", "g")]
    [InlineData("44#", "h")]
    [InlineData("444#", "i")]
    [InlineData("4444#", "g")]
    [InlineData("5#", "j")]
    [InlineData("55#", "k")]
    [InlineData("555#", "l")]
    [InlineData("5555#", "j")]
    [InlineData("6#", "m")]
    [InlineData("66#", "n")]
    [InlineData("666#", "o")]
    [InlineData("6666#", "m")]
    [InlineData("7#", "p")]
    [InlineData("77#", "q")]
    [InlineData("777#", "r")]
    [InlineData("7777#", "s")]
    [InlineData("77777#", "p")]
    [InlineData("8#", "t")]
    [InlineData("88#", "u")]
    [InlineData("888#", "v")]
    [InlineData("8888#", "t")]
    [InlineData("9#", "w")]
    [InlineData("99#", "x")]
    [InlineData("999#", "y")]
    [InlineData("9999#", "z")]
    [InlineData("99999#", "w")]
    [InlineData("0#", " ")]
    [InlineData("00#", " ")]
    [InlineData("4433555 555666#", "hello")]
    [InlineData("8 88777444666*664#", "turing")]
    [InlineData("222 2 22#", "cab")]
    [InlineData("96667775553#", "world")]
    public void OldPhonePad_ShouldReturnCorrectString(string input, string expected)
    {
        var result = KeypadService.OldPhonePad(input);

        Assert.Equal(expected, result);
    }

    
}

keypad_dict = {
    "0": " ",
    "1": "&'(",
    "2": "abc",
    "3": "def",
    "4": "ghi",
    "5": "jkl",
    "6": "mno",
    "7": "pqrs",
    "8": "tuv",
    "9": "wxyz",
}


def OldPhonePad(input: str) -> str:
    output_str = ""
    prev_num = '.'
    i = 0

    for character in input:
        if character == "#":
            break

        if character == " ":
            i = 0
            prev_num = '.'
            continue

        if character == "*":
            if (len(output_str) > 0):
                output_str = output_str[:-1]
            i = 0
            prev_num = '.'
            continue
        
        if (keypad_dict.get(character)):
            if character == prev_num:
                i += 1;
                output_str = output_str[:-1] + keypad_dict[character][i % len(keypad_dict[character])]
            else:
                i = 0
                output_str += keypad_dict[character][i]

        prev_num = character
    return output_str


number = input()
output = OldPhonePad(number)
print(output)
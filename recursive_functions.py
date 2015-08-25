def find_max(listOfNumbers):
    if len(listOfNumbers) == 1:
        return listOfNumbers[0]
    else:
        if listOfNumbers[0] > listOfNumbers[1]:
            del listOfNumbers[1]
        else:
            del listOfNumbers[0]

    return find_max(listOfNumbers)


numbers = {"0": 0, "1": 1, "2": 2, "3": 3, "4": 4, "5": 5, "6": 6, "7": 7, "8": 8, "9": 9}
def dan_string_to_int(toCon):

    if len(toCon) < 2:
        return int_equivs[toCon]
    else:
        return int_equivs[toCon[0]] * (pow(10, len(toCon)-1)) + dan_string_to_int(toCon[1:])


int_equivs = {'0': 0, '1':1, '2':2, '3':3, '4':4, '5':5, '6':6, '7':7, '8':8, '9':9}
def matt_str_to_int(string):
    if len(string) == 1:            # base case
        return int_equivs[string]
    else:
        return matt_str_to_int(string[-1]) + (matt_str_to_int(string[:-1]) * 10)


numbers_string_map = {"0": 0, "1": 1, "2": 2, "3": 3, "4": 4, "5": 5, "6": 6, "7": 7, "8": 8, "9": 9}
def alex_string_to_int(input_string):
    if len(input_string) == 1:
        return numbers_string_map[input_string]
    else:
        last_index = len(input_string)-1
        return alex_string_to_int(input_string[last_index]) + alex_string_to_int(input_string[:last_index]) * 10

def sam_determineint(s):
    if len(s) == 0:
        return 0
    return int(s[0] + ((len(s)-1) * "0")) + sam_determineint(s[1:])
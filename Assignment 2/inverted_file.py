__author__ = 'mazurdm1'
from collections import OrderedDict

class InvertedFileCreator:

    def __init__(self, input_string):
        input_string = input_string.lower()
        input_string = input_string.split(" ")
        self.word_storage = {}

        counter = 0
        for item in input_string:
            if item in self.word_storage:
                self.word_storage[item].append(counter)
            else:
                self.word_storage[item] = [counter]
            counter += 1

        # Convert the normal dict into an dict that is ordered by it's key
        self.word_storage = OrderedDict(sorted(self.word_storage.items(), key=lambda t: t[0]))


if __name__ == "__main__":
    input_string = "this is a long long text lol lol lol this is a word lol"
    inverter = InvertedFileCreator(input_string)
    print (inverter.word_storage)

    ## NB: It will not remove punctuation.

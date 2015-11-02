__author__ = 'mazurdm1'
import Queue


class WordLadderCalculator:

    def __init__(self):
        self.dictionary = set()
        self.set_up_dictionary()
        word_one = raw_input()
        word_two = raw_input()
        self.find_word_ladder(word_one,word_two)


    def find_word_ladder(self, start_word, end_word):
        word_path = dict()
        word_queue = Queue.Queue()
        word_queue.put(start_word)

        while not word_queue.empty():
            current_word = word_queue.get()
            word_path[current_word] = None
            for word in self.adjacent_words(current_word):
                if word in self.dictionary():
                    if word not in word_path.keys():
                        word_path[word] = current_word
                        word_queue.put(word)


        if end_word in word_path.keys():
            current = word_path[end_word]
            while current is not start_word:
                print current
                current = word_path[current]




    def set_up_dictionary(self):

        # Load words file into dictionary
        filename = 'dictionary.txt'
        with open(filename) as item:
            for line in item.readlines():
                self.dictionary.add(line.lower()[:-1])

    def adjacent_words(self, current_word):
        adjacent_words = []
        base_word_array = list(current_word)

        for i in range(len(base_word_array)):
            for letter in self.alphabet:
                new_word = base_word_array[:i] + list(letter) + base_word_array[i + 1:]
                if self.as_string(new_word) in self.dictionary:
                    adjacent_words.append(self.as_string(new_word))

        return adjacent_words

    @staticmethod
    def as_string(chars):
        return "".join(chars)


if __name__ == '__main__':
    wordLadder = WordLadderCalculator()

__author__ = 'mazurdm1'
import Queue
import string


class WordLadderCalculator:

    def __init__(self):
        self.alphabet = list(string.ascii_lowercase)
        self.dictionary = set()
        self.set_up_dictionary()
        word_one = raw_input("Enter the first word: ")
        word_two = raw_input("Enter the second word: ")
        self.find_word_ladder(word_one,word_two)


    def find_word_ladder(self, start_word, end_word):
        # Word path is a dict that is used as a Tree structure
        word_path = dict()
        # The queue is used for breadth first traversal
        word_queue = Queue.Queue()
        word_queue.put(start_word)
        word_path[start_word] = None
        while not word_queue.empty():
            current_word = word_queue.get()
            # Gets all possible one letter different words
            possible_words = self.adjacent_words(current_word)
            for word in possible_words:
                # And not already existing somewhere else in the tree
                if word not in word_path.keys():
                    # Add it to the tree as a child of the current word that is being processed
                    word_path[word] = current_word
                    word_queue.put(word)
            if current_word == end_word:
                # If the word that is found is the word that is being looked for, break the while.
                break

        # Climb back up the ladder from the bottom branch where the found word is located (if it exists)
        if end_word in word_path.keys():
            print "End of ladder:"
            print "--------------"
            print end_word
            current = word_path[end_word]
            while current is not None:
                print current
                current = word_path[current]
            print "---------------"
            print "Start of ladder"
        else:
            print "No possible ladder found"



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
                if self.as_string(new_word) in self.dictionary and self.as_string(new_word) not in adjacent_words:
                    adjacent_words.append(self.as_string(new_word))

        return adjacent_words

    @staticmethod
    def as_string(chars):
        return "".join(chars)


if __name__ == '__main__':
    wordLadder = WordLadderCalculator()

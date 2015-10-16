__author__ = 'mazurdm1'
from color import bcolors as color
import string

class SpellChecker:

    def __init__(self):
        self.correct_words = set()
        self.set_up_dictionary()
        self.to_check = list()
        self.load_file_to_check()
        self.corrections = []
        self.alphabet = list(string.ascii_lowercase)
        self.check_all_words()
        for item in self.corrections:
            print (item)

    def set_up_dictionary(self):
        # Load words file into dictionary
        # filename = 'words.txt'
        filename = input("Input the dictionary's text file address : ")
        with open(filename) as item:
            for line in item.readlines():
                self.correct_words.add(line.lower()[:-1])

    def load_file_to_check(self):
        # Loads the text file with the incorrect spellings t check
        # filename = "checkfile.txt"
        filename = input("Input the txt file address of the file to check : ")
        with open(filename) as item:
            for line in item.readlines():
                self.to_check.append(line.lower())

    def check_all_words(self):

        for i in range(len(self.to_check)):
            for string in self.to_check[i].split():
                self.check_word(string, i)
                self.print_word(string)
            print

    def check_word(self, word, line_occured):
        if word not in self.correct_words:
            self.corrections.append({"Misspelt word" : word, "line occured" : line_occured, "possible corrections": self.get_options(word)})

    def print_word(self, word):
        if word in self.correct_words:
            print (color.ENDC + word),
        else:
            print (color.WARNING + word + color.ENDC),

    def as_string(self, chars):
        return "".join(chars)

    def get_options(self, misspelt_word):
        """
        Returns a dictionary of lists of possible corrections for the misspelt word
        :param misspelt_word:
        :return:
        """
        # Incorrect letter
        incorrect_letter_words = self.single_letter_wrong(misspelt_word)
        # Missing letter
        missing_letter_words = self.single_letter_missing(misspelt_word)
        # Extra letter
        extra_letter_words = self.extra_letter_words(misspelt_word)
        # Pair swapped
        pair_swapped_words = self.pair_of_letters_swapped(misspelt_word)

        return {"single letter wrong": incorrect_letter_words, "missing letter": missing_letter_words , "extra letter": extra_letter_words, "pair sawpped" : pair_swapped_words}

    def extra_letter_words(self, misspelt_word):
        """
        Checks to see if a single letter has accadently been added to the word
        :param misspelt word: The incorrectly spelt word
        :return: a list of possible corrections
        """
        possible_corrections = []
        base_word_array = list(misspelt_word)

        for i in range(len(base_word_array)+1):
            new_word = base_word_array[:i] + base_word_array[i+1:]
            if self.as_string(new_word) in self.correct_words:
                if self.as_string(new_word) not in possible_corrections:
                    possible_corrections.append(self.as_string(new_word))
        return possible_corrections

    def single_letter_missing(self, misspelt_word):
        """
        Checks to see if a single letter has been omittied from the words
        :param misspelt word: The incorrectly spelt word
        :return: a list of possible corrections
        """
        letter_count = len(misspelt_word)
        possible_corrections = []

        for i in range(letter_count + 1):
            for char in self.alphabet:
                new_word = misspelt_word[:i] + char + misspelt_word[i:]
                if self.as_string(new_word) in self.correct_words:
                    possible_corrections.append(new_word)

        return possible_corrections

    def single_letter_wrong(self, misspelt_word):
        """
        Checks to see if a single letter in the words has been replaced with a differnt character
        :param misspelt word: The incorrectly spelt word
        :return: a list of possible corrections
        """
        possible_corrections = []
        base_word_array = list(misspelt_word)

        for i in range(len(base_word_array)):
            for letter in self.alphabet:
                new_word = base_word_array[:i] + list(letter) + base_word_array[i+1:]
                if self.as_string(new_word) in self.correct_words:
                    possible_corrections.append(self.as_string(new_word))

        return possible_corrections

    def pair_of_letters_swapped(self, misspelt_word):
        """
        Checks to see if any two adjacent characters in the word have been swapped
        :param misspelt word: the incorrectly spelt word
        :return: a list of possible corrections
        """
        possible_corrections = []
        base_word_array = list(misspelt_word)

        for i in range(len(base_word_array)-1):
            new_word = list(base_word_array)

            temp = new_word[i]
            new_word[i] = new_word[i+1]
            new_word[i+1] = temp
            temp2 = self.as_string(new_word)
            if temp2 in self.correct_words:
                possible_corrections.append(temp2)
        return possible_corrections

if __name__ == '__main__':
    spellchecker = SpellChecker()

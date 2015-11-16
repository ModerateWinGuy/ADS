__author__ = 'mazurdm1'

import operator

class Calculator:

    def __init__(self):
        self.calc = {
            '+' : operator.add,
            '-' : operator.sub,
            '*' : operator.mul,
            '/' : operator.div,
        }

    def calculate(self, input_string):
        input_string = input_string.split(" ")
        stack = []
        for c in input_string:
            if c in self.calc:
                num_right = stack.pop()
                num_left = stack.pop()
                answer = self.calc[c](num_left, num_right)
                stack.append(answer)
            else:
                stack.append(int(c))

        print(stack.pop())

if __name__ == "__main__":
    cal = Calculator()
    cal.calculate("1 5 + 10 *")

import time

class Tester():
    def __init__(self):
        self.methods_to_test = []
        self.method_input = None
        self.time_to_run = []
        self.run_times = 20000

    # Add in any methods that you want to test
    def addAlgo(self, method_name):
        self.methods_to_test.append(method_name)

    # set whatever input you want to test the methods with
    def set_method_input(self,method_input):
        self.method_input = method_input

    # Test the methods
    def test_methods(self):
        self.time_to_run = []
        for x in self.methods_to_test:
            start_time = time.time()
            for i in range(0,self.run_times):
                x(self.method_input)
            end_time = time.time()
            elapsed = end_time - start_time
            self.time_to_run.append(elapsed)

    # Print out the method names and times they took to run
    def print_times(self):
        for x,y in zip(self.time_to_run, self.methods_to_test):
            method_name = y.__name__
            time_string = x / self.run_times
            print(method_name)
            print( time_string )

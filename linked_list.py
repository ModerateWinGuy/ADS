
"""
A linked list that holds empty spaces of a defauld value and starts at a certain length
"""

class Node():

    def __init__(self, index, data):
        self.data = data
        self.index = index
        self.next_node = None # Points to the next node that is not the default value

    def set_next_node(self, node):
        self.next_node = node


class LinkedList():

    def __init__(self, default):
        self.values = []
        self.head = None
        self.tail = None
        self.default_value = default

    def append(self, value):
        if value is self.default_value:
            self._append()  # Case to add link to default value if value is default
            return

        to_add = Node(len(self.values), value)

        if len(value) is 0:
            self.head = to_add
            self.tail = to_add
        else:
            self.values[-1].set_next_node(to_add)
            self.tail = to_add

        self.values.append(to_add)

    def _append(self):
        self.append(self.default_value)

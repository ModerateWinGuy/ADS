__author__ = 'mazurdm1'

class Node:

    def __init__(self, data, next_node):
        self.data = data
        self.next_node = next_node

class LinkedList:

    def __init__(self, head_node):
        self.head_node = Node(head_node, None)
        self.tail_node = None

    def add_node(self, new_node):

        if self.tail_node == None:
            self.tail_node = Node(new_node, None)
            self.head_node.next_node = self.tail_node
        else:
            new_node = Node(new_node, None)
            self.tail_node.next_node = new_node
            self.tail_node = new_node

    def reverse_list(self):
        #Start at the head of the list
        current_node = self.head_node
        previous_node = None

        while current_node is not None:
            # Swap around the pointer direction until the end is reached
            temp = current_node.next_node
            current_node.next_node = previous_node
            previous_node = current_node
            current_node = temp

        # Swap head and tail
        temp = self.head_node
        self.head_node = self.tail_node
        self.tail_node = temp


if __name__ == "__main__":
    l_list = LinkedList("This")
    l_list.add_node("Is")
    l_list.add_node("A")
    l_list.add_node("Sentance")

    curr_node = l_list.head_node

    while curr_node is not None:
        print(curr_node.data)
        curr_node = curr_node.next_node

    l_list.reverse_list()

    curr_node = l_list.head_node
    while curr_node is not None:
        print(curr_node.data)
        curr_node = curr_node.next_node
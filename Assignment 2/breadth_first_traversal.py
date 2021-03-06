__author__ = 'Daniel'
import Queue

class Tree:
    def __init__(self, root_node):
        self.root = Node(root_node)

    def traverse(self):
        # Start with a que with only the root node
        queue = Queue.Queue()
        queue.put(self.root)
        # Continue while there are still nodes in the queue
        while not queue.empty():
            # get the first item in the queue
            item = queue.get()
            print(item.data)
            for child in item.children:
                # Add that item's children to the waiting queue
                queue.put(child)


class Node:
    def __init__(self, data):
        self.data = data
        self.children = []

    def add_child(self, child_data):
        self.children.append(Node(child_data))


if __name__ == "__main__":
    tree = Tree(1)
    tree.root.add_child(2)
    tree.root.add_child(3)
    tree.root.add_child(4)
    tree.root.children[0].add_child(5)
    tree.root.children[1].add_child(6)
    tree.root.children[2].add_child(7)
    tree.root.children[2].children[0].add_child(8)
    tree.root.children[2].children[0].add_child(9)
    tree.root.children[2].children[0].add_child(10)

    # numbers are expected in order
    tree.traverse()


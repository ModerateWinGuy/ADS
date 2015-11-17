__author__ = 'Daniel'
import Queue

class Tree:
    def __init__(self, root_node):
        self.root = Node(root_node)

    def traverse(self):
        queue = Queue.Queue()
        queue.put(self.root)
        while not queue.empty():
            item = queue.get()
            print(item.data)
            for child in item.children:
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

    tree.traverse()


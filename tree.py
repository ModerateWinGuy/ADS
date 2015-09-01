
class Tree():

    def __init__(self):
        self.root = {}

    def size(self):
        return self.bredth_first_size(self.root)

    def bredth_first_size(self, children):
        size = 0
        for i in children:
            size+=1
            print(i)
        for i in children:
            size = size + self.bredth_first_size(children[i])
        return size

    def set_tree(self, add):
        self.root = add

    def root(self):
        return self.root

    def is_root(self,r):
        if r is self.root:
            return True
        return False

    def is_leaf(self, to_check):
        if len(to_check) is 0:
            return True
        return False

if __name__ == '__main__':
    tree = Tree()
    to_add = {"1": {"2": {"3": {}, "4": {"5": {}}, "6": {}}
            ,"7": {"8": {"9": {}}}}}
    tree.set_tree(to_add)
    print (tree.size())

__author__ = 'Daniel'
from ctypes import *

class DynamicArray:
    """A dynamic array class like a python simplified list"""

    def __init__(self):
        self._n = 0
        self._capacity = 1
        self._A = self._make_array(self._capacity)

    def __len__(self):
        """Return the number of elements sotred in the array."""
        return self._n

    def __getitem__(self, k):
        """Return element at index k"""
        if not 0 <= k < self._n:
            raise IndexError('Invalid Index')
        return self._A[k]

    def get_array(self):
        a = []
        for i in range(self._n):
            a.append(self._A[i])
        return a

    def append(self,obj):
        """Add an object to the end of the array"""
        if self._n == self._capacity:
            self._resize(2 * self._capacity)
        self._A[self._n] = obj
        self._n += 1

    def pop(self):
        """
        Removes the last value from the array and returns it.
        :return: The last value from the array
        """
        if self._n < 1:                     # Return None if the array is empty
            # raise ValueError('Array is empty')
            return None

        to_return = self._A[self._n-1]
        self._n -= 1
        if self._n < (self._capacity / 2):  # Resize the array if it is using less than half of it's assigned memory
            self._resize(self._n)
        return to_return

    def _resize(self, c):
        """
        Resizes the internal array to the provided size
        :param c: The capacity to change the internal array too
        """
        B = self._make_array(c)
        for k in range(self._n):
            B[k] = self._A[k]
        self._A = B
        self._capacity = c

    def _make_array(self, c):
        """
        Returns an array with capacity c
        :param c: The capacity of the array that will be returned
        :return: The new array
        """
        return (c * py_object)()

class SortedDynamicArray(DynamicArray):

    def add(self, obj):
        """
        To be used instead of the append method
        :param obj: The object to be added to the array
        """
        self._find_correct_slot(obj)

    def _find_correct_slot(self, obj):
        """
        Finds the slot that the object should be put into and calls the insert method.
        :param obj: The object to find the correct slot for
        """
        if self._n == 0:
            self.append(obj)
            return

        for k in range(0, self._n):
            if self._A[k] < obj:
                self._insert(obj, k)
                return
        self.append(obj)

    def _insert(self, obj, index):
        """
        Inserts the provided object at the index, pushing the current object in the index position into the next slot
        and everything else following it also.
        :param obj: the object to insert.
        :param index: The position to put the object at.
        """

        if self._n == self._capacity:
            self._resize(2 * self._capacity)
        self._n += 1
        for k in reversed(xrange(index, self._n)): # Goes backwards through the list to move the values along in the array
            self._A[k] = self._A[k-1]

        self._A[index] = obj


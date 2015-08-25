__author__ = 'mazurdm1'
import file_path_yeilder
import DynamicArray

dy = DynamicArray.DynamicArray()
dy.append(1)
dy.append(2)
dy.append(5)
dy.append(8)




dys = DynamicArray.SortedDynamicArray()

dys.add(9)
dys.add(2)
dys.add(5)
dys.add(3)
dys.add(1)
dys.add(7)


print dys.get_array()



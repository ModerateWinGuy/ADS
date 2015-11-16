__author__ = 'mazurdm1'


for i in xrange(100):
    temp = ""

    if i % 3 == 0:
        temp = temp + "Fizz"
    if i % 5 == 0:
        temp = temp +  "Buzz"
    if len(temp) != 0:
        print(temp)
    else:
        print i
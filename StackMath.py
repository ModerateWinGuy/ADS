operators = ["(", "+", "-", "*", "/"]

def do_math(equation):
    """Do A Math"""
    temp = ""
    operator =""
    for chars in equation:
        if chars.isdigit():
            temp += chars
        else:
            operator = chars
            int_one = int(temp)
            temp = ""
    int_two = int(temp)
    to_return = {
        "+": int_one+int_two,
        "-": int_one-int_two,
        "/": int_one/int_two,
        "*": int_one*int_two
    }[operator]

    return to_return


stack = []

user_input = "(5*(1+1))+(7*(14+1))"

for i in range(len(user_input)):
    if user_input[i] != ")":
        stack.append(str(user_input[i]))
        print "[ "+user_input[i] + " ] added to stack"
    else:
        popped = []
        while len(stack) > 0:
            popped.append(stack.pop())
            if popped[-1] == "(":
                break
        del popped[-1]
        print "ToMath [ " + str(popped) +" ]"
        popped.reverse()
        stack.append(do_math("".join(popped)))
        # stack.append(")")
print stack



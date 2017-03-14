def bracesCheck(brace):
    braces = list()
    #check = {'{' : '}', '[' : ']', '(' : ')'}
    for i in range(0, len(brace)):
        if brace[i] == '{':
            braces.append('{')
        elif brace[i] == '[':
            barces.append('[')
        elif brace[i] == '(':
            braces.append('(')

        elif brace[i] == '}':
            braces.pop()
        elif brace[i] == ']':
            barces.pop()
        elif brace[i] == ')':
            braces.pop()
    print braces
    #for val in brace:


bracesCheck("([{}])") # true
bracesCheck("([{})()")# false
bracesCheck("]([{}])")# false

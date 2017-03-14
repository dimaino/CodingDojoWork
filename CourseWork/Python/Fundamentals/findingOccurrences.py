file = open("pandp.txt", "r")
def openFile(file):
    text = file.read()
    return text
str = openFile(file)

something = re.findall(r"", str)
for count in something:
    print count

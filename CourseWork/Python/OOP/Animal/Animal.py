class Animal(object):
    def __init__(self, name):
        print "Animal Created!"
        self.name = name
        self.health = 100
    def walk(self):
        print "Walking!"
        self.health -= 1
        return self
    def run(self):
        print "Running!"
        self.health -= 5
        return self
    def displayHealth(self):
        print "Name:", self.name
        print "Health:", self.health
        print "_"*30
        return self

animal1 = Animal("HARRY POTTER")
animal1.walk().walk().walk().run().run().displayHealth()
# animal1.fly()
# animal1.pet()

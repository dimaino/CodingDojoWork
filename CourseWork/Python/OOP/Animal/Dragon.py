from Animal import Animal
class Dragon(Animal):
    def __init__(self, name):
        super(Dragon, self).__init__(name)
        self.health = 170
    def fly(self):
        print "Flying"
        self.health -= 10
        return self
    def displayHealth(self):
        print "this is a dragon!"
        super(Dragon, self).displayHealth()
        return self

dragon1 = Dragon("Some Dragon")
dragon1.walk().walk().walk().run().run().fly().fly().displayHealth()

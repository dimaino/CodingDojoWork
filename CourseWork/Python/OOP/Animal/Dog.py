from Animal import Animal
class Dog(Animal):
    def __init__(self, name):
        super(Dog, self).__init__(name)
        self.health = 150
    def pet(self):
        print "Petting"
        self.health += 5
        return self
dog1 = Dog("Buddy")
dog1.walk().walk().walk().run().run().pet().displayHealth()

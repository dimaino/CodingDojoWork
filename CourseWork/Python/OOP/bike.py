class Bike(object):
    def __init__(self, price, max_speed):
        print "New Bike"
        self.price = price
        self.max_speed = max_speed
        self.mile = 0
    def displayInfo(self):
        print "Price:", self.price
        print "Max Speed:", self.max_speed
        print "Miles:", self.mile
        return self
    def ride(self):
        print "Riding"
        self.mile += 10
        return self
    def reverse(self):
        if(self.mile > 5):
            self.mile -= 5
            print "Reversing"
        else:
            print "Can't reverse!"
        return self


bike1 = Bike(200, "25mph")
bike1.ride().ride().ride().ride().ride().ride().ride().ride().ride().displayInfo()


bike2 = Bike(200, "25mph")
bike2.ride().ride().reverse().reverse().displayInfo()

bike3 = Bike(200, "25mph")
bike3.reverse().reverse().reverse().displayInfo()

class Car(object):
    def __init__(self, price, speed, fuel, mileage):
        print "New Car"
        self.price = price
        self.speed = speed
        self.fuel = fuel
        self.mileage = mileage
        if(price <= 10000):
            self.tax = 0.12
        else:
            self.tax = 0.15
    def displayInfo(self):
        print "Price:", self.price
        print "Speed:", self.speed
        print "Fuel:", self.fuel
        print "Mileage:", self.mileage
        print "Tax:", self.tax
        print ""

car1 = Car(2000, "35mph", "Full", "15mpg")
car1.displayInfo()
car2 = Car(2000, "5mph", "Full", "105mpg")
car2.displayInfo()
car3 = Car(2000, "15mph", "Kind of Full", "95mpg")
car3.displayInfo()
car4 = Car(2000, "25mph", "Full", "25mpg")
car4.displayInfo()
car5 = Car(2000, "45mph", "Empty", "25mpg")
car5.displayInfo()
car6 = Car(20000000, "35mph", "Empty", "15mpg")
car6.displayInfo()

from __future__ import unicode_literals
from django.db import models

class RestfulManager(models.Manager):
    def addNewProduct(self, pinput):
        errorList = []
        try:
             here = float(pinput['productPrice'])
        except Exception as e:
             here = str(pinput['productPrice'])
        if not isinstance(here, float):
            errorList.append("You need to enter a number for the Price!\n")
        if len(pinput['productName']) < 1:
            errorList.append("You need to enter some text for the name field!\n")
        if len(pinput['productDescription']) < 1:
            errorList.append("You need to enter some text for the description field!\n")
        if not errorList:
            '{:100,.2f}'.format(here)
            self.create(name = pinput['productName'], description = pinput['productDescription'], price = here)
            return True, errorList
        return False, errorList

    def editProduct1(self, pinput, productID):
        errorList = []
        try:
             here = float(pinput['productPrice'])
        except Exception as e:
             here = str(pinput['productPrice'])
        if not isinstance(here, float):
            errorList.append("You need to enter a number for the Price!\n")
        if len(pinput['productName']) < 1:
            errorList.append("You need to enter some text for the name field!\n")
        if len(pinput['productDescription']) < 1:
            errorList.append("You need to enter some text for the description field!\n")
        if not errorList:
            '{:100,.2f}'.format(here)
            self.filter(id=productID).update(name = pinput['productName'], description = pinput['productDescription'], price = here)
            return True, errorList
        return False, errorList

    def removeProducts(self, productID):
        self.filter(id=productID).delete()
        return True

class Product(models.Model):
    name = models.CharField(max_length=200)
    description = models.TextField(max_length=1000)
    price = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    rManager = RestfulManager()

from __future__ import unicode_literals
from django.contrib import messages
from django.db import models
import bcrypt
import re

from datetime import date
import datetime

PASSWORD_REGEX = re.compile(r'^.{7,}$')

class UserManager(models.Manager):
    # Call this function to check for validation and register and login the user
    def registration(self, userInput):
        errorList = []
        if len(userInput['name']) < 3:
            errorList.append('First name needs to be greater than 3 letters!\n')
        if not all(x.isalpha() or x.isspace() for x in userInput['name']):
            errorList.append('First name may only contain letters and spaces!\n')
        if len(userInput['username']) < 1:
            errorList.append('Username cannot be empty!')
        if not PASSWORD_REGEX.match(userInput['password']):
            errorList.append('Password is not long enough.\n')
        if userInput['password'] != userInput['confirm_password']:
            errorList.append('Password match not confirmed.\n')
        if self.filter(username = userInput['username']):
            errorList.append('This email already exists in our database.\n')
        if not errorList:
            hashed = bcrypt.hashpw(userInput['password'].encode(), bcrypt.gensalt())
            current_user = self.create(name = userInput['name'], username = userInput['username'], password = hashed)
            return True, current_user
        return False, errorList

    # Call this function to check for validation and login the user.
    def login(self, userInput):
        errorList = []
        if not userInput['username'] and not userInput['password']:
            errorList.append('Unsuccessful login. Please fill in the email and password field!\n')
            return False, errorList
        if self.filter(username = userInput['username']):
            hashed = self.get(username = userInput['username']).password.encode()
            password = userInput['password'].encode()
            if bcrypt.hashpw(password, hashed) == hashed:
                return True, self.get(username=userInput['username'])
            else:
                errorList.append('Unsuccessful login. Incorrect password!\n')
        else:
            errorList.append('Unsuccessful login. Your username is incorrect!\n')
        return False, errorList


class User(models.Model):
    name = models.CharField(max_length=200)
    username = models.CharField(max_length=200)
    password = models.CharField(max_length=200)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    userManager = UserManager()

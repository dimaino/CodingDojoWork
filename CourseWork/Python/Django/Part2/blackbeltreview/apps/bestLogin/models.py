from __future__ import unicode_literals
from django.contrib import messages
from django.db import models
import bcrypt
import re

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
PASSWORD_REGEX = re.compile(r'^.{7,}$')

class UserManager(models.Manager):
    # Call this function to check for validation and register and login the user
    def registration(self, userInput):
        errorList = []
        if len(userInput['first_name']) < 2:
            errorList.append('First name needs to be greater than 2 letters!\n')
        if len(userInput['last_name']) < 2:
            errorList.append('Last name needs to be greater than 2 letters!\n')
        if not userInput['first_name'].isalpha():
            errorList.append('First name may only contain letters!\n')
        if not userInput['last_name'].isalpha():
            errorList.append('Last name may only contain letters!\n')
        if not EMAIL_REGEX.match(userInput['email']):
            errorList.append('Email is not a valid email! Try this format: something@example.com\n')
        if not PASSWORD_REGEX.match(userInput['password']):
            errorList.append('Password is not long enough.\n')
        if userInput['password'] != userInput['confirm_password']:
            errorList.append('Password match not confirmed.\n')
        if self.filter(email = userInput['email']):
            errorList.append('This email already exists in our database.\n')
        if not errorList:
            hashed = bcrypt.hashpw(userInput['password'].encode(), bcrypt.gensalt())
            current_user = self.create(first_name = userInput['first_name'], last_name = userInput['last_name'], email = userInput['email'], password = hashed)
            return True, current_user
        return False, errorList

    # Call this function to check for validation and login the user.
    def login(self, userInput):
        errorList = []
        if not userInput['email'] and not userInput['password']:
            errorList.append('Unsuccessful login. Please fill in the email and password field!\n')
            return False, errorList
        if self.filter(email = userInput['email']):
            hashed = self.get(email = userInput['email']).password.encode()
            password = userInput['password'].encode()
            if bcrypt.hashpw(password, hashed) == hashed:
                return True, self.get(email=userInput['email'])
            else:
                errorList.append('Unsuccessful login. Incorrect password!\n')
        else:
            errorList.append('Unsuccessful login. Your email is incorrect!\n')
        return False, errorList


class User(models.Model):
    first_name = models.CharField(max_length=200)
    last_name = models.CharField(max_length=200)
    email = models.EmailField()
    password = models.CharField(max_length=200)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    userManager = UserManager()

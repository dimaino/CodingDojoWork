from __future__ import unicode_literals
from django.contrib import messages
from django.db import models
import bcrypt
import re
import math

NAME_REGEX=re.compile(r'^[a-zA-Z]{2,}$')
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
PASSWORD_REGEX = re.compile(r'^.{7,}$')
NUMBER_REGEX = re.compile(r'^[0-9]*$')

class UserManager(models.Manager):
    def registration(self, userInfo):
        errorList = []
        if not NAME_REGEX.match(userInfo['first_name']):
            errorList.append('First name needs to be greater than 2 characters and can only contain letters!\n')
        if not NAME_REGEX.match(userInfo['last_name']):
            errorList.append('Last name needs to be greater than 2 characters and can only contain letters!\n')
        if not EMAIL_REGEX.match(userInfo['email']):
            errorList.append('Email is not a valid email!\n')
        if not PASSWORD_REGEX.match(userInfo['password']):
            errorList.append('Password is not long enough.\n')
        if userInfo['password'] != userInfo['confirm_password']:
            errorList.append('Password match not confirmed.\n')
        if self.filter(email = userInfo['email']):
            errorList('This email already exists in our database.\n')
        if not NUMBER_REGEX.match(userInfo['birthday']) or not userInfo['birthday']:
            errorList.append('Not a number!\n')
        elif int(userInfo['birthday']) < 0 or int(userInfo['birthday']) > 120:
            errorList.append('Your age must be between 0 and 120 years of age :D\n')
        if not errorList:
            hashed = bcrypt.hashpw(userInfo['password'].encode(), bcrypt.gensalt())
            self.create(first_name = userInfo['first_name'], last_name = userInfo['last_name'], email = userInfo['email'], password = hashed, birthday= userInfo['birthday'])
            #request.session['daniela'] = self.get(email=userInfo['email']).id
            current_user = self.get(email=userInfo['email'])
            return True, current_user
        return False, errorList

    def login(self, userInfo):
        errorList = []
        if self.filter(email = userInfo['email']):
            hashed = self.get(email = userInfo['email']).password
            hashed = hashed.encode('utf-8')
            password = userInfo['password']
            password = password.encode('utf-8')
            if bcrypt.hashpw(password, hashed) == hashed:
                #request.session['daniela'] = self.get(email=userInfo['email']).id
                current_user = self.get(email=userInfo['email'])
                return True, current_user
            else:
                errorList.append('Unsuccessful login. Incorrect password\n')
        errorList.append('Unsuccessful login. Your email is incorrect.\n')
        return False, errorList


class User(models.Model):
    first_name = models.CharField(max_length=200)
    last_name = models.CharField(max_length=200)
    email = models.EmailField()
    password = models.CharField(max_length=200)
    birthday = models.PositiveIntegerField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)

    userManager = UserManager()

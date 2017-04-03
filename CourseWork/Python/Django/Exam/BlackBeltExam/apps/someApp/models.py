from __future__ import unicode_literals
from django.db import models
from ..bestLogin.models import User

import bcrypt
import re

from datetime import date
import datetime

DATE_REGEX = re.compile(r'^[0-9]{4}-[0-9]{2}-[0-9]{2}$')

class TravelManager(models.Manager):
    def addTrip(self, stuff, userId):
        errorlist = []
        startdate = None
        enddate = None
        if len(stuff['destination']) < 1 or len(stuff['description']) < 1 or len(stuff['travelStart']) < 1 or len(stuff['travelEnd']) < 1:
            errorlist.append("Check all you fields to make sure they aren't empty!\n")
        if not DATE_REGEX.match(stuff['travelStart']) or not DATE_REGEX.match(stuff['travelEnd']):
            errorlist.append("Your dates needs to be entered with the correct input use the date picker!!!\n")

        try:
            startdate = datetime.datetime.strptime(stuff['travelStart'], "%Y-%m-%d")
            enddate = datetime.datetime.strptime(stuff['travelEnd'], "%Y-%m-%d")
            if startdate > enddate:
                errorlist.append("Start date cannot be before To date!\n")
            if enddate < datetime.datetime.now() or startdate < datetime.datetime.now():
                errorlist.append("You can't plan in the past!\n")
        except Exception:
            if DATE_REGEX.match(stuff['travelStart']):
                errorlist.append("Not an actual date for Travel From Date!\n")
            if DATE_REGEX.match(stuff['travelEnd']):
                errorlist.append("Not an actual date for Travel To Date!\n")

        if not errorlist:

            selected_user = User.userManager.get(id=userId)
            self.create(creator=selected_user, trip=stuff['destination'], description=stuff['description'], travelStart=stuff['travelStart'], travelEnd=stuff['travelEnd'])
            return True, None
        return False, errorlist

    def joinTrip(self, tripId, userId):
        selected_user = User.userManager.get(id=userId)
        trip1 = self.get(id=tripId)
        trip1.allusertrips.add(selected_user)
        trip1.save()



class Trip(models.Model):
    creator = models.ForeignKey(User)
    trip = models.CharField(max_length=200)
    description = models.TextField(max_length=1000)
    travelStart = models.CharField(max_length=200)
    travelEnd = models.CharField(max_length=200)
    allusertrips = models.ManyToManyField(User, related_name="usersontrips")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now = True)
    tManager = TravelManager()

from __future__ import unicode_literals
from django.db import models
from ..app1.models import User

class UserManager(models.Manager):
    def addUserToCourse(self, stuff):
        selected_user = User.userManager.get(id=stuff['user'])
        selected_course = Course.uManager.get(id=stuff['course'])
        selected_course.user.add(selected_user)
        selected_course.save()


class Course(models.Model):
    course_name = models.CharField(max_length=150)
    description = models.TextField()
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now = True)
    user = models.ManyToManyField(User)
    uManager = UserManager()

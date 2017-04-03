from django.shortcuts import render, redirect
from .models import Course
from django.core.urlresolvers import reverse
from ..app1.models import User
from django.db.models import Count
from django.contrib import messages
import math
# Create your views here.
def index(request):
    context = { "courses" : Course.uManager.all()}
    return render(request, 'courses_app/index.html', context)

def addcourse(request):
    Course.uManager.create(course_name=request.POST['course_name'], description=request.POST['description'])
    return redirect(reverse('courseApp:index'))

def removecourse(request, id):
    context = {
        "course": Course.uManager.get(id=id)
    }
    return render(request, 'courses_app/remove.html', context)

def removethis(request, id):
    this = Course.uManager.get(id=id)
    this.delete()
    return redirect(reverse('courseApp:index'))

def addusertocourse(request):
    if request.method == 'POST':
        try:
            Course.uManager.addUserToCourse(request.POST)
        except Exception:
            print "Not a number"
            messages.error(request, "You need to pick both fields!")
            return redirect('courseApp:addusertocourse')
    countusers = Course.uManager.annotate(num_users=Count('user'))
    context = {
        "users": User.userManager.all(),
        "courses": Course.uManager.all(),
        "counts": countusers
    }
    return render(request, 'courses_app/addusertocourse.html', context)

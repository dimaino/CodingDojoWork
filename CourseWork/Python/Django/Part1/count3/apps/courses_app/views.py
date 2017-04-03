from django.shortcuts import render, redirect
from .models import Course
from django.core.urlresolvers import reverse
from ..loginapps.models import User
from django.db.models import Count
# Create your views here.
def index(request):
    context = { "courses" : Course.objects.all()}
    return render(request, 'courses_app/index.html', context)

def addcourse(request):
    Course.objects.create(course_name=request.POST['course_name'], description=request.POST['description'])
    return redirect(reverse('coursesApp:index'))

def removecourse(request, id):
    context = {
        "course": Course.objects.get(id=id)
    }
    return render(request, 'courses_app/remove.html', context)

def removethis(request, id):
    this = Course.objects.get(id=id)
    this.delete()
    return redirect(reverse('coursesApp:index'))

def addusertocourse(request):
    if request.method == 'POST':
        selected_user = User.objects.get(id=request.POST['user'])
        selected_course = Course.objects.get(id=request.POST['course'])
        selected_course.user.add(selected_user)
        selected_course.save()
    countusers = Course.objects.annotate(num_users=Count('user'))
    context = {
        "users": User.userManager.all(),
        "courses": Course.objects.all(),
        "counts": countusers
    }
    return render(request, 'coursesapp/addusertocourse.html', context)

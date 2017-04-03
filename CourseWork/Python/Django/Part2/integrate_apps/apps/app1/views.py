from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from .models import User

def index(request):
    context = {
        'something':User.userManager.all(),
        'hashed':User.userManager.values('password')
    }
    request.session['currentUser'] = None
    return render(request, 'app1/index.html', context)

def register(request):
    if request.method == 'POST':
        user = User.userManager.registration(request.POST)
        if not user[0]:
            for i in range(0, len(user[1])):
                messages.error(request, user[1][i])
            return redirect ('index')
        else:
            request.session['currentUser'] = user[1].id
            return redirect('users:success')

def login(request):
    user = User.userManager.login(request.POST)
    if not user[0]:
        for i in range(0, len(user[1])):
            messages.error(request, user[1][i])
        return redirect('users:index')
    else:
        request.session['currentUser'] = user[1].id
        return redirect ('users:success')

def success(request):
    if request.session['currentUser'] != None:
        context = {
            "thing":User.userManager.filter(id=request.session['currentUser'])
        }
        return render(request, 'app1/success.html', context)
    else:
        messages.warning(request, "woah woah back the fuck up and login or register!")
        return redirect('users:index')

def logout(request):
    request.session['currentUser'] = None
    return redirect('users:index')

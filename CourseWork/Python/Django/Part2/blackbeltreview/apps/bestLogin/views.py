from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from .models import User

def index(request):
    context = {
        'showRegisteredUsers':User.userManager.all(),
    }
    request.session['currentUser'] = None
    return render(request, 'bestLogin/index.html', context)

def register(request):
    if request.method == 'POST':
        user = User.userManager.registration(request.POST)
        if not user[0]:
            for i in range(0, len(user[1])):
                messages.error(request, user[1][i])
            return redirect ('loginUsers:index')
        else:
            request.session['currentUser'] = user[1].id
            return redirect('books:index')

def login(request):
    user = User.userManager.login(request.POST)
    if not user[0]:
        for i in range(0, len(user[1])):
            messages.error(request, user[1][i])
        return redirect('loginUsers:index')
    else:
        request.session['currentUser'] = user[1].id
        return redirect ('books:index')

def logout(request):
    request.session['currentUser'] = None
    messages.success(request, "You have been successfully logged out!")
    return redirect('loginUsers:index')

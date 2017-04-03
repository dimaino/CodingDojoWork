from django.shortcuts import render, redirect
from .models import Secret
from ..bestLogin.models import User
from django.contrib import messages
from django.db.models import Count

def index(request):
    if request.session['currentUser'] != None:
        countlikes = Secret.sManager.annotate(num_likes=Count('user_likes')).order_by('created_at').reverse()[:5]
        context = {
                'currUser':User.userManager.get(id=request.session['currentUser']),
                'showSecrets':Secret.sManager.order_by('created_at').all().reverse()[:5],
                'showDeleteMessage':Secret.sManager.filter(id=request.session['currentUser'])[:5],
                'countlikess':countlikes
            }
    else:
        messages.warning(request, "Please Login or Register to reach this url!\n")
        return redirect('loginUsers:index')
    return render(request, "secrets/index.html", context)

def postSecret(request):
    if request.method == "POST":
        Secret.sManager.addNewSecret(request.POST, request.session['currentUser'])
        return redirect('dojoSecrets:index')
    return redirect('dojoSecrets:index')

def deleteSecret(request, id):
    if request.method == "POST":
        result = Secret.sManager.deleteUserSecret(id, request.session['currentUser'])
        return redirect('dojoSecrets:index')
    elif request.method == "GET":
        result = Secret.sManager.deleteUserSecret(id, request.session['currentUser'])
        return redirect('dojoSecrets:popular')

def secretLikes(request, id):
    if request.method == "POST":
        result = Secret.sManager.addNewLike(id, request.session['currentUser'])
        #if result == False:
        return redirect('dojoSecrets:index')
    elif request.method == "GET":
        result = Secret.sManager.addNewLike(id, request.session['currentUser'])
        return redirect('dojoSecrets:popular')

def mostPopularSecrets(request):
    #theLols = Secret.sManager.annotate(num_likes=Count('user_likes')).order_by('-num_likes')[:5]
    # context = {
    #     'countlikes':theLols,
    #     'currentUser':User.userManager.get(id=request.session['currentUser']),
    # }
    countlikes = Secret.sManager.annotate(num_likes=Count('user_likes')).order_by('-num_likes')[:5]
    context = {
            'currUser':User.userManager.get(id=request.session['currentUser']),
            'showSecrets':Secret.sManager.order_by('-num_likes').all()&Secret.sManager.annotate(num_likes=Count('user_likes')),
            'showDeleteMessage':Secret.sManager.filter(id=request.session['currentUser'])[:5],
            'countlikess':countlikes
        }
    return render(request, "secrets/index2.html", context)

from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from ..bestLogin.models import User
from .models import Trip
from django.db.models import Count

def index(request):
    if request.session['currentUser'] != None:
        selected_user = User.userManager.get(id=request.session['currentUser'])
        thing = Trip.tManager.annotate(userstrip=Count('allusertrips'))
        context = {
            'currentUser':User.userManager.get(id=request.session['currentUser']),
            'myTrips':Trip.tManager.filter(creator=selected_user)|Trip.tManager.filter(allusertrips__id=selected_user.id),
            'allTrips':Trip.tManager.all().exclude(creator=selected_user).exclude(allusertrips__id=selected_user.id),
            'countTrips': thing
        }
        return render(request, 'someApp/index.html', context)
    else:
        messages.warning(request, "Please Login or Register to reach that url!")
        return redirect('loginUsers:index')

def destinationInfo(request, id):
     context = {
         'currTrip':Trip.tManager.get(id=id),
         'otherUsers':User.userManager.filter(usersontrips__id=id)
     }
     return render(request, 'someApp/destination.html', context)

def addTripPage(request):
    context = {
        'currentUser':User.userManager.get(id=request.session['currentUser'])
    }
    return render(request, "someApp/addtrip.html", context)

def addTrip(request):
    triplol = Trip.tManager.addTrip(request.POST, request.session['currentUser'])
    if not triplol[0]:
        for i in range(0, len(triplol[1])):
            messages.error(request, triplol[1][i])
        return redirect('someApp:addTripPage')
    else:
        return redirect('someApp:index')

def joinTrip(request, id):
    result = Trip.tManager.joinTrip(id, request.session['currentUser'])
    return redirect('someApp:index')

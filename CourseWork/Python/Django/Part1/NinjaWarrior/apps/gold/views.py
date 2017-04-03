from django.shortcuts import render, HttpResponse, redirect
import random
import time
# Create your views here.
def index(request):
	return render(request, "gold/index.html")

def moneyProcess(request):
    sentence = ""
    # try:
    #     request.session['hey'].append("ads")
    # except:
    #     request.session['hey'] = ""
    if 'hey' not in request.session:
        request.session['hey'] = []
    if 'wordTracker' not in request.session:
        request.session['wordTracker'] = []

    try:
        request.session['totalGold'] += 0
    except:
        request.session['totalGold'] = 0
    # try:
    #     request.session['wordTracker'] += ""
    # except:
    #     request.session['wordTracker'] = ""
    try:
        request.session['counter'] += 1
    except:
        request.session['counter'] = 0
    request.session['hey'].append("hey")
    request.session['colorText'] = True
    winOlose = random.randrange(0, 101)
    if request.method == "POST":
        if request.POST['btn'] == "farm":
            request.session['gold'] = random.randrange(10,20)
            request.session['totalGold'] += request.session['gold']
            sentence += "Earned " + str(request.session['gold']) + " golds from the farm! " + str(time.strftime("%Y-%m-%d %I:%M %p") + "\n")
            request.session['wordTracker'].append(dict({'color':'green', 'sentence':sentence}))
        if request.POST['btn'] == "cave":
            request.session['gold'] = random.randrange(5,10)
            request.session['totalGold'] += request.session['gold']
            sentence = "Earned " + str(request.session['gold']) + " golds from the cave! " + str(time.strftime("%Y-%m-%d %I:%M %p") + "\n")
            request.session['wordTracker'].append(dict({'color':'green', 'sentence':sentence}))
        if request.POST['btn'] == "house":
            request.session['gold'] = random.randrange(2,5)
            request.session['totalGold'] += request.session['gold']
            sentence += "Earned " + str(request.session['gold']) + " golds from the house! " + str(time.strftime("%Y-%m-%d %I:%M %p") + "\n")
            request.session['wordTracker'].append(dict({'color':'green', 'sentence':sentence}))
        if request.POST['btn'] == "casino":
            request.session['gold'] = random.randrange(0,50)
            if winOlose >= 50:
                request.session['totalGold'] += request.session['gold']
                sentence += "Earned " + str(request.session['gold']) + " golds from the casino! " + str(time.strftime("%Y-%m-%d %I:%M %p") + "\n")
                request.session['wordTracker'].append(dict({'color':'green', 'sentence':sentence}))
            else:
                if int(request.session['totalGold']) > int(request.session['gold']):
                    request.session['colorText'] = False
                    request.session['totalGold'] -= request.session['gold']
                    sentence += "Took " + str(request.session['gold']) + " golds from the casino! " + str(time.strftime("%Y-%m-%d %I:%M %p") + "\n")
                    request.session['wordTracker'].append(dict({'color':'red', 'sentence':sentence}))
                else:
                    request.session['colorText'] = False
                    request.session['totalGold'] = 0
                    sentence += "Tried to take " + str(request.session['gold']) + " golds but couldn't because you cant have less than 0! " + str(time.strftime("%Y-%m-%d %I:%M %p") + "\n")
                    request.session['wordTracker'].append(dict({'color':'red', 'sentence':sentence}))
    request.session.modified = True
    thing = request.session['wordTracker']
    return redirect("/")

def reset(request):
    request.session.pop('totalGold', None)
    request.session.pop('wordTracker', None)
    request.session.pop('hey', None)
    return redirect("/")

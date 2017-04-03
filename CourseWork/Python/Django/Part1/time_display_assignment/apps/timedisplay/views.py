from django.shortcuts import render, HttpResponse
import time
def index(request):
    time1 = time.strftime('%b %d, %Y %I:%M%p')
    context = {
        "somekey":time1
    }
    return render(request,'timedisplay/index.html', context)

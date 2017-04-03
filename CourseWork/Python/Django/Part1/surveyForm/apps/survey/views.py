from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
	return render(request, "survey/index.html")

def surveyProcess(request):
    request.session['name1'] = request.POST['fullName']
    request.session['loca'] = request.POST['loc']
    request.session['lang'] = request.POST['lan']
    request.session['mess'] = request.POST['message']
    try:
        request.session['count'] += 1
    except Exception as e:
        request.session['count'] = 1
    return redirect('/result')


def result(request):
    return render(request, "survey/survey.html")

from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
	return render(request, "disninja/index.html")

def stuff(request):
    context = {
        "imagesrc":"images/tmnt.png"
    }
    return render(request, "disninja/ninjas.html", context)

def ninjas(request, color):
    context = {
        'color':color,
        'imagesrc':color
    }
    if color == "blue":
        context["imagesrc"] = "images/leonardo.jpg"
    elif color == "orange":
        context["imagesrc"] = "images/michelangelo.jpg"
    elif color == "red":
        context["imagesrc"] = "images/raphael.jpg"
    elif color == "purple":
        context["imagesrc"] = "images/donatello.jpg"
    else:
        context["imagesrc"] = "images/notapril.jpg"
    return render(request, "disninja/ninjas.html", context)

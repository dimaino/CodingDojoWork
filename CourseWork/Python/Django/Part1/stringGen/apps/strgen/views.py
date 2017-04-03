from django.shortcuts import render, HttpResponse
import string
import random

def index(request):
    if request.method == "POST":
        request.session['key'] = string_gen()
        try:
            request.session['lolz'] += 1
        except Exception as e:
            request.session['lolz'] = 1

        return render(request, "strgen/index.html")
    else:
        return render(request, "strgen/index.html")
	return render(request, "strgen/index.html")

def string_gen(size=14, chars=string.ascii_uppercase + string.digits):
    return ''.join(random.choice(chars) for _ in range(size))

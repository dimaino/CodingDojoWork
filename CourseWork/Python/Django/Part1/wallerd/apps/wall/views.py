from django.shortcuts import render, HttpResponse
from .models import Users, Messages, Comments
# Create your views here.
def index(request):
    Users.objects.create(first_name="Daniel", last_name="Imaino", email="dimaino@comcast.net", password="12345678")
    users = Users.objects.all()
    print users
    return render(request, "wall/index.html")

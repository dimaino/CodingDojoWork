from django.shortcuts import render, HttpResponse
from forms import ContactForm
from django.contrib.sessions.backends.db import SessionStore

# Create your views here.
def contact(request):
    request.session.name = ""
    form = ContactForm()
    if request.method == 'GET':
        form = ContactForm()
    else:
        form = ContactForm(request.POST)
        if form.is_valid():
            content = form.cleaned_data['contact_name']
            request.session.name = content

    #form = ContactForm()
    #s = SessionStore()
    #form_class = ContactForm(request.POST)
    #s['key'] = form_class.cleaned_data['contact_name']
    #s = SessionStore(session_key='2b1189a188b44ad18c35e113ac6ceead')
    return render(request, "lol_app/index.html", {'form':form})

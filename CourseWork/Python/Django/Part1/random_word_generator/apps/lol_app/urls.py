from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.contact, name='home')
    #url(r'^contact/$', views.contact, name='contact')
]

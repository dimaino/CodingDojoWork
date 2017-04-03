from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name="index"),
    url(r'^addcourse$', views.addcourse, name="addcourse"),
    url(r'^removecourse/(?P<id>\d+)$', views.removecourse, name="removecourse"),
    url(r'^removethis/(?P<id>\d+)$', views.removethis, name="removethis"),
    url(r'^addusertocourse', views.addusertocourse, name="addusertocourse"),
]

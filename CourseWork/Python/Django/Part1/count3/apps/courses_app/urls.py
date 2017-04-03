from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name="coursesapp_index"),
    url(r'^addcourse$', views.addcourse, name="coursesapp_addcourse"),
    url(r'^removecourse/(?P<id>\d+)$', views.removecourse, name="coursesapp_removecourse"),
    url(r'^removethis/(?P<id>\d+)$', views.removethis, name="coursesapp_removethis"),
    url(r'^addusertocourse', views.addusertocourse, name="coursesapp_addusertocourse"),
]

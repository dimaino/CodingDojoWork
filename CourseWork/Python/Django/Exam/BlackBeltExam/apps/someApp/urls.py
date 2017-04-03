from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name ="index"),
    url(r'^add$', views.addTripPage, name="addTripPage"),
    url(r'^add/tripinfo$', views.addTrip, name="addTrip"),
    url(r'^destination/(?P<id>\d+)$', views.destinationInfo, name="tripDetails"),
    url(r'^join/(?P<id>\d+)$', views.joinTrip, name="tripJoin"),
]

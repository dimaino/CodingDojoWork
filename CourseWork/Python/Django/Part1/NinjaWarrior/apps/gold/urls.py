from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^process$', views.moneyProcess),
    url(r'^reset$', views.reset)
]

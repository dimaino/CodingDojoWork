from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^addPost$', views.postSecret, name='addPost'),
    url(r'^deletePost/(?P<id>\d+)$', views.deleteSecret, name='deletePost'),
    url(r'^likes/(?P<id>\d+)$', views.secretLikes, name='likes'),
    url(r'^secrets/$', views.mostPopularSecrets, name='popular'),
]

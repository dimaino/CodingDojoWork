from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name='index'),
    url(r'^products/new$', views.newProduct, name='newProduct'),
    url(r'^products/show/(?P<id>\d+)$', views.showProduct, name='showProduct'),
    url(r'^products/edit/(?P<id>\d+)$', views.editProduct, name='editProduct'),
    url(r'^products/update/(?P<id>\d+)$', views.updateProduct1, name='updateProduct1'),
    url(r'^products/delete/(?P<id>\d+)$', views.removeProduct, name='removeProduct'),
    url(r'^products/createNewProduct$', views.createProduct, name='createProduct'),
]

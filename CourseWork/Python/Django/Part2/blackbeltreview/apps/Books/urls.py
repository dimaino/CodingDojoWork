from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index, name ="index"),
    url(r'^add$', views.bookandreviewPage, name= "bookreviewpage"),
    url(r'^addStuff$', views.makebookandreview, name = "madeBookandReview"),
    url(r'^(?P<id>\d+)$', views.showSpecificBook, name = "specificBook"),
    url(r'^addReview/(?P<id>\d+)$', views.addReviewToBook, name = "reviewToBook"),
    url(r'^deleteReview/(?P<id>\d+)$', views.deleteReview, name = "delete"),
    url(r'^users/(?P<id>\d+)$', views.showUserAndReviewedBooks, name = "showUser"),
]

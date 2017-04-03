from __future__ import unicode_literals
from django.db import models
from ..bestLogin.models import User
import re, time

class BookManager(models.Manager):
    # Creates the Review, Author, and Book objects
    def addBookandReview(self, formData, userId):
        errorlist = []
        authorsname = ""
        # Checks to make sure the forms aren't empty
        if len(formData['booktitle']) < 1 or len(formData['reviewcontent']) < 1:
            errorlist.append("Fill in all the fields!")

        try:
            if len(formData['authorname']) < 1:
                authorsname = formData['authorname1']
        except Exception as e:

            authorsname = formData['authorname']

        # Creates the review if there aren't strings in the errorlist
        if not errorlist:
            # Get the user object to add to the Review Table
            userobject = User.userManager.get(id=userId)
            # Should accept author and pass through author data to Book and Review models
            authorobject = Author.bManager.create(name=authorsname)
            # Should accept Book title and an author object
            bookobject = Book.bManager.create(title=formData['booktitle'], author=authorobject)
            # Should accept Review content, Review rating, a user object and a book object
            reviewobject = Review.bManager.create(content=formData['reviewcontent'], rating=formData['reviewrating'], user=userobject, book=bookobject)
            reviewobject.userReviews.add(userobject)
            reviewobject.save()
            print bookobject.id
            # Returns True as long as there are no errors and also a reviewobject
            return True, reviewobject
        # Returns false if there are errors and also sends a list of string errors
        return False, errorlist

    def addReview(self, formData, userId, bookId):
        errorlist = []
        userobject = User.userManager.get(id=userId)
        bookobject = Book.bManager.get(id=bookId)
        bo = False
        if len(formData['reviewcontent']) < 1:
            errorlist.append("Fill in all the fields!")

        try:
            if Review.bManager.get(user=userobject, book=bookobject) and not errorlist:
                Review.bManager.get(user=userobject, book=bookobject).delete()
                bo = True
                reviewobject = Review.bManager.create(content=formData['reviewcontent'], rating=formData['reviewrating'], user=userobject, book=bookobject)
                reviewobject.userReviews.add(userobject)
                reviewobject.save()
        except Exception as e:
            pass


        if not errorlist and not bo:
            reviewobject = Review.bManager.create(content=formData['reviewcontent'], rating=formData['reviewrating'], user=userobject, book=bookobject)
            reviewobject.userReviews.add(userobject)
            reviewobject.save()
            return True, reviewobject

        return False, errorlist

    def delReview(self, reviewId):
        reviewdel = self.get(id=reviewId)
        bookid = reviewdel.book.id
        self.get(id=reviewId).delete()

        print bookid
        return bookid

class Author(models.Model):
    name = models.CharField(max_length=100)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    bManager = BookManager()

class Book(models.Model):
    title = models.CharField(max_length=100)
    author = models.ForeignKey(Author, related_name="bookauthor")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    bManager = BookManager()

class Review(models.Model):
    content = models.TextField(max_length=100)
    rating = models.TextField(max_length=100)
    user = models.ForeignKey(User, related_name="auserreview")
    book = models.ForeignKey(Book, related_name="bookreview")
    userReviews = models.ManyToManyField(User, related_name="usersthatreview")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    bManager = BookManager()

    class Meta:
        unique_together = (('user', 'book'),)

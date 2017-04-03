from django.shortcuts import render, HttpResponse, redirect
from django.contrib import messages
from ..bestLogin.models import User
from .models import Review, Book, Author
from django.db.models import Count, Avg

def index(request):
	# For clearing all information in the database!
	#Review.bManager.all().delete() # This is here to get rid of bad data.
	#Book.bManager.all().delete()
	#Author.bManager.all().delete()

	# Check if the user is currently logged in with a session
	if request.session['currentUser'] != None:
		count1 = Book.bManager.annotate(numReviews=Count('bookreview__rating'))
		ratingList = []
		convertRatings = Review.bManager.all().order_by('-id')[:3]
		for i in convertRatings:

			addPercent = int(i.rating)*20
			ratingList.append(addPercent)
		revi = Review.bManager.all().order_by('id').distinct()
		context = {
		"currentUserLoggedIn":User.userManager.get(id=request.session['currentUser']),
		"Reviews":revi.order_by('-id')[:3],
		"Table1Test":Review.bManager.all().order_by('book__title'),
		"Table2Test":Book.bManager.all(),
		"Table3Test":Author.bManager.all(),
		"allUsers":User.userManager.all(),
		"someCount":count1,
		"theRatings":ratingList,
		}
		return render(request, "Books/index.html", context)
	else:
		messages.warning(request, "Please Login or Register to reach this url!")
		return redirect('loginUsers:index')

def bookandreviewPage(request):
	context = {
		'authors':Author.bManager.all(),
	}
	return render(request, "Books/addbookorreview.html", context)

def showSpecificBook(request, id):
	bookobject = Book.bManager.get(id=id)
	context = {
		'showReviews':Review.bManager.filter(book=bookobject),
		'showBook':bookobject,
	}
	return render(request, "Books/booksPage.html", context)

def makebookandreview(request):
	if request.method == "POST":
		review = Review.bManager.addBookandReview(request.POST, request.session['currentUser'])
		if not review[0]:
			for i in range(0, len(review[1])):
				messages.error(request, review[1][i])
			return redirect('books:bookreviewpage')
		else:
			return redirect('books:specificBook', id=review[1].book.id)

def addReviewToBook(request, id):
	review = Review.bManager.addReview(request.POST, request.session['currentUser'], id)
	if not review[0]:
		for i in range(0, len(review[1])):
			messages.error(request, review[1][i])
		return redirect('books:specificBook', id=id)
	else:
		return redirect('books:specificBook', id=id)

def deleteReview(request, id):
	bookID = Review.bManager.delReview(id)
	return redirect('books:specificBook', id=bookID)

def showUserAndReviewedBooks(request, id):
	userobject = User.userManager.get(id=id)
	count1 = Review.bManager.annotate(numReviews=Count('userReviews')).filter(user=userobject)
	counts = 0
	for i in range(0, len(count1)):
		counts += count1[i].numReviews
	context = {
		'showUser':User.userManager.get(id=id),
		'showUsersReviews':Review.bManager.filter(user=userobject),
		'reviewCount':counts
	}
	return render(request, "Books/Userreview.html", context)

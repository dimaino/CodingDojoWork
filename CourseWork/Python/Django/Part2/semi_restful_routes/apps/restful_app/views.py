from django.shortcuts import render, redirect
from django.contrib import messages
from .models import Product
from django.urls import reverse

def index(request):
    context = {
        'showAllProducts':Product.rManager.all()
    }
    return render(request, "restful_app/index.html", context)

def newProduct(request):
    return render(request, "restful_app/new_product.html")

def showProduct(request, id):
    context = {
        "currentProduct":Product.rManager.get(id=id)
    }
    return render(request, "restful_app/product_page.html", context)

def editProduct(request, id):
    context = {
        "currentProduct":Product.rManager.get(id=id)
    }
    return render(request, "restful_app/edit_product.html", context)

def removeProduct(request, id):
    if request.method == 'POST':
        Product.rManager.removeProducts(id)
        print "HERE"
    return redirect('rest:index')

def createProduct(request):
    if request.method == 'POST':
        thing = Product.rManager.addNewProduct(request.POST)
        if thing[0] != True:
            for i in range(0, len(thing[1])):
                messages.error(request, thing[1][i])
    return redirect('rest:newProduct')

def updateProduct1(request, id):
    if request.method == 'POST':
        thing = Product.rManager.editProduct1(request.POST, id)
        if not thing[0]:
            for i in range(0, len(thing[1])):
                messages.error(request, thing[1][i])
    return redirect('rest:editProduct', id=id)

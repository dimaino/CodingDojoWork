from flask import Flask, request, redirect, render_template, flash, session
from mysqlconnection import MySQLConnector
from flask_bcrypt import Bcrypt
import re
app = Flask(__name__)
mysql = MySQLConnector(app,'the_wall')
bcrypt = Bcrypt(app)
EMAIL_REGEX=re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX=re.compile(r'^[a-zA-Z]{2,}$')
app.secret_key = "AKeyofSecrets!"

#==============================================================================#
#                                                                              #
#                              Starting Route                                  #
#                                                                              #
#==============================================================================#
# Index method displays all the users.  This will need a view template.
@app.route('/users')
def index():

    select_query_for_user = "SELECT * FROM users"
    returnQueriedUsers = mysql.query_db(select_query_for_user)
    return render_template("index.html", usersTable=returnQueriedUsers)

#==============================================================================#
#                                                                              #
#                                New User Route                                #
#                                                                              #
#==============================================================================#
# New method displays a form allowing one to create a new user.  This will need a view template.
@app.route('/users/new')
def newUser():
    return render_template("the_wall.html")

# Edit method displays a form allowing one to edit the record for that specified user.  This will need a view template.
@app.route('/users/<id>/edit')
def editUser():
    return render_template("the_wall.html")

# Show method displays the info for that specified user.  This will need a view template.
@app.route('/users/<id>')
def showUser():
    return render_template("The_wall.html")

# Create method inserts a new user record into our database. This POST should be sent from the form on the page /users/new.  Have this redirect to /users/<id> once created (the id of the database record just created).
#@app.route('/users/create')
#def createUser():

# Destroy method removes the database record of that particular user.  Have this redirect back to /users once deleted.
@app.route('/users/<id>/destroy')
def destroyUser():
    redirect('/users')

# Update method processes the submitted form, which will change the database record for that particular user.  This POST should be sent from /users/<id>/edit. Have this redirect to /users/<id> once updated.
#@app.route('/users/<id>')
#def updateUser():
#    return redirect('/users')

app.run(debug=True)

from flask import Flask, request, redirect, render_template, flash, session
from mysqlconnection import MySQLConnector
from flask_bcrypt import Bcrypt
import re
app = Flask(__name__)
mysql = MySQLConnector(app,'registration')
bcrypt = Bcrypt(app)
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX=re.compile(r'[a-zA-Z]{2,}')
app.secret_key = "someSecretSadKey"


@app.route('/')
def index():
    return render_template('index.html')

@app.route('/register', methods=['POST'])
def register():
    working = True
    if not NAME_REGEX.match(request.form['first']):
        flash('Your First name can contain letters only , at least 2 characters!')
        working=False
    if not NAME_REGEX.match(request.form['last']):
        flash('Your Last name can contain letters only , at least 2 characters!')
        working=False
    if not EMAIL_REGEX.match(request.form['email']):
        flash('Invalid email!')
        working=False
    if not request.form['password']==request.form['password2']:
        flash('Your passwords are not matching')
        working=False
    if len(request.form['password'])<8:
        flash('Your password has to be 8 character or more!!')
        working=False
    if working==True:
        someNThings = bcrypt.generate_password_hash(request.form['password'])
        query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (:first_name, :last_name, :email, :password, NOW(), NOW())"
        data = {
            'first_name':request.form['first'],
            'last_name':request.form['last'],
            'email':request.form['email'],
            'password':someNThings
        }
        mysql.query_db(query, data)
        query_get_user = "SELECT * FROM users WHERE email= :email LIMIT 1"
        moreData = {
            'email':request.form['email']
        }
        returnDBinfo = mysql.query_db(query_get_user, moreData)
        session['user_id'] = returnDBinfo[0]['id']
        return redirect('/success')
    return redirect('/')

# Success is the route when a valid email and password are in the database.
# It queries for the specific login id that it got from the login route.
# Also it will display the data of the user at the success page such as first and last name and email.
@app.route('/success')
def success():
     query = "SELECT * FROM users WHERE id = :login_id"
     data = {'login_id': session['user_id']}
     returnSQL = mysql.query_db(query, data)
     return render_template('index2.html', users=returnSQL[0])

# Login is the route that checks for current entry of a user name and password in the database.
# If the login and password and vaild and are in the database it redirects the the success route.
@app.route('/login', methods=['POST'])
def login():
    loginCheck = True
    if len(request.form['email']) < 1:
            flash("Login Error - Email cannot be blank!")
            loginCheck = False
    if len(request.form['password']) < 1:
            flash("Login Error - Password cannot be blank!")
            loginCheck = False
    if loginCheck == True:
         email = request.form['email']
         password = request.form['password']
         user_query = "SELECT * FROM users WHERE email = :email"
         query_data = {
            'email': email
         }
         user = mysql.query_db(user_query, query_data)
         if len(user) == 0:
             flash("Login Error - You have not registered.")
             return redirect('/')
         if bcrypt.check_password_hash(user[0]['password'], password) and user[0]['email'] == email:
             session['user_id'] = user[0]['id']
             return redirect('/success')
         else:

             flash("Login Error - Your password is wrong.")
             return redirect('/')
    else:
        return redirect('/')

app.run(debug=True)

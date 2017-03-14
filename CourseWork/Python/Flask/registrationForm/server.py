from flask import Flask, render_template, redirect, request, session, flash
# the "re" module will let us perform some regular expression operations
import re
# create a regular expression object that we can use run operations on
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX = re.compile(r'[^0-9]+$')
UPPERCASE_REGEX = re.compile(r'[A-Z]+')
NUM_REGEX = re.compile(r'[0-9]+')
#BIRTH_REGEX = re.compile(r'\d{4}[-/]\d{2}[-/]\d{2}')

app = Flask(__name__)
app.secret_key = "ThisIsSecret!"
@app.route('/', methods=['GET'])
def index():
  return render_template("index.html")
@app.route('/process', methods=['POST'])
def submit():
    #str = request.form['birthday']
    #yearCheck = str[0] + str[1] + str[2] + str[3]
    #monthCheck = str[5] + str[6]
    #dayCheck = str[8] + str[9]
    #print yearCheck
    #print monthCheck
    #print dayCheck
    if len(request.form['email']) < 1:
        flash("Email cannot be blank!")
    elif not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
    else:
        flash("Email was successfully entered!")
    if len(request.form['first_name']) < 1:
        flash("First Name cannot be blank!")
    elif not NAME_REGEX.match(request.form['first_name']):
        flash("First Name cannot contain numbers!")
    else:
        flash("Name was successfully entered!")
    if len(request.form['last_name']) < 1:
        flash("Last Name cannot be blank!")
    elif not NAME_REGEX.match(request.form['last_name']):
        flash("Last Name cannot contain numbers!")
    else:
        flash("Last Name was successfully entered!")
    if len(request.form['password']) < 1:
        flash("Password cannot be blank!")
    elif len(request.form['password']) < 8:
        flash("NEED MOAR CHAR'S!")
    elif not UPPERCASE_REGEX.match(request.form['password']) and not NUM_REGEX.match(request.form['password']):
        flash("1 Uppercase Letter and Number")
    else:
        flash("Password was successfully entered!")
    if len(request.form['confirm_password']) < 1:
        flash("Confirm Password cannot be blank!")
    elif request.form['password'] != request.form['confirm_password']:
        flash("Passwords dont match")
    else:
        flash("Confirm Password was successfully entered!!")
    '''if not BIRTH_REGEX.match(request.form['birthday']):# and int(yearCheck) > 2018 and int(monthCheck) > 13 and int(dayCheck) > 32:
        flash("Birthday needs to be ended like 2017-12-31, 0000-00-00, year month day")
    else:
        flash("Birthday was successfully entered!!")
'''
    return redirect('/')
app.run(debug=True)

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
@app.route('/')
def index():
    return render_template("index.html")

#==============================================================================#
#                                                                              #
#                            Registeration Route                               #
#                                                                              #
#==============================================================================#
@app.route('/register', methods=['POST'])
def register():
    checkForValidRegister = True
    firstN = request.form['firstForm']
    lastN = request.form['lastForm']
    emailCheck = request.form['emailForm']
    password_1 = request.form['passwordForm']
    password_2 = request.form['passwordComForm']

    firstName = firstN.capitalize()
    lastName = lastN.capitalize()

    query_get_user_login_id = "SELECT * FROM users WHERE email = :email"
    userData = {
        'email': emailCheck
    }
    login_email_request = mysql.query_db(query_get_user_login_id, userData)

    if len(firstName) < 1:
        flash("First Name field cannot be empty!")
        checkForValidRegister = False
    elif not NAME_REGEX.match(firstName):
        flash("First Name must contain only letters and be a minimum of 2 letters!")
        checkForValidRegister = False
    if len(lastName) < 1:
        flash("Last Name field cannot be empty!")
        checkForValidRegister = False
    elif not NAME_REGEX.match(lastName):
        flash("Last Name must contain only letters and be a minimum of 2 letters!")
        checkForValidRegister = False
    if not password_1 == password_2:
        flash("Passwords don't match")
        checkForValidRegister = False
    if len(password_1) < 8:
        flash("Password length needs to be at least 8 characters long")
        checkForValidRegister = False
    if not EMAIL_REGEX.match(emailCheck):
        flash('Invalid Email - Check your formatting, should be like example@example.com')
        print "pass"
        checkForValidRegister = False
    if len(login_email_request) == 0:
        print "pass"
    elif login_email_request[0]['email'] == emailCheck:
        print "pass"
        flash("Email Address already in use. Please use another email address!")
        checkForValidRegister = False
    if checkForValidRegister == True:
        encrypted_password = bcrypt.generate_password_hash(password_1)
        insert_query = "INSERT INTO users (first_name, last_name, email, password, created_at, updated_at) VALUES (:first_name, :last_name, :email, :password, NOW(), NOW())"
        data_to_insert = {
            'first_name':firstName,
            'last_name':lastName,
            'email':emailCheck,
            'password':encrypted_password
        }
        mysql.query_db(insert_query, data_to_insert)
        query_get_user_login_id = "SELECT * FROM users WHERE email= :email LIMIT 1"
        moreData = {
            'email':emailCheck
        }
        returnDBinfo = mysql.query_db(query_get_user_login_id, moreData)
        session['user_id'] = returnDBinfo[0]['id']
        return redirect('/wall')
    return redirect('/')

#==============================================================================#
#                                                                              #
#                                 login Route                                  #
#                                                                              #
#==============================================================================#
@app.route('/login', methods=['POST'])
def login():
    checkForValidLogin = True;
    emailCheck = request.form['emailForm']
    password_1 = request.form['passwordForm']
    if len(emailCheck) < 1:
        flash("Login Error - Email Field cannot be empty!")
        checkForValidLogin = False
    if len(password_1) < 1:
        flash("Login Error = Password Field cannot be empty!")
        checkForValidLogin = False
    if checkForValidLogin == True:
        query_get_user_login_id = "SELECT * FROM users WHERE email = :email"
        userData = {
            'email': emailCheck
        }
        select_query_user_email = mysql.query_db(query_get_user_login_id, userData)
        if len(select_query_user_email) == 0:
            flash("Login Error - You have not registered.")
            return redirect('/')
        if bcrypt.check_password_hash(select_query_user_email[0]['password'], password_1) and select_query_user_email[0]['email'] == emailCheck:
            session['user_id'] = select_query_user_email[0]['id']
            return redirect('/wall')
        else:
            flash("Login Error - Your password is wrong.")
            return redirect('/')
    return redirect('/')

#==============================================================================#
#                                                                              #
#                                 Wall Route                                   #
#                                                                              #
#==============================================================================#
@app.route('/wall')
def success():
    query_for_user_id = "SELECT * FROM users WHERE id = :login_id"
    data_from_user_id = {
        'login_id':session['user_id']
    }
    returnQueriedInfo = mysql.query_db(query_for_user_id, data_from_user_id)

    session['userCheck'] = True
    session['messageCheck'] = True
    session['commentCheck'] = True

    select_query_for_user = "SELECT * FROM users"
    returnQueriedUsers = mysql.query_db(select_query_for_user)

    select_query_for_message = "SELECT * FROM messages ORDER BY created_at DESC"
    returnQueriedMessage = mysql.query_db(select_query_for_message)

    select_query_for_comment = "SELECT * FROM comments"
    returnQueriedComment = mysql.query_db(select_query_for_comment)

    session['messageLen'] = len(returnQueriedMessage)

    if len(returnQueriedUsers) == 0:
        session['userCheck'] = False
    if len(returnQueriedMessage) == 0:
        session['messageCheck'] = False
    if len(returnQueriedComment) == 0:
        session['commentCheck'] = False
    if session['messageCheck'] == True and session['commentCheck'] == False:
        session['commentCheck'] = False
        return render_template('the_wall.html', loginUser=returnQueriedInfo[0], messageInfo=returnQueriedMessage, userNames=returnQueriedUsers)
    if session['messageCheck'] == True and session['commentCheck'] == True:
        return render_template('the_wall.html', loginUser=returnQueriedInfo[0], messageInfo=returnQueriedMessage, userNames=returnQueriedUsers, commentInfo=returnQueriedComment)
    return render_template('the_wall.html', loginUser=returnQueriedInfo[0])

#==============================================================================#
#                                                                              #
#                              PostMessage Route                               #
#                                                                              #
#==============================================================================#
@app.route('/wall/postMessage', methods=['POST'])
def postMessage():
    messageText = request.form['post_a_message']
    insert_query_for_message = "INSERT INTO messages (user_id, messages, created_at, updated_at) VALUES (:user_id, :messages, NOW(), NOW())"
    messageData = {
        'user_id':session['user_id'],
        'messages':messageText
    }
    mysql.query_db(insert_query_for_message, messageData)
    return redirect('/wall')

#==============================================================================#
#                                                                              #
#                              postComment Route                               #
#                                                                              #
#==============================================================================#
@app.route('/wall/<id>/postComment', methods=['POST'])
def postComment(id):
    commentText = request.form['post_a_comment']
    if len(commentText) > 1:
        select_query_for_message = "SELECT * FROM messages WHERE id = :id"
        messageData = {
            'id':id
        }
        message_id_lol = mysql.query_db(select_query_for_message, messageData)

        insert_query_for_message = "INSERT INTO comments (message_id, user_id, comment, created_at, updated_at) VALUES (:message_id, :user_id, :comment, NOW(), NOW())"
        commentData = {
            'message_id':message_id_lol[0]['id'],
            'user_id':session['user_id'],
            'comment':commentText
        }
        mysql.query_db(insert_query_for_message, commentData)
        return redirect('/wall')
    else:
        flash("You cannot post blank entries!")
    return redirect('/wall')

#==============================================================================#
#                                                                              #
#                             deleteMessage Route                              #
#                                                                              #
#==============================================================================#
@app.route('/wall/<id>/deleteMessage', methods=['POST'])
def deleteMessage(id):
    select_query_for_message= "SELECT * FROM messages WHERE id = :id AND user_id = :user_id"
    messageData = {
        'id':id,
        'user_id':session['user_id']
    }
    message_id_lol = mysql.query_db(select_query_for_message, messageData)
    data = {
        'id':id
    }
    delete_comments_query = 'DELETE FROM comments WHERE message_id = :id'
    mysql.query_db(delete_comments_query, data)
    delete_messages_query = "DELETE FROM messages WHERE id = :id"
    mysql.query_db(delete_messages_query, data)
    return redirect('/wall')

#==============================================================================#
#                                                                              #
#                                 logout Route                                 #
#                                                                              #
#==============================================================================#
@app.route('/wall/logout', methods=['POST'])
def logout():
    session.pop('user_id', None)
    return redirect('/')

app.run(debug=True)

from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friends')
app.secret_key = "ThisIsSecret!"


@app.route('/')
def index():
    query = "SELECT * FROM list_friends"                         
    permanent = mysql.query_db(query)
    return render_template('index.html', makeupname=permanent )


@app.route('/friends', methods=['POST'])
def create():
    query = "INSERT INTO list_friends (first_name, last_name, age, created_at, updated_at) VALUES (:first_name, :last_name, :age, NOW(), NOW())"
    data = {
    'first_name':request.form['first'],
    'last_name':request.form['last'],
    'age':request.form['age']
    }
    mysql.query_db(query, data) 
    return redirect('/')


@app.route('/friends/<id>/edit',methods=['POST'] )
def edit(id): 
    query = "SELECT * FROM list_friends WHERE id= :id" 
    data = {'id': id}                        
    permanent1 = mysql.query_db(query, data)
    return render_template('index2.html', something=permanent1)

@app.route('/friends/<id>', methods=['POST'])
def update(id):
    query = "UPDATE list_friends SET first_name = :first_name, last_name = :last_name, age = :age WHERE id = :id"
    data = {
             'first_name': request.form['first'], 
             'last_name':  request.form['last'],
             'age': request.form['age'],
             'id': id
           }
    mysql.query_db(query, data)
    return redirect('/')


@app.route('/friends/<id>/delete', methods=['POST'])
def delete(id):
    print id
    query = "DELETE FROM list_friends WHERE id= :id"
    data = {'id': id}
    mysql.query_db(query, data)
    return redirect('/')



app.run(debug=True)
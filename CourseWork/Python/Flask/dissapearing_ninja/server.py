from flask import Flask, render_template, request, redirect, session, url_for
import random
import time
app = Flask(__name__)
app.secret_key='notyourbusiness'

@app.route('/')
def index():	
	return render_template('index.html')

@app.route('/ninja')
def ninja():
	session.pop("img", None)
	session["img"]=url_for('static', filename='tmnt.png', width=100)
	return render_template('index2.html')

@app.route('/ninja/blue')
def ninja_blue():
	session.pop("img", None)
	session['img']=url_for('static', filename='leonardo.jpg', width=100)
	return render_template('index2.html')

@app.route('/ninja/orange')
def ninja_orange():
	session.pop("img", None)
	session['img']=url_for('static', filename='michelangelo.jpg', width=100)
	return render_template('index2.html')

@app.route('/ninja/red')
def ninja_red():
	session.pop("img", None)
	session['img']=url_for('static', filename='raphael.jpg', width=100)
	return render_template('index2.html')

@app.route('/ninja/purple')
def ninja_purple():
	session.pop("img", None)
	session['img']=url_for('static', filename='donatello.jpg', width=100)
	return render_template('index2.html')

@app.route('/ninja/<x>')
def notapril(x):
	session.pop("img", None)
	session['img']=url_for('static', filename='notapril.jpg', width=100)
	return render_template('index2.html')


app.run(debug=True)
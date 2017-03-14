from flask import Flask, render_template, session, request, redirect
import time
import random

app = Flask(__name__)
app.secret_key = 'LOLBITCH'

#b = 0
@app.route('/')
def index():
    return render_template("index.html")

@app.route('/process_money', methods=['POST'])
def button_counter():
    #global b
    try:
        session['totalGold'] += 0
    except Exception as e:
        session['totalGold'] = 0
    try:
        session['activity'] += ""
    except Exception as e:
        session['activity'] = ""
    z = random.randrange(0,101)
    #current_time=datetime.utcnow()
    #print datetime.datetime.now().strftime("%Y-%m-%d %H:%M")
    if request.method == 'POST':
        if request.form['plc'] == 'farm':
            session['gold'] = random.randrange(10,20)
            a = int(session['gold'])
            b = int(session['totalGold'])
            b += a
            session['totalGold'] = b
            session['activity'] += "Earned " + str(a) + " golds from the farm! " + str(time.strftime("%Y-%m-%d %I:%M %p")) + "\n"
            print "Found GOld", a, b
        elif request.form['plc'] == 'cave':
            session['gold'] = random.randrange(5,10)
            a = int(session['gold'])
            b = int(session['totalGold'])
            b += a
            session['totalGold'] = b
            session['activity'] += "Earned " + str(a) + " golds from the cave! " + str(time.strftime("%Y-%m-%d %I:%M %p")) + "\n"
            print "something", a, b
        elif request.form['plc'] == 'house':
            session['gold'] = random.randrange(2,5)
            a = int(session['gold'])
            b = int(session['totalGold'])
            b += a
            session['totalGold'] = b
            session['activity'] += "Earned " + str(a) + " golds from the house! " + str(time.strftime("%Y-%m-%d %I:%M %p")) + "\n"
            print "something1", a, b
        elif request.form['plc'] == 'casino':
            if z >= 50:
                session['gold'] = random.randrange(0,50)
                a = int(session['gold'])
                b = int(session['totalGold'])
                b += a
                session['totalGold'] = b
                session['activity'] += "Earned " + str(a) + " golds from the casino! " + str(time.strftime("%Y-%m-%d %I:%M %p")) + "\n"
                print session['activity']
            else:
                session['gold'] = random.randrange(0,50)
                a = int(session['gold'])
                b = int(session['totalGold'])
                b -= a
                session['totalGold'] = b
                session['activity'] += "Took " + str(a) + " golds from the casino! " + str(time.strftime("%Y-%m-%d %I:%M %p")) + "\n"
                print session['activity']

    return redirect('/')

app.run(debug=True)

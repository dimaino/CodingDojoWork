from flask import Flask, render_template, session, request, redirect
app = Flask(__name__)
app.secret_key = 'LOLBITCH'

# This part counts when the page refreshes and also shows the default layout
@app.route('/')
def index():
    try:
        session['counter'] += 1
    except Exception:
        session['counter'] = 0
    return render_template("index.html")

# This part adds 1 plus the refresh page as one to look like its counting 2
# /data is the form being requested
# as long as the button is pressed (request.method == 'POST') add 2
@app.route('/data', methods=['POST'])
def button_counter():
    #if request.method == 'POST':
    session['counter'] += 1
    return redirect('/')

# This part reset the counter to 0 because refreshing counts the 1 and shows 1
# /somedata is the other form being requested
# as long as the button is pressed (request.method == 'POST') reset to 1
@app.route('/somedata', methods=['POST'])
def button_reset():
    #if request.method == 'POST':
    session['counter'] = 0
    return redirect('/')

app.run(debug=True)

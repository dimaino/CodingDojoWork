from flask import Flask, render_template
app = Flask(__name__)

@app.route('/')
def index():
  return render_template('index.html', phrase="Ello, govna")

@app.route('/ninja')
def ninja():
    return render_template('ninja.html')

@app.route('/dojo/new')
def dojos():
    return render_template('dojos.html')
app.run(debug=True)

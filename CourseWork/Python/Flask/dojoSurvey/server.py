from flask import Flask, render_template, request, redirect, url_for
app = Flask(__name__)

@app.route('/')
def index():
  return render_template('index.html')

@app.route('/data/<name>/<location>/<language>/<comment>')
def data(name, location, language, comment):
     return render_template('data.html', name=name, location=location, language=language, comment=comment)

@app.route('/submit', methods=['POST'])
def user_info():
    #print "Got Post Info"
    name = request.form['name']
    location = request.form['location']
    language = request.form['language']
    comment = request.form['text']
    return redirect(url_for('data', name=name, location=location, language=language, comment=comment))
    #return render_template('submit.html')#, name=name, location=location, language=language, comment=comment)
app.run(debug=True)

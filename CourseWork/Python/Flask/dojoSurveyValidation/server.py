from flask import Flask, render_template, request, flash, redirect
app = Flask(__name__)

app.secret_key = 'LOLBITCH'

@app.route('/')
def index():
  return render_template('index.html')

@app.route('/submit', methods=['POST'])
def user_info():
    if len(request.form['name']) < 1 or len(request.form['text']) < 1 or len(request.form['text']) > 119:
        print "BAD"
        flash("Failed! You SUCK!!! Name: {} Location: {} Language: {} Comments: {}".format(request.form['name'], request.form['location'], request.form['language'], request.form['text']))

        return render_template('submit.html')
    else:
        flash("Success! Name: {} Location: {} Language: {} Comments: {}".format(request.form['name'], request.form['location'], request.form['language'], request.form['text']))
        return render_template('submit.html')
    return redirect('/')
app.run(debug=True)

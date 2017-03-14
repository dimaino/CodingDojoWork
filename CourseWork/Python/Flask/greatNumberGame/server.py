from flask import Flask, render_template, session, request, redirect
'''
# Import flask and also import all theses predefined methods such as render_template.
# render_template - To render a template you can use the render_template() method. All you have to do is provide the name of the template.
# and the variables you want to pass to the template engine as keyword arguments. ex. return render_template("index.html", name=name, location=location)
# session - are objects which allows you to store information specific to a user from one request to the next. In order to use session's you must import it at the top.
# request - are objects that contain the data that the client (ex. a browser) has sent to your app - a request could call the URL parameters and any POST data.
# redirect - allows a user to go to another endpoint. So basically when you return redirect("some_location") you go to that file.
'''
import random # Allows appicaltion to use random and randoms functions.

app = Flask(__name__) #Flask uses the import name to know where to look up resources, templates, static files, instance folder, etc.


app.secret_key = 'LOLBITCH'
'''
# This line creates a secret key. This key should be randomly generated in a real application.
# sessions are implemented on top of cookies for you and signs the cookies cryptographically.
# Basically store whatever information you want in a session and knowing the secret key allows someone to modify its data.

# this is the initial start location of the application. So when you run the server it will return render_template("index.html") so that page will load.
# route - route() decorator in Flask is used to bind URL to a function.
# Example
#
#@app.route("/hello")
#def hello_world():
#   return 'hello world'
#
# Here, URL '/hello' rule is bound to the hello_world() function. As a result, if a user visits localhost:5000/hello URL, the output of the hello_world() function will be rendered in the browser.
'''
@app.route('/')
def index():
    return render_template("index.html")
'''
# This is linked to the form action called /data and has the method POST which is a secure way to pass data through a form.
# This function(def button_counter():) checks if the request.method is POST and if its true it enters the loop and makes a random variable which is stored in a session['someKey']
# the lines a and b are both making the random variable and the input from the user through text input in the html into integers and set them to vaiables a and b.
# the it checks if they are equal and returns an html file that shows they are the same or it goes though the rest of the if statements to preform the same operation.
'''
@app.route('/data', methods=['POST'])
def button_counter():
    if request.method == 'POST':
        session['someKey'] = random.randrange(0,101)
        a = int(session['someKey'])
        b = int(request.form['Guess'])
        if a == b:
            print "Random:", a
            print "Guess:", b
            return render_template("justright.html")
        if a > b:
            print "Random:", a
            print "Guess:", b
            return render_template("low.html")
        else:
            print "Random:", a
            print "Guess:", b
            return render_template("high.html")
            # if none of the statements return a value the original index.html will be directed to.
    return redirect('/')

# This just calls the index.html if submit with the value of Play Again is pressed, it has the action /playAgain and the method post.
@app.route('/playAgain', methods=['POST'])
def reset_stuff():
    if request.method == 'POST':
        return render_template("index.html")
    return redirect('/')
# This line allows you to show an interactive traceback and console in the browser when there is an error.
app.run(debug=True)

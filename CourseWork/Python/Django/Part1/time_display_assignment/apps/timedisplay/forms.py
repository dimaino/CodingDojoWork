from django import forms

class RandomGenerator(form.Form):
    random_word = forms.CharField(max_length = 100)

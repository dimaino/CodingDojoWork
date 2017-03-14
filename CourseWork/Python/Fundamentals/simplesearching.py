import re
def get_matching_words(regex):
    words = ["aimlessness", "assassin", "baby", "beekeeper", "belladonna", "cannonball", "crybaby", "denver", "embraceable", "facetious", "flashbulb", "gaslight", "hobgoblin", "iconoclast", "issue", "kebab", "kilo", "laundered", "mattress", "millennia", "natural", "obsessive", "paranoia", "queen", "rabble", "reabsorb", "sacrilegious", "schoolroom", "tabby", "tabloid", "unbearable", "union", "videotape"]
    matches = []
    for word in words:
        if re.search(regex,word):
 	          matches.append(word)
    return matches
print "Problem 1"
print get_matching_words(r"v")
print "Problem 2"
print get_matching_words(r"ss")
print "Problem 3"
print get_matching_words(r"\e$")
print "Problem 4"
print get_matching_words(r"b.b")
print "Problem 5"
print get_matching_words(r"b.{1,}b")
print "Problem 6"
print get_matching_words(r"b.{0,}b")
print "Problem 7"
print get_matching_words(r"a.{0,}e.{0,}i.{0,}o.{0,}u")
print "Problem 8"
print get_matching_words(r"^[aegilnoprsux]*$")
print "Problem 9"
print get_matching_words(r"(\w)\1+")

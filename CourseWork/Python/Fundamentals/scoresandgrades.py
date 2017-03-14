import random


def gengrades():
    print "Scores and Grades"
    for count in range(0, 10):
        random_num = random.randint(60,100)
        if random_num <= 69:
            print "Score: " + str(random_num) + "; Your grade is D"
        elif random_num > 69 and random_num <= 79:
            print "Score: " + str(random_num) + "; Your grade is C"
        elif random_num > 79 and random_num <= 89:
            print "Score: " + str(random_num) + "; Your grade is B"
        else:
            print "Score: " + str(random_num) + "; Your grade is A"
    print "End of the program. Bye!"

gengrades()

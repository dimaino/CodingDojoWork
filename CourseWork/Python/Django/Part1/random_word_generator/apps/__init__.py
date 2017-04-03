<!DOCTYPE html>
<html>
    <head>
        <title>StringGenerator</title>
    </head>
    <body>
        <form action="" method="post">
            {% csrf_token %}
            <input type="text" name="first_name">
            <input type="submit" value="submit">
        </form>
    </body>
</html>

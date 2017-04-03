from __future__ import unicode_literals
from django.db import models
from ..bestLogin.models import User

class SecretManager(models.Manager):
    def addNewSecret(self, stuff, userId):
        if len(stuff['secretPost']) < 0:
            return "message not long enough for  a secret!"
        else:
            selected_user = User.userManager.get(id=userId)
            self.create(creator = selected_user, description=stuff['secretPost'])

    def deleteUserSecret(self, secretId, userId):
        try:
            secret = self.get(id=secretId)
        except:
            print "bad!"
            return False
        selected_user = User.userManager.get(id=userId)

        if secret.creator != selected_user:
            print "dont delete others stuff"
            return False
        secret.delete()

    def addNewLike(self, likeId, userId):
        selected_user = User.userManager.get(id=userId)
        like = self.get(id=likeId)
        like.user_likes.add(selected_user)
        like.save()


class Secret(models.Model):
    creator = models.ForeignKey(User)
    description = models.TextField(max_length=1000)
    user_likes = models.ManyToManyField(User, related_name="User_likes")
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now = True)

    sManager = SecretManager()

# -*- coding: utf-8 -*-
# Generated by Django 1.10.6 on 2017-03-21 22:51
from __future__ import unicode_literals

from django.db import migrations
import django.db.models.manager


class Migration(migrations.Migration):

    dependencies = [
        ('courses_app', '0001_initial'),
    ]

    operations = [
        migrations.AlterModelManagers(
            name='course',
            managers=[
                ('uManager', django.db.models.manager.Manager()),
            ],
        ),
    ]
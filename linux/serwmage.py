#!/usr/bin/python

import random
import string

import sys
from PyQt5.QtGui import QPixmap, QScreen
from PyQt5.QtCore import QRect
from PyQt5.QtWidgets import QApplication

from pynput.mouse import Listener, Button

import pysftp

host = open("./hostname.txt", "r").read(10)
username = open("./username.txt", "r").read(10)
password = open("./password.txt", "r").read(30)
print(host,username,password)

def shoot(xS, yS, xE, yE):
    app = QApplication(sys.argv)
    img = QScreen.grabWindow(app.primaryScreen(), QApplication.desktop().winId())
    imgCrop = img.copy(QRect(xS, yS, xE, yE)).save('img.png', 'png')
    filename = randomString()
    with pysftp.Connection(host, username=username, password=password) as sftp: sftp.put(imgCrop, "/home/img/"+filename)
    # toClipBoard(filename)
    quit()

def randomString():
    letters = string.asci_letters
    return ''.join(random.choice(letters) for i in range(16))


# def toClipBoard():

xStart = 0
yStart = 0
xEnd = 0
yEnd = 0
click = 1

def onDown(x, y, button, pressed):
    global xStart
    global yStart
    global xEnd
    global yEnd
    global click
    if button == Button.left and pressed:
        if click == 1:
            xStart = x
            yStart = y
            click = 2
        elif click == 2:
            xEnd = x
            yEnd = y
            click = 1
            shoot(xStart, yStart, xEnd, yEnd)

with Listener(on_move=None, on_click=onDown, on_scroll=None) as listener: listener.join()

#!/usr/bin/python

import random
import string
import sys
from PyQt5.QtGui import QPixmap, QScreen
from PyQt5.QtCore import QRect
from PyQt5.QtWidgets import QApplication
from pynput.mouse import Listener, Button
import pysftp
import pyperclip
from PIL import Image
from io import BytesIO

xStart = 0
yStart = 0
xEnd = 0
yEnd = 0
click = 1

def shoot(rect):
    imgname = randomString()
    app = QApplication(sys.argv)
    img = QScreen.grabWindow(app.primaryScreen(), QApplication.desktop().winId())
    imgCrop = img.copy(rect).save(imgname + '.png', 'png')

    path = '/home/webserver/webroot/img/' + imgname + '.png'
    localpath = imgname + '.png'
    print(imgname) 
    filename = randomString()
    with pysftp.Connection("serwm.com", username="webimg", password="") as sftp: sftp.put(localpath, path)
    toClipBoard(imgname)
    quit()

def randomString():
    letters = string.ascii_letters
    return ''.join(random.choice(letters) for i in range(16))

def toClipBoard(filename):
    pyperclip.copy("img.serwm.com/" + filename + ".png")

def getRect(xS, yS, xE, yE):
    if xS < xE and yS > yE:
        x = xS
        y = yS
        w = xE - xS
        h = yE - yS
    elif xS > xE and yS < yE:
        x = xE
        y = yE
        w = xS - xE
        h = yS - yE
    elif xS < xE and yS < yE:
        x = xS
        y = yE
        w = xE - xS
        h = yS - yE
    elif xS > xE and yS <yE:
        x = xE
        y = yS
        w = xS - xE
        h = yE - yS

    return QRect(x, y, w, h)

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
            print(getRect(xStart, yStart, xEnd, yEnd))
            shoot(getRect(xStart, yStart, xEnd, yEnd))
def main():
    host = open("./hostname.txt", "r").read(10)
    username = open("./username.txt", "r").read(10)
    password = open("./password.txt", "r").read(30)

    with Listener(on_move=None, on_click=onDown, on_scroll=None) as listener: listener.join()

if __name__ == "__main__":
    main()

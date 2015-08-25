__author__ = 'mazurdm1'
import os

def walk(dir_path):
    contents = os.listdir(dir_path)
    folders = []
    files = []

    for object in contents:
        x = os.path.join(dir_path, object)
        if os.path.isdir(x):
            folders.append(x)
        else:
            files.append(x)

    yield dir_path, folders, files

    for dir in folders:
        for next_folder in walk(dir):
            yield next_folder

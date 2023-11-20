import tkinter as tk
from tkinter import ttk
from pymongo import MongoClient

# Подключение к MongoDB
client = MongoClient('localhost')

# Выбор базы данных (если ее нет, она будет создана)
db = client['22305']

# Выбор коллекции (если ее нет, она будет создана)
collection = db['Gashkov-listComands']

# Вставка данных в коллекцию
collection.drop()


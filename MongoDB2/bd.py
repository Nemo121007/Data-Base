import tkinter as tk
from tkinter import ttk
from pymongo import MongoClient
#ssh -L 27017:192.168.112.103:27017 -N -T gashkov@kappa.cs.petrsu.ru

client = MongoClient('localhost')

# Выбор базы данных (если ее нет, она будет создана)
db = client['22305']

# Выбор коллекции (если ее нет, она будет создана)
collection = db['Gashkov-listProducts']

# #1
#category_name = "Категория 1"
#a = collection.aggregate([
#    {"$match": {"Название категории": category_name}},
#    {"$unwind": "$Товары"},
#    {"$project": {"название_товара": "$Товары.Название товара"}}
#])


# 2
#category_name = "Категория 1"
#a = collection.aggregate([
#    {"$match": {"Название категории": category_name}},
#    {"$unwind": "$Товары"},
#    {"$unwind": "$Товары.Особые характеристики"},
#    {"$group": {
#        "_id": "$Товары.Название товара",
#        "характеристики": {"$addToSet": "$Товары.Особые характеристики"}
#    }},
#    {"$project": {
#        "товар": "$_id",
#        "характеристики": 1,
#        "_id": 0
#    }}
#])


# 3
#buyer_name = "Имя покупателя 1"
#a = collection.aggregate([
#    {"$match": {"Товары.Покупатели.Имя": buyer_name}},
#    {"$unwind": "$Товары"},
#    {"$unwind": "$Товары.Покупатели"},
#    {"$match": {"Товары.Покупатели.Имя": buyer_name}},
#    {"$project": {
#        "название_товара": "$Товары.Название товара",
#        "цена": "$Товары.Цена"
#    }}
#])

# 4
#color_to_find = "Цвет 1"
#a = collection.aggregate([
#    {"$unwind": "$Товары"},
#    {"$match": {"Товары.Особые характеристики.Цвет": color_to_find}},
#    {"$project": {
#        "Название товара": "$Товары.Название товара",
#        "Производитель": "$Товары.Производитель",
#        "Цена": "$Товары.Цена",
#        "_id": 0
#    }}
#])

# 5
#b = collection.find()
#a = collection.aggregate( [
#    {"$unwind": "$Товары"},
#    {"$unwind": "$Товары.Покупатели"},
#    {"$group": {
#        "_id": None,
#        "total_sold": {"$sum": "$Товары.Цена"}
#    }},
#    {"$project": {"_id": 0, "total_sold": 1}}
#])





#6
#a = collection.aggregate([
#    {"$unwind": "$Товары"},
#    {"$group": {
#        "_id": "$Название категории",
#        "total_products": {"$sum": 1}
#    }},
#    {"$project": {"_id": 0, "category": "$_id", "total_products": 1}}
#])

#7
#product_name = "Название товара 1"
#a = collection.aggregate([
#    {"$unwind": "$Товары"},
#    {"$match": {"Товары.Название товара": product_name}},
#    {"$unwind": "$Товары.Покупатели"},
#    {"$project": {"_id": 0, "buyer_name": "$Товары.Покупатели.Имя"}}
#])


#8
product_name = "Название товара 1"
delivery_service = "Служба доставки 1"

a = collection.aggregate([
    {"$unwind": "$Товары"},
    {"$match": {"Товары.Название товара": product_name}},
    {"$unwind": "$Товары.Покупатели"},
    {"$match": {"Товары.Покупатели.Служба доставки": delivery_service}},
    {"$project": {"_id": 0, "buyer_name": "$Товары.Покупатели.Имя"}}
])


for i in a:
    print(i)
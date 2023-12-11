import tkinter as tk
from tkinter import ttk

# Функции для каждого блока
def f1(value):
    print(f"Вызвана функция 1 с параметром: {value}")

def f2(value):
    print(f"Вызвана функция 2 с параметром: {value}")

def f3():
    print("Вызвана функция 3")

def f4():
    print("Вызвана функция 4")

def f5():
    print("Вызвана функция 5")

def f6(from_stop, to_stop):
    print(f"Вызвана функция 6 с параметрами: {from_stop}, {to_stop}")

def f7(from_stop, to_stop):
    print(f"Вызвана функция 7 с параметрами: {from_stop}, {to_stop}")

def f8(value1, value2, value3):
    print(f"Вызвана функция 8 с параметрами: {value1}, {value2}, {value3}")

def f9():
    print("Вызвана функция 9")

def f10(from_stop, to_stop):
    print(f"Вызвана функция 10 с параметрами: {from_stop}, {to_stop}")

def f11(value):
    print(f"Вызвана функция 11 с параметром: {value}")

def f12():
    print("Вызвана функция 12")

# Создание основного окна
root = tk.Tk()
root.title("Главное меню")

# Фреймы для блоков
frames = [ttk.Frame(root) for _ in range(12)]

# Блок 1
label1 = ttk.Label(frames[0], text="Список остановок")
stops = ["Остановка 1", "Остановка 2", "Остановка 3"]
combo1 = ttk.Combobox(frames[0], values=stops)
combo1.set(stops[0])
button1 = ttk.Button(frames[0], text="Просмотр", command=lambda: f1(combo1.get()))
label1.pack()
combo1.pack()
button1.pack()

# Блок 2
label2 = ttk.Label(frames[1], text="Список организаций")
orgs = ["Организация 1", "Организация 2", "Организация 3"]
combo2 = ttk.Combobox(frames[1], values=orgs)
combo2.set(orgs[0])
button2 = ttk.Button(frames[1], text="Просмотр", command=lambda: f2(combo2.get()))
label2.pack()
combo2.pack()
button2.pack()

# Блок 3
label3 = ttk.Label(frames[2], text="Список пересадок")
button3 = ttk.Button(frames[2], text="Просмотр", command=f3)
label3.pack()
button3.pack()

# Блок 4
label4 = ttk.Label(frames[3], text="Одиночные остановки")
button4 = ttk.Button(frames[3], text="Просмотр", command=f4)
label4.pack()
button4.pack()

# Блок 5
label5 = ttk.Label(frames[4], text="Учебные организации")
button5 = ttk.Button(frames[4], text="Просмотр", command=f5)
label5.pack()
button5.pack()

# Блок 6
label6 = ttk.Label(frames[5], text="Маршруты")
label_from6 = ttk.Label(frames[5], text="Откуда:")
label_to6 = ttk.Label(frames[5], text="Куда:")
stops6 = ["Остановка 1", "Остановка 2", "Остановка 3"]
combo_from6 = ttk.Combobox(frames[5], values=stops6)
combo_from6.set(stops6[0])
combo_to6 = ttk.Combobox(frames[5], values=stops6)
combo_to6.set(stops6[0])
button6 = ttk.Button(frames[5], text="Просмотр", command=lambda: f6(combo_from6.get(), combo_to6.get()))
label6.pack()
label_from6.pack()
combo_from6.pack()
label_to6.pack()
combo_to6.pack()
button6.pack()

# Блок 7
label7 = ttk.Label(frames[6], text="Маршрут")
label_from7 = ttk.Label(frames[6], text="Откуда:")
label_to7 = ttk.Label(frames[6], text="Куда:")
stops7 = ["Остановка 1", "Остановка 2", "Остановка 3"]
combo_from7 = ttk.Combobox(frames[6], values=stops7)
combo_from7.set(stops7[0])
combo_to7 = ttk.Combobox(frames[6], values=stops7)
combo_to7.set(stops7[0])
button7 = ttk.Button(frames[6], text="Просмотр", command=lambda: f7(combo_from7.get(), combo_to7.get()))
label7.pack()
label_from7.pack()
combo_from7.pack()
label_to7.pack()
combo_to7.pack()
button7.pack()

# Блок 8
label8 = ttk.Label(frames[7], text="Список 3 остановок")
stops8 = ["Остановка 1", "Остановка 2", "Остановка 3"]
combo1_8 = ttk.Combobox(frames[7], values=stops8)
combo1_8.set(stops8[0])
combo2_8 = ttk.Combobox(frames[7], values=stops8)
combo2_8.set(stops8[0])
combo3_8 = ttk.Combobox(frames[7], values=stops8)
combo3_8.set(stops8[0])
button8 = ttk.Button(frames[7], text="Просмотр", command=lambda: f8(combo1_8.get(), combo2_8.get(), combo3_8.get()))
label8.pack()
combo1_8.pack()
combo2_8.pack()
combo3_8.pack()
button8.pack()

# Блок 9
label9 = ttk.Label(frames[8], text="Максимум магазинов")
button9 = ttk.Button(frames[8], text="Просмотр", command=f9)
label9.pack()
button9.pack()

# Блок 10
label10 = ttk.Label(frames[9], text="Кратчайший маршрут")
label_from10 = ttk.Label(frames[9], text="Откуда:")
label_to10 = ttk.Label(frames[9], text="Куда:")
combo_from10 = ttk.Combobox(frames[9], values=stops8)
combo_from10.set(stops8[0])
combo_to10 = ttk.Combobox(frames[9], values=stops8)
combo_to10.set(stops8[0])
button10 = ttk.Button(frames[9], text="Просмотр", command=lambda: f10(combo_from10.get(), combo_to10.get()))
label10.pack()
label_from10.pack()
combo_from10.pack()
label_to10.pack()
combo_to10.pack()
button10.pack()

# Блок 11
label11 = ttk.Label(frames[10], text="Список организаций")
orgs11 = ["Организация 1", "Организация 2", "Организация 3"]
combo11 = ttk.Combobox(frames[10], values=orgs11)
combo11.set(orgs11[0])
button11 = ttk.Button(frames[10], text="Просмотр", command=lambda: f11(combo11.get()))
label11.pack()
combo11.pack()
button11.pack()

# Блок 12
label12 = ttk.Label(frames[11], text="Длина")
button12 = ttk.Button(frames[11], text="Просмотр", command=f12)
label12.pack()
button12.pack()

# Распределение блоков по сетке
for i in range(3):
    for j in range(4):
        frames[i * 4 + j].grid(row=i, column=j, padx=10, pady=10)

# Запуск главного цикла
root.mainloop()

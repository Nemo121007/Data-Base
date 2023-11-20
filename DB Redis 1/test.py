import tkinter as tk
import redis
from tkinter import ttk
from tkinter import font
from tkinter import Tk
from webcolors import CSS3_HEX_TO_NAMES

colors = list(CSS3_HEX_TO_NAMES.values())


# Создаем подключение к Redis
#connection = redis.Redis(host='192.168.112.103', password='student')
connection = redis.Redis(host='127.0.0.1', port=6379, db=0, password='student')

# Функция для удобвста получения элементов с бд
def get_int_from_db(settings, key):
    return settings[key].decode()


def save_settings():
    # Сохраняем настройки в Redis для выбранного пользователя
    selected_user = user.get(user.curselection())  # Получаем выбранного пользователя из списка
    font = combo1.get()
    font_size = text2.get()
    if int(font_size) < 0:
        print('не сохраняем')
        return
    font_color = combo3.get()
    font_style = combo2.get()

    settings = {
        'font': font,
        'font_size': font_size,
        'font_color': font_color,
        'font_style': font_style,
    }

    # Используем хэш Redis для хранения настроек пользователя
    connection.hmset('22305-Gashkov' + str(selected_user), settings)


def update_label_text():
    # Обновляем надпись с учетом текущих настроек
    selected_user = user.get(user.curselection())  # Получаем выбранного пользователя из списка
    settings = connection.hgetall('22305-Gashkov' + str(selected_user))
    print(settings)
    # Применяем настройки к тексту в надписи
    formatted_text = 'This is a sample text.'
    if settings:
        custom_font = (get_int_from_db(settings, b'font'), get_int_from_db(settings, b'font_size'),
                       get_int_from_db(settings, b'font_style'))
        font_color = get_int_from_db(settings, b'font_color')

        label.config(text=formatted_text, font=custom_font, foreground=font_color, )
    else:
        label.config(text=formatted_text, font='', foreground='black')


root = tk.Tk()

fonts = font.families()


lib = []
for font_name in fonts:
    lib.append(font_name)
libFam = ['bold', 'italic', 'bold italic']
libColor = ()

root.title('Настройки текстового сообщения')
root.geometry('600x400')

# Создаем метку и поле для размера шрифта
label2 = tk.Label(root, text='Размер шрифта')
label2.grid(row=1, column=1)
text2 = tk.Entry(root)
text2.grid(row=1, column=2)

# Создаем метку и выпадающий список для названия шрифта
label1 = tk.Label(root, text='Название шрифта')
label1.grid(row=2, column=1)
font_names = lib
combo1 = ttk.Combobox(root, values=font_names)
combo1.grid(row=2, column=2)
combo1.bind("<<ComboboxSelected>>")

# Создаем метку и поле для цвета шрифта
label3 = tk.Label(root, text='Начертание шрифта')
label3.grid(row=3, column=1)
font_names = libFam
combo2 = ttk.Combobox(root, values=font_names)
combo2.grid(row=3, column=2)
combo2.bind("<<ComboboxSelected>>")

# Создаем метку и поле для начертания шрифта
label4 = tk.Label(root, text='Цвет шрифта')
label4.grid(row=4, column=1)
font_names = colors
combo3 = ttk.Combobox(root, values=font_names)
combo3.grid(row=4, column=2)
combo3.bind("<<ComboboxSelected>>")

user = tk.Listbox(root, width=30, height=3)
user.insert(0, 'User A')
user.insert(1, 'User B')
user.insert(2, 'User C')
user.grid(row=2, column=3)

do_it = tk.Button(root, text='Сохранить настройки', command=save_settings)
do_it.grid(row=4, column=3)

label = tk.Label(root, text='This is a sample text.')
label.grid(row=6, column=1, columnspan=3)

user.bind('<<ListboxSelect>>', lambda event: update_label_text())

root.mainloop()
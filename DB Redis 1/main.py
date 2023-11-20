import redis
import tkinter as tk

# Подключение к серверу Redis
redis_host = '192.168.112.103'
redis_password = 'student'
redis_connection = redis.StrictRedis(host=redis_host, password=redis_password, decode_responses=True)

# Функция для сохранения настроек пользователя в Redis
def save_user_settings():
    user_key = f"{group}-{last_name}-{user_selection.get()}"
    settings = {
        "font_name": font_name_entry.get(),
        "font_size": font_size_entry.get(),
        "font_color": font_color_entry.get(),
        "font_style": font_style_entry.get()
    }
    redis_connection.hmset(user_key, settings)

# Функция для отображения текста с настройками на надписи
def update_label_text():
    label.config(text=text_entry.get())

# Функция для применения настроек пользователя к тексту
def apply_user_settings():
    user_key = f"{group}-{last_name}-{user_selection.get()}"
    user_settings = redis_connection.hgetall(user_key)
    if user_settings:
        label.config(font=(user_settings['font_name'], user_settings['font_size']), fg=user_settings['font_color'], relief=user_settings['font_style'])
        update_label_text()

# Создание основного окна приложения
app = tk.Tk()
app.title("Настройки текста")
app.geometry("400x300")

# Группа и фамилия пользователя
group = '22305'
last_name = 'Gashkov'

# Создание полей ввода и элементов управления
font_name_label = tk.Label(app, text="Шрифт:")
font_name_label.pack()
font_name_entry = tk.Entry(app)
font_name_entry.pack()

font_size_label = tk.Label(app, text="Размер шрифта:")
font_size_label.pack()
font_size_entry = tk.Entry(app)
font_size_entry.pack()

font_color_label = tk.Label(app, text="Цвет шрифта:")
font_color_label.pack()
font_color_entry = tk.Entry(app)
font_color_entry.pack()

font_style_label = tk.Label(app, text="Начертание:")
font_style_label.pack()
font_style_entry = tk.Entry(app)
font_style_entry.pack()

save_button = tk.Button(app, text="Сохранить настройки", command=save_user_settings)
save_button.pack()

text_entry = tk.Entry(app, width=30)
text_entry.pack()
text_entry.bind("<KeyRelease>", lambda event: update_label_text())

label = tk.Label(app, text="")
label.pack()

user_selection = tk.StringVar()
user_selection.set("")  # По умолчанию нет выбранного пользователя

# Раскрывающийся список с пользователями
user_list = tk.OptionMenu(app, user_selection, "A1B2", "B3C4", "C5D6")  # Замените значения на реальные имена пользователей
user_list.pack()

apply_button = tk.Button(app, text="Применить настройки пользователя", command=apply_user_settings)
apply_button.pack()

app.mainloop()

import tkinter as tk
from tkinter import ttk
import redis
from tkinter import messagebox
import tkinter.simpledialog
from tkinter import ttk, messagebox, simpledialog

nameUser = '22305-Gashkov-redis2:'

# Создание соединения с Redis
#connection = redis.Redis(host='192.168.112.103', password='student')
connection = redis.Redis(host='127.0.0.1', port=6379, db=0, password='student')
#connection.delete('22305-Gashkov-redis2:Спортсмен 1 Судья 1')

listScores = []
dictSportsperson = {}


#Функция загрузки списка спортсменов, судей и баллов
def GetListScoresSportspersonJudge():
    global listScores
    listScores = []
    for key in connection.keys(nameUser + '*'):
        full_key = key.decode()
        _, data = full_key.split(':', 1)
        sportsperson, judge = data.split(',', 1)
        listScores.append((sportsperson, judge, int(connection[key])))
    return listScores
    #if len(listScores) == 0:
    #    return [("Спортсмен 1", "Судья 1", 1), ("Спортсмен 2", "Судья 2", 1), ("Спортсмен 2", "Судья 2", 1)]

# Функция для добавления баллов
def add_score():
    sportsperson = sportsperson_var.get()
    judge = judge_var.get()
    score = int(score_entry.get())

    if (score < 0):
        messagebox.showerror("Ошибка", "Введено отрицательное количество баллов")
        return

    for turp in listScores:
        if (sportsperson == turp[0] and judge == turp[1]):
            user_response = messagebox.askquestion("Подтверждение", f"Запись для '{sportsperson}' и '{judge}' уже существует. Вы уверены, что хотите перезаписать ее?")
            if user_response == "yes":
                key = nameUser + str(sportsperson) + ',' + str(judge)
                connection.set(key, str(score))
                update_rankings()
            else:
                return

# Функция для обновления рейтинга
def update_rankings():
    global listScores
    global dictSportsperson
    dictSportsperson.clear()
    listScores = GetListScoresSportspersonJudge()
    for i in listScores:
        if not (i[0] in dictSportsperson.keys()):
            dictSportsperson[i[0]] = i[2]
            continue
        dictSportsperson[i[0]] += i[2]
    rankings_listbox.delete(0, tk.END)
    sorted_tuples = sorted(dictSportsperson.items(), key=lambda item: item[1], reverse=True)
    for sportsperson, scores in sorted_tuples:
        rankings_listbox.insert(tk.END, f"{sportsperson}: {scores}")

def show_full_list():
    full_list_window = tk.Toplevel(root)
    full_list_window.title("Полный список")

    # Отсортировать listScores по имени спортсмена и судьи
    sorted_listScores = sorted(listScores, key=lambda item: (item[0], item[1]))

    for i, item in enumerate(sorted_listScores, start=1):
        full_list_window.geometry("600x400")  # Измените размер окна по своему усмотрению
        label = tk.Label(full_list_window, text=f"{i}. Спортсмен: \t {item[0]}, \t Судья: \t {item[1]}, \t Баллы: \t {item[2]}")
        label.pack()

# Создание окна
root = tk.Tk()
root.title("Спортивный монитор")

# Создание и настройка виджетов
sportsperson_label = tk.Label(root, text="Спортсмен:")
sportsperson_var = tk.StringVar()
sportsperson_combobox = ttk.Combobox(root, textvariable=sportsperson_var, values=["Спортсмен 1", "Спортсмен 2"])
judge_label = tk.Label(root, text="Судья:")
judge_var = tk.StringVar()
judge_combobox = ttk.Combobox(root, textvariable=judge_var, values=["Судья 1", "Судья 2"])
score_label = tk.Label(root, text="Баллы:")
score_entry = tk.Entry(root)
save_button = tk.Button(root, text="Сохранить баллы", command=add_score)
rankings_label = tk.Label(root, text="Рейтинг спортсменов:")
rankings_listbox = tk.Listbox(root)


# Размещение виджетов на форме
sportsperson_label.grid(row=0, column=0)
sportsperson_combobox.grid(row=0, column=1)
judge_label.grid(row=1, column=0)
judge_combobox.grid(row=1, column=1)
score_label.grid(row=2, column=0)
score_entry.grid(row=2, column=1)
save_button.grid(row=3, column=0, columnspan=2)
rankings_label.grid(row=4, column=0, columnspan=2)
rankings_listbox.grid(row=5, column=0, columnspan=2)

full_list_button = tk.Button(root, text="Весь список", command=show_full_list)
full_list_button.grid(row=6, column=0, columnspan=2)


update_rankings()

# Запуск приложения
root.mainloop()
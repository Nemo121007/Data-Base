import tkinter as tk
from tkinter import ttk
from pymongo import MongoClient
import logging
logging.basicConfig(level=logging.DEBUG)

#ssh -L 27017:192.168.112.103:27017 -N -T gashkov@kappa.cs.petrsu.ru
class GamesWindow:
    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listGame']
    def on_treeview_click(self, event):
        item = self.tree.focus()  # Получаем выделенный элемент
        values = self.tree.item(item, 'values')  # Получаем значения в текущей строке
        column_id = self.tree.identify_column(event.x)

        if values:
            # Индексы 0, 1 и 2 соответствуют столбцам 'Дата', 'Хозяева', 'Счёт'
            date_value, hosts_value, score_value = values[0], values[1], values[2]
            data = (values[0], values[1], values[2], values[3])
            # Ваш код обработки значений
            print(f"Values: Date={date_value}, Hosts={hosts_value}, Score={score_value}")
            # Открытие окна с нарушениями
            if (column_id == '#5'):
                violations_window = ViolationsWindow(root, data)
                root.wait_window(violations_window.root)

            # Открытие окна с голами
            if (column_id == '#6'):
                goals_window = GoalsWindow(root, data)
                root.wait_window(goals_window.root)

            # Открытие окна с пенальти
            if (column_id == '#7'):
                penalties_window = PenaltiesWindow(root, data)
                root.wait_window(penalties_window.root)

            # Открытие окна с ударами по воротам
            if (column_id == '#8'):
                shots_on_goal_window = ShotsOnGoalWindow(root, data)
                root.wait_window(shots_on_goal_window.root)

        else:
            print("No values for the selected item.")

    def __init__(self, root):
        self.root = tk.Toplevel(root)
        self.root.title("Игры")

        # Создание таблицы с данными об играх
        self.tree = ttk.Treeview(self.root, columns=("Дата", "Хозяева", "Гости", "Счёт", "Нарушения", "Мячи", "Пенальти", "Удары по воротам"))
        self.tree.heading("Дата", text="Дата")
        self.tree.heading("Хозяева", text="Хозяева")
        self.tree.heading("Гости", text="Гости")
        self.tree.heading("Счёт", text="Счёт")
        self.tree.heading("Нарушения", text="Нарушения")
        self.tree.heading("Мячи", text="Мячи")
        self.tree.heading("Пенальти", text="Пенальти")
        self.tree.heading("Удары по воротам", text="Удары по воротам")

        self.tree.column("Нарушения", width=100)  # Установка ширины для колонки "Нарушения"
        self.tree.column("Мячи", width=100)  # Установка ширины для колонки "Мячи"
        self.tree.column("Пенальти", width=100)  # Установка ширины для колонки "Пенальти"
        self.tree.column("Удары по воротам", width=140)  # Установка ширины для колонки "Удары по воротам"

        # Пример данных (вы можете заменить их своими данными)
        i = 0
        for l in self.collection.find():
            if l != "":

                violations = len(l["violation"])
                goal = len(l["goal"])
                penalty = len(l["penalty"])
                shootGoal = len(l["shootGoal"])

                self.tree.insert("", i, values=(l["date"], l["owner"], l["guests"], l["score"], str(violations), str(goal), str(penalty), str(shootGoal)))
            else:
                self.tree.insert("", i, values=("", "", "", ""))
            i += 1
        #self.tree.insert("", 0, values=("Дата 1", "Хозяева 1", "Гости 1", "Счёт 1", "Нарушения 1", "Мячи 1", "Пенальти 1", "Удары по воротам 1"))
        #self.tree.insert("", 1, values=("Дата 2", "Хозяева 2", "Гости 2", "Счёт 2", "Нарушения 2", "Мячи 2", "Пенальти 2", "Удары по воротам 2"))

        # Размещение таблицы на форме
        self.tree.pack(expand=True, fill="both")

        self.tree.bind("<Button-1>", self.on_treeview_click)

        # Создание полей ввода для новой игры
        self.new_game_frame = ttk.Frame(self.root)
        self.new_game_frame.pack(pady=10)

        # Поля ввода для новой игры
        self.entry_labels = ["Дата", "Хозяева", "Гости", "Счёт"]
        self.entry_widgets = {}

        for i, label in enumerate(self.entry_labels):
            ttk.Label(self.new_game_frame, text=label + ":").grid(row=0, column=i, padx=5, pady=5)
            entry = ttk.Entry(self.new_game_frame)
            entry.grid(row=1, column=i, padx=5, pady=5)
            self.entry_widgets[label] = entry

        # Добавление кнопки "Добавить игру"
        self.add_button = ttk.Button(self.new_game_frame, text="Добавить игру", command=self.add_game)
        self.add_button.grid(row=2, columnspan=len(self.entry_labels), pady=10)

    def add_game(self):
        # Получение данных из полей ввода
        values = [self.entry_widgets[label].get() for label in self.entry_labels]

        # Пример: добавление новой строки в таблицу
        new_id = len(self.tree.get_children()) + 1
        values = [values[0], values[1], values[2], values[3], "0", "0", "0", "0"]
        self.tree.insert("", "end", text=str(new_id), values=values)

        # Очистка полей ввода
        for entry in self.entry_widgets.values():
            entry.delete(0, "end")

        item = {"date" : str(values[0]), "owner" : str(values[1]), "guests" : str(values[2]), "score" : str(values[3]),
                "violation" : "", "goal" : "", "penalty" : "", "shootGoal" : ""}

        # Вставка данных в коллекцию
        self.collection.insert_one(item)

class ViolationsWindow:
    data = ()

    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listGame']

#(date, owner, guests, score)
    def GetPlayer(self):
        client = MongoClient('localhost')

        # Выбор базы данных (если ее нет, она будет создана)
        db = client['22305']

        # Выбор коллекции (если ее нет, она будет создана)
        collection = db['Gashkov-listComands']

        listPlayer = []
        for line in collection.find():
            try:
                for i in line["Position"]:
                    if not type(i) == dict:
                        try:
                            if not listPlayer.__contains__(line["mainPlayer"]):
                                listPlayer.append(line["mainPlayer"])
                            if not listPlayer.__contains__(line["reservePlayer"]):
                                listPlayer.append(line["mainPlayer"])
                            continue
                        except:
                            continue
                    if not listPlayer.__contains__(i["mainPlayer"]):
                        listPlayer.append(i["mainPlayer"])
                    if not listPlayer.__contains__(i["reservePlayer"]):
                        listPlayer.append(i["mainPlayer"])
            except:
                listPlayer = []
        return listPlayer

    def __init__(self, parent, data):
        self.data = data
        self.parent = parent
        self.root = tk.Toplevel(parent)
        self.root.title("Нарушения")

        # Создание таблицы с данными о нарушениях
        self.tree = ttk.Treeview(self.root, columns=("Время", "Карточка", "Футболист", "Тип нарушения"))
        self.tree.heading("Время", text="Время")
        self.tree.heading("Карточка", text="Карточка")
        self.tree.heading("Футболист", text="Футболист")
        self.tree.heading("Тип нарушения", text="Тип нарушения")

        # Пример данных (вы можете заменить их своими данными)
        i = 0
        for row in self.collection.find({"date" : str(data[0]), "owner" : str(data[1]), "guests" : str(data[2]), "score" : str(data[3])}):
            try:
                l = row["violation"]
                for line in l:
                    self.tree.insert("", i, values=(line["time"], line["card"], line["player"], line["violation"]))
            except:
                self.tree.insert("", i, values=("", "", "", ""))
            i += 1

        #self.tree.insert("", 0, values=("12:34", "Желтая", "Иванов", "Фол"))
        #self.tree.insert("", 1, values=("23:45", "Красная", "Петров", "Офсайд"))

        # Размещение таблицы на форме
        self.tree.pack(expand=True, fill="both")

        # Создание полей ввода для нового нарушения
        self.new_violation_frame = ttk.Frame(self.root)
        self.new_violation_frame.pack(pady=10)

        # Поля ввода для нового нарушения
        self.entry_labels = ["Время", "Карточка", "Футболист", "Тип нарушения"]
        self.entry_widgets = {}

        for i, label in enumerate(self.entry_labels):
            ttk.Label(self.new_violation_frame, text=label + ":").grid(row=0, column=i, padx=5, pady=5)
            entry = ttk.Entry(self.new_violation_frame)
            entry.grid(row=1, column=i, padx=5, pady=5)
            self.entry_widgets[label] = entry

            # Создание выпадающего списка для "Карточка"
        self.card_choices = ["Желтая", "Красная"]  # Ваши варианты для "Карточка"
        self.card_var = tk.StringVar(self.root)
        self.card_var.set(self.card_choices[0])
        self.card_dropdown = ttk.Combobox(self.new_violation_frame, textvariable=self.card_var,
                                          values=self.card_choices)
        self.card_dropdown.grid(row=1, column=self.entry_labels.index("Карточка"), padx=5, pady=5)

        # Создание выпадающего списка для "Футболист"
        self.players = self.GetPlayer()  # Ваши варианты для "Футболист"
        self.player_var = tk.StringVar(self.root)
        self.player_var.set(self.players[0])
        self.player_dropdown = ttk.Combobox(self.new_violation_frame, textvariable=self.player_var, values=self.players)
        self.player_dropdown.grid(row=1, column=self.entry_labels.index("Футболист"), padx=5, pady=5)

        # Добавление кнопки "Добавить нарушение"
        self.add_button = ttk.Button(self.new_violation_frame, text="Добавить нарушение", command=self.add_violation)
        self.add_button.grid(row=2, columnspan=len(self.entry_labels), pady=10)

    def add_violation(self):
        # Получение данных из полей ввода
        time_value = self.entry_widgets["Время"].get()
        card_value = self.card_var.get()  # Получение выбранного значения из выпадающего списка "Карточка"
        player_value = self.player_var.get()  # Получение выбранного значения из выпадающего списка "Футболист"
        violation_type_value = self.entry_widgets["Тип нарушения"].get()
        values = (time_value, card_value, player_value, violation_type_value)

        # Пример: добавление новой строки в таблицу
        new_id = len(self.tree.get_children()) + 1
        self.tree.insert("", "end", text=str(new_id),
                         values=(time_value, card_value, player_value, violation_type_value))

        # Очистка полей ввода
        for entry in self.entry_widgets.values():
            entry.delete(0, "end")
        self.card_dropdown.set(self.card_choices[0])  # Сброс выбранного значения в выпадающем списке "Карточка"
        self.player_dropdown.set(self.players[0])  # Сброс выбранного значения в выпадающем списке "Футболист"

        data = []
        for row in self.collection.find({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])}):
            try:
                if row["violation"] != "":
                    for i in row["violation"]:
                        data.append(i)
            except:
                data = []

        data.append({"time": str(values[0]), "card": str(values[1]), "player": str(values[2]), "violation": str(values[3])})
        self.collection.update_one({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])},
                                   {"$set": {"violation": data}})

class GoalsWindow:
    data = ()

    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listGame']

    def __init__(self, parent, data):
        self.data = data
        self.parent = parent
        self.root = tk.Toplevel(parent)
        self.root.title("Голы")

        # Создание таблицы с данными о голах
        self.tree = ttk.Treeview(self.root, columns=("Футболист", "Откуда", "Время", "Передача"))
        self.tree.heading("Футболист", text="Футболист")
        self.tree.heading("Откуда", text="Откуда")
        self.tree.heading("Время", text="Время")
        self.tree.heading("Передача", text="Передача")

        # Пример данных (вы можете заменить их своими данными)
        i = 0
        for row in self.collection.find({"date" : str(data[0]), "owner" : str(data[1]), "guests" : str(data[2]), "score" : str(data[3])}):
            try:
                l = row["goal"]
                for line in l:
                    self.tree.insert("", i, values=(line["player"], line["place"], line["time"], line["transfer"]))
            except:
                self.tree.insert("", i, values=("", "", "", ""))
            i += 1

        #self.tree.insert("", 0, values=("Иванов", "Штрафная", "12:34", "Петров"))
        #self.tree.insert("", 1, values=("Петров", "Вне штрафной", "23:45", "Сидоров"))

        # Размещение таблицы на форме
        self.tree.pack(expand=True, fill="both")

        # Создание полей ввода для нового гола
        self.new_goal_frame = ttk.Frame(self.root)
        self.new_goal_frame.pack(pady=10)

        # Поля ввода для нового гола
        self.entry_labels = ["Футболист", "Откуда", "Время", "Передача"]
        self.entry_widgets = {}

        for i, label in enumerate(self.entry_labels):
            ttk.Label(self.new_goal_frame, text=label + ":").grid(row=0, column=i, padx=5, pady=5)
            entry = ttk.Entry(self.new_goal_frame)
            entry.grid(row=1, column=i, padx=5, pady=5)
            self.entry_widgets[label] = entry

        # Добавление кнопки "Добавить гол"
        self.add_button = ttk.Button(self.new_goal_frame, text="Добавить гол", command=self.add_goal)
        self.add_button.grid(row=2, columnspan=len(self.entry_labels), pady=10)

    def add_goal(self):
        # Получение данных из полей ввода
        values = [self.entry_widgets[label].get() for label in self.entry_labels]

        # Пример: добавление новой строки в таблицу
        new_id = len(self.tree.get_children()) + 1
        self.tree.insert("", "end", text=str(new_id), values=values)

        # Очистка полей ввода
        for entry in self.entry_widgets.values():
            entry.delete(0, "end")

        data = []
        for row in self.collection.find({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])}):
            try:
                if row["goal"] != "":
                    for i in row["goal"]:
                        data.append(i)
            except:
                data = []

        data.append({"player": str(values[0]), "place": str(values[1]), "time": str(values[2]), "transfer": str(values[3])})
        self.collection.update_one({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])},
                                   {"$set": {"goal": data}})

class PenaltiesWindow:
    data = ()

    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listGame']

    def __init__(self, parent, data):
        self.data = data
        self.parent = parent
        self.root = tk.Toplevel(parent)
        self.root.title("Пенальти")

        # Создание таблицы с данными о пенальти
        self.tree = ttk.Treeview(self.root, columns=("Футболист", "Откуда", "Время", "Передача"))
        self.tree.heading("Футболист", text="Футболист")
        self.tree.heading("Откуда", text="Откуда")
        self.tree.heading("Время", text="Время")
        self.tree.heading("Передача", text="Передача")

        # Пример данных (вы можете заменить их своими данными)
        i = 0
        for row in self.collection.find({"date" : str(data[0]), "owner" : str(data[1]), "guests" : str(data[2]), "score" : str(data[3])}):
            try:
                l = row["penalty"]
                for line in l:
                    self.tree.insert("", i, values=(line["player"], line["place"], line["time"], line["transfer"]))
            except:
                self.tree.insert("", i, values=("", "", "", ""))
            i += 1
        #self.tree.insert("", 0, values=("Иванов", "Штрафная", "12:34", "Петров"))
        #self.tree.insert("", 1, values=("Петров", "Вне штрафной", "23:45", "Сидоров"))

        # Размещение таблицы на форме
        self.tree.pack(expand=True, fill="both")

        # Создание полей ввода для нового пенальти
        self.new_penalty_frame = ttk.Frame(self.root)
        self.new_penalty_frame.pack(pady=10)

        # Поля ввода для нового пенальти
        self.entry_labels = ["Футболист", "Откуда", "Время", "Передача"]
        self.entry_widgets = {}

        for i, label in enumerate(self.entry_labels):
            ttk.Label(self.new_penalty_frame, text=label + ":").grid(row=0, column=i, padx=5, pady=5)
            entry = ttk.Entry(self.new_penalty_frame)
            entry.grid(row=1, column=i, padx=5, pady=5)
            self.entry_widgets[label] = entry

        # Добавление кнопки "Добавить пенальти"
        self.add_button = ttk.Button(self.new_penalty_frame, text="Добавить пенальти", command=self.add_penalty)
        self.add_button.grid(row=2, columnspan=len(self.entry_labels), pady=10)

    def add_penalty(self):
        # Получение данных из полей ввода
        values = [self.entry_widgets[label].get() for label in self.entry_labels]

        # Пример: добавление новой строки в таблицу
        new_id = len(self.tree.get_children()) + 1
        self.tree.insert("", "end", text=str(new_id), values=values)

        # Очистка полей ввода
        for entry in self.entry_widgets.values():
            entry.delete(0, "end")

        data = []
        for row in self.collection.find({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])}):
            try:
                if row["penalty"] != "":
                    for i in row["penalty"]:
                        data.append(i)
            except:
                data = []

        data.append({"player": str(values[0]), "place": str(values[1]), "time": str(values[2]), "transfer": str(values[3])})
        self.collection.update_one({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])},
                                   {"$set": {"penalty": data}})

class ShotsOnGoalWindow:
    data = ()

    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listGame']

    def __init__(self, parent, data):
        self.data = data
        self.parent = parent
        self.root = tk.Toplevel(parent)
        self.root.title("Удары по воротам")

        # Создание таблицы с данными об удачных ударами по воротам
        self.tree = ttk.Treeview(self.root, columns=("Футболист", "Откуда", "Время", "Передача"))
        self.tree.heading("Футболист", text="Футболист")
        self.tree.heading("Откуда", text="Откуда")
        self.tree.heading("Время", text="Время")
        self.tree.heading("Передача", text="Передача")

        # Пример данных (вы можете заменить их своими данными)
        i = 0
        for row in self.collection.find({"date" : str(data[0]), "owner" : str(data[1]), "guests" : str(data[2]), "score" : str(data[3])}):
            try:
                l = row["shootGoal"]
                for line in l:
                    self.tree.insert("", i, values=(line["player"], line["place"], line["time"], line["transfer"]))
            except:
                self.tree.insert("", i, values=("", "", "", ""))
            i += 1
        #self.tree.insert("", 0, values=("Иванов", "Штрафная", "12:34", "Петров"))
        #self.tree.insert("", 1, values=("Петров", "Вне штрафной", "23:45", "Сидоров"))

        # Размещение таблицы на форме
        self.tree.pack(expand=True, fill="both")

        # Создание полей ввода для нового удачного удара по воротам
        self.new_shot_frame = ttk.Frame(self.root)
        self.new_shot_frame.pack(pady=10)

        # Поля ввода для нового удачного удара по воротам
        self.entry_labels = ["Футболист", "Откуда", "Время", "Передача"]
        self.entry_widgets = {}

        for i, label in enumerate(self.entry_labels):
            ttk.Label(self.new_shot_frame, text=label + ":").grid(row=0, column=i, padx=5, pady=5)
            entry = ttk.Entry(self.new_shot_frame)
            entry.grid(row=1, column=i, padx=5, pady=5)
            self.entry_widgets[label] = entry

        # Добавление кнопки "Добавить удар по воротам"
        self.add_button = ttk.Button(self.new_shot_frame, text="Добавить удар по воротам", command=self.add_shot)
        self.add_button.grid(row=2, columnspan=len(self.entry_labels), pady=10)

    def add_shot(self):
        # Получение данных из полей ввода
        values = [self.entry_widgets[label].get() for label in self.entry_labels]

        # Пример: добавление новой строки в таблицу
        new_id = len(self.tree.get_children()) + 1
        self.tree.insert("", "end", text=str(new_id), values=values)

        # Очистка полей ввода
        for entry in self.entry_widgets.values():
            entry.delete(0, "end")

        data = []
        for row in self.collection.find({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])}):
            try:
                if row["shootGoal"] != "":
                    for i in row["shootGoal"]:
                        data.append(i)
            except:
                data = []

        data.append({"player": str(values[0]), "place": str(values[1]), "time": str(values[2]), "transfer": str(values[3])})
        self.collection.update_one({"date" : str(self.data[0]), "owner" : str(self.data[1]), "guests" : str(self.data[2]), "score" : str(self.data[3])},
                                   {"$set": {"shootGoal": data}})

class FullListWindow:
    listComand = []
    # Подключение к MongoDB
    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listComands']

    def on_treeview_click(self, event):
        item = self.tree.focus()  # Получаем выделенный элемент
        values = self.tree.item(item, 'values')  # Получаем значения в текущей строке
        column_id = self.tree.identify_column(event.x)

        if values:
            # Индексы 0, 1 и 2 соответствуют столбцам 'Дата', 'Хозяева', 'Счёт'
            name = values[0]

            # Ваш код обработки значений
            print(f"Values: Date={name}")
            # Открытие окна с нарушениями
            if (column_id == '#4'):
                positions_window = PositionsWindow(root, name)
                root.wait_window(positions_window.root)
        else:
            print("No values for the selected item.")

    for doc in collection.find():
        listComand.append(doc)

    def __init__(self, root):
        self.root = tk.Toplevel(root)
        self.root.title("Команды")

        # Создание таблицы с данными о командах
        self.tree = ttk.Treeview(self.root, columns=("Название", "Город", "Тренер", "Позиции"))
        self.tree.heading("Название", text="Название")
        self.tree.heading("Город", text="Город")
        self.tree.heading("Тренер", text="Тренер")
        self.tree.heading("Позиции", text="Позиции")

        # Пример данных (вы можете заменить их своими данными)
        i = 0
        for d in self.listComand:
            self.tree.insert("", i, values=(d["Name"], d["City"], d["Trainer"], "Просмотр"))
            i += 1

        # Размещение таблицы на форме
        self.tree.pack(expand=True, fill="both")

        self.tree.bind("<Button-1>", self.on_treeview_click)

        # Создание полей ввода для новой команды
        self.new_team_frame = ttk.Frame(self.root)
        self.new_team_frame.pack(pady=10)

        # Поля ввода для новой команды
        self.entry_labels = ["Название", "Город", "Тренер"]
        self.entry_widgets = {}

        for i, label in enumerate(self.entry_labels):
            ttk.Label(self.new_team_frame, text=label + ":").grid(row=0, column=i, padx=5, pady=5)
            entry = ttk.Entry(self.new_team_frame)
            entry.grid(row=1, column=i, padx=5, pady=5)
            self.entry_widgets[label] = entry

        # Добавление кнопки "Добавить команду"
        self.add_button = ttk.Button(self.new_team_frame, text="Добавить команду", command=self.add_team)
        self.add_button.grid(row=2, columnspan=len(self.entry_labels), pady=10)

    def add_team(self):
        # Получение данных из полей ввода
        values = [self.entry_widgets[label].get() for label in self.entry_labels]

        # Пример: добавление новой строки в таблицу
        new_id = len(self.tree.get_children()) + 1
        self.tree.insert("", "end", text=str(new_id), values=(values[0], values[1], values[2], "Просмотр"))

        # Очистка полей ввода
        for entry in self.entry_widgets.values():
            entry.delete(0, "end")

        item = {"Name" : str(values[0]), "City" : str(values[1]), "Trainer" : str(values[2]), "Position" : ""}

        # Вставка данных в коллекцию
        self.collection.insert_one(item)

class PositionsWindow:
    # Подключение к MongoDB
    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listComands']

    name = ""
    def __init__(self, parent, nameComands):
        self.name = nameComands
        self.parent = parent
        self.root = tk.Toplevel(parent)
        self.root.title("Позиции")

        # Создание таблицы с данными о позициях
        self.tree = ttk.Treeview(self.root, columns=("Позиция", "Основной игрок", "Запасной игрок"))
        self.tree.heading("Позиция", text="Позиция")
        self.tree.heading("Основной игрок", text="Основной игрок")
        self.tree.heading("Запасной игрок", text="Запасной игрок")

        # Пример данных (вы можете заменить их своими данными)
        a = self.collection.find({"name" : str(self.name)})
        i = 0
        for row in self.collection.find({"Name" : str(self.name)}):
            try:
                if row["Position"] != "":
                    for m in row["Position"]:
                        line = m
                        self.tree.insert("", i, values=(line["place"], line["mainPlayer"], line["reservePlayer"]))
                else:
                    break
                i += 1
            except:
                a = 0

        # Размещение таблицы на форме
        self.tree.pack(expand=True, fill="both")

        # Создание полей ввода для новой позиции
        self.new_position_frame = ttk.Frame(self.root)
        self.new_position_frame.pack(pady=10)

        # Поля ввода для новой позиции
        self.entry_labels = ["Позиция", "Основной игрок", "Запасной игрок"]
        self.entry_widgets = {}

        for i, label in enumerate(self.entry_labels):
            ttk.Label(self.new_position_frame, text=label + ":").grid(row=0, column=i, padx=5, pady=5)
            entry = ttk.Entry(self.new_position_frame)
            entry.grid(row=1, column=i, padx=5, pady=5)
            self.entry_widgets[label] = entry

        # Добавление кнопки "Добавить позицию"
        self.add_button = ttk.Button(self.new_position_frame, text="Добавить позицию", command=self.add_position)
        self.add_button.grid(row=2, columnspan=len(self.entry_labels), pady=10)

    def add_position(self):
        # Получение данных из полей ввода
        values = [self.entry_widgets[label].get() for label in self.entry_labels]

        # Пример: добавление новой строки в таблицу
        new_id = len(self.tree.get_children()) + 1
        self.tree.insert("", "end", text=str(new_id), values=values)

        # Очистка полей ввода
        for entry in self.entry_widgets.values():
            entry.delete(0, "end")

        #item = {"place": str(values[0]), "mainPlayer": str(values[1]), "reservePlayer": str(values[2])}
        #self.collection.update_one({"Name": self.name}, {"$set": {"Position": item}})

        data = []
        a = self.collection.find({"Name": self.name})
        for row in a:
            try:
                if type(row["Position"]) != dict:
                    for i in row["Position"]:
                        data.append(i)
                elif type(row["Position"]) == dict:
                    data.append(row)
            except:
                data = []

        data.append(
            {"place": str(values[0]), "mainPlayer": str(values[1]), "reservePlayer": str(values[2])})
        self.collection.update_one({"Name": self.name},
                                   {"$set": {"Position": data}})

class FilterDialogGame:
    # Подключение к MongoDB
    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listGame']

    def __init__(self, parent):
        self.parent = parent
        self.root = tk.Toplevel(parent)
        self.root.title("Фильтр игр")

        # Поле "Что"
        self.label_what = ttk.Label(self.root, text="Что:")
        self.label_what.grid(row=0, column=2, padx=5, pady=5)
        self.choices_what = ["Нарушения", "Мячи", "Пенальти", "Удары по воротам"]  # Ваши варианты для "Что"
        self.choice_var_what = tk.StringVar(self.root)
        self.choice_var_what.set(self.choices_what[0])
        self.dropdown_what = ttk.Combobox(self.root, textvariable=self.choice_var_what, values=self.choices_what)
        self.dropdown_what.grid(row=0, column=3, padx=5, pady=5)

        # Поле "Выбор"
        self.label_choice = ttk.Label(self.root, text="Выбор:")
        self.label_choice.grid(row=1, column=0, padx=5, pady=5)
        self.choices = [">", ">=", "=", "<=", "<"]  # Ваш список выбора
        self.choice_var = tk.StringVar(self.root)
        self.choice_var.set(self.choices[0])  # Установка значения по умолчанию
        self.dropdown = ttk.Combobox(self.root, textvariable=self.choice_var, values=self.choices)
        self.dropdown.grid(row=1, column=1, padx=5, pady=5)

        # Поле "Количество"
        self.label_count = ttk.Label(self.root, text="Количество:")
        self.label_count.grid(row=1, column=2, padx=5, pady=5)
        self.entry_count = ttk.Entry(self.root)
        self.entry_count.grid(row=1, column=3, padx=5, pady=5)

        # Кнопка "Применить"
        self.apply_button = ttk.Button(self.root, text="Применить", command=self.apply_filter)
        self.apply_button.grid(row=2, columnspan=4, pady=10)

        # Поле для отображения числа
        self.result_label = ttk.Label(self.root, text="Результат: ")
        self.result_label.grid(row=3, columnspan=4, pady=10)

    def apply_filter(self):
        # Здесь вы можете использовать значения полей для применения вашего фильтра
        filter_what = self.choice_var_what.get()
        filter_choice = self.choice_var.get()
        filter_count = self.entry_count.get()

        # Пример вывода значений фильтра
        print("Что:", filter_what)
        print("Выбор:", filter_choice)
        print("Количество:", filter_count)

        oldFilter = filter_what
        dictFilterWhat = {"Нарушения":"violation", "Мячи":"goal", "Пенальти":"penalty", "Удары по воротам":"shootGoal"}
        filter_what = dictFilterWhat[filter_what]

        result = []
        data = self.collection.find()
        if filter_choice == "=":
            for l in data:
                if (str(len(l[filter_what])) == filter_count):
                    result.append([l["date"], l["owner"], l["guests"], l["score"], str(len(l[filter_what]))])
        elif filter_choice == "<":
            for l in data:
                if (str(len(l[filter_what])) < filter_count):
                    result.append([l["date"], l["owner"], l["guests"], l["score"], str(len(l[filter_what]))])
        elif filter_choice == "<":
            for l in data:
                if (str(len(l[filter_what])) < filter_count):
                    result.append([l["date"], l["owner"], l["guests"], l["score"], str(len(l[filter_what]))])
        elif filter_choice == "<=":
            for l in data:
                if (str(len(l[filter_what])) <= filter_count):
                    result.append([l["date"], l["owner"], l["guests"], l["score"], str(len(l[filter_what]))])
        elif filter_choice == ">=":
            for l in data:
                if (str(len(l[filter_what])) >= filter_count):
                    result.append([l["date"], l["owner"], l["guests"], l["score"], str(len(l[filter_what]))])
        elif filter_choice == ">":
            for l in data:
                if (str(len(l[filter_what])) > filter_count):
                    result.append([l["date"], l["owner"], l["guests"], l["score"], str(len(l[filter_what]))])



        # Вывод результата
        result_text = f"Результат: {len(result)}"  # Или любой другой результат, который вы хотите отобразить
        self.result_label.config(text=result_text)

        # Таблица с данными
        self.result_table = ttk.Treeview(self.root, columns=("Дата", "Хозяева", "Гости", "Счёт", oldFilter))
        self.result_table.heading("Дата", text="Дата")
        self.result_table.heading("Хозяева", text="Хозяева")
        self.result_table.heading("Гости", text="Гости")
        self.result_table.heading("Счёт", text="Счёт")
        self.result_table.heading(oldFilter, text=oldFilter)

        # Пример данных (замените их своими данными)
        for l in result:
            self.result_table.insert("", 0, values=l)

        # Размещение таблицы на форме
        self.result_table.grid(row=4, columnspan=4, padx=5, pady=5)


class FilterDialogPlayer:
    # Подключение к MongoDB
    client = MongoClient('localhost')

    # Выбор базы данных (если ее нет, она будет создана)
    db = client['22305']

    # Выбор коллекции (если ее нет, она будет создана)
    collection = db['Gashkov-listGame']

    def __init__(self, parent):
        self.parent = parent
        self.root = tk.Toplevel(parent)
        self.root.title("Фильтр игроков")

        # Поле "Что"
        self.label_what = ttk.Label(self.root, text="Что:")
        self.label_what.grid(row=0, column=2, padx=5, pady=5)
        self.choices_what = ["Нарушения", "Мячи", "Пенальти", "Удары по воротам"]  # Ваши варианты для "Что"
        self.choice_var_what = tk.StringVar(self.root)
        self.choice_var_what.set(self.choices_what[0])
        self.dropdown_what = ttk.Combobox(self.root, textvariable=self.choice_var_what, values=self.choices_what)
        self.dropdown_what.grid(row=0, column=3, padx=5, pady=5)

        # Поле "Выбор"
        self.label_choice = ttk.Label(self.root, text="Выбор:")
        self.label_choice.grid(row=1, column=0, padx=5, pady=5)
        self.choices = [">", ">=", "=", "<=", "<"]  # Ваш список выбора
        self.choice_var = tk.StringVar(self.root)
        self.choice_var.set(self.choices[0])  # Установка значения по умолчанию
        self.dropdown = ttk.Combobox(self.root, textvariable=self.choice_var, values=self.choices)
        self.dropdown.grid(row=1, column=1, padx=5, pady=5)

        # Поле "Количество"
        self.label_count = ttk.Label(self.root, text="Количество:")
        self.label_count.grid(row=1, column=2, padx=5, pady=5)
        self.entry_count = ttk.Entry(self.root)
        self.entry_count.grid(row=1, column=3, padx=5, pady=5)

        # Кнопка "Применить"
        self.apply_button = ttk.Button(self.root, text="Применить", command=self.apply_filter)
        self.apply_button.grid(row=2, columnspan=4, pady=10)

        # Поле для отображения числа
        self.result_label = ttk.Label(self.root, text="Результат: ")
        self.result_label.grid(row=3, columnspan=4, pady=10)

    def apply_filter(self):
        # Здесь вы можете использовать значения полей для применения вашего фильтра
        filter_what = self.choice_var_what.get()
        filter_choice = self.choice_var.get()
        filter_count = self.entry_count.get()

        # Пример вывода значений фильтра
        print("Что:", filter_what)
        print("Выбор:", filter_choice)
        print("Количество:", filter_count)

        oldNameFilter = filter_what
        dictFilterWhat = {"Нарушения": "violation", "Мячи": "goal", "Пенальти": "penalty",
                          "Удары по воротам": "shootGoal"}
        filter_what = dictFilterWhat[filter_what]

        res = {}
        result = []
        data = self.collection.find()

        for l in data:
            try:
                for line in l[filter_what]:
                    if res.__contains__(line["player"]):
                        res[line["player"]] += 1
                    else:
                        res[line["player"]] = 1
            except:
                continue
        for i in res.keys():
            if (filter_choice == "=="):
                if (res[i]) == int(filter_count):
                    result.append((i, res[i]))
            elif (filter_choice == "<"):
                if (res[i]) < int(filter_count):
                    result.append((i, res[i]))
            elif (filter_choice == "<="):
                if (res[i]) <= int(filter_count):
                    result.append((i, res[i]))
            elif (filter_choice == ">="):
                if (res[i]) >= int(filter_count):
                    result.append((i, res[i]))
            elif (filter_choice == ">"):
                if (res[i]) > int(filter_count):
                    result.append((i, res[i]))

        # Вывод результата
        result_text = f"Результат: {len(result)}"  # Или любой другой результат, который вы хотите отобразить
        self.result_label.config(text=result_text)

        # Таблица с данными
        self.result_table = ttk.Treeview(self.root, columns=("Игрок", oldNameFilter))
        self.result_table.heading("Игрок", text="Игрок")
        self.result_table.heading(oldNameFilter, text=oldNameFilter)

        # Пример данных (замените их своими данными)
        for l in result:
            self.result_table.insert("", 0, values=l)

        # Размещение таблицы на форме
        self.result_table.grid(row=4, columnspan=4, padx=5, pady=5)

def show_teams_window():
    full_list_window = FullListWindow(root)
    root.wait_window(full_list_window.root)

def show_games_window():
    games_window = GamesWindow(root)
    root.wait_window(games_window.root)

def show_filter_dialog_game():
    filter_window = FilterDialogGame(root)
    root.wait_window(filter_window.root)

def show_filter_dialog_player():
    filter_window = FilterDialogPlayer(root)
    root.wait_window(filter_window.root)

# Создание основного окна
root = tk.Tk()
root.title("Главный экран")

# Создание кнопки "Команды"
commands_button = tk.Button(root, text="Команды", command=show_teams_window)
commands_button.pack(pady=20)

# Создание кнопки "Игры"
games_button = tk.Button(root, text="Игры", command=show_games_window)
games_button.pack(pady=20)

# Создание кнопки "Фильтр"
filter_button = tk.Button(root, text="Фильтр по играм", command=show_filter_dialog_game)
filter_button.pack(pady=20)

# Создание кнопки "Фильтр"
filter_button = tk.Button(root, text="Фильтр по игрокам", command=show_filter_dialog_player)
filter_button.pack(pady=20)

# Запуск основного цикла обработки событий
root.mainloop()

from neo4j import GraphDatabase

URI = "bolt://localhost:7687"
AUTH = ("user", "qwertyuiop")

s = (
    "CREATE (:Station {name: 'остановка 1'}),"
    "(:Station {name: 'остановка 2'}),"
    "(:Station {name: 'остановка 3'}),"
    "(:Station {name: 'остановка 4'}),"
    "(:Station {name: 'остановка 5'}),"
    "(:Station {name: 'остановка 6'}),"
    "(:Station {name: 'остановка 7'}),"
    "(:Station {name: 'остановка 8'}),"
    "(:Station {name: 'остановка 9'}),"
    "(:Station {name: 'остановка 10'}),"
    "(:Station {name: 'остановка 11'}),"
    "(:Station {name: 'остановка 12'}),"
    "(:Station {name: 'остановка 13'}),"
    "(:Station {name: 'остановка 14'}),"
    "(:Station {name: 'остановка 15'}),"
    "(:Station {name: 'остановка 16'}),"
    "(:Station {name: 'остановка 17'}),"
    "(:Station {name: 'остановка 18'}),"
    "(:Station {name: 'остановка 19'}),"
    "(:Station {name: 'остановка 20'});"
)


o = (
    "CREATE (:organization:education{name: 'Учебная организация 1'}),"
    "(:organization:education{name: 'Учебная организация 2'}),"
    "(:organization:public{name: 'Организация 3'}),"
    "(:organization:public{name: 'Организация 4'}),"
    "(:organization:public{name: 'Организация 5'}),"
    "(:organization:public{name: 'Организация 6'}),"
    "(:organization:public{name: 'Организация 7'}),"
    "(:organization:public{name: 'Организация 8'}),"
    "(:organization:public{name: 'Организация 9'}),"
    "(:organization:public{name: 'Организация 10'}),"
    "(:organization:public{name: 'Организация 11'}),"
    "(:organization:public{name: 'Организация 12'}),"
    "(:organization:public{name: 'Организация 13'}),"
    "(:organization:public{name: 'Организация 14'}),"
    "(:organization:public{name: 'Организация 15'}),"
    "(:organization:public{name: 'Организация 16'}),"
    "(:organization:public{name: 'Организация 17'}),"
    "(:organization:public{name: 'Организация 18'}),"
    "(:organization:public{name: 'Организация 19'}),"
    "(:organization:public{name: 'Организация 20'});"
)


r = [
    # Маршрут 1: 1-2-3-4-5-6 интервал 100
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 1' AND b.name = 'остановка 2' CREATE (a)-[:road{type: 'маршрут 1', distance: 100}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 2' AND b.name = 'остановка 3' CREATE (a)-[:road{type: 'маршрут 1', distance: 100}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 3' AND b.name = 'остановка 4' CREATE (a)-[:road{type: 'маршрут 1', distance: 100}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 4' AND b.name = 'остановка 5' CREATE (a)-[:road{type: 'маршрут 1', distance: 100}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 5' AND b.name = 'остановка 6' CREATE (a)-[:road{type: 'маршрут 1', distance: 100}]->(b);",

    # Маршрут 2: 2-7-8-9-10 интервал 200
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 2' AND b.name = 'остановка 7' CREATE (a)-[:road{type: 'маршрут 2', distance: 200}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 7' AND b.name = 'остановка 8' CREATE (a)-[:road{type: 'маршрут 2', distance: 200}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 8' AND b.name = 'остановка 9' CREATE (a)-[:road{type: 'маршрут 2', distance: 200}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 9' AND b.name = 'остановка 10' CREATE (a)-[:road{type: 'маршрут 2', distance: 200}]->(b);",

    # Маршрут 3: 5-11-12-13 интервал 300
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 5' AND b.name = 'остановка 11' CREATE (a)-[:road{type: 'маршрут 3', distance: 300}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 11' AND b.name = 'остановка 12' CREATE (a)-[:road{type: 'маршрут 3', distance: 300}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 12' AND b.name = 'остановка 13' CREATE (a)-[:road{type: 'маршрут 3', distance: 300}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 13' AND b.name = 'остановка 14' CREATE (a)-[:road{type: 'маршрут 3', distance: 300}]->(b);",

    # Маршрут 4: 7-14-15-16-17 интервал 400
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 7' AND b.name = 'остановка 14' CREATE (a)-[:road{type: 'маршрут 4', distance: 400}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 14' AND b.name = 'остановка 15' CREATE (a)-[:road{type: 'маршрут 4', distance: 400}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 15' AND b.name = 'остановка 16' CREATE (a)-[:road{type: 'маршрут 4', distance: 400}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 16' AND b.name = 'остановка 17' CREATE (a)-[:road{type: 'маршрут 4', distance: 400}]->(b);",

    # Маршрут 5: 11-18-19-20 интервал 500
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 11' AND b.name = 'остановка 18' CREATE (a)-[:road{type: 'маршрут 5', distance: 500}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 18' AND b.name = 'остановка 19' CREATE (a)-[:road{type: 'маршрут 5', distance: 500}]->(b);",
    "MATCH (a:Station),(b:Station) WHERE a.name = 'остановка 19' AND b.name = 'остановка 20' CREATE (a)-[:road{type: 'маршрут 5', distance: 500}]->(b);"
]


l = [
    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 1' AND b.name = 'Учебная организация 1' "
     "CREATE (a)-[r: link{name: 'education'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 2' AND b.name = 'Учебная организация 2' "
     "CREATE (a)-[r: link{name: 'education'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 3' AND b.name = 'Организация 3' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 4' AND b.name = 'Организация 4' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 5' AND b.name = 'Организация 5' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 6' AND b.name = 'Организация 6' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 7' AND b.name = 'Организация 7' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 8' AND b.name = 'Организация 8' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 9' AND b.name = 'Организация 9' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 10' AND b.name = 'Организация 10' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 11' AND b.name = 'Организация 11' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 12' AND b.name = 'Организация 12' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 13' AND b.name = 'Организация 13' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 14' AND b.name = 'Организация 14' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 15' AND b.name = 'Организация 15' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 16' AND b.name = 'Организация 16' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 17' AND b.name = 'Организация 17' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 18' AND b.name = 'Организация 18' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 19' AND b.name = 'Организация 19' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);"),

    ("MATCH (a:Station), (b:organization) "
     "WHERE a.name = 'остановка 20' AND b.name = 'Организация 20' "
     "CREATE (a)-[r: link{name: 'public'}]->(b);")
]


with GraphDatabase.driver(URI, auth=AUTH) as driver:
    #driver.execute_query(s)
    for query in l:
        driver.execute_query(query)

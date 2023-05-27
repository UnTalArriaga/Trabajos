import copy
                
#Declaración del mapa de Rumania con sus ciudades colindantes
#y su costo de traslación

Rumania = [["Ara","Sib", 140],["Ara","Zer", 75],["Ara","Tim", 118],
            ["Sib","Fag", 99],["Sib","Rim", 80],["Zer","Ora", 71],
            ["Ora","Sib", 151],["Tim","Lug", 111],["Lug","Meh", 70],
            ["Meh","Dob",75],["Dob","Cra",120],["Rim","Cra",146],
            ["Rim","Pit",97],["Fag","Buc",211],["Pit","Buc",101],
            ["Pit","Cra",138],["Buc","Giu",90],["Buc","Urz",85],
            ["Urz","Vas",142],["Urz","Hir",98],["Vas","Ias",92],
            ["Hir","Efo",86],["Ias","Nea",87]]

#Lista que guarda los recorridos (trayectorias), que puede tomar desde
#un nodo inicial
recorridos=list()

#Lista de ciudades expandidas
ciudadesVisitadas = list()




# Función distanciaTotal
#Funcion que devuelve la distancia total
#de la trayectoria actual

def distanciaTotal (distancia):
    return distancia[1]

# Función existe
# Función que comprueba la integridad de las entradas
# se asegura de que las ciudades de inicio y fin ingresadas
# se encuentren en el mapa de Rumania

def existe(ciudad):
    for i in range (len(Rumania)):
        for j in range (2):
            if(ciudad.casefold() == str(Rumania[i][j]).casefold()):
                return Rumania[i][j]
    return None
    
# Función divNodo
# Función que divide el nodo actual (ciudad actual)
# para poder crear las diferentes trayectorias a sus
# ciudades colindantes. (El numero de copias depende
# de la cantidad de ciudades colindantes) 

def divNodo(nodo_div,num_div):
    global recorridos
    
    for i in range (num_div-1):
        recorridos.append(copy.deepcopy(nodo_div))


# Función insertar recorridos  
# Esta funcion inserta a una lista todas las posibles
# trayectorias desde el nodo actual (ciudad actual).      

def insertarRecorrido(nodoActual,ciudadesSiguientes):
    global recorridos
    
    if(len(recorridos)== 0):
        tmp2=list()
        tmp2.append(nodoActual)
        recorridos.append([tmp2,0])
    
    banderaPrimero = True
    nodo_div = list()  
    cantidadrecorridos= len(recorridos)
    i = 0
    j = 0
    while j < cantidadrecorridos:
        if(recorridos[j][0][-1]==nodoActual):
                
            if(banderaPrimero):
                nodo_div = recorridos[j]
                divNodo(nodo_div,len(ciudadesSiguientes))
                cantidadrecorridos = len(recorridos)
                banderaPrimero = False
                
            recorridos[j][0].append(ciudadesSiguientes[i][0])
            recorridos[j][1]+=ciudadesSiguientes[i][1]
            i+=1
        j+=1

# Función posiblesCiudades
# Función que verifica para el nodo actual (ciudad actual), cuales
# son los diferentes nodos a los que se puede ir (Siguientes ciudades)

def posiblesCiudades (nodoActual):
    destinos = list()
    
    for i in range (len(Rumania)):
        for j in range (2):
            if(nodoActual == Rumania[i][j]):
                if(j == 0 and Rumania[i][1] not in ciudadesVisitadas):
                    destinos.append([Rumania[i][1],Rumania[i][2]])
                elif (j==1 and Rumania[i][0] not in ciudadesVisitadas):
                    destinos.append([Rumania[i][0],Rumania[i][2]])
    return destinos
                   
# Función Expandir
# Esta función expande el nodo e inserta en la lista que 
# guarda las trayectorias todas las posibles trayectorias
# a las que podamos trasladarnos

def expandir(nodoActual):
    
    global ciudadesVisitadas,recorridos
    
    ciudadesSiguientes = posiblesCiudades(nodoActual)
    ciudadesVisitadas.append(nodoActual)
    
    if(len(ciudadesSiguientes) == 0):
        recorridos.pop(0)
    else:
        insertarRecorrido(nodoActual,ciudadesSiguientes)
    
    recorridos.sort(key = distanciaTotal)
    Tierra()
    
    return recorridos[0][0][-1]
        

# Función Tierra
#Función cuyo proposito es eliminar de la lista de trayectorias
#las ciudades ya visitadas de mayor costo

def Tierra ():
    global recorridos
    
    for x in recorridos:
        for y in recorridos:
            if(x[0][-1] == y[0][-1] and x[1] < y[1]):
                recorridos.remove(y)


# Función Main
#Función donde se inicializa el proceso de busqueda
#a partir de la introducción de los datos iniciales
#y la llamada a las funciones que realizan la busqueda

def main():
    ciudadInicio = existe (input("Ciudad de inicio:\n->"))
    ciudadFin = existe(input("Ciudad de fin:\n->"))
    x = 1
    if(ciudadInicio!= None and ciudadFin != None):
        ciudadActual=ciudadInicio
    
        while(ciudadActual!=ciudadFin):
            print("\nPaso: ",x)
            ciudadActual = expandir(ciudadActual)
            print(recorridos)
            #araprint("\n\n")
            x+=1
        print("----------------------------------------------------------------------------")
        print("----------------------------------------------------------------------------")
        print("La trayectoria óptima es: ", recorridos[0][0])
        print("\nEl costo total es: ", recorridos[0][1])
        print("----------------------------------------------------------------------------")
        print("----------------------------------------------------------------------------")

    else:
        print("Las ciudades ingresadas no se encuentran en el mapa")



#Bloque de codigo donde se ejecuta la función main
#Este bloque se encuentra dentro de una especie de ciclo
#"DO-WHILE" con el motivo de poder realizar multiples
#busquedas en una sola ejecución del programa
while True:   
    main()
    opcion = input("\nIngresar otra trayectoria? SI/NO\n->").lower();
    recorridos.clear()
    ciudadesVisitadas.clear()

    if opcion == "no":
        break 


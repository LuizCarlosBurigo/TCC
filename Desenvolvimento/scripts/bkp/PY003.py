from PY000 import sendRabbitMQ
import os
import glob
import time
import sys
import json
import shutil
from time import gmtime, strftime
from PY000 import config_diretorios, ciclosScrips


agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
horaLog = strftime("%H_%M_%S", gmtime())
nomeArqLog = 'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PYE003_' + horaLog + '.log'
tracelog = False
estePrograma = 'PY003'


def verificaLog():
    global tracelog
    tracelog = os.path.isfile(
        'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PYE003.TRACELOG')
    if tracelog:
        log_id_py003()
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Iniciando processo de Extração\n"
        msgLog(mensagem)
        return True
    return False


def log_id_py003():
    arqLog = open(nomeArqLog, "w")
    arqLog.close()


def msgLog(mensagem):
    arqLog = open(nomeArqLog, "a")
    arqLog.write(mensagem)
    arqLog.close()


def verificaKill():
    arqKill = os.path.isfile(
        'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PY003.KILL')
    if arqKill:
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Arquivo .KILL encontrado, programa irá encerrar.\n"
        msgLog(mensagem)
        return True
    return False


def processarArquivos():
    global estePrograma
    dic_diretorios = config_diretorios(estePrograma)
    if not isinstance(dic_diretorios, dict):
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - " + dic_diretorios + "\n"
        msgLog(mensagem)
        return False

    tempoCiclo = ciclosScrips(estePrograma)
    if not isinstance(tempoCiclo, int):
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - " + tempoCiclo + "\n"
        msgLog(mensagem)
        return False

    dirSend = dic_diretorios['send']
    filas = dic_diretorios['filas']

    kill = False

    while not kill:
        for fila in filas:
            filaQueue = fila['NOME_FILA']

            if not os.path.isdir(dirSend + '/' + filaQueue):
                os.mkdir(dirSend + '/' + filaQueue)

            dirArq = dirSend + '/' + filaQueue + '/*.*'
            dirSended = dirSend + '/' + filaQueue + '/Sended/'
            if not os.path.isdir(dirSended):
                os.mkdir(dirSended)
            for file in glob.glob(dirArq):
                with open(file, 'r') as jsonFileLeitura:
                    dadosJson = json.load(jsonFileLeitura)
                    for item in dadosJson:
                        sendRabbitMQ(filaQueue, item)

                shutil.move(file, dirSended + os.path.basename(file))

        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        tempo = str(tempoCiclo)
        mensagem = agora + " O programa entrara em sleep por " + tempo + "segundos\n"
        msgLog(mensagem)
        time.sleep(tempoCiclo)

processarArquivos()




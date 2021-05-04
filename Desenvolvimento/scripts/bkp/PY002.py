import os
import glob
import time
import sys
import shutil
from time import gmtime, strftime
import json
from PY000 import config_diretorios, ciclosScrips


agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
horaLog = strftime("%H_%M_%S", gmtime())
nomeArqLog = 'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PYE002_' + horaLog + '.log'
tracelog = False
estePrograma = 'PY002'


def verificaLog():
    global tracelog
    tracelog = os.path.isfile(
        'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PYE002.TRACELOG')
    if tracelog:
        log_id_py002()
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Iniciando processo de Extração\n"
        msgLog(mensagem)
        return True
    return False


def log_id_py002():
    arqLog = open(nomeArqLog, "w")
    arqLog.close()


def msgLog(mensagem):
    arqLog = open(nomeArqLog, "a")
    arqLog.write(mensagem)
    arqLog.close()


def verificaKill():
    arqKill = os.path.isfile(
        'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PY001.KILL')
    if arqKill:
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Arquivo .KILL encontrado, programa irá encerrar.\n"
        msgLog(mensagem)
        return True
    return False


def geraEntidades(arqTmp, filas, dirSend):
    arqJsom = []
    try:
        for linha in arqTmp:
            arquivo = linha[0:8]
            acao = linha[8:9]
            conteudo = {'conteudo': linha[9:]}

            for fila in filas:
                if fila['MASCARA_FILA'] == arquivo:
                    cabecalho = {}
                    nomeEntidade = fila['NOME_ENTIDADE']
                    cabecalho['timeStamp'] = strftime(
                        "%Y-%m-%d %H:%M:%S", gmtime())
                    cabecalho['arquivo'] = arquivo
                    cabecalho['acao'] = acao
                    cabecalho[nomeEntidade] = conteudo
                    nomeArquivo = nomeEntidade
                    break

            nomeArquivo = nomeArquivo + \
                strftime("_%Y_%m_%d_%H_%M_%S", gmtime()) + '.json'
            arqJsom.append(cabecalho)
        with open(dirSend + '/' + fila['NOME_FILA'] + '/' + nomeArquivo, 'w') as json_file:
            json.dump(arqJsom, json_file, indent=4)
    except Exception as e:
        tb = sys.exc_info()
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + 'Erro - ' + str(e.with_traceback(tb[2]))
        msgLog(mensagem)
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
    dirErr = dic_diretorios['err'] + '/'
    dirOld = dic_diretorios['estracao'] + '/Old/'
    dirTemp = dic_diretorios['temp']
    filas = dic_diretorios['filas']

    fileTemp = dirTemp + '/CSBH*.*'
    dirSend = dirSend + '/'
    kill = False

    while not kill:
        for file in glob.glob(fileTemp):
            arqTmp = open(file, "r")
            try:
                geraEntidades(arqTmp, filas, dirSend)
                arqTmp.close()
                shutil.move(file, dirOld + os.path.basename(file))
            except Exception as e:
                tb = sys.exc_info()
                agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
                mensagem = agora + 'Erro - ' + str(e.with_traceback(tb[2]))
                msgLog(mensagem)
                shutil.move(file, dirErr + os.path.basename(file))

        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        tempo = str(tempoCiclo)
        mensagem = agora + " O programa entrara em sleep por " + tempo + "segundos\n"
        msgLog(mensagem)
        time.sleep(tempoCiclo)


# =========================================================== Começa execução ==============================================================================================
tracelog = verificaLog()
kill = verificaKill()
if not kill:
    processarArquivos()

import os
import glob
import time
import sys
from time import gmtime, strftime
from PY000 import config_diretorios, ciclosScrips

agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
horaLog = strftime("%H_%M_%S", gmtime())
nomeArqLog = 'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PYE001_' + horaLog + '.log'
tracelog = False
estePrograma = 'PY001'


def verificaLog():
    global tracelog
    tracelog = os.path.isfile(
        'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PYE001.TRACELOG')
    if tracelog:
        log_id_py001()
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Iniciando processo de Extração\n"
        msgLog(mensagem)
        return True
    return False


def log_id_py001():
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


def processarArquivos():
    global estePrograma
    dic_diretorios = config_diretorios('PY001')
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
    
    dirExtracao = dic_diretorios['estracao']
    dirLog = dic_diretorios['log']
    dirTemp = dic_diretorios['temp']

    if not dirExtracao and tracelog:
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - Diretório Extração não encontrado\n"
        msgLog(mensagem)
    
    if not dirTemp and tracelog:
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - Diretório Tmp não encontrado\n"
        msgLog(mensagem)

    if not dirLog and tracelog:
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - Diretório Log não encontrado\n"
        msgLog(mensagem)

    fileExtracao = dirExtracao + '/CSBH*.*'
    fileTemp = dirTemp + '/'
    kill = False
   
    while not kill:
        for f in glob.glob(fileExtracao):
            nome = f[55:]
            try:
                os.rename(f, fileTemp + nome)
            except Exception as e:
                tb = sys.exc_info()
                agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
                mensagem = agora + 'Erro - ' + str(e.with_traceback(tb[2]))
                msgLog(mensagem)

        kill = verificaKill()
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

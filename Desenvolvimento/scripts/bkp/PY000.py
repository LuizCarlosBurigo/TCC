#!/usr/bin/env python
import pika
import os
import time
import sys
import xmltodict
from time import gmtime, strftime
import json

nomeArqLog = 'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/Extracao/Log/PYE000.log'
idArqconfig = 'C:/Users/luiz.carlos/Desktop/Estudo/TCC/Dados/BaseDados_CSBH_01/CONFIG_EXTRACAO.xml'


def log_id_config():
    arqLog = open(nomeArqLog, "w")
    arqLog.close()
    return nomeArqLog


def msgLog(mensagem):
    global nomeArqLog
    idArqLog = os.path.isfile(nomeArqLog)
    if not idArqLog:
        nomeArqLog = log_id_config()

    arqLog = open(nomeArqLog, "a")
    arqLog.write(mensagem)
    arqLog.close()


def abrirConfig():
    global idArqconfig
    arqConfig = os.path.isfile(idArqconfig)
    if not arqConfig:
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - Arquivo CONFIG_EXTRACAO.xml não encontrado\n"
        msgLog(mensagem)
        return "Verifique o arquivo: " + nomeArqLog

    with open(idArqconfig) as xml_file:
        data_dict = xmltodict.parse(xml_file.read())
    xml_file.close()

    return data_dict


def ciclosScrips(idProgama):
    agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
    mensagem = agora + " Buscando configurações ciclo - " + idProgama + "\n"
    msgLog(mensagem)
    data_dict = abrirConfig()
    if not isinstance(data_dict, dict):
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - " + data_dict + "\n"
        msgLog(mensagem)
        return mensagem

    tagCiclo = 'TEMPO_ENTRE_CICLOS_' + idProgama
    ciclo = data_dict['CONFIG_EXTRACAO']['CONFIG_SCRIPTS'][tagCiclo]
    try:
        int(ciclo)
    except:
        mensagem = agora + " Erro - ciclo" + ciclo + "inválido\n"
        msgLog(mensagem)

    if ciclo == '0':
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - ciclo" + ciclo + "inválido\n"
        msgLog(mensagem)
        return "Verifique o arquivo: " + nomeArqLog
    ciclo = int(ciclo)
    return ciclo


def config_diretorios(idProgama):
    agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
    mensagem = agora + " Buscando configurações diretório - " + idProgama + "\n"
    msgLog(mensagem)

    data_dict = abrirConfig()
    if not isinstance(data_dict, dict):
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - " + data_dict + "\n"
        msgLog(mensagem)
        return mensagem

    dic_diretorios = {}
    dirExtracao = data_dict['CONFIG_EXTRACAO']['CONFIG_DIRETORIOS']['DIRETORIO_EXTRACAO']
    dirTemp = data_dict['CONFIG_EXTRACAO']['CONFIG_DIRETORIOS']['DIRETORIO_TEMP']
    dirSend = data_dict['CONFIG_EXTRACAO']['CONFIG_DIRETORIOS']['DIRETORIO_SEND']
    dirLog = data_dict['CONFIG_EXTRACAO']['CONFIG_DIRETORIOS']['DIRETORIO_LOG']
    dirErr = data_dict['CONFIG_EXTRACAO']['CONFIG_DIRETORIOS']['DIRETORIO_ERR']
    filas = data_dict['CONFIG_EXTRACAO']['CONFIG_FILAS']['FILA']

    if dirExtracao == "":
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - diretório Extracao não cadastrado não encontrado\n"
        msgLog(mensagem)
        return "Verifique o arquivo: " + nomeArqLog

    if dirTemp == "":
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - diretório Temp não cadastrado não encontrado\n"
        msgLog(mensagem)
        return "Verifique o arquivo: " + nomeArqLog

    if dirSend == "":
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - diretório Send não cadastrado não encontrado\n"
        msgLog(mensagem)
        return "Verifique o arquivo: " + nomeArqLog

    if dirLog == "":
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - diretório Log não cadastrado não encontrado\n"
        msgLog(mensagem)
        return "Verifique o arquivo: " + nomeArqLog

    if dirErr == "":
        agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
        mensagem = agora + " Erro - diretório de Err não cadastrado não encontrado\n"
        msgLog(mensagem)
        return "Verifique o arquivo: " + nomeArqLog

    agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
    mensagem = agora + " Diretório Extração: " + dirExtracao + "\n"
    msgLog(mensagem)

    agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
    mensagem = agora + " Diretório Tmp: " + dirTemp + "\n"
    msgLog(mensagem)

    agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
    mensagem = agora + " Diretório Send: " + dirSend + "\n"
    msgLog(mensagem)

    agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
    mensagem = agora + " Diretório Log: " + dirLog + "\n"
    msgLog(mensagem)

    agora = strftime("%Y-%m-%d %H:%M:%S", gmtime())
    mensagem = agora + " Diretório Err: " + dirErr + "\n"
    msgLog(mensagem)

    dic_diretorios['estracao'] = dirExtracao
    dic_diretorios['temp'] = dirTemp
    dic_diretorios['send'] = dirSend
    dic_diretorios['log'] = dirLog
    dic_diretorios['err'] = dirErr

    if idProgama != 'PY001':
        dic_diretorios['filas'] = filas

    return dic_diretorios


def sendRabbitMQ(queueEntity, message):
    connection = pika.BlockingConnection(
        pika.ConnectionParameters(host='localhost'))
    channel = connection.channel()

    channel.queue_declare(queue=queueEntity)

    channel.basic_publish(exchange='',
                          routing_key=queueEntity,
                          body=json.dumps(message),
                          properties=pika.BasicProperties(
                              delivery_mode=2,  # make message persistent
                          ))
    connection.close()

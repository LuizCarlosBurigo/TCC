
       IDENTIFICATION DIVISION.
       PROGRAM-ID. CSBH00001I.
      *>=====================================================================
       ENVIRONMENT DIVISION.
       configuration section.
      *>=====================================================================
       INPUT-OUTPUT Section.
       File-Control.
           COPY CSBHS001.
           COPY CSBHS002.
           COPY CSBHS003.
           COPY CSBHS004.
           COPY CSBHS005.
           COPY CSBHS006.
           COPY CSBHS007.
           COPY CSBHS008.
           COPY CSBHS009.

           select trace-log assign to wid-arquivo-log
                  status  is ws-resultado-acesso
                  organization is line sequential.



      *>=====================================================================
       DATA DIVISION.
       FILE SECTION.
           COPY CSBHF001.
           COPY CSBHF002.
           COPY CSBHF003.
           COPY CSBHF004.
           COPY CSBHF005.
           COPY CSBHF006.
           COPY CSBHF007.
           COPY CSBHF008.
           COPY CSBHF009.

           fd   trace-log.
           01   log-registro.
                03 log-linha                       pic  x(2048).




      *>=====================================================================
       WORKING-STORAGE SECTION.

       78  versao                                            value "a".
       78  este-programa                                     value "CSBH00001I".

       01  ws-campos-trabalho.
           03 ws-id-tracelog-csbh0001i             pic 9(03) value zeroes.
              88 ws-tracelog-csbh0001i                       value zeroes.
           03 wid-arquivo-log                      pic x(250).

      *>=====================================================================
       COPY CSBHW0001.
      *>=====================================================================
       LINKAGE SECTION.
       COPY CSBHW0002.

      *>=====================================================================
       PROCEDURE DIVISION USING linkage-parametros.
       MAIN-PROCEDURE.
      *>=====================================================================
       0000-controle section.
       0000.
            perform 1000-inicializacao
            perform 2000-processamento
            perform 3000-finalizacao
          .
       0000-saida.
       exit program
       STOP RUN.
      *>=====================================================================
       1000-inicializacao section.
       1000.
            perform 9000-csbsp001-carga-inicial
            perform 9000-verifica-tracelog
            if   not lnk-sem-erro
                 move lnk-id-erro                  to ws-ds-tracelog
                 perform 9000-tracelog
            end-if

           .
       1000-exit.
            exit.
      *>=====================================================================
       2000-processamento section.
       2000.
            move "2000-processamento - Inicio"     to ws-ds-tracelog
            perform 9000-tracelog
            perform 9000-abrir-o-CSBHD001
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD002
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD003
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD004
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD005
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD006
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD007
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD008
            perform 9000-controle-abertura
            perform 9000-abrir-o-CSBHD009
            perform 9000-controle-abertura

            move "2000-processamento - Fim"     to ws-ds-tracelog
            perform 9000-tracelog
           .
       2000-exit.
            exit.
      *>=====================================================================
       3000-finalizacao section.
       3000.
            move "3000-finalizacao - Inicio"       to ws-ds-tracelog
            perform 9000-tracelog

            close CSBHD001
            close CSBHD002
            close CSBHD003
            close CSBHD004
            close CSBHD005
            close CSBHD006
            close CSBHD007
            close CSBHD008
            close CSBHD009
            close trace-log

            move "3000-finalizacao - Fim"          to ws-ds-tracelog
            perform 9000-tracelog
           .
       3000-exit.
            exit.
      *>=====================================================================
       9000-verifica-tracelog section.
       9000.
            initialize                             ws-check-file
            string lnk-dtbLog delimited by space,
                   este-programa, ".TRACELOG" into ws-filename

            call "CBL_CHECK_FILE_EXIST" using ws-filename
                                              ws-file-details
            move Return-Code                    to ws-id-tracelog-csbh0001i

            if   ws-tracelog-csbh0001i
                 accept ws-data-inv from date yyyymmdd
                 string lnk-dtbLog delimited by spaces, este-programa, "_",
                        lnk-cd-empresa lnk-cd-filial delimited by size,
                        ws-data-inv delimited by size, ".LOG" into wid-arquivo-log
                 open extend trace-log
                 if   not ws-operacao-ok
                     open output trace-log
                 end-if
            end-if
           .
       9000-exit.
            exit.

      *>=====================================================================
       9000-tracelog section.
       9000.
            if   ws-tracelog-csbh0001i
                 accept ws-horas                   from time
                 move spaces                       to log-linha
                 string ws-dia-inv "/" ws-mes-inv "/" ws-ano-inv, " ",
                        ws-hora ":" ws-minutos ":" ws-segundos ":"
                        ws-horas (7:2) " - " ws-ds-tracelog into log-linha
                 open extend trace-log
                 write log-registro
            end-if
            move spaces                            to ws-ds-tracelog
           .
       9000-exit.
            exit.

      *>=====================================================================
       9000-controle-abertura section.
       9000.
            if   not processamento-sem-erro
                 move whs-mensagem                 to ws-ds-tracelog
                 perform 9000-tracelog
            end-if
           .
       9000-exit.
            exit.

      *>=====================================================================
      *> Procedure padrão
       COPY CSBHP001.
      *>=====================================================================
      *> Leitura/acesso
       COPY CSBHL001.
       COPY CSBHL002.
       COPY CSBHL003.
       COPY CSBHL004.
       COPY CSBHL005.
       COPY CSBHL006.
       COPY CSBHL007.
       COPY CSBHL008.
       COPY CSBHL009.

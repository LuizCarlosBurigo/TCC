
       IDENTIFICATION DIVISION.
       PROGRAM-ID. CSBH01001C.
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
           COPY CSBHS999.

           select trace-log assign to wid-arquivo-log
                  status  is ws-resultado-acesso
                  organization is line sequential.

           select arqcidadecsv assign to wid-arqcidadecsv
                  organization is line sequential
                  file status ws-resultado-acesso.

           select arqlojacsv assign to wid-arqlojacsv
                  organization is line sequential
                  file status ws-resultado-acesso.


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
           COPY CSBHF999.

           fd   trace-log.
           01   log-registro.
                03 log-linha                       pic  x(2048).

           fd arqcidadecsv.
           01 reg-arqcidadecsv                     pic  x(350).

           fd arqlojacsv.
           01 reg-arqlojacsv                       pic  x(350).

      *>=====================================================================
       WORKING-STORAGE SECTION.

       78  versao                                            value "a".
       78  este-programa                                     value "CSBH01001C".

       01  ws-campos-trabalho.
           03 ws-id-tracelog-csbh01001c             pic 9(03) value zeroes.
              88 ws-tracelog-csbh01001c                       value zeroes.
           03 ws-id-arquivo-aberto                  pic x(01) value spaces.
              88 ws-arquivo-aberto                            value "S" "s".

       01  ws-campos-alfa-arqcsv.
            03 ws-cd-cidade-alfa                    pic x(09) value spaces.
            03 ws-cd-empresa-alfa                   pic x(03) value spaces.
            03 ws-cd-filial-alfa                    pic x(03) value spaces.
            03 ws-num-alfa                          pic x(09) value spaces.
            03 ws-cd-saida-alfa                     pic x(09) value spaces.
            03 ws-cd-transportadora-alfa            pic x(09) value spaces.
            03 ws-total-alfa                        pic x(12) value spaces.
            03 ws-frete-alfa                        pic x(12) value spaces.
            03 ws-imposto-alfa                      pic x(12) value spaces.

       01  ws-campos-label-arqcsv.
           03 ws-campos-cidade-csv.                 *> Exemplo: CSBH01001C_CIDADE.CSV
              05 ws-cd-cidade-1                     pic 9(09).
              05 ws-uf-1                            pic x(09).
              05 ws-ds-cidade-1                     pic x(80).

           03 ws-campos-loja-csv.                   *> Exemplo: CSBH01001C_LOJA.CSV
              05 ws-cd-empresa-2                    pic 9(03).
              05 ws-cd-filial-2                     pic 9(04).
              05 ws-endereco-2                      pic x(80).
              05 ws-num-2                           pic 9(09).
              05 ws-bairro-2                        pic x(80).
              05 ws-cnpj-2                          pic x(18).
              05 ws-cd-cidade-2                   pic 9(09).

           03  ws-campos-saida-csv.                 *> Exemplo: CSBH01001C_SAIDA.CSV
               05 ws-cd-empresa-3                   pic 9(03).
               05 ws-cd-filial-3                    pic 9(03).
               05 ws-cd-saida-3                     pic 9(09).
               05 ws-cd-transportadora-3            pic 9(09).
               05 ws-total-3                        pic s9(09)v99.
               05 ws-frete-3                        pic s9(09)v99.
               05 ws-imposto-3                      pic s9(09)v99.

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
            perform 3000-finalizacao.
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

            move "1000-inicializacao - Inicio"     to ws-ds-tracelog
            perform 9000-tracelog
            perform 9000-abrir-io-CSBHD001
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD002
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD003
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD004
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD005
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD006
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD007
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD008
            perform 9000-controle-abertura
            perform 9000-abrir-io-CSBHD009
            perform 9000-controle-abertura

            move "1000-inicializacao - Fim"     to ws-ds-tracelog
            perform 9000-tracelog
           .
       1000-exit.
            exit.
      *>=====================================================================
       2000-processamento section.
       2000.
            move "2000-processamento - Inicio"     to ws-ds-tracelog
            perform 9000-tracelog
            perform 2100-processa-cidade-csv
            perform 2200-processa-loja-csv


            move "2000-processamento - Fim"     to ws-ds-tracelog
            perform 9000-tracelog
           .
       2000-exit.
            exit.
      *>=====================================================================
       2100-processa-cidade-csv section.
       2100.
            move "2100-processa-cidade-csv - Inicio"   to ws-ds-tracelog
            perform 9000-tracelog

            initialize                                    ws-check-file
            string lnk-dtbLog delimited by space,
                   este-programa, "_CIDADE.CSV" into ws-filename

            call "CBL_CHECK_FILE_EXIST" using ws-filename
                                              ws-file-details
            end-call
            move Return-Code                           to ws-cbl-status-code
            if   ws-cbl-status
                 move ws-filename                      to wid-arqcidadecsv
                 perform 2110-valida-arquivo-cidade
            else
                 string "Arquivo " delimited by size, ws-filename, delimited by space,
                        " não encontrado" into ws-ds-tracelog
                 perform 9000-tracelog
            end-if

            move "2100-processa-cidade-csv - Final"   to ws-ds-tracelog
            perform 9000-tracelog
           .
       2100-exit.
            exit.

      *>=====================================================================
       2110-valida-arquivo-cidade section.
       2110.
            open input arqcidadecsv
            if   not ws-operacao-ok
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] erro de abertura - status: ", ws-status into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            read arqcidadecsv *> Despreza cabeçalho
            read arqcidadecsv
            if   not ws-operacao-ok
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "Erro - Arquivo vazio: [" delimited by size, ws-filename delimited by space,
                        "] - status: ", ws-status into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            move "N"                               to ws-id-arquivo-aberto
            move 2                                 to ws-idx-001
            perform
              until not ws-operacao-ok
                    perform 2120-valida-campos-cidade
                    read arqcidadecsv
            end-perform
            close arqcidadecsv
            .
       2110-exit.
            exit.
      *>=====================================================================
      2120-valida-campos-cidade section.
      2120.
            initialize                                      ws-campos-cidade-csv
                                                            ws-campos-alfa-arqcsv.

            unstring reg-arqcidadecsv delimited by ";" into ws-cd-cidade-alfa
                                                            ws-uf-1
                                                            ws-ds-cidade-1

            move function numval (ws-cd-cidade-alfa)        to ws-cd-cidade-1

            if   ws-cd-cidade-1 equal zero
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] linha ", ws-idx-001,
                        " campo Cidade inválido: ", ws-cd-cidade-1            into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            if   ws-uf-1 equal spaces
            or   ws-ds-cidade-1 equal spaces
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] linha ", ws-idx-001,
                        " campo UF ou Descrição Cidade errado",
                                                       into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            if   ws-arquivo-aberto
                 close CSBHD002
                 perform 9000-abrir-io-CSBHD002
                 if   not ws-operacao-ok
                 and  not ws-arquivo-inexistente
                      string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                             "] ", whs-mensagem  into ws-ds-tracelog
                      perform 9000-tracelog
                      exit section
                 end-if
            end-if

            move "S"                               to ws-id-arquivo-aberto
            initialize                             fccdd-cidade
            move ws-cd-cidade-1                    to fccdd-cd-cidade
            move ws-uf-1                           to fccdd-uf
            move ws-ds-cidade-1                    to fccdd-ds-cidade
            perform 9000-ler-CSBHD002-ran

            if   not ws-operacao-ok
                 perform 9000-gravar-CSBHD002
            else
                 perform 9000-regravar-CSBHD002
            end-if

            if   not ws-operacao-ok
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] ", whs-mensagem       into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if
            add 1                                  to ws-idx-001
          .
      2120-exit.
           exit.
      *>=====================================================================
      2200-processa-loja-csv section.
      2200.
            move "2200-processa-loja-csv - Inicio"     to ws-ds-tracelog
            perform 9000-tracelog

            initialize                                    ws-check-file
            string lnk-dtbLog delimited by space,
                   este-programa, "_LOJA.CSV"        into ws-filename

            call "CBL_CHECK_FILE_EXIST" using ws-filename
                                              ws-file-details
            end-call
            move Return-Code                           to ws-cbl-status-code
            if   ws-cbl-status
                 move ws-filename                      to wid-arqcidadecsv
                 perform 2110-valida-arquivo-cidade
            else
                 string "Arquivo " delimited by size, ws-filename, delimited by space,
                        " não encontrado" into ws-ds-tracelog
                 perform 9000-tracelog
            end-if

            move "2200-processa-loja-csv - Final"      to ws-ds-tracelog
            perform 9000-tracelog
          .
      2200-exit.
           exit.

      *>=====================================================================
      2210-valida-arquivo-loja section.
      2210.
            open input arqlojacsv
            if   not ws-operacao-ok
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] erro de abertura - status: ", ws-status into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            read arqlojacsv *> Despreza cabeçalho
            read arqlojacsv
            if   not ws-operacao-ok
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "Erro - Arquivo vazio: [" delimited by size, ws-filename delimited by space,
                        "] - status: ", ws-status into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            move "N"                               to ws-id-arquivo-aberto
            move 2                                 to ws-idx-001
            perform
              until not ws-operacao-ok
                    perform 2220-valida-campos-loja
                    read arqlojacsv
            end-perform
            close arqlojacsv

           .
       2210-exit.
            exit.

      *>=====================================================================
       2220-valida-campos-loja section.
       2220.
            initialize                                      ws-campos-loja-csv
                                                            ws-campos-alfa-arqcsv.

            unstring reg-arqlojacsv delimited by ";"   into ws-cd-empresa-alfa
                                                            ws-cd-filial-alfa
                                                            ws-endereco-2
                                                            ws-num-alfa
                                                            ws-bairro-2
                                                            ws-cnpj-2
                                                            ws-cd-cidade-alfa

            move function numval (ws-cd-empresa-alfa)       to ws-cd-empresa-2
            move function numval (ws-cd-filial-alfa)        to ws-cd-filial-2
            move function numval (ws-num-alfa)              to ws-num-2
            move function numval (ws-cd-cidade-alfa)        to ws-cd-cidade-2

            if   ws-cd-empresa-2 equal zeros
            or   ws-cd-filial-2  equal zeros
            or   ws-num-2        equal zeros
            or   ws-cd-cidade-2  equal zeros
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] linha ", ws-idx-001,
                        " campo númerico inválido, verifique os campos ",
                        "Empresa,Filial,Numero e Cidade" into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            if   ws-endereco-2 equal spaces
            or   ws-bairro-2   equal spaces
            or   ws-cnpj-2     equal spaces
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] linha ", ws-idx-001,
                        " campo de texto inválido, verifique os campos ",
                        "Endereço, bairro e CNPJ" into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if

            if   ws-arquivo-aberto
                 perform 9000-abrir-io-CSBHD001
                 if   not ws-operacao-ok
                 and  not ws-arquivo-inexistente
                      string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                             "] ", whs-mensagem  into ws-ds-tracelog
                      perform 9000-tracelog
                      exit section
                 end-if
            end-if

            move "S"                               to ws-id-arquivo-aberto
            initialize                             fclj-loja
            move ws-cd-empresa-2                   to fclj-cd-empresa
            move ws-cd-filial-2                    to fclj-cd-filial
            move ws-endereco-2                     to fclj-endereco
            move ws-num-2                          to fclj-num
            move ws-bairro-2                       to fclj-bairro
            move ws-cnpj-2                         to fclj-cnpj
            move ws-cd-cidade-2                    to fclj-cd-cidade
            perform 9000-ler-CSBHD001-ran
            if   not ws-operacao-ok
                 perform 9000-gravar-CSBHD002
            else
                 perform 9000-regravar-CSBHD002
            end-if

            if   not ws-operacao-ok
                 string "Erro - Arquivo: [" delimited by size, ws-filename delimited by space,
                        "] ", whs-mensagem       into ws-ds-tracelog
                 perform 9000-tracelog
                 exit section
            end-if
            add 1                                  to ws-idx-001
           .
       2220-exit.
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
            end-call
            move Return-Code                    to ws-id-tracelog-csbh01001c

            if   ws-tracelog-csbh01001c
                 accept ws-data-inv from date yyyymmdd
                 string lnk-dtbLog delimited by spaces, este-programa, "_",
                        lnk-cd-empresa lnk-cd-filial delimited by size,
                        ws-data-inv delimited by size, ".LOG" into wid-arquivo-log
                 open extend trace-log
                 if   not ws-operacao-ok
                      open output trace-log
                 end-if
                 close trace-log
            end-if
           .
       9000-exit.
            exit.

      *>=====================================================================
       9000-tracelog section.
       9000.
            if   ws-tracelog-csbh01001c
                 accept ws-horas                   from time
                 move spaces                       to log-linha
                 string ws-dia-inv "/" ws-mes-inv "/" ws-ano-inv, " ",
                        ws-hora ":" ws-minutos ":" ws-segundos ":"
                        ws-horas (7:2) " - " ws-ds-tracelog into log-linha
                 open extend trace-log
                 write log-registro
                 close trace-log
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
       COPY CSBHL999.

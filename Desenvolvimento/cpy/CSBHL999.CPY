*>
*>
       9000-gravar-CSBHD010 section.
            if   not lnk-extractionPath-des
                 string lnk-extractionPath delimited by spaces, "\", este-programa, "_",
                        lnk-cd-empresa lnk-cd-filial delimited by size, ".Temp" into wid-CSBH999
                 open extend CSBHD999
                 if   not ws-operacao-ok
                      open output CSBHD999
                      initialize                             fiitg-dados
                      move ws-registro-estracao              to fiitg-dados
                      write fiitg-dados
                      if   not ws-operacao-ok
                           initialize                        whs-mensagem
                           move ws-resultado-acesso          to ws-status
                           perform 9000-csbsp001-monta-status
                           string "9000-Erro de gravação arquivo CSBHD010" into whs-mensagem
                      end-if

                      close CSBHD999
                      exit section
                 end-if

                 initialize                             fiitg-dados
                 move ws-registro-estracao              to fiitg-dados
                 write fiitg-dados
                 if   not ws-operacao-ok
                      move "oi1" to whs-mensagem
                      initialize                        whs-mensagem
                      move ws-resultado-acesso          to ws-status
                      perform 9000-csbsp001-monta-status
                      string "9000-Erro de gravação arquivo CSBHD010" into whs-mensagem
                 end-if

                 close CSBHD999
            end-if
            .
       9000-exit.
            exit.
*>

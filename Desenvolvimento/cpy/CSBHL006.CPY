*>
       9000-abrir-i-CSBHD006 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD006.CAD" delimited by size into wid-csbh006
            open input CSBHD006
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD006" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD006 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD006.CAD" delimited by size into wid-csbh006
            open output CSBHD006
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (OUTPUT) arquivo CSBHD006" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD006 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD006.CAD" delimited by size into wid-csbh006
            open i-o CSBHD006
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD006" into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD006-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD006.
*>
*>
       9000-ler-CSBHD006-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD006 previous.
*>
*>
       9000-ler-CSBHD006-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD006 next.
*>
*>
       9000-str-CSBHD006-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD006
                key is equal fdfnc-chave-1.
*>
*>
       9000-str-CSBHD006-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD006
                key is greater fdfnc-chave-1.
*>
*>
       9000-str-CSBHD006-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD006
                key is not greater fdfnc-chave-1.
*>
*>
       9000-str-CSBHD006-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD006
                key is less fdfnc-chave-1.
*>
*>
       9000-ler-CSBHD006-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD006 with ignore lock.
*>
*>
       9000-ler-CSBHD006-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD006 previous with ignore lock.
*>
*>
       9000-ler-CSBHD006-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD006 next with ignore lock.
*>
*>
       9000-gravar-CSBHD006 section.
            write fdfnc-fornecedor
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD006" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD006 section.
            rewrite fdfnc-fornecedor
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD006" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD006 section.
            delete CSBHD006
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD006" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

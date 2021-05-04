*>
       9000-abrir-i-CSBHD003 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD003.CAD" delimited by size into wid-csbh003
            open input CSBHD003
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD003" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD003 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD003.CAD" delimited by size into wid-csbh003
            open output CSBHD003
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (OUTPUT) arquivo CSBHD003" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD003 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD003.CAD" delimited by size into wid-csbh003
            open i-o CSBHD003
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD003" into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD003-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD003.
*>
*>
       9000-ler-CSBHD003-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD003 previous.
*>
*>
       9000-ler-CSBHD003-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD003 next.
*>
*>
       9000-str-CSBHD003-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is equal fesd-chave-1.
*>
*>
       9000-str-CSBHD003-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is greater fesd-chave-1.
*>
*>
       9000-str-CSBHD003-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is not greater fesd-chave-1.
*>
*>
       9000-str-CSBHD003-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is less fesd-chave-1.

*>
*>
       9000-str-CSBHD003-eql-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is equal fesd-chave-2.
*>
*>
       9000-str-CSBHD003-gtr-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is greater fesd-chave-2.
*>
*>
       9000-str-CSBHD003-ngtr-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is not greater fesd-chave-2.
*>
*>
       9000-str-CSBHD003-lss-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD003
                key is less fesd-chave-2.
*>
*>
       9000-ler-CSBHD003-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD003 with ignore lock.
*>
*>
       9000-ler-CSBHD003-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD003 previous with ignore lock.
*>
*>
       9000-ler-CSBHD003-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD003 next with ignore lock.
*>
*>
       9000-gravar-CSBHD003 section.
            write fesd-saida
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD003" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD003 section.
            rewrite fesd-saida
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD003" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD003 section.
            delete CSBHD003
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD003" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

*>
       9000-abrir-i-CSBHD004 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD004.CAD" delimited by size into wid-csbh004
            open input CSBHD004
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD004" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD004 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD004.CAD" delimited by size into wid-csbh004
            open output CSBHD004
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (OUTPUT) arquivo CSBHD004" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD004 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD004.CAD" delimited by size into wid-csbh004
            open i-o CSBHD004
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD004" into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD004-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD004.
*>
*>
       9000-ler-CSBHD004-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD004 previous.
*>
*>
       9000-ler-CSBHD004-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD004 next.
*>
*>
       9000-str-CSBHD004-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is equal feisd-chave-1.
*>
*>
       9000-str-CSBHD004-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is greater feisd-chave-1.
*>
*>
       9000-str-CSBHD004-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is not greater feisd-chave-1.
*>
*>
       9000-str-CSBHD004-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is less feisd-chave-1.

*>
*>
       9000-str-CSBHD004-eql-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is equal feisd-chave-2.
*>
*>
       9000-str-CSBHD004-gtr-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is greater feisd-chave-2.
*>
*>
       9000-str-CSBHD004-ngtr-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is not greater feisd-chave-2.
*>
*>
       9000-str-CSBHD004-lss-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is less feisd-chave-2.
*>
*>
       9000-str-CSBHD004-eql-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is equal feisd-chave-3.
*>
*>
       9000-str-CSBHD004-gtr-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is greater feisd-chave-3.
*>
*>
       9000-str-CSBHD004-ngtr-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is not greater feisd-chave-3.
*>
*>
       9000-str-CSBHD004-lss-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD004
                key is less feisd-chave-3.
*>
*>
       9000-ler-CSBHD004-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD004 with ignore lock.
*>
*>
       9000-ler-CSBHD004-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD004 previous with ignore lock.
*>
*>
       9000-ler-CSBHD004-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD004 next with ignore lock.
*>
*>
       9000-gravar-CSBHD004 section.
            write feisd-item-saida
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD004" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD004 section.
            rewrite feisd-item-saida
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD004" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD004 section.
            delete CSBHD004
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD004" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

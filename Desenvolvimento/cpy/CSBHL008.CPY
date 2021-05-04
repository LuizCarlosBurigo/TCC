*>
       9000-abrir-i-CSBHD008 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD008.CAD" delimited by size into wid-csbh008
            open input CSBHD008
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD008" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD008 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD008.CAD" delimited by size into wid-csbh008
            open output CSBHD008
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (OUTPUT) arquivo CSBHD008" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD008 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD008.CAD" delimited by size into wid-csbh008
            open i-o CSBHD008
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD008" into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD008-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD008.
*>
*>
       9000-ler-CSBHD008-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD008 previous.
*>
*>
       9000-ler-CSBHD008-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD008 next.
*>
*>
       9000-str-CSBHD008-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD008
                key is equal fddps-chave-1.
*>
*>
       9000-str-CSBHD008-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD008
                key is greater fddps-chave-1.
*>
*>
       9000-str-CSBHD008-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD008
                key is not greater fddps-chave-1.
*>
*>
       9000-str-CSBHD008-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD008
                key is less fddps-chave-1.
*>
*>
       9000-ler-CSBHD008-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD008 with ignore lock.
*>
*>
       9000-ler-CSBHD008-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD008 previous with ignore lock.
*>
*>
       9000-ler-CSBHD008-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD008 next with ignore lock.
*>
*>
       9000-gravar-CSBHD008 section.
            write fddps-item-entrada
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD008" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD008 section.
            rewrite fddps-item-entrada
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD008" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD008 section.
            delete CSBHD008
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD008" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

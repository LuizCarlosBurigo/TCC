*>
       9000-abrir-i-CSBHD001 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD001.CAD" delimited by size into wid-csbh001
            open input CSBHD001.
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD001"
                 into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD001 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD001.CAD" delimited by size into wid-csbh001
            open output CSBHD001.
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (WRITE) arquivo CSBHD001" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD001 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD001.CAD" delimited by size into wid-csbh001
            open i-o CSBHD001.
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD001"
                 into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD001-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD001.
*>
*>
       9000-ler-CSBHD001-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD001 previous.
*>
*>
       9000-ler-CSBHD001-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD001 next.
*>
*>
       9000-str-CSBHD001-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD001
                key is equal fclj-chave-1.
*>
*>
       9000-str-CSBHD001-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD001
                key is greater fclj-chave-1.
*>
*>
       9000-str-CSBHD001-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD001
                key is not greater fclj-chave-1.
*>
*>
       9000-str-CSBHD001-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD001
                key is less fclj-chave-1.
*>
*>
       9000-ler-CSBHD001-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD001 with ignore lock.
*>
*>
       9000-ler-CSBHD001-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD001 previous with ignore lock.
*>
*>
       9000-ler-CSBHD001-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD001 next with ignore lock.
*>
*>
       9000-gravar-CSBHD001 section.
            write fclj-loja
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD001" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD001 section.
            rewrite fclj-loja
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD001" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD001 section.
            delete CSBHD001
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD001" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

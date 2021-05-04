*>
       9000-abrir-i-CSBHD005 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD005.CAD" delimited by size into wid-csbh005
            open input CSBHD005
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD005" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD005 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD005.CAD" delimited by size into wid-csbh005
            open output CSBHD005
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (OUTPUT) arquivo CSBHD005" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD005 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD005.CAD" delimited by size into wid-csbh005
            open i-o CSBHD005
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD005" into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD005-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD005.
*>
*>
       9000-ler-CSBHD005-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD005 previous.
*>
*>
       9000-ler-CSBHD005-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD005 next.
*>
*>
       9000-str-CSBHD005-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD005
                key is equal fetpt-chave-1.
*>
*>
       9000-str-CSBHD005-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD005
                key is greater fetpt-chave-1.
*>
*>
       9000-str-CSBHD005-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD005
                key is not greater fetpt-chave-1.
*>
*>
       9000-str-CSBHD005-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD005
                key is less fetpt-chave-1.
*>
*>
       9000-ler-CSBHD005-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD005 with ignore lock.
*>
*>
       9000-ler-CSBHD005-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD005 previous with ignore lock.
*>
*>
       9000-ler-CSBHD005-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD005 next with ignore lock.
*>
*>
       9000-gravar-CSBHD005 section.
            write fetpt-transportadora
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD005" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD005 section.
            rewrite fetpt-transportadora
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD005" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD005 section.
            delete CSBHD005
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD005" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

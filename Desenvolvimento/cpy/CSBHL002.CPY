*>
       9000-abrir-i-CSBHD002 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD002.CAD" delimited by size into wid-csbh002
            open input CSBHD002.
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD002"
                 into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD002 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD002.CAD" delimited by size into wid-csbh002
            open output CSBHD002.
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                string "9000-Erro de abertura (OUTPUT) arquivo CSBHD002"
                 into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD002 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD002.CAD" delimited by size into wid-csbh002
            open i-o CSBHD002.
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD002"
                 into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD002-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD002.
*>
*>
       9000-ler-CSBHD002-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD002 previous.
*>
*>
       9000-ler-CSBHD002-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD002 next.
*>
*>
       9000-str-CSBHD002-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD002
                key is equal fccdd-chave-1.
*>
*>
       9000-str-CSBHD002-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD002
                key is greater fccdd-chave-1.
*>
*>
       9000-str-CSBHD002-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD002
                key is not greater fccdd-chave-1.
*>
*>
       9000-str-CSBHD002-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD002
                key is less fccdd-chave-1.
*>
*>
       9000-ler-CSBHD002-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD002 with ignore lock.
*>
*>
       9000-ler-CSBHD002-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD002 previous with ignore lock.
*>
*>
       9000-ler-CSBHD002-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD002 next with ignore lock.
*>
*>
       9000-gravar-CSBHD002 section.
            write fccdd-cidade
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD002" into whs-mensagem
            else
                 move spaces                       to ws-registro-estracao
                 string "CSBHF002", "W" fccdd-cidade
                                                 into ws-registro-estracao
                 perform 9000-gravar-CSBHD010
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD002 section.
            rewrite fccdd-cidade
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD002" into whs-mensagem
            else
                 move spaces                       to ws-registro-estracao
                 string "CSBHF002", "R" fccdd-cidade
                                                 into ws-registro-estracao
                 perform 9000-gravar-CSBHD010
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD002 section.
            delete CSBHD002
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD002" into whs-mensagem
            else
                 move spaces                       to ws-registro-estracao
                 string "CSBH002", "D" fccdd-cidade, fccdd-cidade
                                                 into ws-registro-estracao
                 perform 9000-gravar-CSBHD010
            end-if
            .
       9000-exit.
            exit.
*>

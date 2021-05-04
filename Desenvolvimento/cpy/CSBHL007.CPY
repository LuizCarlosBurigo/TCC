*>
       9000-abrir-i-CSBHD007 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD007.CAD" delimited by size into wid-csbh007
            open input CSBHD007
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (INPUT) arquivo CSBHD007" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-o-CSBHD007 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD007.CAD" delimited by size into wid-csbh007
            open output CSBHD007
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (OUTPUT) arquivo CSBHD007" into whs-mensagem
            end-if.

*>
*>
       9000-abrir-io-CSBHD007 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD007.CAD" delimited by size into wid-csbh007
            open i-o CSBHD007
            if   not ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de abertura (I-O) arquivo CSBHD007" into whs-mensagem
            end-if.

*>
*>
       9000-ler-CSBHD007-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD007.
*>
*>
       9000-ler-CSBHD007-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD007 previous.
*>
*>
       9000-ler-CSBHD007-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD007 next.
*>
*>
       9000-str-CSBHD007-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is equal fdetd-chave-1.
*>
*>
       9000-str-CSBHD007-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is greater fdetd-chave-1.
*>
*>
       9000-str-CSBHD007-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is not greater fdetd-chave-1.
*>
*>
       9000-str-CSBHD007-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is less fdetd-chave-1.

*>
*>
       9000-str-CSBHD007-eql-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is equal fdetd-data-pedido.
*>
*>
       9000-str-CSBHD007-gtr-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is greater fdetd-data-pedido.
*>
*>
       9000-str-CSBHD007-ngtr-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is not greater fdetd-data-pedido.
*>
*>
       9000-str-CSBHD007-lss-2 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is less fdetd-data-pedido.
*>
*>
       9000-str-CSBHD007-eql-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is equal fdetd-data-entrada.
*>
*>
       9000-str-CSBHD007-gtr-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is greater fdetd-data-entrada.
*>
*>
       9000-str-CSBHD007-ngtr-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is not greater fdetd-data-entrada.
*>
*>
       9000-str-CSBHD007-lss-3 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is less fdetd-data-entrada.
*>
*>
       9000-str-CSBHD007-eql-4 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is equal fdetd-nunf.
*>
*>
       9000-str-CSBHD007-gtr-4 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is greater fdetd-nunf.
*>
*>
       9000-str-CSBHD007-ngtr-4 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is not greater fdetd-nunf.
*>
*>
       9000-str-CSBHD007-lss-4 section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD007
                key is less fdetd-nunf.
*>
*>
       9000-ler-CSBHD007-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD007 with ignore lock.
*>
*>
       9000-ler-CSBHD007-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD007 previous with ignore lock.
*>
*>
       9000-ler-CSBHD007-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD007 next with ignore lock.
*>
*>
       9000-gravar-CSBHD007 section.
            write feisd-item-saida
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD007" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD007 section.
            rewrite feisd-item-saida
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD007" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD007 section.
            delete CSBHD007
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD007" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

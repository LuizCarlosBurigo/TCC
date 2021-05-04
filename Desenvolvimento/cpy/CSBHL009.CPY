*>
       9000-abrir-i-CSBHD009 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD009.CAD" delimited by size into wid-csbh009
            open input CSBHD009
            if   not ws-operacao-ok
                 display ws-resultado-acesso
            end-if.

*>
*>
       9000-abrir-o-CSBHD009 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD009.CAD" delimited by size into wid-csbh009
            open output CSBHD009
            if   not ws-operacao-ok
                 display ws-resultado-acesso
            end-if.

*>
*>
       9000-abrir-io-CSBHD009 section.
*>--------------------------
*>
       9000-inicio.
            string lnk-dtbpath delimited by " "
                   "/CSBHD009.CAD" delimited by size into wid-csbh009
            open i-o CSBHD009
            if   not ws-operacao-ok
                 display ws-resultado-acesso
            end-if.

*>
*>
       9000-ler-CSBHD009-ran section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD009.
*>
*>
       9000-ler-CSBHD009-pre section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD009 previous.
*>
*>
       9000-ler-CSBHD009-next section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD009 next.
*>
*>
       9000-str-CSBHD009-eql section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD009
                key is equal fdpdt-chave-1.
*>
*>
       9000-str-CSBHD009-gtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD009
                key is greater fdpdt-chave-1.
*>
*>
       9000-str-CSBHD009-ngtr section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD009
                key is not greater fdpdt-chave-1.
*>
*>
       9000-str-CSBHD009-lss section.
*>--------------------------
*>
       9000-inicio.
            start CSBHD009
                key is less fdpdt-chave-1.
*>
*>
       9000-ler-CSBHD009-ran-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD009 with ignore lock.
*>
*>
       9000-ler-CSBHD009-pre-iglock section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD009 previous with ignore lock.
*>
*>
       9000-ler-CSBHD009-next-ignore section.
*>--------------------------
*>
       9000-inicio.
            read CSBHD009 next with ignore lock.
*>
*>
       9000-gravar-CSBHD009 section.
            write fdpdt-produto
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de gravação arquivo CSBHD009" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>
*>
       9000-regravar-CSBHD009 section.
            rewrite fdpdt-produto
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de regravação arquivo CSBHD009" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.

*>
*>
       9000-excluir-CSBHD009 section.
            delete CSBHD009
            if   ws-operacao-ok
                 initialize                        whs-mensagem
                 move ws-resultado-acesso          to ws-status
                 perform 9000-csbsp001-monta-status
                 string "9000-Erro de exclusão arquivo CSBHD009" into whs-mensagem
            end-if
            .
       9000-exit.
            exit.
*>

*>
*>Copy procedure Rotinas Padrão
*>
*>===============================================================================
       9000-csbsp001-monta-status section.
       9000.
            if   ws-byte-1-status = "9"
                 move ws-bit-2                     to ws-byte-3-status
                 move ws-byte-1-status             to ws-byte-2-status
                 move " "                          to ws-byte-1-status
            end-if
           .
       9000-exit.
            exit.

*>===============================================================================
       9000-csbsp001-carga-inicial section.
       9000.
            call carga-linkage
                USING linkage-parametros
                ON EXCEPTION
                    CONTINUE
            END-CALL
           .
       9000-exit.
            exit.

*>===============================================================================

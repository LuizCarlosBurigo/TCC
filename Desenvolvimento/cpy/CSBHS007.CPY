      *>FD          : CSBHF007.CPY
       SELECT CSBHD007 Assign to disk wid-csbh007
              organization    is indexed
              access mode     is dynamic
              record key      is fdetd-chave-1
              alternate key   is fdetd-data-pedido
              with duplicates
              alternate key   is fdetd-data-entrada
              with duplicates
              alternate key   is fdetd-nunf
              with duplicates
              lock mode       is manual
              file status     is ws-resultado-acesso.

      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF008.CPY
      *>Select      : CSBHS008.CPY
      *>CSBHL       : CSBHL008.CPY
      *>Nome Físico : CSBHD008.CAD
      *>Area Negocio: "Deposito"
      *>Descricao   : "Item Entrada"
      *>
      *>        SELECT CSBHD008 Assign to disk wid-csbh008
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is fddps-chave-1
      *>               lock mode       is manual
      *>               file status     is ws-resultado-acesso.
      *>
      *>=====================================================================

       FD  CSBHD008.

      *>=====================================================================
      *>Nome Lógico : item entrada
      *>Área Negócio: Deposito
      *>GerarIndex  : sim
      *>=====================================================================
       01  fddps-item-entrada.
           03 fddps-chave-1.
              05 fddps-cd-empresa                 pic  9(03).
                 *>FK: fccdd-cd-empresa
              05 fddps-cd-filial                  pic  9(03).
                 *>FK: fccdd-cd-loja
              05 fddps-cd-entrada                 pic  9(09).
                 *>FK: fdpdt-cd-entrada
              05 fddps-cd-produto                 pic  9(09).
              05 fddps-sequencia                  pic  9(09).
                 *>FK: fdpdt-cd-sequencia
           03 fddps-lote                          pic  x(80).
           03 fddps-quantidade                    pic  9(09).
           03 fdetd-frete                         pic s9(09)v99.

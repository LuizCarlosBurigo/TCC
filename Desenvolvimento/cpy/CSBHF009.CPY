      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF009.CPY
      *>Select      : CSBHS009.CPY
      *>CSBHL       : CSBHL009.CPY
      *>Nome Físico : CSBHD009.CAD
      *>Area Negocio: "Deposito"
      *>Descricao   : "Produto"
      *>
      *>        SELECT CSBHD009 Assign to disk wid-csbh009
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is fdpdt-chave-1
      *>               lock mode       is manual
      *>               file status     is ws-resultado-acesso.
      *>
      *>=====================================================================

       FD  CSBHD009.

      *>=====================================================================
      *>Nome Lógico : produto
      *>Área Negócio: Deposito
      *>GerarIndex  : sim
      *>=====================================================================
       01  fdpdt-produto.
           03 fdpdt-chave-1.
              05 fdpdt-cd-empresa                 pic  9(03).
                 *>FK: fccdd-cd-empresa
              05 fdpdt-cd-filial                  pic  9(03).
                 *>FK: fccdd-cd-loja
              05 fdpdt-cd-entrada                 pic  9(09).
                 *>FK:fddps-cd-entrada
              05 fdpdt-cd-produto                 pic  9(09).
              05 fdpdt-cd-sequencia               pic  9(09).
                 *>FK:fddps-sequencia
           03 fdpdt-lote                          pic  x(80).
           03 fdpdt-qtdade                        pic  9(09).
           03 fdpdt-valor                         pic s9(09)v99.

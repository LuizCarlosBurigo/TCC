      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF007.CPY
      *>Select      : CSBHS007.CPY
      *>CSBHL       : CSBHL007.CPY
      *>Nome Físico : CSBHD007.CAD
      *>Area Negocio: "Deposito"
      *>Descricao   : "Entrada"
      *>
      *>        SELECT CSBHD007 Assign to disk wid-wid-csbh007
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is fdetd-chave-1
      *>               alternate key   is fdetd-data-pedido
      *>               with duplicates
      *>               alternate key   is fdetd-data-entrada
      *>               with duplicates
      *>               alternate key   is fdetd-nunf
      *>               with duplicate
      *>
      *>=====================================================================

       FD  CSBHD007.

      *>=====================================================================
      *>Nome Lógico : entrada
      *>Área Negócio: Deposito
      *>GerarIndex  : sim
      *>=====================================================================
       01  fdetd-entrada.
           03 fdetd-chave-1.
              05 fdfnc-cd-empresa                 pic  9(03).
                 *>FK: fccdd-cd-empresa
              05 fdfnc-cd-filial                  pic  9(03).
                 *>FK: fccdd-cd-loja
              05 fdfnc-cd-entrada                 pic  9(09).
              05 fdfnc-cd-transpordadora          pic  9(09).
                 *> FK: feisd-cd-transpordadora
           03 fdetd-data-pedido.
              05 fdetd-data-pedido-ano            pic  9(04).
              05 fdetd-data-pedido-mes            pic  9(02).
              05 fdetd-data-pedido-dia            pic  9(02).
           03 fdetd-data-entrada.
              05 fdetd-data-entrada-ano           pic  9(04).
              05 fdetd-data-entrada-mes           pic  9(02).
              05 fdetd-data-entrada-dia           pic  9(02).
           03 fdetd-total                         pic s9(09)v99.
           03 fdetd-frete                         pic s9(09)v99.
           03 fdetd-nunf                          pic s9(09).
           03 fdetd-srnf                          pic s9(03).

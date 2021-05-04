      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF003.CPY
      *>Select      : CSBHS003.CPY
      *>CSBHL       : CSBHL003.CPY
      *>Nome Físico : CSBHD003.CAD
      *>Area Negocio: "Expedição"
      *>Descricao   : "Saida"
      *>
      *>        SELECT CSBHD003 Assign to disk wid-csbh003
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is fesd-chave-1
      *>               alternate key   is fesd-chave-2 with duplicates
      *>=====================================================================

       FD  CSBHD003.

      *>=====================================================================
      *>Nome Lógico : saida
      *>Área Negócio: Expedição
      *>GerarIndex  : sim
      *>=====================================================================
       01  fesd-saida.
           03 fesd-chave-1.
              05 fesd-cd-empresa                 pic 9(03).
                  *>FK: feisd-cd-empresa
              05 fesd-cd-filial                  pic 9(03).
                  *>FK: feisd-cd-filial
              05 fesd-cd-saida                   pic 9(09).
                 *> FK: feisd-cd-saida
           03 fesd-chave-2.
              05 fesd-cd-transportadora          pic 9(09).
              *>FK: feisd-cd-transpordadora
           03 fesd-total                         pic s9(09)v99.
           03 fesd-frete                         pic s9(09)v99.
           03 fesd-imposto                       pic s9(09)v99.

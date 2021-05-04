      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF004.CPY
      *>Select      : CSBHS004.CPY
      *>CSBHL       : CSBHL004.CPY
      *>Nome Físico : CSBHD004.CAD
      *>Area Negocio: "Expedição"
      *>Descricao   : "Item Saida"
      *>
      *>        SELECT CSBHD004 Assign to disk wid-csbh004
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is feisd-chave-1
      *>               alternate key   is feisd-chave-2 with duplicates
      *>               alternate key   is feisd-chave-3 with duplicates
      *>=====================================================================

       FD  CSBHD004.

      *>=====================================================================
      *>Nome Lógico : item saida
      *>Área Negócio: Expedição
      *>GerarIndex  : sim
      *>=====================================================================
       01  feisd-item-saida.
           03 feisd-chave-1.
              05 feisd-cd-empresa                 pic  9(03).
                  *>FK: fesd-cd-empresa
              05 feisd-cd-filial                  pic  9(03).
                  *>FK: fesd-cd-filial
              05 feisd-saida              pic  9(09).
           03 feisd-chave-2.
              05 feisd-cd-saida                   pic  9(09).
              *>FK: fesd-cd-saida
           03 feisd-chave-3.
              05 feisd-cd-produto                    pic  9(09).
              *>FK: feisd-cd-produto
           03 feisd-lote                          pic  x(80).
           03 feisd-qtdade                        pic  9(09).
           03 feisd-valor                         pic s9(09)v99.

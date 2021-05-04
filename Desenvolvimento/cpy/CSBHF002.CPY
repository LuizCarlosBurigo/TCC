      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF002.CPY
      *>Select      : CSBHS002.CPY
      *>CSBHL       : CSBHL002.CPY
      *>Nome Físico : CSBHD002.CAD
      *>Area Negocio: "Coorporativo"
      *>Descricao   : "Cidade"
      *>
      *>        SELECT CSBHD002 Assign to disk wid-csbh002
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is fccdd-chave-1
      *>               alternate key   is fccdd-chave-2 with duplicates
      *>=====================================================================

       FD  CSBHD002.

      *>=====================================================================
      *>Nome Lógico : cidade
      *>Área Negócio: Coorporativo
      *>GerarIndex  : sim
      *>=====================================================================
       01  fccdd-cidade.
           03 fccdd-chave-1.
              05 fccdd-cd-cidade                  pic 9(09).
              *>FK: fccdd-fornecedor
           03 fccdd-uf                            pic x(09).
              *>FK: fccdd-fornecedor
           03 fccdd-ds-cidade                     pic x(80).

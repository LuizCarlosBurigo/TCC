      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF001.CPY
      *>Select      : CSBHS001.CPY
      *>CSBHL       : CSBHL001.CPY
      *>Nome Físico : CSBHD001.CAD
      *>Area Negocio: "Cooporativo"
      *>Descricao   : "Loja"
      *>
      *>        SELECT CSBHD002D Assign to disk wid-CSBH001
      *>               organization     is indexed
      *>               access mode      is dynamic
      *>               record key       is fclj-chave-1
      *>               alternate key    is fclj-chave-2 with duplicates
      *>
      *>=====================================================================

       FD  CSBHD001.

      *>=====================================================================
      *>Nome Lógico : loja
      *>Área Negócio: Coorporativo
      *>GerarIndex  : sim
      *>=====================================================================
       01  fclj-loja.
           03 fclj-chave-1.
              05 fclj-cd-empresa                 pic 9(03).
                  *>FK: fccdd-cd-empresa
              05 fclj-cd-filial                  pic 9(03).
                  *>FK: fccdd-cd-loja
           03 fclj-endereco                      pic x(80).
           03 fclj-num                           pic 9(09).
           03 fclj-bairro                        pic x(80).
           03 fclj-cnpj                          pic x(18).
           03 fclj-chave-2.
              05 fclj-cd-cidade                  pic 9(09).

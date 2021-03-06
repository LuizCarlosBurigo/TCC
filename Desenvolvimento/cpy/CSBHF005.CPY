      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informa��es ==============================
      *>FD          : CSBHF005.CPY
      *>Select      : CSBHS005.CPY
      *>CSBHL       : CSBHL005.CPY
      *>Nome F�sico : CSBHD005.CAD
      *>Area Negocio: "Expedi��o"
      *>Descricao   : "Transportadora"
      *>
      *>        SELECT CSBHD005 Assign to disk wid-csbh005
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is fetpt-chave-1
      *>=====================================================================

       FD  CSBHD005.

      *>=====================================================================
      *>Nome L�gico : transportadora
      *>�rea Neg�cio: Expedi��o
      *>GerarIndex  : sim
      *>=====================================================================
       01  fetpt-transportadora.
           03 fetpt-chave-1.
              05 feisd-cd-transpordadora          pic  9(09).
              05 feisd-cd-cidade                  pic  9(09).
                 *>FK: feisd-cd-cidade
           03 fetpt-ds-transportadora             pic  x(80).
           03 fetpt-endereco                      pic  x(80).
           03 fetpt-numero                        pic  9(09).
           03 fetpt-bairro                        pic  x(80).
           03 fetpt-cep                           pic  x(09).
           03 fetpt-cnpj                          pic  x(14).
           03 fetpt-email                         pic  x(80).
           03 fetpt-telefone    occurs 4 times.
              05 fetpt-ddd                        pic  9(03).
              05 fetpt-numero-telefone            pic  9(09).

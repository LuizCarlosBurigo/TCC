      *>=====================================================================
      *>Gerado em   : 27/02/1990
      *>========================== Informações ==============================
      *>FD          : CSBHF006.CPY
      *>Select      : CSBHS006.CPY
      *>CSBHL       : CSBHL006.CPY
      *>Nome Físico : CSBHD006.CAD
      *>Area Negocio: "Deposito"
      *>Descricao   : "Fornecedor"
      *>
      *>        SELECT CSBHD002 Assign to disk wid-csbh006
      *>               organization    is indexed
      *>               access mode     is dynamic
      *>               record key      is fdfnc-chave-1
      *>
      *>=====================================================================

       FD  CSBHD006.

      *>=====================================================================
      *>Nome Lógico : fornecedor
      *>Área Negócio: Deposito
      *>GerarIndex  : sim
      *>=====================================================================
       01  fdfnc-fornecedor.
           03 fdfnc-chave-1.
              05 fdfnc-cd-fornecedor              pic  9(09).
              05 fdfnc-cd-cidade                  pic  9(09).
                 *>FK: feisd-cd-cidade
           03 fdfnc-ds-fornecedor                 pic  x(80).
           03 fdfnc-endereco                      pic  x(80).
           03 fdfnc-numero                        pic  9(09).
           03 fdfnc-bairro                        pic  x(80).
           03 fdfnc-cep                           pic  x(09).
           03 fdfnc-cnpj                          pic  x(14).
           03 fdfnc-email                         pic  x(80).
           03 fdfnc-telefone    occurs 4 times.
              05 fdfnc-ddd                        pic  9(03).
              05 fdfnc-numero-telefone            pic  9(09).

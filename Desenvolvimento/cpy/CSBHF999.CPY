      *>=====================================================================
      *>Gerado em   : 07/03/2021
      *>========================== Informações ==============================
      *>FD          : CSBHF999.CPY
      *>Select      : CSBHS999.CPY
      *>CSBHL       : CSBHL999.CPY
      *>Nome Físico : CSBHD999.CAD
      *>Area Negocio: "Integração"
      *>Descricao   : "Dump Extração"
      *>
      *>        SELECT CSBHD999 Assign to disk wid-csbh999
      *>               status  is ws-resultado-acesso
      *>               organization is line sequential.
      *>
      *>=====================================================================

       FD CSBHD999.

      *>=====================================================================
      *>Nome Lógico : Extração
      *>Área Negócio: Integração
      *>GerarIndex  : sim
      *>=====================================================================
      01 fiitg-dados.
         03 fiitg-entrada-dados                    pic x(17000) value spaces.

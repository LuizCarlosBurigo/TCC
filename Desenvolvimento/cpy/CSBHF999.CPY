      *>=====================================================================
      *>Gerado em   : 07/03/2021
      *>========================== Informa��es ==============================
      *>FD          : CSBHF999.CPY
      *>Select      : CSBHS999.CPY
      *>CSBHL       : CSBHL999.CPY
      *>Nome F�sico : CSBHD999.CAD
      *>Area Negocio: "Integra��o"
      *>Descricao   : "Dump Extra��o"
      *>
      *>        SELECT CSBHD999 Assign to disk wid-csbh999
      *>               status  is ws-resultado-acesso
      *>               organization is line sequential.
      *>
      *>=====================================================================

       FD CSBHD999.

      *>=====================================================================
      *>Nome L�gico : Extra��o
      *>�rea Neg�cio: Integra��o
      *>GerarIndex  : sim
      *>=====================================================================
      01 fiitg-dados.
         03 fiitg-entrada-dados                    pic x(17000) value spaces.

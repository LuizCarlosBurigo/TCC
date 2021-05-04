
       IDENTIFICATION DIVISION.
       PROGRAM-ID. CSBH0001F.
      *>=====================================================================
       ENVIRONMENT DIVISION.
       configuration section.
      *>=====================================================================
       INPUT-OUTPUT Section.
       File-Control.

      *>=====================================================================
       DATA DIVISION.
       FILE SECTION.

      *>=====================================================================
       WORKING-STORAGE SECTION.

       78  versao                                  value "a".



      *>=====================================================================
       COPY CSBHW0001.

      *>=====================================================================
       LINKAGE SECTION.
       COPY CSBHW0002.

      *>=====================================================================
       PROCEDURE DIVISION USING linkage-parametros.
       MAIN-PROCEDURE.
      *>=====================================================================
       0000-controle section.
       0000.
           move spaces                              to lnk-dtbLog
                                                       lnk-dtbPath
                                                       lnk-id-erro
                                                       lnk-extractionPath

           move zeroes                              to lnk-cd-empresa
                                                       lnk-cd-filial

           move "C:\Users\luiz.carlos\Desktop\Estudo\TCC\Dados\BaseDados_CSBH_01"  to lnk-dtbPath

           move "C:\Users\luiz.carlos\Desktop\Estudo\TCC\Dados\Interno\log\"       to lnk-dtbLog
           move "C:\Users\luiz.carlos\Desktop\Estudo\TCC\Dados\Extracao"           to lnk-extractionPath
           move 001                                                                to lnk-cd-empresa
           move 0020                                                               to lnk-cd-filial
           .
       0000-saida.
       exit program
       STOP RUN.
      *>=====================================================================
      *> Procedure padrão
      *>=====================================================================
      *> Leitura/acesso
       COPY CSBHP001.


       IDENTIFICATION DIVISION.
       PROGRAM-ID. CSBH01001E.
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
       01  ws-tamanho-registro  pic 9(18).


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
            perform 9000-csbsp001-carga-inicial
           .
       0000-saida.
       exit program
       STOP RUN.
      *>=====================================================================
      *> Procedure padrão
      COPY CSBHP001.
      *>=====================================================================
      *> Leitura/acessoE.

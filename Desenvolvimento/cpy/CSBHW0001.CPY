
*>
       78  c001-copy-id                             value "CSBHW0001".
       78  carga-linkage                            value "CSBH0001F".
       01  ws001-campos-trabalho.
           03 ws-status-acesso.
              05 ws-status               pic x(7)   value spaces.
              05 ws-r-status             redefines
                 ws-status.
                 07 ws-byte-1-status     pic x(1).
                 07 ws-byte-2-status     pic x(1).
                 07 ws-byte-3-status     pic 9(3).
              05 ws-rr-status            redefines
                 ws-status.
                 07 ws-bit-1             pic 9(2).
                 07 ws-bit-2             pic 9(2).
                 07 filler               pic x(3).
              05 ws-rrr-status           redefines
                 ws-status.
                 07 ws-bit-1-1           pic 9(2).
                 07 filler               pic x(3).
           03 ws-este-programa           pic x(12).
           03 whs-mensagem               pic x(250) value spaces.
              88 processamento-sem-erro             value spaces.
           03 ws-ds-tracelog             pic x(400) value spaces.
           03 ws-id-opcao                pic 9(02)  value zeroes.
           03 ws-registro-estracao       pic x(17000) value spaces.

           03 ws-resultado-acesso        pic x(2).
              88 ws-acesso-invalido          value "47", "48","49".
              88 ws-operacao-ok                     value "00" "02".
              88 ws-eof-arquivo                     value "10".
              88 ws-registro-inexistente            value "23".
              88 ws-registro-existente              value "22".
              88 ws-arquivo-inexistente             value "35".
              88 ws-arquivo-locado                  value "9A".
              88 ws-registro-locado                 value "9D".
              88 ws-arquivo-corrompido            value x"3906",x"3929". *> 9006 = x"3906", 9041 = x"3929"

           03 ws-horas                   pic 9(8)   value 0.
           03 rs-hora-1                  redefines
              ws-horas.
              05 filler                  pic x(2).
              05 ws-min-seg-des          pic 9(6).
           03 rs-hora-2                  redefines
              ws-horas.
              05 ws-hora                 pic 9(2).
              05 ws-minutos              pic 9(2).
              05 ws-segundos             pic 9(2).
              05 filler                  pic x(2).
           03 rs-hora-3                  redefines
              ws-horas.
              05 filler                  pic x(2).
              05 ws-min-seg              pic 9(4).
              05 filler                  pic x(2).
           03 rs-hora-4                  redefines
              ws-horas.
              05 ws-hh-mm                pic 9(4).
              05 filler                  pic x(4).
           03 rs-hora-5                  redefines
              ws-horas.
              05 ws-hh-mm-ss             pic 9(6).
              05 filler                  pic x(2).

           03 ws-data-inv                pic 9(8)    value zeroes.
           03 ws-rdata-inv               redefines
              ws-data-inv.
              05 ws-ano-inv              pic 9(4).
              05 ws-mes-inv              pic 9(2).
              05 ws-dia-inv              pic 9(2).
           03 ws-data-6                  pic 9(6)    value zeroes.


           03 ws-check-file.
              05 ws-filename             pic x(255)  value spaces.
              05 ws-file-details.
                 07 ws-file-size         pic x(8)    value spaces.
                 07 ws-file-date.
                    10 ws-day            pic x       value spaces.
                    10 ws-month          pic x       value spaces.
                    10 ws-year           pic x(2)    value spaces.
                 07 ws-file-time.
                    10 ws-hours          pic x       value spaces.
                    10 ws-minutes        pic x       value spaces.
                    10 ws-seconds        pic x       value spaces.
                    10 ws-hundredths     pic x       value spaces.
           03 ws-cbl-status-code         pic 9(03)   value zeroes.
              88 ws-cbl-status                       value zeroes.

       01  ws-indices.
           03 ws-idx-001                 pic 9(09).
           03 ws-idx-002                 pic 9(09).
           03 ws-idx-002                 pic 9(09).
           03 ws-idx-002                 pic 9(09).
           03 ws-idx-002                 pic 9(09).
           03 ws-idx-002                 pic 9(09).
           03 ws-idx-002                 pic 9(09).
           03 ws-idx-002                 pic 9(09).

       01  ws001-wid-arquivos.
           03 wid-temporario             pic x(250) value spaces.
           03 wid-CSBH001                pic x(250) value spaces.
           03 wid-CSBH002                pic x(250) value spaces.
           03 wid-CSBH003                pic x(250) value spaces.
           03 wid-CSBH004                pic x(250) value spaces.
           03 wid-CSBH005                pic x(250) value spaces.
           03 wid-CSBH006                pic x(250) value spaces.
           03 wid-CSBH007                pic x(250) value spaces.
           03 wid-CSBH008                pic x(250) value spaces.
           03 wid-CSBH009                pic x(250) value spaces.
           03 wid-CSBH999                pic x(250) value spaces.

# fluxocaixa

1. Vamos precisar autorizar eu IP (o Banco de dados está na Azure SQL)
favor enviar o IP para gustavobdev@gmail.com ou no whats 13 996730299

2. use o endpoint /Lancamento para enviar o lançamento 

(payload) 
{
  "descricao": "string",
  "valor": 0,
  "tipo": 0,
  "data": "2024-08-01T13:30:36.867Z",
  "consolidado": 0
}

3. caso queria listar um intervalo recebendo os totais por período utilize o endpoint Lancamento/filtroPorData

Passe a data inicial e a final. Ele irá retornar as somatórias das categorias credito e débito tanto individuais como a média entre elas, além de uma lista com todos os lançamentos do período 

4. Para consolidar, envie a lista do intervalo no endpoint /Lancamento/Consolidado 

# TEST MASIVIAN

## Lista de Endpoints

#### Ruletas
 - ../api/Roulette/CreateRoulette - Crea una nueva ruleta y devulve el id de esta
 - ../api/Roulette/GetRoulettes - Obtiene todas las ruletas y respectivo estado.
 - ../api/Roulette/CloseRoulette/id - Cierra la ruleta y muestra el historial de apuestas.
 - ../api/Roulette/OpenRulette/id - Abre la ruleta del id especificado.
 #### Apuestas
 - ../api/Bet/AddBet - Realiza una enviando el siguiente JSON en body { "Id":0, "RouletteId":0, "Amount" : 500, "Color" : "Black", "Number" : 23, "BetDate" :null } y retorna un mensaje unformativo.
 - ../api/Bets/GetBets - Obtiene todas las apuestas realizadas.

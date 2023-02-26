# FoodGuard
First test/version for FoodGuard

## Obbiettivi

- Calendario
- inventario
- lista della spesa

## API

**GetFrigo()** - Return all of Frigo's content (Json format)

api innestato all'indirizzo : *http://168.119.117.67:8080/getFrigo*
- input: *niente*
- outuput: *file Frigo.db, database*

**UploadToFrigo(Obj)** - Upload Object to Frigo

api innestato all'indirizzo : *http://168.119.117.67:8080/UploadToFrigo?id=ID&name=%22NAME%22&buy=BUY&exp=EXP*
- input: 
1) **ID** int, id del'oggetto
2) **NAME** string, nome dell'oggetto
3) **BUY** int, data di acquisto
4) **EXP** int, data di scadenza
- output: *true* o *false* in base al sucesso dell'operazione

**RemoveFromFrigo()** - Remove from Frigo

api innestato all'indirizzo : *http://168.119.117.67:8080/RemoveFromFrigo?id=ID*
- input:
1) **ID** int, id dell'oggetto
- output: *true* o *false* in base al sucesso dell'operazione

## Org

*Client* - C# app

*Server* - Nodejs app, supports the API

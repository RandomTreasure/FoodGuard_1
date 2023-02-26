// Librerie (come classi)
const http = require("http");  //gestisce le richieste http e tutto quello che riguarda i messaggi
const fs = require("fs");   //gestisce i file di sistema
const url = require("url");  //gestisce i parametri url
const sqlite3 = require('sqlite3').verbose();
// --- Lib

// Variabili 
const port = 8080;
const databasePath = './database/Frigo.db';
// --- Var


var server = http.createServer(function(req, res){

    //ovviamente la data è a sua volta un oggetto (va inizializzato a ogni richiesta che senno rimane la data di inizio del server)
    var date = new Date();
    //prendo il path di richiesta e il query GET, in pratica sono delle variabili passate quando si fa una richiesta. utile per gestire gli api.
    var path = url.parse(req.url, true).pathname; //api obsoleto andrebbe cambiato ma non ho voglia
    var query = url.parse(req.url, true).query;

    //scrivo su terminale data, ip di chi fa' la richiesta e in che modo (GET o POST)
    console.log(date.toString(), "  ", req.socket.remoteAddress, "  ", req.method);
    console.log(path, " - ", query);

    //faccio uno switch per vedere che api è richiesto
    switch(path) {
        case "/":
            //se nulla è richiesto invio indietro una pagina web
            fs.readFile("index.html", function(err, data){
            sendData(res, data,{"Content-Type" : "text/html"});
            }); break;
        case "/getFrigo":
            //risponde con il file Frigo.db alla richiesta di getFrigo. In pratica rimanda indietro l'intero database (comodo in piccole dimensioni)
            fs.readFile(databasePath, function(err, data){
                sendData(res, data,{"Content-Type" : "text/html"});
            }); break;
        case "/UploadToFrigo":
            //aggiorna il database con la query e risponde true o false se ha avuto sucesso o no
            //controllo anche se i parametri sono presenti o no
            if ((typeof query.id !== 'undefined') && (typeof query.name !== 'undefined') && (typeof query.buy !== 'undefined') && (typeof query.exp !== 'undefined')) {
                UploadToFrigo(res, query); 
            } else { 
                console.log("error in upload parameters");
                sendData(res, "false", {"Content-Type": "text/plain"});
            }
            //sendData(res, "UploadToFrigo API", {"Content-Type" : "text/html"});
            break;
        case "/RemoveFromFrigo":
            //aggiorna il database rimuovendo l'oggetto designato dalla query e risponde true o false se ha avuto sucesso o no
            RemoveFromFrigo(res, query);
            //sendData(res, "RemoveFromFrigo API", {"Content-Type" : "text/html"});
            break;            
        case "/getJson":
            getJson(res, query);
    }
}).listen(port);
console.log("Starting server at port: ", port);

// FUNZIONI -----
// separo in varie funzioni le azioni, dovrebbe migliorare la leggibilità e la comprensione del codice

//Invio dati semplificato
function sendData(res, data, head) {
    res.writeHead(200, head);
    res.end(data);
}

//Carico dati sul database
function UploadToFrigo(res, query) {
    
    //Mi conetto al database. 
    let db = new sqlite3.Database(databasePath , (err) => {
        if (err) { console.error(err.message); } 
        else {console.log("Connected to database: ", databasePath);};
    });

    //Formatto una striga che funzionerà da query per sql. Prendo i valori da caricare dalla query url.
    //eg:   http://http://168.119.117.67:8080/UploadToFrigo?id=1121&name=%22stuff%22&buy=23&exp=44
    //carichera un oggetto con id = 1121, name= stuff, buy= 23 e exp = 44
    //il tutto manderà un messaggio con true se è riuscito nell'azione.
    let sql = "INSERT INTO Frigo (id, name, buy, exp) VALUES (" + query.id + "," + query.name + "," + query.buy + "," + query.exp + ");";
    db.run(sql, [], (err) => {
        if (err) { 
            sendData(res, "false", {"Content-Type": "text/plain"});
            throw err ;
        } else {
            //ATTENZIONE, manderà un messaggio positivo anche se non esisteva un oggetto con quel id
            console.log("Data Uploaded Sucessfully");
            sendData(res, "true", {"Content-Type": "text/plain"});
        }
    });

    //chiudo il database
    db.close();
    console.log("database cosed");
}

//Rimuovo un oggetto dal database con un particolare id
function RemoveFromFrigo(res, query) {
    
    //Mi conetto al database. 
    let db = new sqlite3.Database(databasePath , (err) => {
        if (err) { console.error(err.message); } 
        else {console.log("Connected to database: ", databasePath);};
    });

    //Formatto una striga che funzionerà da query per sql. Prendo i valori da caricare dalla query url.
    //eg:   http://http://168.119.117.67:8080/RemoveFromFrigo?id=1121
    //rimuovo l'oggetto (o tutti gli ogetti) con id=1121
    //il tutto manderà un messaggio con true se è riuscito nell'azione.
    let sql = "DELETE FROM Frigo WHERE id=" + query.id + ";"
    db.run(sql, [], (err) => {
        if (err) { 
            sendData(res, "false", {"Content-Type": "text/plain"});
            throw err ;
        } else {
            console.log("Data Removed Sucessfully");
            sendData(res, "true", {"Content-Type": "text/plain"});
        }
    });

    db.close();
    console.log("database closed");
}

function getJson(res, query) {
    let db = new sqlite3.Database(databasePath , (err) => {
        if (err) { console.error(err.message); }
        else {console.log("Connected to database: ", databasePath);}
    });


    let sql = "SELECT * FROM Frigo;";
    db.all(sql, [], (err, rows) => {
        if (err) {
            sendData(res, "false", {"Content-Type": "text/plain"});
            throw err;
        } else {
            console.log("Data Send Sucesfully");
            sendData(res, JSON.stringify(rows), {"Content-Type": "application/json"});
        };
    });
}

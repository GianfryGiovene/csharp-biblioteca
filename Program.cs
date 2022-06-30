﻿/*
Si vuole progettare un sistema per la gestione di una biblioteca. 
Gli utenti si possono registrare al sistema, fornendo:
cognome,
nome,
email,
password,
recapito telefonico,
Gli utenti registrati possono effettuare dei prestiti sui documenti che sono di vario tipo 
(libri, DVD). I documenti sono caratterizzati da:
un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
titolo,
anno,
settore (storia, matematica, economia, …),
stato (In Prestito, Disponibile),
uno scaffale in cui è posizionato,
un autore (Nome, Cognome).
Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.
L’utente deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, 
effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un utente.

ULTRA BONUS
una serie di istanze per "popolare" il nostro "fake db"
 2 o 3 utenti -> registrati
 2 o 3 libri --> tutti disponibili
 Gli utenti si possono registrare specificando i dati ...


 Biblioteca online
 1. registrati
 2. login

login 
 email: ..
 passowrd: ..

 Biblioteca online
 1. Cerca libri
 2. Cerca dvd

 Registrazione
 Scrivmi il nome: 
 scrivimi il cognome.. etc
 scrivi la passowrd: 

 Menu libro (titolo)
 1. visualizza dettagli libro
 2. richiedi prestito
 3. restitutisci


 tutti i menu hanno esci o torna indietro


*/
using csharp_biblioteca;





List<Loan> loans = new List<Loan>();
List<RegisteredUser> registeredUsers = new List<RegisteredUser>();
List<Document> documents = new List<Document>();

RegisteredUser user = new RegisteredUser("Pippo", "Lacco", "pippo@libero.it", "password123", "3271259845");

documents.Add( new Book(12345, 235, "Cacciatore di acquiloni", 2008, "Romance", "Pipino il Breve"));
documents.Add(new Book(87484, 235, "Vola farfalla", 1999, "Scienze", "Edward Alan Poe"));
documents.Add(new Dvd(12584, 126, "Cacciatore di acquiloni", 2008, "Romance", "Pipino il Breve"));

registeredUsers.Add(new RegisteredUser("Prencipe", "Carlo", "pippo@libero.it", "password123", "3271259845"));


foreach(Document document in documents)
{
    Console.WriteLine(document.ReadInformation());
}


// ricerca per titolo

void SearchByTitleLibrary() 
{

    string wordSearched = user.SearchByTitle();
    foreach(Document document in documents)
    {
        if (wordSearched == document.title)
        { 
            Console.WriteLine(document.ReadInformation());
        }
    }
    
}


SearchByTitleLibrary();
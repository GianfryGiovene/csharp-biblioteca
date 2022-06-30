/*
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

Book book = new Book("Cacciatore di acquiloni", 2008, "Romance", "Pipino il Breve");
Dvd dvd = new Dvd("Vola farfalla", 1999, "Scienze", "Edward Alan Poe");

documents.Add( new Book(12345, 235, "Cacciatore di acquiloni", 2008, "Romance", "Pipino il Breve"));
documents.Add(new Book(87484, 235, "Vola farfalla", 1999, "Scienze", "Edward Alan Poe"));
documents.Add(new Dvd(12584, 126, "Cacciatore di acquiloni", 2008, "Romance", "Pipino il Breve"));
documents[0].isAvailable = true;
documents[1].isAvailable = false;
documents[2].isAvailable = true;
registeredUsers.Add(new RegisteredUser("Prencipe", "Carlo", "pippo@libero.it", "password123", "3271259845"));


// funzione ricerca  per titolo

Document SearchByTitleLibrary() 
{
    string wordSearched = user.SearchByTitle();
    foreach(Document document in documents)
    {
        if (wordSearched == document.title)
        { 
            Console.WriteLine(document.ReadInformation());
            return document;
        }
    }
    return null;
}



// funzione ricerca  per codice

Document SearchByCodeLibrary()
{
    int codeSearched = user.SearchByCode();

    foreach (Document document in documents)
    {
        
        if (document.GetType() == book.GetType())
        {
            Book libro = (Book)document;
            if (codeSearched == libro.bookIsbn)
            {
                Console.WriteLine(libro.ReadInformation());
                return libro;
            }
        }
        else
        {
            Dvd dvd = (Dvd)document;
            if (codeSearched == dvd.serialNumber)
            {
                Console.WriteLine(dvd.ReadInformation());
                return dvd;
            }
        }    
    }
    return null;
}


Console.Write("Vuoi cercare per 'titolo' o per 'codice'? ");

string typeOfResearch = Console.ReadLine();

if(typeOfResearch == "titolo")
{

    Document itemSearched = SearchByTitleLibrary();
    if (itemSearched.isAvailable)
    {

        Console.WriteLine("Prodotto disponibile vuoi prenderlo in prestito? y or n");
        string validator = Console.ReadLine();
        Console.Write(validator);
        if (validator == "y")
        {
            Console.Write("Entro?");
            Loan loan = new Loan(user, itemSearched);
            loan.LoanTime();
        }

    }
    else
    {
        Console.WriteLine("Non disponibile");
    }
   
}
else
{
    Document itemSearched = SearchByCodeLibrary();
    if (itemSearched.isAvailable)
    {

        Console.WriteLine("Prodotto disponibile vuoi prenderlo in prestito? y or n");
        char validator = char.Parse(Console.ReadLine());
        if (validator == 'y')
        {
            Console.Write("Entro?");
            Loan loan = new Loan(user, itemSearched);
            loan.LoanTime();

        }
    }
    else
    {

        Console.WriteLine("Non disponibile");

    }

}

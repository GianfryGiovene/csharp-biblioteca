/*
Si vuole progettare un sistema per la gestione di una biblioteca. 

Gli utenti 
si possono registrare al sistema, fornendo:
cognome,
nome,
email,
password,
recapito telefonico,


Gli utenti 
registrati possono effettuare  ricerca
    sui 
documenti che sono di vario tipo (libri, DVD).
I documenti sono caratterizzati da:
un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
titolo,
anno,
settore (storia, matematica, economia, …),
stato (In Prestito, Disponibile),
uno scaffale in cui è posizionato,
un autore (Nome, Cognome).

Per i libri
si ha in aggiunta il numero di pagine, entre per 
i dvd 
la durata.

L’utente
deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, 
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
List<Rent> rents = new List<Rent>();
List<Document> documents = new List<Document>();
List<User> users = new List<User>();


documents.Add(new Book(12345, 235, "Cacciatore di acquiloni", 2008, "Romance", "Pipino il Breve"));
documents.Add(new Book(87484, 235, "Vola farfalla", 1999, "Scienze", "Edward Alan Poe"));
documents.Add(new Dvd(12584, 126, "Cacciatore di acquiloni", 2008, "Romance", "Pipino il Breve"));
documents[0].IsAvailable = true;
documents[1].IsAvailable = false;
documents[2].IsAvailable = true;

Guest guest = new Guest();
users.Add(new User("Prencipe", "Carlo", "pippo@libero.it", "password123", "3271259845"));
Console.WriteLine("***** Menù Ospite *****\n\nCosa si vuole fare?\n1 - Registrarsi\n2 - Ricercare documenti\n3 - LogIn\n4 - Ricerca prestiti");
int validator = Int32.Parse(Console.ReadLine());

switch(validator)
{
    case 1:

        User user = guest.GuestRegistration();
        users.Add(user);
        break;

    case 2:
        
        Document document = SearchInDocuments(documents);

        break;
    case 3:

        User userLogged = LogIn(users);
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("Passare alla sezione Noleggio?\n1 - si\n2 - no");
        validator = Int32.Parse(Console.ReadLine());    

        if (validator == 1)
        {
            RentADocument(documents, userLogged);
        }
        break;
    case 4:
        findUserRents(rents);
        break;
}
// login

User LogIn(List<User> users)
{
    Console.Write("Inserire Username: ");
    string username = Console.ReadLine();  
    Console.Write("Inserire Password :");
    string password = Console.ReadLine();
    Console.Clear();
    foreach (User user in users)
    {
        if(user.Username == username && user.Password == password)
        {

            Console.WriteLine("*** Sei Loggato ***");
            return user;
        }
        else
        {

            Console.WriteLine("*** Nome o Password non validi ***");
            return null;

        }
    }
    return null;
}
//metodo ricerca prestiti per nome utente
void findUserRents(List<Rent> rents)
{
    Console.Write("Inserire nome persona che si vuole cercare: ");
    string nameInput = Console.ReadLine();
    Console.Write("Inserire cognome persona che si vuole cercare: ");
    string surnameInput = Console.ReadLine();

    foreach (Rent rent in rents)
    {
        if (nameInput == rent.User.Name && surnameInput == rent.User.Surname)
        {
            Console.Write("nome: {0}\ncognome: {1}\nemail: {2}\ntelephone: {3}\n\n ***** Informazioni documenti *****\n{4}\n", rent.User.Name, rent.User.Surname, rent.User.Email, rent.User.Telephone, rent.Document.SetInformation());
        }

    }

}
// metodi ricerca documenti

void RentADocument(List<Document> documents, User user)
{
    Console.WriteLine("**** Noleggio documenti ****\n");

    Document findDocument = SearchInDocuments(documents);

    if (findDocument.IsAvailable)
    {
        Console.WriteLine("\nDocumento disponibile, noleggiarlo?\n1 - si\n2 - no");
        int rentValidator = Int32.Parse(Console.ReadLine());
        if (rentValidator == 1)
        {
            findDocument.takenTo = DateTime.Today.ToShortDateString();

            Console.Write("Inizio prestito del documento: {0} ", findDocument.takenTo);
            
            Console.Write("Fine del prestito (gg/mm/aaaa): ");
            findDocument.returnDate = Console.ReadLine();
            Rent rent = new Rent(user, findDocument, findDocument.takenTo, findDocument.returnDate);
            rents.Add(rent);

        }
    }
}



Document SearchInDocuments(List<Document> documents)
{
    Document document;
    Console.Write("***** Ricerca documenti *****\n\nCome si vuole cercare il documento?\n1 - codice identificativo\n2 - nome del documento");
    int validator = Int32.Parse(Console.ReadLine());
    switch (validator)
    {
        case 2:

            string documentName = SearchByTitle();
            document = SearchByTitleLibrary(documentName);
            return document;

        case 1:

            int documentCode = SearchByCode();
            document = SearchByCodeLibrary(documentCode);
            return document;

    }
    return null;
}


    // salva titolo
string SearchByTitle()
{
    Console.Write("\nInserire il titolo che si vuole cercare: ");
    string titoloCercato = Console.ReadLine();
    Console.Clear();
    return titoloCercato;
}   

    // salva codice

int SearchByCode()
{
    Console.Write("Cerca per codice: ");
    int codiceCercato = Int32.Parse(Console.ReadLine());
    Console.Clear();
    return codiceCercato;
}



Document SearchByTitleLibrary(string wordSearched)
{
    foreach (Document document in documents)
    {
        if (wordSearched == document.Title)
        {
            Console.WriteLine(document.SetInformation());
            return document;
        }
    }
    return null;
}


// funzione ricerca per codice

Document SearchByCodeLibrary(int codeSearched)
{
    foreach (Document document in documents)
    {
        
        if (document is Book)
        {
            Book libro = (Book)document;
            if (codeSearched == libro.bookIsbn)
            {
                Console.WriteLine(libro.SetInformation());
                return libro;
            }
        }
        else
        {
            Dvd dvd = (Dvd)document;
            if (codeSearched == dvd.serialNumber)
            {
                Console.WriteLine(dvd.SetInformation());
                return dvd;
            }
        }
        
    }
    return null;
}

// fine ricerca documenti


/************OLD ************

//vorrei creare una lista di prestiti (globale)
List <Loan> lendingsList = new List<Loan>();
List<RegisteredUser> registeredUsers = new List<RegisteredUser>();
List<Document> documents = new List<Document>();

RegisteredUser user = new RegisteredUser("Pippo", "Farabutto", "pippo@libero.it", "password123", "3271259845");


registeredUsers.Add(new RegisteredUser("Prencipe", "Carlo", "pippo@libero.it", "password123", "3271259845"));


// funzione ricerca  per titolo



//funzione trova persona e prestito
void findUserLoan(List<Loan> loansList)
{
    Console.Write("Inserire nome persona che si vuole cercare: ");
    string userInput = Console.ReadLine();

    foreach (Loan loan in loansList)
    {
        if (userInput == user.name)
        {
            Console.Write("nome: {0}\ncognome: {1}\nemail: {2}\ntelephone: {3}", user.name, user.surname, user.email, user.telephone);
        }

    }

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
            
            Loan loan = new Loan(user, itemSearched);
            loan.LoanTime();
            lendingsList.Add(loan);
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
            
            Loan loan = new Loan(user, itemSearched);
            loan.LoanTime();
            lendingsList.Add(loan);

        }
    }
    else
    {

        Console.WriteLine("Non disponibile");

    }

}

Console.WriteLine(documents[0].SetInformation());

findUserLoan(lendingsList);
************OLD ************/
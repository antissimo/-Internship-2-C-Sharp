using System;
using System.Collections.Generic;
using System.Text;
namespace PopisStanovnistva
{
    class Program
    {
        static void Main(string[] args)
        {
            




            var popis = new Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)>()
            {
                {"12345678911",("Ante Ivanic",new DateTime(2002,9,25))},
                {"22345678912",("Luka Madas",new DateTime(1973,1,8))},
                {"13323478911",("Ante Antic",new DateTime(1928,9,2))},
                {"42345686211",("Marin Modric",new DateTime(2014,12,15))},
                {"10145234511",("Miro Miric",new DateTime(2005,4,25))},
                {"42391023511",("Ante Culic",new DateTime(1982,5,8))},
                {"91294234511",("Ivan Perkovic",new DateTime(2000,4,25))},
                {"42301293849",("Luka Modric",new DateTime(1973,6,16))},
                {"98423517234",("Mateo Modric",new DateTime(1992,8,27))},


            };
            IspisMenia();
            var odabir = Console.ReadLine();
            while (odabir != "0") {
                switch (odabir)
                {
                    case "1":
                        Izbornik1(popis);
                        break;
                    case "2":
                        IspisPoOibu(popis);
                        break;
                    case "3":
                        IspisPoValueu(popis);
                        break;
                    case "4":
                        DodavanjeUPopis(popis);
                        break;
                    case "5":
                        BrisanjeOibon(popis);
                        break;
                    case "6":
                        BrisanjeImenomIPrezimenom(popis);
                        break;
                    case "7":
                        BrisanjeSvega(popis);
                        break;
                    case "8":
                        Izbornik8(popis);
                        break;
                    case "9":
                        Statistika(popis);
                        break;
                    default:
                        Console.WriteLine("Nepravilan unos");
                        break;

                }
                IspisMenia();
                odabir = Console.ReadLine();
            }
            
        }
        static void Statistika(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();
            Console.WriteLine("1 - Postotak nezaposlenih");
            Console.WriteLine("2 - Ispis najčešćeg imena i koliko ga stanovnika ima");
            Console.WriteLine("3 - Ispis najčešćeg prezimena i koliko ga stanovnika ima");
            Console.WriteLine("4 - Ispis datum na koji je rođen najveći broj ljudi i koji je to datum");
            Console.WriteLine("5 - Ispis broja ljudi rođenih u svakom od godišnjih doba ");
            Console.WriteLine("6 - Ispis najmlađeg stanovnika");
            Console.WriteLine("7 - Ispis najstarijeg stanovnika");
            Console.WriteLine("8 - Prosječan broj godina");
            Console.WriteLine("9 - Medijan godina");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            var izbornikStatistika = Console.ReadLine();
            

            switch (izbornikStatistika)
            {
                case "1":
                    PostotakNezaposlenih(dictionary);
                    break;
                case "2":
                    IspisNajcescegImena(dictionary);
                    break;
                case "3":
                    IspisNajcescegPrezimena(dictionary);
                    break;
                case "4":
                    IspisNajcescegDatuma(dictionary);
                    break;
                case "5":
                    GodisnjaDoba(dictionary);
                    break;
                case "6":
                    IspisNajmanjeg(dictionary);
                    break;
                case "7":
                    IspisNajstarijeg(dictionary);
                    break;
                case "8":
                    ProsjekGodina(dictionary);
                    break;
                case "9":
                    MedijanGodina(dictionary);
                    break;
                case "0":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Nepravilan unos");
                    break;




            }

        }
        static void MedijanGodina(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            List<int> a = new List<int>();
            foreach (var osoba in dictionary)
            {
                var godine = DateTime.Today.Year - osoba.Value.dateOfBirth.Year;
                a.Add(godine);
            }
            var temp = 0;
            var i = 0;
            int n=a.Count;
            var j = 0;
            var median = 0;
            for (i = 0; i < n - 1; i++)
            {
                for (j = 0; j < n - i - 1; j++)
                {
                    if (a[j] < a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                }
            }
            if (n % 2 == 0)
            {
                median =(a[(n / 2) - 1] + a[(n / 2)]) / 2;
            }
            else
            {
                median = a[(n / 2)];
            }
            Console.WriteLine(median);
        }
        static void ProsjekGodina(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();
            decimal zbrojGodina = 0;
            decimal brojac = 0;
            foreach (var osoba in dictionary)
            {
                var godine = DateTime.Today.Year - osoba.Value.dateOfBirth.Year;
                zbrojGodina += godine;
                brojac++;
            }
            decimal prosjek=decimal.Round(zbrojGodina / brojac, 2, MidpointRounding.AwayFromZero);
            Console.WriteLine("Prosjek godina je " + prosjek);
        }
        static void IspisNajstarijeg(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)

        {
            Console.Clear();
            var najmanja = 0;
            var najmladjaOib = "";
            var najmladjaImeIPrezime = "";
            var najmladjaDatum = new DateTime(2020, 8, 9);
            var mjesec = 0;
            var dan = 0;

            foreach (var osoba in dictionary)
            {
                var godine = DateTime.Today.Year - osoba.Value.dateOfBirth.Year;
                if (godine > najmanja)
                {
                    najmanja = godine;
                    najmladjaOib = osoba.Key;
                    najmladjaImeIPrezime = osoba.Value.nameAndSurname;
                    najmladjaDatum = osoba.Value.dateOfBirth;
                    mjesec = osoba.Value.dateOfBirth.Month;
                    mjesec = osoba.Value.dateOfBirth.Day;
                }
                if (godine == najmanja)
                {
                    if (osoba.Value.dateOfBirth.Month > mjesec)
                    {
                        najmanja = godine;
                        najmladjaOib = osoba.Key;
                        najmladjaImeIPrezime = osoba.Value.nameAndSurname;
                        najmladjaDatum = osoba.Value.dateOfBirth;
                        mjesec = osoba.Value.dateOfBirth.Month;
                        mjesec = osoba.Value.dateOfBirth.Day;
                    }
                    else if (osoba.Value.dateOfBirth.Month == mjesec)
                    {
                        if (osoba.Value.dateOfBirth.Day > dan)
                        {
                            najmanja = godine;
                            najmladjaOib = osoba.Key;
                            najmladjaImeIPrezime = osoba.Value.nameAndSurname;
                            najmladjaDatum = osoba.Value.dateOfBirth;
                            mjesec = osoba.Value.dateOfBirth.Month;
                            mjesec = osoba.Value.dateOfBirth.Day;
                        }
                    }
                }

            }
            Console.WriteLine($"Najstarija osoba je{najmladjaOib} {najmladjaImeIPrezime} {najmladjaDatum}");
        }
        static void IspisNajmanjeg(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            var najmanja = 999999;
            var najmladjaOib = "";
            var najmladjaImeIPrezime = "";
            var najmladjaDatum = new DateTime(2020,8,9);
            var mjesec = 13;
            var dan = 32;

            foreach(var osoba in dictionary)
            {
                var godine = DateTime.Today.Year - osoba.Value.dateOfBirth.Year;
                if (godine < najmanja)
                {
                    najmanja = godine;
                    najmladjaOib = osoba.Key;
                    najmladjaImeIPrezime = osoba.Value.nameAndSurname;
                    najmladjaDatum = osoba.Value.dateOfBirth;
                    mjesec = osoba.Value.dateOfBirth.Month;
                    mjesec = osoba.Value.dateOfBirth.Day;
                }
                if (godine==najmanja)
                {
                    if (osoba.Value.dateOfBirth.Month < mjesec) { 
                    najmanja = godine;
                    najmladjaOib = osoba.Key;
                    najmladjaImeIPrezime = osoba.Value.nameAndSurname;
                    najmladjaDatum = osoba.Value.dateOfBirth;
                    mjesec = osoba.Value.dateOfBirth.Month;
                    mjesec = osoba.Value.dateOfBirth.Day;
                    }else if (osoba.Value.dateOfBirth.Month == mjesec)
                    {
                        if (osoba.Value.dateOfBirth.Day < dan)
                        {
                            najmanja = godine;
                            najmladjaOib = osoba.Key;
                            najmladjaImeIPrezime = osoba.Value.nameAndSurname;
                            najmladjaDatum = osoba.Value.dateOfBirth;
                            mjesec = osoba.Value.dateOfBirth.Month;
                            mjesec = osoba.Value.dateOfBirth.Day;
                        }
                    }
                }
                
            }
            Console.WriteLine($"Najmladja osoba je {najmladjaOib} {najmladjaImeIPrezime} {najmladjaDatum}");
        }
        static void GodisnjaDoba(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            var ljeto = 0;
            var jesen = 0;
            var zima = 0;
            var proljece = 0;
            foreach (var osoba in dictionary)
            {
                var mjesec = osoba.Value.dateOfBirth.Month;
                var dan = osoba.Value.dateOfBirth.Day;
                switch (mjesec)
                {
                    case 1:
                        zima++;
                        break;
                    case 2:
                        zima++;
                        break;
                    case 3:
                        if (dan < 21) zima++;
                        else proljece++;
                        break;
                    case 4:
                        proljece++;
                        break;
                    case 5:
                        proljece++;
                        break;
                    case 6:
                        if (dan < 21) proljece++;
                        else ljeto++;
                        break;
                    case 7:
                        ljeto++;
                        break;
                    case 8:
                        ljeto++;
                        break;
                    case 9:
                        if (dan < 23) ljeto++;
                        else jesen++;
                        break;
                    case 10:
                        jesen++;
                        break;
                    case 11:
                        jesen++;
                        break;
                    case 12:
                        if (dan < 21) jesen++;
                        else zima++;
                        break;
                }
               
                


            }
            List<int> lista = new List<int>() { zima, ljeto, jesen, proljece };
            lista.Sort();
            if (zima == lista[0]) Console.WriteLine("U zimi je rodjeno " + lista[0] + " ljudi");
            else if (ljeto == lista[0]) Console.WriteLine("U ljeto je rodjeno " + lista[0] + " ljudi");
            else if (jesen == lista[0]) Console.WriteLine("U jesen je rodjeno " + lista[0] + " ljudi");
            else Console.WriteLine("U proljecu je rodjeno " + lista[0] + " ljudi");
            if (zima == lista[1] && zima!=lista[0]) Console.WriteLine("U zimi je rodjeno " + lista[1] + " ljudi");
            else if (ljeto == lista[1]) Console.WriteLine("U ljeto je rodjeno " + lista[1] + " ljudi");
            else if (jesen == lista[1]) Console.WriteLine("U jesen je rodjeno " + lista[1] + " ljudi");
            else Console.WriteLine("U proljecu je rodjeno " + lista[1] + " ljudi");
            if (zima == lista[2] && zima!=lista[1] && zima != lista[0]) Console.WriteLine("U zimi je rodjeno " + lista[2] + " ljudi");
            else if (ljeto == lista[2] && ljeto != lista[1]) Console.WriteLine("U ljeto je rodjeno " + lista[2] + " ljudi");
            else if (jesen == lista[2]) Console.WriteLine("U jesen je rodjeno " + lista[2] + " ljudi");
            else Console.WriteLine("U proljecu je rodjeno " + lista[2] + " ljudi");
            if (zima == lista[3] && zima != lista[2] && zima != lista[0] && zima != lista[1] ) Console.WriteLine("U zimi je rodjeno " + lista[3] + " ljudi");
            else if (ljeto == lista[3] && ljeto != lista[2] && ljeto != lista[1]) Console.WriteLine("U ljeto je rodjeno " + lista[3] + " ljudi");
            else if (jesen == lista[3] && jesen != lista[2]) Console.WriteLine("U jesen je rodjeno " + lista[3] + " ljudi");
            else Console.WriteLine("U proljecu je rodjeno " + lista[3] + " ljudi");
        }
        static void IspisNajcescegDatuma(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            List<int> brojPonavljanja = new List<int>();
            List<int> mjesecPonavljanja = new List<int>();
            List<int> danPonavljanja = new List<int>();

            foreach (var osoba in dictionary)
            {
                var mjesec = osoba.Value.dateOfBirth.Month;
                var dan=osoba.Value.dateOfBirth.Day;
                var temp = 0;
                for (var i = 0; i < mjesecPonavljanja.Count; i++)
                {
                    if (mjesecPonavljanja[i] == mjesec && danPonavljanja[i]==dan)
                    {
                        brojPonavljanja[i]++;
                        temp++;
                    }

                }
                if (temp == 0)
                {
                    danPonavljanja.Add(dan);
                    mjesecPonavljanja.Add(mjesec);
                    brojPonavljanja.Add(1);
                }

            }
            var najveci = 0;
            var najveciIndex = -1;
            for (var i = 0; i < brojPonavljanja.Count; i++)
            {
                if (brojPonavljanja[i] > najveci)
                {
                    najveci = brojPonavljanja[i];
                    najveciIndex = i;

                }

            }
            Console.WriteLine("Datum koji se najvise puta ponavlja je " + danPonavljanja[najveciIndex]+"/"+mjesecPonavljanja[najveciIndex] + " i ponavlja se " + brojPonavljanja[najveciIndex] + " puta");
        }
        static void IspisNajcescegPrezimena(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            List<int> brojPonavljanja = new List<int>();
            List<string> imenaPonavljanja = new List<string>();
            
            foreach (var osoba in dictionary)
            {
                var temp0 = 0;
                var ime = "";
                foreach (var slovo in osoba.Value.nameAndSurname)
                {
                    if (slovo.ToString() == " ")
                    {
                        temp0=1;
                    }
                    else if(temp0==1)ime += slovo;



                }
                var temp = 0;
                for (var i = 0; i < imenaPonavljanja.Count; i++)
                {
                    if (imenaPonavljanja[i] == ime)
                    {
                        brojPonavljanja[i]++;
                        temp++;
                    }

                }
                if (temp == 0)
                {
                    imenaPonavljanja.Add(ime);
                    brojPonavljanja.Add(1);
                }

            }
            var najveci = 0;
            var najveciIndex = -1;
            for (var i = 0; i < brojPonavljanja.Count; i++)
            {
                if (brojPonavljanja[i] > najveci)
                {
                    najveci = brojPonavljanja[i];
                    najveciIndex = i;

                }

            }
            Console.WriteLine("Prezime koje se najvise puta ponavlja je " + imenaPonavljanja[najveciIndex] + " i ponavlja se " + brojPonavljanja[najveciIndex] + " puta");
        }
        static void IspisNajcescegImena(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            List<int> brojPonavljanja = new List<int>();
            List<string> imenaPonavljanja = new List<string>();
            foreach(var osoba in dictionary)
            {
                var ime = "";
                foreach(var slovo in osoba.Value.nameAndSurname)
                {
                    if (slovo.ToString()==" ")
                    {
                        break;
                    }
                    ime += slovo;

                }
                var temp = 0;
                for (var i = 0; i < imenaPonavljanja.Count;i++)
                {
                    if (imenaPonavljanja[i] == ime)
                    {
                        brojPonavljanja[i]++;
                        temp++;
                    }

                }
                if (temp == 0)
                {
                    imenaPonavljanja.Add(ime);
                    brojPonavljanja.Add(1);
                }

            }
            var najveci = 0;
            var najveciIndex = -1;
            for (var i=0;i< brojPonavljanja.Count; i++)
            {
                if (brojPonavljanja[i] > najveci) {
                    najveci = brojPonavljanja[i];
                    najveciIndex = i;

                 }
                        
            }
            Console.WriteLine("Ime koje se najvise puta ponavlja je "+imenaPonavljanja[najveciIndex]+" i ponavlja se "+ brojPonavljanja[najveciIndex] + " puta");
        }
        static void PostotakNezaposlenih(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            double nezaposleniCounter = 0;
            double zaposleniCounter = 0;
            foreach(var osoba in dictionary) {

                var today = DateTime.Today;
                var age = today.Year - osoba.Value.dateOfBirth.Year;
                if (osoba.Value.dateOfBirth.Date > today.AddYears(-age)) age--;
                if (age < 23 || age > 65) nezaposleniCounter++;
                else zaposleniCounter++;
            }
            double postotak = 100*(nezaposleniCounter / (nezaposleniCounter + zaposleniCounter));
            Console.WriteLine(postotak+"% ljudi na popisu je nezaposleno");
        }
        static void Izbornik8(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.WriteLine("1 - Uredi OIB stanovnika");
            Console.WriteLine("2 - Uredi ime i prezime stanovnika");
            Console.WriteLine("3 - Uredi datum rođenja");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            var odabir8 = Console.ReadLine();
            Console.WriteLine("Unesite oib osobe koje zelite promijeniti");
            var oibZaMinjat = Console.ReadLine();
            switch (odabir8)
            {
                case "1":
                    Console.WriteLine("Unesite oib u koji zelite promijeniti");
                    var noviOib = Console.ReadLine();
                    if (noviOib.Length == 11)
                    {
                        foreach (var osoba in dictionary)
                        {
                            if (oibZaMinjat == osoba.Key)
                            {
                                dictionary.Add(noviOib, (osoba.Value.nameAndSurname, osoba.Value.dateOfBirth));
                                dictionary.Remove(oibZaMinjat);
                            }

                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Unesite ime i prezime u koji zelite promijeniti");
                    var novoImeIPrezime = Console.ReadLine();
                    if (novoImeIPrezime!="")
                    {
                        foreach (var osoba in dictionary)
                        {
                            if (oibZaMinjat == osoba.Key)
                            {
                                dictionary[oibZaMinjat] = (novoImeIPrezime, osoba.Value.dateOfBirth);
                            }

                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Unesite datum rodjenja u koji zelite promijeniti");
                    var noviDatumRodjenja = Console.ReadLine();
                    if (noviDatumRodjenja != "")
                    {
                        foreach (var osoba in dictionary)
                        {
                            if (oibZaMinjat == osoba.Key)
                            {
                                dictionary[oibZaMinjat] = (osoba.Value.nameAndSurname, DateTime.Parse(noviDatumRodjenja));
                            }

                        }
                    }
                    break;
                case "0":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Nepravilan unos");
                    break;



            }
        }
        static void BrisanjeSvega(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.WriteLine("Jeste li sigurni da zelite uciniti ovu promjenu(upisite 1 ako ste sigurni)");
            var provjera = int.Parse(Console.ReadLine());
            if (provjera == 1)
            {
                foreach (var osoba in dictionary)
                {
                    dictionary.Remove(osoba.Key);

                }
            }
            else return;
            
        }

        static void BrisanjeImenomIPrezimenom(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.WriteLine("Upisite ime i prezime osobe koju zelite izbrisati");
            var imeIPrezimeZaBrisat = Console.ReadLine();
            Console.WriteLine("Upisite datum rodjenja osobe koju zelite izbrisati");
            var  datumRodjenjaZaBrisat = Console.ReadLine();
            Console.WriteLine("Jeste li sigurni da zelite uciniti ovu promjenu(upisite 1 ako ste sigurni)");
            var provjera = int.Parse(Console.ReadLine());
            if (provjera == 1)
            {
                var temp = 0;
                foreach (var osoba in dictionary)
                {
                    if (osoba.Value.nameAndSurname == imeIPrezimeZaBrisat && osoba.Value.dateOfBirth == DateTime.Parse(datumRodjenjaZaBrisat))
                    {
                        temp++;
                    }
                }
                switch (temp)
                {
                    case 0:
                        Console.WriteLine("Ta osoba ne postoji");
                        break;
                    case 1:
                        foreach (var osoba in dictionary)
                        {
                            if (osoba.Value.nameAndSurname == imeIPrezimeZaBrisat && osoba.Value.dateOfBirth == DateTime.Parse(datumRodjenjaZaBrisat))
                            {
                                dictionary.Remove(osoba.Key);
                            }
                        }
                        return;
                    default:
                        BrisanjeOibon(dictionary);
                        break;

                }
            }
            else return;

              

        }
        static void BrisanjeOibon(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        
        {
            Console.Clear();
            Console.WriteLine("Upisite oib osobe koju zelite izbrisati");
            
            var oibZaBrisat = Console.ReadLine();
            Console.WriteLine("Jeste li sigurni da zelite uciniti ovu promjenu(upisite 1 ako ste sigurni)");
            var provjera = int.Parse(Console.ReadLine());
            if (provjera == 1)
            {
                foreach (var osoba in dictionary)
                {
                    if (osoba.Key == oibZaBrisat)
                    {
                        dictionary.Remove(oibZaBrisat);
                    }
                }
                Console.Clear();
                return;
            }
            else return;
            
        }
        static void DodavanjeUPopis(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();
            Console.WriteLine("Upisite oib osobe koje zelite unijeti");
            var noviOib = Console.ReadLine();
            Console.WriteLine("Upisite ime i prezime osobe koje zelite unijeti");
            var novoImeIPrezime = Console.ReadLine();
            Console.WriteLine("Upisite datum rodjenja  osobe koje zelite unijeti u formatu (godina,mjesec,dan)");
            var noviDatumRodjenja = DateTime.Parse(Console.ReadLine());

            if (noviOib.Length==11 && novoImeIPrezime!=" ")
                dictionary.Add(noviOib, (novoImeIPrezime, noviDatumRodjenja));
            else { 
                Console.WriteLine("Neispravan unos");
                
            }
            return;
        }

        static void IspisPoValueu(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();
            Console.WriteLine("Upisite ime i prezime pa u sljedecem redu datum rodjenja  koji zelite pretraziti");
            var imeIPrezimeZaPretrazit = Console.ReadLine();
            var datumRodjenjaZaPretrazit = Console.ReadLine();
            var temp = 0;
            foreach (var osoba in dictionary)
            {
                if (osoba.Value.nameAndSurname == imeIPrezimeZaPretrazit && osoba.Value.dateOfBirth == DateTime.Parse(datumRodjenjaZaPretrazit))
                {
                    Console.WriteLine(osoba.Key);
                    temp++;
                    

                }
            }
            if (temp == 0) { 
                Console.WriteLine("Ta osoba ne postoji u popisu");
            }
            return;
            
        }

        static void IspisPoOibu(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();
            Console.WriteLine("Upisite oib koji zelite pretraziti");
            var oibZaPretrazit=Console.ReadLine();
            foreach(var osoba in dictionary)
            {
                if (osoba.Key == oibZaPretrazit) {
                    Console.WriteLine(osoba.Value.nameAndSurname + " " + osoba.Value.dateOfBirth);
                    
                    return;

                }
            }
            Console.WriteLine("Taj oib ne postoji u popisu");
            return;
        }
        static void IspisMenia()
        {
            Console.WriteLine("Odaberite akciju");
            Console.WriteLine("1 - Ispis stanovništva");
            Console.WriteLine("2 - Ispis stanovnika po OIB - u");
            Console.WriteLine("3 - Ispis OIB - a po unosu imena i prezimena te datuma rođenja");
            Console.WriteLine("4 - Unos novog stanovnika");
            Console.WriteLine("5 - Brisanje stanovnika unosom OIB - a");
            Console.WriteLine("6 - Birsanje stanovnika po imenu i prezimenu te datumu rođenja");
            Console.WriteLine("7 - Brisanje svih stanovnika");
            Console.WriteLine("8 - Uređivanje stanovnika");
            Console.WriteLine("9 - Statistika");
            Console.WriteLine("0 - Izlaz iz aplikacije");
        }
        static void IspisStanovnikaKakoSuSpremljeni(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)


        {
            Console.Clear();
            foreach (var osoba in dictionary)
            {
                Console.WriteLine(osoba.Key + " "+ osoba.Value.nameAndSurname+ " "+ osoba.Value.dateOfBirth);
            }
        }

        static void IspisStanovnikaPoDatumuUzlazno(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();

            var sortedDict = from entry in dictionary orderby entry.Value.dateOfBirth.Year ascending select entry;
            foreach(var entry in sortedDict)
            {
                Console.WriteLine(entry.Key+" "+entry.Value.nameAndSurname+" "+ entry.Value.dateOfBirth);
            }
        }
        static void IspisStanovnikaPoDatumuSilazno(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();

            var sortedDict = from entry in dictionary orderby entry.Value.dateOfBirth.Year descending select entry;
            foreach (var entry in sortedDict)
            {
                Console.WriteLine(entry.Key + " " + entry.Value.nameAndSurname + " " + entry.Value.dateOfBirth);
            }
        }
        static void Izbornik1(Dictionary<string, (string nameAndSurname, DateTime dateOfBirth)> dictionary)
        {
            Console.Clear();
            Console.WriteLine("Odaberite kako ih zelite ispisati");
            Console.WriteLine("1 - Onako kako su spremljeni");
            Console.WriteLine("2 - Po datumu rođenja uzlazno");
            Console.WriteLine("3 - Po datumu rođenja silazno");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            var odabirMeni1 = Console.ReadLine();
            switch (odabirMeni1)
            {
                case "1":
                    IspisStanovnikaKakoSuSpremljeni(dictionary);
                    break;
                case "2":
                    IspisStanovnikaPoDatumuUzlazno(dictionary);
                    break;
                case "3":
                    IspisStanovnikaPoDatumuSilazno(dictionary);
                    break;
                case "0":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Nepravilan unos");
                    break;
            }
        }






    }
}
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class User
    {
        public string Username;
        public string Password;
        public string Mail;
        public string Id;
        public User(string username, string password, string mail, string id)
        {
            Username = username;
            Password = password;
            Mail = mail;
            Id = id;
        }
    }
    class Worker
    {
        public string Name;
        public string Surname;
        public string Cins;
        public string Yas;
        public string Tehsil;
        public string Is_Tecrubesi;
        public string Kateqoriya;
        public string Seher;
        public string Emek_Haqqi;
        public string Phone;
        public string Username;
        public Worker(string Username, string name, string surname, string cins, string yas, string tehsil, string is_Tecrubesi, string kateqoriya, string seher, string emek_Haqqi, string phone)
        {
            Name = name;
            Surname = surname;
            Cins = cins;
            Yas = yas;
            Tehsil = tehsil;
            Is_Tecrubesi = is_Tecrubesi;
            Kateqoriya = kateqoriya;
            Seher = seher;
            Emek_Haqqi = emek_Haqqi;
            Phone = phone;
            this.Username = Username;
        }
    }
    class Muraciet
    {
        public string worker_Username_;
        public string Elan_adi;
        public string employer_Username;
        public Muraciet(string worker_Username_, string elan_adi, string employer_Username)
        {
            this.worker_Username_ = worker_Username_;
            Elan_adi = elan_adi;
            this.employer_Username = employer_Username;
        }
    }
    class Employer
    {
        public string Is_Elani;
        public string Sirketin_adi;
        public string Kateqoriya;
        public string Is_Melumat;
        public string Seher;
        public string Maas;
        public string Yas;
        public string Tehsil;
        public string Is_Tecrubesi;
        public string Phone;
        public string Username;
        public Employer(string USername, string is_Elani, string sirketin_adi, string kateqoriya, string is_Melumat, string seher, string maas, string yas, string tehsil, string is_Tecrubesi, string phone)
        {
            Is_Elani = is_Elani;
            Sirketin_adi = sirketin_adi;
            Kateqoriya = kateqoriya;
            Is_Melumat = is_Melumat;
            Seher = seher;
            Maas = maas;
            Yas = yas;
            Tehsil = tehsil;
            Is_Tecrubesi = is_Tecrubesi;
            Phone = phone;
            Username = USername;
        }

    }
    class Program
    {
        static List<User> Users = new List<User>();
        static List<Worker> Workers = new List<Worker>();
        static List<Employer> Employers = new List<Employer>();
        static List<Muraciet> Muraciyet_ = new List<Muraciet>();
        static string Username_;
        static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            if (File.Exists("Users.json"))
            {
                string jsonUsers = File.ReadAllText("Users.json");
                Users = JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            }
            if (File.Exists("Workers.json"))
            {
                string jsonWorkers = File.ReadAllText("Workers.json");
                Workers = JsonConvert.DeserializeObject<List<Worker>>(jsonWorkers);
            }
            if (File.Exists("Employers.json"))
            {
                string jsonEmployers = File.ReadAllText("Employers.json");
                Employers = JsonConvert.DeserializeObject<List<Employer>>(jsonEmployers);
            }
            if (File.Exists("Muraciyet_s.json"))
            {
                string jsonMuraciyet_ = File.ReadAllText("Muraciyet_.json");
                Muraciyet_ = JsonConvert.DeserializeObject<List<Muraciet>>(jsonMuraciyet_);
            }


            while (true)
            {
                string Input;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Qeydiyyat->1  Daxil ol->2");
                    Input = (Console.ReadLine());
                    Console.Clear();
                } while (Control_Empty(Input));
                switch (Input)
                {
                    case "1":
                        logger.Info("Qeydiyyat");
                        Sing_In();
                        string json = JsonConvert.SerializeObject(Users);
                        System.IO.File.WriteAllText("Users.json", json);
                        Console.WriteLine("*******");
                        break;
                    case "2":
                        logger.Info("Daxil ol");
                        if (Sing_Up() == "1")
                        {
                            Console.Clear();
                            Worker();
                            continue;
                        }
                        if (Sing_Up() == "2")
                        {
                            Console.Clear();
                            Employer();
                            continue;
                        }
                        break;
                }
            }
        }
        static void Employer()
        {
            string inputt = "0";
            string input;
            while (inputt != "5")
            {
                Console.WriteLine(" Elan yerlesdirmek->1     Muracietler->2   Cixis->3");
                do
                {
                    inputt = Console.ReadLine();
                    Console.Clear();
                } while (Control_Empty(inputt));
                string Is_Elani = "";
                string Sirketin_adi = "";
                string Kateqoriya = "";
                string Is_Melumat = "";
                string Seher = "";
                string Maas = "";
                string Yas = "";
                string Tehsil = "";
                string Is_Tecrubesi = "";
                string Phone = "";
                switch (inputt)
                {
                    case "1":
                        logger.Info("Elan yerlesdirmek");
                        do
                        {
                            Console.WriteLine(" Elanin adini daxil edin");
                            Is_Elani = Console.ReadLine();
                        } while (Control_Empty(Is_Elani));
                        do
                        {
                            Console.WriteLine("Sirketin adini daxil edin");
                            Sirketin_adi = Console.ReadLine();
                        } while (Control_Empty(Sirketin_adi));

                        do
                        {
                            Console.WriteLine("Kateqoriya");
                            Console.WriteLine("Hekim->1  Jurnalist->2  IT mutexesis->3  Tercumeci->4");
                            input = Console.ReadLine();
                        } while (Control_Empty(input));
                        switch (input)
                        {
                            case "1":
                                Kateqoriya = "Hekim";
                                break;
                            case "2":
                                Kateqoriya = "Jurnalist";
                                break;
                            case "3":
                                Kateqoriya = "IT mutexesis";
                                break;
                            case "4":
                                Kateqoriya = "Tercumeci";
                                break;
                        }
                        do
                        {
                            Console.WriteLine("Is haqinda melumat daxil edin");
                            Is_Melumat = Console.ReadLine();
                        } while (Control_Empty(Is_Melumat));
                        do
                        {
                            Console.WriteLine(" Seher secin");
                            Console.WriteLine("Bak->1  Gence->2  Seki->3");
                            input = Console.ReadLine();


                        } while (Control_Empty(input));

                        switch (input)
                        {
                            case "1":
                                Seher = "Baki";

                                break;

                            case "2":
                                Seher = "Gence";

                                break;

                            case "3":
                                Seher = "Seki";

                                break;
                        }
                        do
                        {
                            Console.WriteLine("Emek haqqini daxil edin");
                            Maas = Console.ReadLine();
                        } while (Control_Empty(Maas));
                        do
                        {
                            Console.WriteLine("Yasi daxil edin");
                            Yas = Console.ReadLine();
                        } while (Control_Empty(Yas));
                        do
                        {
                            Console.WriteLine("Tehsili secin");
                            Console.WriteLine("Orta->1  Natamam ali->2  Ali->3  ");

                            input = Console.ReadLine();

                        } while (Control_Empty(input));
                        switch (input)
                        {
                            case "1":
                                Tehsil = "Orta";
                                break;
                            case "2":
                                Tehsil = "Natamam ali";
                                break;
                            case "3":
                                Tehsil = "Ali";
                                break;
                        }
                        do
                        {
                            Console.WriteLine("Is tecrubesi");
                            Console.WriteLine("1 ilden asagi->1  1 ilden-3ile qeder->2  3ilden-5ile qeder->3  5ilden daha cox->4");
                            input = Console.ReadLine();
                        } while (Control_Empty(input));
                        switch (input)
                        {
                            case "1":
                                Is_Tecrubesi = "1 ilden asagi";
                                break;
                            case "2":
                                Is_Tecrubesi = "1 ilden-3ile qeder";
                                break;
                            case "3":
                                Is_Tecrubesi = "3 ilden-5 ile qeder";
                                break;
                            case "4":
                                Is_Tecrubesi = "5 ilden daha cox";
                                break;
                        }
                        do
                        {

                            Console.WriteLine("Elaqe nomresi ");
                            Console.WriteLine("Numune->+994551234567");
                            Phone = Console.ReadLine();
                        } while (Control_Empty(Phone) == true || Control_Phone(Phone) == false);
                        Employers.Add(new Employer(Username_, Is_Elani, Sirketin_adi, Kateqoriya, Is_Melumat, Seher, Maas, Yas, Tehsil, Is_Tecrubesi, Phone));
                        break;
                    case "2":
                        logger.Info("Muraciyetler");
                        bool isEmpty = !Muraciyet_.Any();
                        if (isEmpty == true)

                        {
                            Console.WriteLine("Muraciyet tapilmadi");
                            logger.Error("Muraciyet tapilmadi");
                            break;
                        }
                        var t = Muraciyet_.FindAll(x => x.employer_Username == Username_).ToList();
                        foreach (var item_ in t)
                        {

                            Console.WriteLine($"Elanin adi->{item_.Elan_adi}");
                            Console.WriteLine("->>>>>>>>>>>>>>>>");
                            Console.WriteLine("Muraciyet eden isci");
                            var p = Workers.FindAll(x => x.Username == item_.worker_Username_).ToList();
                            foreach (var item in p)
                            {

                                Console.WriteLine($"Ad->{item.Name}");
                                Console.WriteLine($"Soyad={item.Surname}");
                                Console.WriteLine($"Cins->{item.Cins}");
                                Console.WriteLine($"Yas={item.Yas}");
                                Console.WriteLine($"Tehsil->{item.Tehsil}");
                                Console.WriteLine($"Is Tecrubesi={item.Is_Tecrubesi}");
                                Console.WriteLine($"Kateqoriya->{item.Kateqoriya}");
                                Console.WriteLine($"Seher={item.Seher}");
                                Console.WriteLine($"Emek haqqi->{item.Emek_Haqqi}");
                                Console.WriteLine($"Elaqe nomresi->{item.Phone}");
                                Console.WriteLine("*************************************");
                            }
                        }
                        break;
                    case "3":
                        logger.Info("Cixis");
                        Console.WriteLine("Cixis");
                        string json = JsonConvert.SerializeObject(Employers);
                        System.IO.File.WriteAllText("Employers.json", json);
                        break;
                }
            }
        }
        static void Worker()
        {
            string inputt = "0";
            while (inputt != "6")
            {
                string input = "";
                string Name = "";
                string Surname = "";
                string yas = "";
                string phone = "";
                string Minimum_emekhaqqi = "";
                string Cins_ = "";
                string Kateqoriya = "";
                string Tehsil = "";
                string Is_tecrubesi = "";
                string Seher = "";
                Console.WriteLine("Usenam_");
                Console.WriteLine(Username_);
                do
                {
                    Console.WriteLine("CV yerlesdir->1  EN uygun Elanlar->2  Axtaris->3  Melumat->4  Butun elanlari goster->5  Log out->6 ");
                    inputt = Console.ReadLine();
                    Console.Clear();
                } while (Control_Empty(inputt));
                switch (inputt)
                {
                    case "1":
                        logger.Info("CV yerlesdirmek");
                        bool CV = true;
                        foreach (var item in Workers)
                        {
                            Console.WriteLine("****");
                            if (item.Username == Username_)
                            {
                                logger.Error("Artiq CV var");
                                Console.WriteLine("Artiq  CV var");
                                CV = false;
                            }
                        }
                        if (CV == false) break;
                        do
                        {
                            Console.WriteLine("Ad daxil edin ");
                            Name = Console.ReadLine();
                        } while (Control_Empty(Name));
                        do
                        {
                            Console.WriteLine("Soyad daxil edin");
                            Surname = Console.ReadLine();
                        } while (Control_Empty(Surname));
                        do
                        {
                            Console.WriteLine(" Cins secin");
                            Console.WriteLine("Kisi->1  Qadin->2");
                            input = Console.ReadLine();
                            if (input == "1")
                            {
                                Cins_ = "Kisi";
                            }
                            if (input == "2")
                            {

                                Cins_ = "Qadin";
                            }
                        } while (Control_Empty(input));
                        do
                        {
                            Console.WriteLine("Yas daxil edin");
                            yas = Console.ReadLine();

                        } while (Control_Empty(yas));
                        do
                        {
                            Console.WriteLine(" Tehsil daxil edin");
                            Console.WriteLine("Orta->1  Natamam ali->2  Ali->3  ");
                            input = Console.ReadLine();
                        } while (Control_Empty(input));
                        switch (input)
                        {
                            case "1":
                                Tehsil = "Orta";
                                break;
                            case "2":
                                Tehsil = "Natamam ali";
                                break;
                            case "3":
                                Tehsil = "Ali";
                                break;
                        }
                        do
                        {
                            Console.WriteLine("Is tecrubesi");
                            Console.WriteLine("1 ilden asagi->1  1 ilden-3ile qeder->2  3ilden-5ile qeder->3  5ilden daha cox->4");
                            input = Console.ReadLine();
                        } while (Control_Empty(input));
                        switch (input)
                        {
                            case "1":
                                Is_tecrubesi = "1 ilden asagi";
                                break;
                            case "2":
                                Is_tecrubesi = "1 ilden-3ile qeder";
                                break;
                            case "3":
                                Is_tecrubesi = "3 ilden-5 ile qeder";
                                break;
                            case "4":
                                Is_tecrubesi = "5 ilden daha cox";
                                break;
                        }
                        do
                        {
                            Console.WriteLine("Kateqoriya");
                            Console.WriteLine("Hekim->1  Jurnalist->2  IT mutexesis->3  Tercumeci->4");
                            input = Console.ReadLine();
                        } while (Control_Empty(input));
                        switch (input)
                        {
                            case "1":
                                Kateqoriya = "Hekim";
                                break;
                            case "2":
                                Kateqoriya = "Jurnalist";
                                break;
                            case "3":
                                Kateqoriya = "IT mutexesis";
                                break;
                            case "4":
                                Kateqoriya = "Tercumeci";
                                break;
                        }
                        do
                        {
                            Console.WriteLine("Seher secin");
                            Console.WriteLine("Bak->1  Gence->2  Seki->3");
                            input = Console.ReadLine();
                        } while (Control_Empty(input));
                        switch (input)
                        {
                            case "1":
                                Seher = "Baki";
                                break;
                            case "2":
                                Seher = "Gence";
                                break;
                            case "3":
                                Seher = "Seki";
                                break;
                        }
                        do
                        {
                            Console.WriteLine("Minimum emek haqqi");
                            Minimum_emekhaqqi = Console.ReadLine();
                        } while (Control_Empty(Minimum_emekhaqqi));
                        do
                        {
                            Console.WriteLine("Elaqe nomresi");
                            Console.WriteLine("Numune->+994551234567");
                            phone = Console.ReadLine();
                        } while (Control_Empty(phone) == true || Control_Phone(phone) == false);
                        Workers.Add(new Worker(Username_, Name, Surname, Cins_, yas, Tehsil, Is_tecrubesi, Kateqoriya, Seher, Minimum_emekhaqqi, phone));
                        break;
                    case "2":
                        logger.Info("En uygun is elani");
                        bool isEmpty = !Employers.Any();
                        if (isEmpty == true)
                        {
                            Console.WriteLine("Is elani tapilmadi");
                            logger.Error("Is elani tapilmadi");
                            break;
                        }
                        var i = Workers.FindAll(x => x.Username == Username_).ToList();
                        isEmpty = !i.Any();
                        if (isEmpty == true)
                        {
                            Console.WriteLine(" CV daxil edin");
                            logger.Error("Cv daxil edin");
                            break;
                        }
                        var a = Workers.FindAll(x => x.Username == Username_).ToList();
                        int counter = 1;
                        foreach (var item in Employers)
                        {
                            foreach (var item_ in a)
                            {
                                if (item.Kateqoriya == item_.Kateqoriya || item.Maas == item_.Emek_Haqqi || item.Seher == item_.Seher || item.Tehsil == item_.Tehsil || item.Yas == item_.Yas)
                                {
                                    Console.WriteLine($"{counter}-> IS_elani->{item.Is_Elani}");
                                    counter++;
                                }
                            }
                        }
                        int b = 0;
                        counter = 0;
                        string Usernname = "";
                        Console.WriteLine(" Elan daxil edin");
                        int input_ = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in Employers)
                        {
                            if (b == input_ - 1)
                            {
                                Usernname = item.Username;
                                Console.WriteLine($"Is elani->{item.Is_Elani}");
                                Console.WriteLine($"Kateqoriya->{ item.Kateqoriya}");
                                Console.WriteLine($"Is_Melumat->{ item.Is_Melumat}");
                                Console.WriteLine($"Seher->{item.Seher}");
                                Console.WriteLine($"Maas->{item.Maas}");
                                Console.WriteLine($"Yas->{ item.Yas}");
                                Console.WriteLine($"Tehsil->{item.Tehsil}");
                                Console.WriteLine($"Is tecrubesi->{item.Is_Tecrubesi}");
                                Console.WriteLine($"Phone->{item.Phone}");
                                Console.WriteLine("*************************************");
                            }
                            b++;
                        }
                        b = 0;

                        Console.WriteLine("Secin y/n");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "y":
                                foreach (var item in Employers)
                                {
                                    if (b == input_ - 1)
                                    {
                                        Muraciyet_.Add(new Muraciet(Username_, item.Is_Elani, item.Username));
                                    }
                                    b++;
                                }
                                break;
                            case "n":
                                break;
                        }
                        break;
                    case "3":
                        logger.Info("Kateqoriyaya gore is elani");
                        isEmpty = !Employers.Any();
                        if (isEmpty == true)
                        {
                            Console.WriteLine("Is elani tapilmadi");
                            logger.Error("Is elani tapilmadi");
                            break;
                        }
                        i = Workers.FindAll(x => x.Username == Username_).ToList();

                        isEmpty = !i.Any();
                        if (isEmpty == true)
                        {
                            Console.WriteLine(" CV daxil edin");
                            logger.Error("CV daxil edin");
                            break;
                        }
                        string Seher_ = "";
                        Console.WriteLine("Baki->1  Gence->2  Seki->3");
                        Console.WriteLine(" Seher secin");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "1":
                                Seher_ = "Baki";
                                break;
                            case "2":
                                Seher_ = "Gence";
                                break;
                            case "3":
                                Seher_ = "Seki";
                                break;
                        }
                        b = 0;
                        counter = 1;
                        var t = Employers.FindAll(x => x.Seher == Seher_).ToList();
                        isEmpty = !t.Any();
                        if (isEmpty == true)
                        {
                            Console.WriteLine("Elan tapilmadi");
                            logger.Error("Elan tapilmadi");
                            break;
                        }
                        foreach (var item in t)
                        {
                            Console.WriteLine($"{counter}->  Elan adi->  {item.Is_Elani}");
                            counter++;
                        }
                        Console.WriteLine(" Elan secin");
                        input_ = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in Employers)
                        {
                            if (b == input_ - 1)
                            {
                                Console.WriteLine($"Is elani->{item.Is_Elani}");
                                Console.WriteLine($"Kateqoriya->{ item.Kateqoriya}");
                                Console.WriteLine($"Is_Melumat->{ item.Is_Melumat}");
                                Console.WriteLine($"Seher->{item.Seher}");
                                Console.WriteLine($"Maas->{item.Maas}");
                                Console.WriteLine($"Yas->{ item.Yas}");
                                Console.WriteLine($"Tehsil->{item.Tehsil}");
                                Console.WriteLine($"Is tecrubesi->{item.Is_Tecrubesi}");
                                Console.WriteLine($"Phone->{item.Phone}");
                                Console.WriteLine("****************************************");
                            }
                            b++;
                        }
                        b = 0;
                        Console.WriteLine("secin y/n");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "y":
                                foreach (var item in Employers)
                                {
                                    if (b == input_ - 1)
                                    {
                                        Muraciyet_.Add(new Muraciet(Username_, item.Is_Elani, item.Username));

                                    }
                                    b++;
                                }
                                break;
                            case "n":
                                break;

                        }
                        break;
                    case "4":
                        logger.Info("CV Melumatlari");
                        a = Workers.FindAll(x => x.Username == Username_).ToList();
                        foreach (var item in a)
                        {
                            Console.WriteLine($"Ad->{item.Name}");
                            Console.WriteLine($"Soyad={item.Surname}");
                            Console.WriteLine($"Cins->{item.Cins}");
                            Console.WriteLine($"Yas={item.Yas}");
                            Console.WriteLine($"Tehsil->{item.Tehsil}");
                            Console.WriteLine($"Is Tecrubesi={item.Is_Tecrubesi}");
                            Console.WriteLine($"Kateqoriya->{item.Kateqoriya}");
                            Console.WriteLine($"Seher={item.Seher}");
                            Console.WriteLine($"Emek haqqi->{item.Emek_Haqqi}");
                            Console.WriteLine($"Elaqe nomresi->{item.Phone}");
                            Console.WriteLine("**************************************");
                        }
                        break;
                    case "5":
                        isEmpty = !Employers.Any();
                        if (isEmpty == true)
                        {
                            Console.WriteLine("Is elani tapilmadi");
                            logger.Error("Elan Tapilmadi");
                            break;
                        }
                        b = 0;
                        counter = 0;
                        foreach (var item in Employers)
                        {
                            Console.WriteLine($"{counter}->  {item.Is_Elani}");
                            counter++;
                        }
                        Console.WriteLine(" Elan secin");
                        input_ = Convert.ToInt32(Console.ReadLine());
                        foreach (var item in Employers)
                        {
                            if (b == input_ - 1)
                            {
                                Console.WriteLine($"Is elani->{item.Is_Elani}");
                                Console.WriteLine($"Kateqoriya->{ item.Kateqoriya}");
                                Console.WriteLine($"Is_Melumat->{ item.Is_Melumat}");
                                Console.WriteLine($"Seher->{item.Seher}");
                                Console.WriteLine($"Maas->{item.Maas}");
                                Console.WriteLine($"Yas->{ item.Yas}");
                                Console.WriteLine($"Tehsil->{item.Tehsil}");
                                Console.WriteLine($"Is tecrubesi->{item.Is_Tecrubesi}");
                                Console.WriteLine($"Elaqe nomresi->{item.Phone}");
                                Console.WriteLine("***************************************");
                            }
                            b++;
                        }
                        b = 0;
                        i = Workers.FindAll(x => x.Username == Username_).ToList();
                        isEmpty = !i.Any();
                        if (isEmpty == true)
                        {
                            Console.WriteLine(" CV daxil edin");
                            logger.Error("CV daxil edin");
                            break;
                        }
                        Console.WriteLine("Secin y/n");
                        input = Console.ReadLine();
                        switch (input)
                        {
                            case "y":
                                foreach (var item in Employers)
                                {
                                    if (b == input_ - 1)
                                    {

                                        Muraciyet_.Add(new Muraciet(Username_, item.Is_Elani, item.Username));

                                    }
                                    b++;
                                }

                                break;
                            case "n":

                                break;
                        }

                        break;
                    case "6":
                        Console.WriteLine("Cixis");
                        logger.Info("Cixis");
                        string json = JsonConvert.SerializeObject(Workers);
                        System.IO.File.WriteAllText("Workers.json", json);
                        string json_ = JsonConvert.SerializeObject(Muraciyet_);
                        System.IO.File.WriteAllText("Muraciyet_.json", json_);
                        break;
                }
            }
        }
        static void Sing_In()
        {
            Random rand = new Random();
            string Input;
            string Password;
            string Mail;
            bool while_ = true;
            string charc;
            string q = "";
            do
            {
                Console.WriteLine("Worker->1  Employer->2");
                Input = Console.ReadLine();
                Console.Clear();
            } while (Control_Empty(Input));
            do
            {
                Console.WriteLine(" Username daxil edin");
                Username_ = Console.ReadLine();
                logger.Info("Username daxil edin");
            } while (Control_Empty(Username_) || Control_same_Username(Username_));
            do
            {
                while_ = false;
                Console.WriteLine(" Parol daxil edin");
                Password = Console.ReadLine();
                logger.Info("Parol daxil edin");
                if (Control_Empty(Password) == false & Control_Password(Password) == true)
                {
                    Console.WriteLine(" Parolu tekrarlayin");
                    logger.Info("Parolu tekrarlayin");

                    string new_Password = Console.ReadLine();
                    if (new_Password == Password & Control_Empty(new_Password) == false) while_ = true;
                }
            } while (while_ == false);
            do
            {
                Console.WriteLine(" Mail daxil edin");
                Mail = Console.ReadLine();
                logger.Info("Mail daxil edin");
            } while (Control_Empty(Mail) || Control_mail(Mail) == false || Control_same_Mail(Mail));
            do
            {
                q = null;

                string chars_ = "Aq0XsQ1E1dcC2De3Rf4g4Huy5Lop6Tt7m8pP9Byi";
                Random random = new Random();
                int[] arr = new int[4];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = rand.Next(0, chars_.Length - 1);
                    q += chars_[arr[i]];
                }
                Console.WriteLine(q);
                Console.WriteLine("Verilenleri daxil edin");
                logger.Info("Verilen simvollar daxil edin");
                charc = Console.ReadLine();
            } while (charc != q);
            Users.Add(new User(Username_, Password, Mail, Input));
        }
        static string Sing_Up()
        {
            string Password;

            do
            {
                Console.WriteLine(" Username daxil edin");
                logger.Info("Username daxil edin");
                Username_ = Console.ReadLine();
            } while (Control_Empty(Username_));
            do
            {
                Console.WriteLine("Parol daxil edin");
                logger.Info("Paro daxil edin");
                Password = Console.ReadLine();
            } while (Control_Empty(Password));
            foreach (var item in Users)
            {
                if (item.Username == Username_ & item.Password == Password & item.Id == "1" || item.Username == Username_ & item.Password == Password & item.Id == "2")
                {
                    Console.WriteLine(item.Id);
                    return item.Id;
                }
            }
            Console.Clear();
            Console.WriteLine("Istifadeci tapilmadi ");
            logger.Error("Istifadeci tapilmadi");

            return "0";
        }
        static bool Control_same_Username(string a)
        {
            foreach (var item in Users)
            {
                if (item.Username == a)
                {
                    Console.Clear();
                    Console.WriteLine("Artiq Username var");
                    logger.Error($"Artiq Username var->{a}");
                    return true;
                }
            }
            return false;
        }
        static bool Control_same_Mail(string a)
        {
            foreach (var item in Users)
            {
                if (item.Mail == a)
                {
                    Console.Clear();
                    Console.WriteLine($"Artiq Mail var{a}");
                    logger.Error("Atriq Mail var");
                    return true;
                }
            }
            return false;
        }
        static bool Control_Empty(string a)
        {

            if (string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a))
            {
                Console.WriteLine("Enter Empty");
                logger.Error("ENter empty");
                return true;
            }
            return false;
        }
        static bool Control_mail(string a)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(a, pattern);
        }
        static bool Control_Password(string a)
        {
            string Pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
            return Regex.IsMatch(a, Pattern);
        }
        static bool Control_Phone(string a)
        {
            string Pattern = @"^\+994(55|51|55|70|77)([0-9]){7}$";
            return Regex.IsMatch(a, Pattern);
        }
    }
}

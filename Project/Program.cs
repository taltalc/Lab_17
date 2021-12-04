using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Lab/Bank.json";

            if (!File.Exists(path))
            {
                File.Create(path);

            }
            BankAccount<int> bankAccount1 = new BankAccount <int> ("Петров", 1, 100);
           
            JsonSerializerOptions options1 = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            }; 
            string jsstring1 = JsonSerializer.Serialize(bankAccount1, options1);
            using (StreamWriter stream = new StreamWriter(path, false))
            {
                stream.WriteLine(jsstring1);
            }

            string line1 = "";
            StreamReader streamReader1 = new StreamReader(path, false);

            line1 = streamReader1.ReadToEnd();
            streamReader1.Close();
            BankAccount<int> bankAccount1print = JsonSerializer.Deserialize<BankAccount<int>>(line1);
            Console.WriteLine(line1);

            BankAccount<string> bankAccount2 = new BankAccount<string>("Иванов", "AD", 200);
            JsonSerializerOptions options2 = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsstring2 = JsonSerializer.Serialize(bankAccount2, options2);
            using (StreamWriter stream = new StreamWriter(path,false))
            {
                stream.WriteLine(jsstring2);
            }

            string line2 = "";
            StreamReader streamReader2 = new StreamReader(path, false);

            line2 = streamReader2.ReadToEnd();
            streamReader2.Close();
            BankAccount<string> bankAccount12print = JsonSerializer.Deserialize<BankAccount<string>>(line2);
            Console.WriteLine(line2);





            Console.ReadKey();
            
        }

    }
    class BankAccount<T>
    {
        public string Name { get; set; }
        public T Accountnumber { get; set; }
        public double Balance { get; set; }

        public BankAccount (string name, T accountnumber, double balance)
        {
            Name = name;
            T Accountnumber =  accountnumber;
            Balance = balance;
        }
            

          
            
    }

}

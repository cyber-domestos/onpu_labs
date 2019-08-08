using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    class Patient
    {
        private string name;
        private int accountNumber;
        private string typeOfWork;
        private int cost;
        private string paymentStamp;
        private int debt;

        public Patient()
        {
            
        }

        public Patient(string name, int accountNumber, string typeOfWork, int cost, string paymentStamp, int debt)
        {
            this.name = name;
            this.accountNumber = accountNumber;
            this.typeOfWork = typeOfWork;
            this.cost = cost;
            this.paymentStamp = paymentStamp;
            this.debt = debt;
        }

        public string Name { get => name; set => name = value; }
        public int AccountNumber { get => accountNumber; set => accountNumber = value; }
        public string TypeOfWork { get => typeOfWork; set => typeOfWork = value; }
        public int Cost { get => cost; set => cost = value; }
        public string PaymentStamp { get => paymentStamp; set => paymentStamp = value; }
        public int Debt { get => debt; set => debt = value; }

        public void Write(BinaryWriter bw)
        {
            bw.Write(Name);
            bw.Write(AccountNumber);
            bw.Write(TypeOfWork);
            bw.Write(Cost);
            bw.Write(PaymentStamp);
            bw.Write(Debt);

        }
        
        public static Patient Read(BinaryReader br)
        {
            Patient q = new Patient();
            q.Name = br.ReadString();
            q.AccountNumber = br.ReadInt32();
            q.TypeOfWork = br.ReadString();
            q.Cost = br.ReadInt32();
            q.PaymentStamp = br.ReadString();
            q.Debt = br.ReadInt32();
            return q;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BankTransaction.ML.Prediction.Category.Models
{
    [DataContract]
    public class TransactionData
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }

        [DataMember(Name = "information")]
        public string Information { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "creditDebitIndicator")]
        public string CreditDebitIndicator { get; set; }
    }
}

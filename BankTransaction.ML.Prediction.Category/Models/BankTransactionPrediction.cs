using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTransaction.ML.Prediction.Category.Models
{
    public class BankTransactionPrediction
    {
        [ColumnName("PredictedLabel")]
        public string Category;
    }
}

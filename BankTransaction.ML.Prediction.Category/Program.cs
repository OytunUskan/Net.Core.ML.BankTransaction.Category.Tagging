using BankTransaction.ML.Prediction.Category.Models;
using BankTransaction.ML.Prediction.Category.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankTransaction.ML.Prediction.Category
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Some manually chosen transactions with some modifications.
            Console.WriteLine("Loading training data...");
            List<TransactionData> trainingData = GetTrainingData();

            Console.WriteLine("Training the model...");
            var trainingService = new BankTransactionTrainingService();
            trainingService.Train(trainingData, "Model.zip");

            Console.WriteLine("Prepare transaction labeler...");
            var labelService = new BankTransactionLabelService();
            labelService.LoadModel("Model.zip");

            Console.WriteLine("Predict some transactions based on their description and type...");
            Console.WriteLine();

           //Starbucks : Coffee
            MakePrediction(labelService, "STARBUCKS", "Debit");
            //PRET A MANGER : Coffee
            MakePrediction(labelService, "MANGER", "Debit");
            //This case use training1.json
            MakePrediction(labelService, "SIMIT SARAYI", "Debit");
            


        }

        private static void MakePrediction(BankTransactionLabelService labelService, string information, string creditDebitIndicator)
        {
            string prediction = labelService.PredictCategory(new TransactionData
            {
                Information = information,
                CreditDebitIndicator = creditDebitIndicator
            });

            Console.WriteLine($"{information} ({creditDebitIndicator}) => {prediction}");
        }

        private static List<TransactionData> GetTrainingData()
        {
            return JsonConvert.DeserializeObject<List<TransactionData>>(File.ReadAllText("training.json"));
        }
    }
}

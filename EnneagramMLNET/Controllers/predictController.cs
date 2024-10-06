using EnneagramMLNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace EnneagramMLNet.Controllers
{
    public class predictController : Controller
    {
        [HttpGet]
        public IActionResult diabet()
        {
            return View();
        }


        [HttpPost]
        public IActionResult diabet(Patient patient)
        {
            MLModel.ModelInput sampleData = new MLModel.ModelInput()
            {
                Pregnancies = patient.Pregnancies,
                Glucose = patient.Glucose,
                BloodPressure = patient.BloodPressure,
                SkinThickness = patient.SkinThickness,
                Insulin = patient.Insulin,
                BMI = patient.BMI,
                DiabetesPedigreeFunction = patient.DiabetesPedigreeFunction,
                Age = patient.Age,
            };

            var sortedScoresWithLabel = MLModel.PredictAllLabels(sampleData);

            StringBuilder prediction = new();

            foreach (var score in sortedScoresWithLabel)
            {
                prediction.AppendLine($"{score.Key,-40}{score.Value,-20}");
            }
            patient.Prediction = prediction.ToString();

            return View(patient);
        }

        [HttpGet]
        public IActionResult personality()
        {
            return View();
        }

        [HttpPost]
        public IActionResult personality(PersonalityMLModel.ModelInput modelInput)
        {

            var sortedScoresWithLabel = PersonalityMLModel.PredictAllLabels(modelInput);

            string personalityKey = "";
            float personalityValue = 0F;

            foreach (var score in sortedScoresWithLabel)
            { 
                if (score.Value > personalityValue)
                {
                    personalityValue = score.Value;
                    personalityKey = score.Key;
                }
               
            }
            
            modelInput.PredictionResult = $"{personalityKey} : {personalityValue}";

            return View(modelInput);
        }

    }
}

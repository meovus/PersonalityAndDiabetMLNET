namespace EnneagramMLNet.Models
{
    public class Patient
    {
        public float Pregnancies { get; set; }
        public float Glucose { get; set; }
        public float BloodPressure { get; set; }
        public float SkinThickness { get; set; }
        public float Insulin { get; set; }
        public float BMI { get; set; }
        public float DiabetesPedigreeFunction { get; set; }
        public float Age { get; set; }
        public float Outcome { get; set; }
        public string? Prediction { get; set; }
    }
}

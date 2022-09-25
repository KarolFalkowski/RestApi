namespace PeselApp.Models
{
    public class PeselResponse
    {
        public int age { get; set; }
        public double promotion { get; set; }

        public PeselResponse(int age, double promotion)
        {
            this.age = age;
            this.promotion = promotion;
        }
    }
}

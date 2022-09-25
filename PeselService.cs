namespace PeselApp
{
    public class PeselService
    {
        public static double CalculatePromotions(string pesel)
        {
            DateTime today = DateTime.Now;
            int month = Int32.Parse(pesel.Substring(2, 2));

            //W przypadku nowych peseli, zmiana wartosci miesaca z np na 21 na 01
            if (month >= 20)
                month -= 20;
            int day = Int32.Parse(pesel.Substring(4, 2));
            double promo;

            if (today.Month == month && today.Day == day)
                promo = 0.10;
            else if (today.Month == month)
                promo = 0.05;
            else
            {
                if (today.Month >= 2 && today.Month <= 9)
                    promo = 0;
                else
                    promo = 0.025;
            }

            return promo;
        }
    }
}


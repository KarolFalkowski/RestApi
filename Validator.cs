namespace PeselApp
{
    internal static class Validator
    {
        public static string validateName(string name, string surname)
        {
            if (name.Any(char.IsDigit))
                return "Wrong name";
            if (surname.Any(char.IsDigit))
                return "Wrong surname";
            return "";
        }
        public static string validatePesel(string pesel)
        {
            if (pesel.Any(char.IsLetter))
                return "Pesel contains letters";
            if (pesel.Length < 11)
                return "Pesel is too short";
            if (pesel.Length > 11)
                return "Pesel is too long";

            int[] peselArray = new int[11];
            for (int i = 0; i < pesel.Length; i++)
                peselArray[i] = Int32.Parse(pesel[i].ToString());

            int sum = peselArray[0];
            sum += peselArray[1] * 3;
            sum += peselArray[2] * 7;
            sum += peselArray[3] * 9;
            sum += peselArray[4];
            sum += peselArray[5] * 3;
            sum += peselArray[6] * 7;
            sum += peselArray[7] * 9;
            sum += peselArray[8];
            sum += peselArray[9] * 3;
            sum += peselArray[10];
            string sumaAsString = "" + sum;
            if (sumaAsString[sumaAsString.Length - 1] != '0')
                return "Wrong pesel";

            return pesel;
        }
    }
}
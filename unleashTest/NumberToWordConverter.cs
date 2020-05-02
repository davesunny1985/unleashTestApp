using System;

namespace unleashTest
{
    public class NumberToWordConverter
    {
        private static String OnesPlaces(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = "";
            switch (_Number)
            {

                case 1:
                    name = "One";
                    break;
                case 2:
                    name = "Two";
                    break;
                case 3:
                    name = "Three";
                    break;
                case 4:
                    name = "Four";
                    break;
                case 5:
                    name = "Five";
                    break;
                case 6:
                    name = "Six";
                    break;
                case 7:
                    name = "Seven";
                    break;
                case 8:
                    name = "Eight";
                    break;
                case 9:
                    name = "Nine";
                    break;
            }
            return name;
        }

        private static String TensPlaces(String Number)
        {
            int _Number = Convert.ToInt32(Number);
            String name = null;
            switch (_Number)
            {
                case 10:
                    name = "Ten";
                    break;
                case 11:
                    name = "Eleven";
                    break;
                case 12:
                    name = "Twelve";
                    break;
                case 13:
                    name = "Thirteen";
                    break;
                case 14:
                    name = "Fourteen";
                    break;
                case 15:
                    name = "Fifteen";
                    break;
                case 16:
                    name = "Sixteen";
                    break;
                case 17:
                    name = "Seventeen";
                    break;
                case 18:
                    name = "Eighteen";
                    break;
                case 19:
                    name = "Nineteen";
                    break;
                case 20:
                    name = "Twenty";
                    break;
                case 30:
                    name = "Thirty";
                    break;
                case 40:
                    name = "Fourty";
                    break;
                case 50:
                    name = "Fifty";
                    break;
                case 60:
                    name = "Sixty";
                    break;
                case 70:
                    name = "Seventy";
                    break;
                case 80:
                    name = "Eighty";
                    break;
                case 90:
                    name = "Ninety";
                    break;
                default:
                    if (_Number > 0)
                    {
                        name = TensPlaces(Number.Substring(0, 1) + "0") + " " + OnesPlaces(Number.Substring(1));
                    }
                    break;
            }
            return name;
        }

        private static String ConvertWholeNumber(String Number, bool roundOffPoints = false)
        {
            string word = "";
            try
            {
                bool beginsZero = false;
                bool isDone = false;

                double dblAmt = (Convert.ToDouble(roundOffPoints ? "0." + Number : Number));
                Number = dblAmt.ToString("G29");
                if (roundOffPoints)
                {
                    dblAmt = Math.Round(dblAmt, 2);
                    dblAmt *= 100;
                    Number = dblAmt.ToString();
                }
                if (dblAmt > 0)
                {
                    beginsZero = Number.StartsWith("0") || Number.StartsWith(".");

                    int numDigits = Number.Length;
                    int pos = 0;
                    String place = "";
                    switch (numDigits)
                    {
                        case 1:

                            word = OnesPlaces(Number);
                            isDone = true;
                            break;
                        case 2:
                            word = TensPlaces(Number);
                            isDone = true;
                            break;
                        case 3:
                            pos = (numDigits % 3) + 1;
                            place = " Hundred ";
                            break;
                        case 4:
                        case 5:
                        case 6:
                            pos = (numDigits % 4) + 1;
                            place = " Thousand ";
                            break;
                        case 7:
                        case 8:
                        case 9:
                            pos = (numDigits % 7) + 1;
                            place = " Million ";
                            break;
                        case 10:
                        case 11:
                        case 12:

                            pos = (numDigits % 10) + 1;
                            place = " Billion ";
                            break;
                        default:
                            isDone = true;
                            break;
                    }
                    if (!isDone)
                    {
                        if (Number.Substring(0, pos) != "0" && Number.Substring(pos) != "0")
                        {
                            try
                            {
                                word = ConvertWholeNumber(Number.Substring(0, pos)) + place + ConvertWholeNumber(Number.Substring(pos));
                            }
                            catch { }
                        }
                        else
                        {
                            word = ConvertWholeNumber(Number.Substring(0, pos)) + ConvertWholeNumber(Number.Substring(pos));
                        }
                    }
                    if (word.Trim().Equals(place.Trim())) word = "";
                }
            }
            catch { }
            return word.Trim();
        }

        public static String ConvertToWords(String number)
        {
            String val = "", wholeNo = number, andStr = "", pointStr = "", minusStr = "";
            String endStr = "";
            double num;
            bool result = double.TryParse(number, out num);
            if (!result)
            {
                return String.Empty;
            }
            if (num == 0d)
            {
                return "Zero";
            }
            if (number.StartsWith("-"))
            {
                minusStr = "Minus ";
                number = number.Substring(1, number.Length - 1);
                wholeNo = number;
            }

            if (number.StartsWith("."))
            {
                number = "0" + number;
                wholeNo = number;
            }

            try
            {
                int decimalPlace = num.ToString().IndexOf(".");
                if (decimalPlace > 0)
                {
                    wholeNo = number.Substring(0, decimalPlace);
                    string points = number.Substring(decimalPlace + 1);
                    if (Convert.ToInt32(points) > 0)
                    {
                        andStr = Convert.ToDecimal(number) < 1 ? "" : Convert.ToDecimal(number) > 2 ? "Dollars" : "Dollar";
                        andStr += (Convert.ToDecimal(number) > 1 ? " and" : "");
                        endStr = "Cents";
                        pointStr = ConvertWholeNumber(points, true);
                    }
                    val = String.Format("{0} {1} {2} {3}", ConvertWholeNumber(wholeNo).Trim(), andStr, pointStr, endStr);
                }
                else
                {
                    andStr = Convert.ToDecimal(number) < 1 ? "" : Convert.ToDecimal(number) > 2 ? "Dollars" : "Dollar";
                    val = String.Format("{0} {1}", ConvertWholeNumber(wholeNo).Trim(), andStr);
                }
            }
            catch {
            }
            return minusStr + val.Trim();
        }
    }
}

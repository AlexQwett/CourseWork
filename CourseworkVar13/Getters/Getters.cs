using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseworkVar13
{
    public class Getters
    {
        protected static string UppercaseFirstLetter(string value)
        {
            if (value.Length > 0)
            {
                char[] array = value.ToCharArray();
                array[0] = char.ToUpper(array[0]);
                return new string(array);
            }

            return value;
        }

        protected static string GetString(string massage, bool whitespace = false, bool required = true)
        {
            string value;
            string pattern;

            if (whitespace == true)
            {
                pattern = @"[^a-zA-Zа-яА-ЯїЇєЇіІґҐ ]";
            }
            else
            {
                pattern = @"[^a-zA-Zа-яА-ЯїЇєЇіІґҐ]";
            }

            do
            {
                Console.Write(massage);
                value = Console.ReadLine();

                if (!required && value == "")
                {
                    return "";
                }

            } while (Regex.IsMatch(value, pattern) || value == "");

            return UppercaseFirstLetter(value);
        }

        protected static string GetIdentificationCode(string message = "Ідентифікаційний код: ", bool required = true)
        {
            string IdentificationCode;

            do
            {
                Console.Write(message);
                IdentificationCode = Console.ReadLine();

                if (!required && IdentificationCode == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(IdentificationCode, @"(?:^|\s)(?!0+)([0-9]{10})(?:$|\s|\.|\,)"));

            return IdentificationCode;
        }

        protected static int GetInt(string message, int from = int.MinValue, int to = int.MaxValue, bool required = true)
        {
            string res;
            bool test = true;

            do
            {
                Console.Write(message);
                res = Console.ReadLine();

                if (!required && res == "")
                {
                    return 0;
                }

                if (Regex.IsMatch(res, @"[^0-9]") || res == "")
                {
                    continue;
                }
                else if (int.Parse(res) > to || int.Parse(res) < from)
                {
                    continue;
                }
                else
                {
                    test = false;
                }

            } while (test);

            return int.Parse(res);
        }

        protected static string GetEmail(bool required = true)
        {
            string Email;

            do
            {
                Console.Write("Email: ");

                Email = Console.ReadLine();

                if (!required && Email == "")
                {
                    return "";
                }
            } while (!Regex.IsMatch(Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"));

            return Email;
        }

        protected static double GetDouble(string message, double from = double.MinValue, double to = double.MaxValue, bool required = true)
        {
            Console.Write(message);
            string value = Console.ReadLine().Replace('.', ',');

            if (!required && value == "")
            {
                return 0;
            }

            double res;
            bool test = double.TryParse(value, out res);

            while (!test)
            {
                Console.Write(message);
                value = Console.ReadLine().Replace('.', ',');
                test = double.TryParse(value, out res);
            }

            return res;
        }

        protected static string GetDate(string massage)
        {
            string pattern = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec)))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)(?:0?2|(?:Feb))\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
            string date;

            do
            {
                Console.Write(massage);
                date = Console.ReadLine();
            } while (!Regex.IsMatch(date, pattern));

            return date;
        }

        protected static string GetTime()
        {
            string date;

            do
            {
                Console.Write("Час: ");
                date = Console.ReadLine();
            } while (!Regex.IsMatch(date, @"^([01]\d|2[0-3]):([0-5]\d)$"));

            return date;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using API.Controllers;

namespace CourseworkVar13
{
    class Menu : Getters
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            DoctorsController doctorsController = new DoctorsController();
            PatientsController patientsController = new PatientsController();
            ScheduleController scheduleController = new ScheduleController();
            SearchController searchController = new SearchController();

            while (true)
            {
                Console.Clear();
                Console.Write("Введіть сутність з якою бажаєте працювати або її номер:\n" +
                              "1. Лікар\n" +
                              "2. Пацієнт\n" +
                              "3. Керування записом на прийом\n" +
                              "4. Пошук\n" +
                              "Щоб закрити програму введіть \"Вихід\": \n");

                string entity = Console.ReadLine();
                Console.Clear();

                if (entity == "1" || UppercaseFirstLetter(entity) == "Лікар")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Додати або обновити дані лікаря\n" +
                              "2. Видалити дані лікаря\n" +
                              "3. Переглянути дані лікаря\n" +
                              "4. Переглянути список всіх лікарів та їх спеціалізації\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Додати або обновити дані лікаря" || UppercaseFirstLetter(action) == "Додати" || UppercaseFirstLetter(action) == "Обновити")
                        {
                            Console.Clear();
                            Console.WriteLine(doctorsController.AddOrUpdateDoctor(GetString("Ім'я: "), GetString("Прізвище: "), GetInt("Вік: ", 18, 115), GetEmail(), GetIdentificationCode(), GetString("Кваліфікація: ", true),
                                                               GetInt("Стаж(років): ", 1), GetInt("Кабінет №: ")));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Видалити лікаря" || UppercaseFirstLetter(action) == "Видалити")
                        {
                            Console.Clear();
                            string id = GetIdentificationCode("Ідентифікаційний код: ", false);

                            Console.WriteLine(doctorsController.DeleteDoctor(id));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Переглянути дані лікаря")
                        {
                            Console.Clear();
                            string id = GetIdentificationCode("Ідентифікаційний код: ", false);

                            Console.Clear();
                            Console.WriteLine(doctorsController.GetDoctorInfo(id));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Переглянути список всіх лікарів" || UppercaseFirstLetter(action) == "Переглянути список")
                        {
                            Console.Clear();
                            Console.WriteLine("Список лікарів та їх спеціалізації: ");

                            Console.WriteLine(doctorsController.GetDoctorsInfo());

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }

                        Console.Clear();
                    }
                }
                else if (entity == "2" || UppercaseFirstLetter(entity) == "Пацієнт")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Додати або обновити дані пацієнта\n" +
                              "2. Видалити дані пацієнта\n" +
                              "3. Переглянути дані пацієнта\n" +
                              "4. Переглянути список всіх пацієнтів\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Додати або обновити дані пацієнта" || UppercaseFirstLetter(action) == "Додати" || UppercaseFirstLetter(action) == "Обновити")
                        {
                            Console.Clear();
                            Console.WriteLine(patientsController.AddOrUpdatePatient(GetString("Ім'я: "), GetString("Прізвище: "), GetInt("Вік: ", 18, 115), GetEmail(), GetIdentificationCode(), GetString("Передбачувана хвороба: ", true),
                                                               GetDate("Орієнтовна дата захворювання: ")));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Видалити дані пацієнта" || UppercaseFirstLetter(action) == "Видалити")
                        {
                            Console.Clear();
                            string id = GetIdentificationCode("Ідентифікаційний код: ", false);

                            Console.WriteLine(patientsController.DeletePatient(id));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Переглянути дані пацієнта")
                        {
                            Console.Clear();
                            string id = GetIdentificationCode("Ідентифікаційний код: ", false);

                            Console.WriteLine("\n" + patientsController.GetPatientInfo(id));

                            if (patientsController.GetPatientInfo(id) == "Пацієнта не знайдено")
                            {
                                Console.ReadLine();
                                Console.Clear();
                                continue;
                            }
                                

                            while (true)
                            {
                                Console.Write("Бажаєте внести запис у мадичну книжку?(Так або Ні): ");

                                string confirm = Console.ReadLine();

                                if (UppercaseFirstLetter(confirm) == "Так" || UppercaseFirstLetter(confirm) == "Да")
                                {
                                    string Desease = GetString("Хвороба: ");
                                    string DetactionDate = GetDate("Дата виявлення хвороби: ");
                                    string RecoveryDate = GetDate("Дата одужання: ");

                                    patientsController.AddNewMedicalBookNote(id, Desease, DetactionDate, RecoveryDate);
                                }
                                else if (UppercaseFirstLetter(confirm) == "Ні")
                                {
                                    break;
                                }
                                else if (UppercaseFirstLetter(action) == "Вихід")
                                {
                                    Environment.Exit(1);
                                }
                            }

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Переглянути список всіх пацієнтів" || UppercaseFirstLetter(action) == "Переглянути список")
                        {
                            Console.Clear();
                            Console.WriteLine("Список пацієнтів: ");

                            Console.WriteLine(patientsController.GetPatientsInfo());

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (entity == "3" || UppercaseFirstLetter(entity) == "Керування записом на прийом")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Записати пацієнта на прийом\n" +
                              "2. Стерти запис\n" +
                              "3. Переглянути дані запису\n" +
                              "4. Переглянути список всіх записів за датою\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Записати пацієнта на прийом" || UppercaseFirstLetter(action) == "Записати")
                        {
                            Console.Clear();
                            bool test = scheduleController.AddNote(GetDate("Дата прийому: "), GetTime(), GetIdentificationCode("Ідентифікаційний код пацієнта: "), GetString("Кваліфікація лікаря: ", true));

                            if(test == true)
                                Console.WriteLine("Запис на прийом успішно створено, щоб продовжити натисніть \"Enter\"");
                            else
                                Console.WriteLine("В даний час лікар не зможе прийняти пацієнта або дані були введені не вірно, щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Стерти запис" || UppercaseFirstLetter(action) == "Стерти")
                        {
                            Console.Clear();
                            bool test = scheduleController.DeleteNote(GetDate("Дата прийому: "), GetTime(), GetIdentificationCode("Ідентифікаційний код пацієнта: "), GetString("Кваліфікація лікаря: ", true));

                            if (test == true)
                                Console.WriteLine("Запис успішно видалено, щоб продовжити натисніть \"Enter\"");
                            else
                                Console.WriteLine("Даний запис не існує, щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Переглянути дані запису")
                        {
                            Console.Clear();
                            string info = scheduleController.GetNoteInfo(GetDate("Дата прийому: "), GetTime(), GetIdentificationCode("Ідентифікаційний код пацієнта: "), GetString("Кваліфікація лікаря: ", true));

                            Console.WriteLine(info);

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "4" || UppercaseFirstLetter(action) == "Переглянути список всіх записів за датою" || UppercaseFirstLetter(action) == "Переглянути список")
                        {
                            Console.Clear();

                            string date = GetDate("Дата записів: ");

                            Console.Clear();
                            Console.WriteLine($"Cписок записів на {date}: \n");

                            Console.WriteLine(scheduleController.GetNotesInfo(date));

                            Console.WriteLine("\nЩоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (entity == "4" || UppercaseFirstLetter(entity) == "Пошук")
                {
                    while (true)
                    {
                        Console.Write("Введіть назву дії яку бажаєте виконти або її номер:\n" +
                              "1. Пошук пацієнта за його іменем та прізвищем\n" +
                              "2. Пошук лікаря за його іменем та прізвищем\n" +
                              "3. Отримати розклад лікаря за датою\n" +
                              "Щоб повернутись назад введіть \"Назад\", щоб закрити програму введіть \"Вихід\": \n");

                        string action = Console.ReadLine();

                        if (action == "1" || UppercaseFirstLetter(action) == "Пошук пацієнта за його іменем та прізвищем" || UppercaseFirstLetter(action) == "Пошук пацієнта")
                        {
                            Console.Clear();

                            Console.WriteLine(searchController.FindPatient(GetString("Ім'я: "), GetString("Прізвище: ")));

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "2" || UppercaseFirstLetter(action) == "Пошук лікаря за його іменем та прізвищем" || UppercaseFirstLetter(action) == "Пошук лікаря")
                        {
                            Console.Clear();

                            Console.WriteLine(searchController.FindDoctor(GetString("Ім'я: "), GetString("Прізвище: ")));

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (action == "3" || UppercaseFirstLetter(action) == "Отримати розклад лікаря за датою")
                        {
                            Console.Clear();
                            Console.WriteLine(searchController.GetDoctorScheduleByDate(GetDate("Дата записів лікаря: "), GetIdentificationCode("Ідентифікаційний код лікаря: ")));

                            Console.WriteLine("Щоб продовжити натисніть \"Enter\"");

                            Console.ReadLine();
                            Console.Clear();
                        }
                        else if (UppercaseFirstLetter(action) == "Назад")
                        {
                            Console.Clear();
                            break;
                        }
                        else if (UppercaseFirstLetter(action) == "Вихід")
                        {
                            Environment.Exit(1);
                        }
                        else
                        {
                            Console.Clear();
                        }
                    }
                }
                else if (UppercaseFirstLetter(entity) == "Вихід")
                {
                    Environment.Exit(1);
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
struct Birthday
{
    public int day;
    public int month;
    public int year;
}

public class Person
{
    private string Name;
    private string Surname;
    private string Patronymic;
    private double Phone;
    private string Country; 
    private Birthday Date;
    private string Organization;
    private string Position;
    private string Notes;


    public Person(string theName, string theSurname, string thePatronymic, string theCountry)
    {
        Name = theName;
        Surname = theSurname;
        Patronymic = thePatronymic;
        Country = theCountry;
        Phone = 0;
        Organization = Position = Notes = " ";
        Date.day = 0;
        Date.month = 0;
        Date.year = 0;
    }

    public Person(string theName, string theSurname, string thePatronymic, string theCountry, double thePhone, string theOrganization, string thePosition, int theDay, int theMonth, int theYear)
    {
        Name = theName;
        Surname = theSurname;
        Patronymic = thePatronymic;
        Country = theCountry;
        Phone = thePhone;
        Organization = theOrganization;
        Position = thePosition;
        Date.day = theDay;
        Date.month = theMonth;
        Date.year = theYear;
        Notes = " ";
    }
   
    public void DisplayPerson() {
        Console.WriteLine($"Сотрудник: {Name} {Surname} {Patronymic}.\n Дата рождения: {Date.day}.{Date.month}.{Date.year}.\n Организация: {Organization}.\n Должность: {Position}.\n Телефон: {Phone}\n Заметки: {Notes}.\n"); ; ;
    }

    public void setName(string theName)
    {
        Name = theName;
    }
    public void setSurname(string theSurname)
    {
        Surname = theSurname;
    }
    public void setPatronymic(string thePatronymic)
    {
        Patronymic = thePatronymic;
    }

    public void setPosition(string thePosition)
    {
        Position = thePosition;
    }

    public void setCountry(string theCountry)
    {
        Country = theCountry;
    }

    public void setPhone(double thePhone)
    {
        Phone = thePhone;
    }

    public void setOrganization(string theOrganization)
    {
        Organization = theOrganization;
    }

    public void setDate(int theDay, int theMonth, int theYear)
    {
        Date.day = theDay;
        Date.month = theMonth;
        Date.year = theYear;
    }

    public void addNote(string theNote)
    {
        Notes = theNote;
    }
    public double getPhone()
    {
        return Phone;
    }
}

namespace Lab
{
    class Program
    {
        static bool checkLeapYear(int theYear)
        {
            if (theYear % 4 == 0)
                return true;
            else
                return false;
        }

        static bool checkCorrectMonth(int theMonth)
        {
            if (theMonth == 1 || theMonth == 3 || theMonth == 5 || theMonth == 7 || theMonth == 8 || theMonth == 10 || theMonth == 12)
                return true;
            else
                return false;
        }
        static bool checkCorrectInputData(int theYear, int theMonth, int theDay)
        {
            if ((theMonth > 0) && (theMonth < 13) && (theYear > 1900) && (theYear < 2100))
                if (checkLeapYear(theYear))
                {
                    if (theMonth == 2)
                    {
                        if ((theDay > 0) && (theDay < 30))
                            return true;
                        else
                            return false;
                    }
                    else if (checkCorrectMonth(theMonth))
                    {
                        if ((theDay > 0) && (theDay < 32))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if ((theDay > 0) && (theDay < 31))
                            return true;
                        else
                            return false;
                    }
                }
                else
                {
                    if (theMonth == 2)
                    {
                        if ((theDay > 0) && (theDay < 29))
                            return true;
                        else
                            return false;
                    }
                    else if (checkCorrectMonth(theMonth))
                    {
                        if ((theDay > 0) && (theDay < 32))
                            return true;
                        else
                            return false;
                    }
                    else
                    {
                        if ((theDay > 0) && (theDay < 31))
                            return true;
                        else
                            return false;
                    }
                }
            else
                return false;
        }

        static bool checkDate(int theDay, int theMonth, int theYear)
        {
            if (checkCorrectInputData(theYear, theMonth, theDay))
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            string PhonePattern = "^8[0-9]{10}$";
            string InputPattern = "^[A-ЯЁ][а-яё]+$";
            int choice;
            LinkedList<Person> noteBook = new LinkedList<Person>();
            bool checkList = false;
            do {
                Console.Write("Лабороторная работа - Записная книжка\n[1] - Добавить запись в книжку\n[2] - Удалить записи из книжки\n[3] - Просмотр записной книжки\n[4] - Редактировать запись в книжке\n[0] - Выход из программы\nВаш выбор >> ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 4)
                    Console.WriteLine("Неправильный выбор, попробуйте ещё раз\n");
                else if (choice == 0)
                    break;
                else
                {
                    switch (choice)
                    {
                        case 1:
                            try
                            {
                                checkList = true;
                                Console.Write("Введите Имя: ");
                                bool checkName = true;
                                string theName;
                                do
                                {
                                    theName = Console.ReadLine();
                                    if (Regex.IsMatch(theName, InputPattern, RegexOptions.IgnoreCase))
                                        checkName = false;
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkName);
                                Console.Write("Введите Фамилию: ");
                                bool checkSurname = true;
                                string theSurname;
                                do
                                {
                                    theSurname = Console.ReadLine();
                                    if (Regex.IsMatch(theSurname, InputPattern, RegexOptions.IgnoreCase))
                                        checkSurname = false;
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkSurname);
                                Console.Write("Введите Отчество: ");
                                bool checkPatronymic = true;
                                string thePatronymic;
                                do
                                {
                                    thePatronymic = Console.ReadLine();
                                    if (Regex.IsMatch(thePatronymic, InputPattern, RegexOptions.IgnoreCase))
                                        checkPatronymic = false;
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkPatronymic);
                                Console.Write("Введите Страну: ");
                                bool checkCountry = true;
                                string theCountry;
                                do
                                {
                                    theCountry = Console.ReadLine();
                                    if (Regex.IsMatch(theCountry, InputPattern, RegexOptions.IgnoreCase))
                                        checkCountry = false;
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkCountry);

                                Console.Write("Введите Должность: ");
                                bool checkPosition = true;
                                string thePosition;
                                do
                                {
                                    thePosition = Console.ReadLine();
                                    if (Regex.IsMatch(thePosition, InputPattern, RegexOptions.IgnoreCase))
                                        checkPosition = false;
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkPosition);
                                Console.Write("Введите Телефон: ");
                                bool checkPhone = true;
                                string thePhoneS;
                                double thePhone = 0;
                                do
                                {
                                    thePhoneS = Console.ReadLine();
                                    if (Regex.IsMatch(thePhoneS, PhonePattern))
                                    {
                                        checkPhone = false;
                                        thePhone = Convert.ToDouble(thePhoneS);
                                    }
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkPhone);
                                Console.Write("Введите Организацию: ");
                                bool checkOrganization = true;
                                string theOrganization;
                                do
                                {
                                    theOrganization = Console.ReadLine();
                                    if (Regex.IsMatch(theOrganization, InputPattern, RegexOptions.IgnoreCase))
                                        checkOrganization = false;
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkOrganization);

                                bool correctDate = true;
                                int theDay, theMonth, theYear;
                                do
                                {
                                    Console.Write("Введите Дeнь рождения: ");
                                    theDay = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Введите Месяц рождения: ");
                                    theMonth = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Введите Год рождения: ");
                                    theYear = Convert.ToInt32(Console.ReadLine());
                                    if (checkDate(theDay, theMonth, theYear))
                                        correctDate = false;
                                    else
                                        Console.Write("Неправильная дата. Попробуйте ещё раз >> ");
                                } while (correctDate);



                                Person tempObject = new Person(theName, theSurname, thePatronymic, theCountry, thePhone, theOrganization, thePosition, theDay, theMonth, theYear);
                                noteBook.AddLast(tempObject);
                                Console.WriteLine("Вы успешно добавили сотрудника, нажмите любую клавишу для продолжения...");
                                Console.ReadLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Исключение: {ex.Message}");
                                Console.WriteLine($"Метод: {ex.TargetSite}");
                                Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
                            }
                            break;
                        case 2:
                            if (checkList)
                            {
                                noteBook.Clear();
                                Console.WriteLine("Успешно удалили список. Нажмите клавиу для продолжения...");
                                Console.ReadLine();
                                checkList = false;
                            }
                            else
                                Console.WriteLine("Сначала создайте записную книжку");
                            break;
                        case 3:
                            if (checkList)
                                foreach (Person tempObject in noteBook)
                                    tempObject.DisplayPerson();
                            else
                                Console.WriteLine("Сначала создайте книжку\n");
                            break;
                        case 4:
                            if (checkList)
                            {
                                Console.Write("Введите номер сотрудника для поиска в записной книжке\n Ваш ввод >> ");
                                bool checkPhoneS = true;
                                bool checkPerson = false;
                                string PhoneS;
                                double Phone = 0;
                                do
                                {
                                    PhoneS = Console.ReadLine();
                                    if (Regex.IsMatch(PhoneS, PhonePattern))
                                    {
                                        checkPhoneS = false;
                                        Phone = Convert.ToDouble(PhoneS);
                                    }
                                    else
                                        Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                } while (checkPhoneS);
                                foreach (Person tempObject in noteBook)
                                {
                                    double tempPhone = tempObject.getPhone();
                                    if (tempPhone == Phone)
                                    {
                                        checkPerson = true;
                                        int choiceAction;
                                        do
                                        {
                                            Console.Write("Редактирование записи\n[1] - Изменить ФИО\n[2] - Изменить должность \n[3] - Изменить страну проживания\n[4] - Изменить номер телефона\n[5] - Изменить организацию\n[6] - Изменить дату рождения\n[7] - Добавить заметку\n[0] - Выход из режима редактирования\nВаш выбор >> ");
                                            choiceAction = Convert.ToInt32(Console.ReadLine());
                                            if (choiceAction > 3)
                                                Console.WriteLine("Неправильно вывбор, попробуйте ещё раз\n");
                                            else if (choiceAction == 0)
                                                break;
                                            else
                                            {
                                                switch (choiceAction)
                                                {
                                                    case 1:
                                                        Console.Write("Введите Имя: ");
                                                        bool checkName = true;
                                                        string theName;
                                                        do
                                                        {
                                                            theName = Console.ReadLine();
                                                            if (Regex.IsMatch(theName, InputPattern, RegexOptions.IgnoreCase))
                                                                checkName = false;
                                                            else
                                                                Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                                        } while (checkName);
                                                        Console.Write("Введите Фамилию: ");
                                                        bool checkSurname = true;
                                                        string theSurname;
                                                        do
                                                        {
                                                            theSurname = Console.ReadLine();
                                                            if (Regex.IsMatch(theSurname, InputPattern, RegexOptions.IgnoreCase))
                                                                checkSurname = false;
                                                            else
                                                                Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                                        } while (checkSurname);
                                                        Console.Write("Введите Отчество: ");
                                                        bool checkPatronymic = true;
                                                        string thePatronymic;
                                                        do
                                                        {
                                                            thePatronymic = Console.ReadLine();
                                                            if (Regex.IsMatch(thePatronymic, InputPattern, RegexOptions.IgnoreCase))
                                                                checkPatronymic = false;
                                                            else
                                                                Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                                        } while (checkPatronymic);
                                                        tempObject.setName(theName);
                                                        tempObject.setSurname(theSurname);
                                                        tempObject.setPatronymic(thePatronymic);
                                                        Console.WriteLine("Успешное изменение данных.\n");
                                                        break;
                                                    case 2:
                                                        Console.Write("Введите Должность: ");
                                                        bool checkPosition = true;
                                                        string thePosition;
                                                        do
                                                        {
                                                            thePosition = Console.ReadLine();
                                                            if (Regex.IsMatch(thePosition, InputPattern, RegexOptions.IgnoreCase))
                                                                checkPosition = false;
                                                            else
                                                                Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                                        } while (checkPosition);
                                                        tempObject.setPosition(thePosition);
                                                        Console.WriteLine("Успешное изменение данных.\n");
                                                        break;
                                                    case 3:
                                                        Console.Write("Введите Страну: ");
                                                        bool checkCountry = true;
                                                        string theCountry;
                                                        do
                                                        {
                                                            theCountry = Console.ReadLine();
                                                            if (Regex.IsMatch(theCountry, InputPattern, RegexOptions.IgnoreCase))
                                                                checkCountry = false;
                                                            else
                                                                Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                                        } while (checkCountry);
                                                        tempObject.setCountry(theCountry);
                                                        Console.WriteLine("Успешное изменение данных.\n");
                                                        break;
                                                    case 4:
                                                        Console.Write("Введите Телефон: ");
                                                        bool checkPhone = true;
                                                        string thePhoneS;
                                                        double thePhone = 0;
                                                        do
                                                        {
                                                            thePhoneS = Console.ReadLine();
                                                            if (Regex.IsMatch(thePhoneS, PhonePattern))
                                                            {
                                                                checkPhone = false;
                                                                thePhone = Convert.ToDouble(thePhoneS);
                                                            }
                                                            else
                                                                Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                                        } while (checkPhone);
                                                        tempObject.setPhone(thePhone);
                                                        Console.WriteLine("Успешное изменение данных.\n");
                                                        break;
                                                    case 5:
                                                        Console.Write("Введите Организацию: ");
                                                        bool checkOrganization = true;
                                                        string theOrganization;
                                                        do
                                                        {
                                                            theOrganization = Console.ReadLine();
                                                            if (Regex.IsMatch(theOrganization, InputPattern, RegexOptions.IgnoreCase))
                                                                checkOrganization = false;
                                                            else
                                                                Console.Write("Неправильный формат. Попробуйте ещё раз >> ");
                                                        } while (checkOrganization);
                                                        tempObject.setOrganization(theOrganization);
                                                        Console.WriteLine("Успешное изменение данных.\n");
                                                        break;
                                                    case 6:
                                                        bool correctDate = true;
                                                        int theDay, theMonth, theYear;
                                                        do
                                                        {
                                                            Console.Write("Введите Дeнь рождения: ");
                                                            theDay = Convert.ToInt32(Console.ReadLine());
                                                            Console.Write("Введите Месяц рождения: ");
                                                            theMonth = Convert.ToInt32(Console.ReadLine());
                                                            Console.Write("Введите Год рождения: ");
                                                            theYear = Convert.ToInt32(Console.ReadLine());
                                                            if (checkDate(theDay, theMonth, theYear))
                                                                correctDate = false;
                                                            else
                                                                Console.Write("Неправильная дата. Попробуйте ещё раз >> ");
                                                        } while (correctDate);
                                                        tempObject.setDate(theDay, theMonth, theYear);
                                                        Console.WriteLine("Успешное изменение данных.\n");
                                                        break;
                                                    case 7:
                                                        Console.Write("Введите заметку >> ");
                                                        string theNote = Console.ReadLine();
                                                        tempObject.addNote(theNote);
                                                        Console.WriteLine("Успешное добавление заметки.\n");
                                                        break;
                                                }
                                            }

                                        } while (choiceAction != 0);
                                    }
                                }
                                if (!checkPerson)
                                    Console.WriteLine("Пользователь не найден с таким номером\n");
                            }
                            else
                                Console.WriteLine("Сначала создайте записную книжку\n");
                            break;
                    }
                }

            } while (choice != 0);

            if (checkList)
                noteBook.Clear();
        }
    }
}

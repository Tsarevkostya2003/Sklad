using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Sklad
{
    internal enum Roll
    {
        Администратор = 0,
        Кассир =1,
        Кладовщик =2, 
        Менеджер =3,
        Бухгалтер=4
    }
    internal class Admin
    {

        public void Menuadm(List<User> users, User us)

        {
            ConsoleKey key;
            ConsoleKey key1;

            

            do
            {
                Console.Clear();
                Console.WriteLine("Кабинет Администратора - " + us.Login);
                Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                Console.WriteLine("   | ID |  Login        |   Password    |Rol|                | F1 - Ввод нового пользователя   |");
                Console.WriteLine("---+----+---------------+-------------------+                | F2 - Поиск пользователя         |");
                Console.WriteLine("                                                             | F3 - Редактирование пользователя|");
                Console.WriteLine("                                                             | F4 - Удаление пользователя      |");
                Console.WriteLine("                                                             | F5 - Просмотр пользователя      |");

                Console.SetCursorPosition(0,4);
                foreach (var user in users)
                {
                    Console.WriteLine("   |{0,4}|{1,15}|{2,15}|{3,3}|", user.Id, user.Login, user.Password, user.Rol);
                }
                Console.WriteLine("---+----+---------------+-------------------+");
                Strelka st = new Strelka(4, 4 + users.Count() - 1);
                key = st.MovemenuAdm(4);
                if (key == ConsoleKey.F1)   //Добавить 
                {
                    Console.Clear();
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Кабинет Администратора - " + us.Login);
                            Console.WriteLine("-------------------------------------------------------------+---------------------------------+");
                            Console.WriteLine("Ввод нового пользователя   Ecs - выход                       | 0 - Роль администратора         |");
                            Console.WriteLine("-------------------------------------------------------------+ 1 - Кассир                      |");
                            Console.WriteLine("                                                             | 2 - Кадровик                    |");
                            Console.WriteLine("                                                             | 3 - Менеджер                    |");
                            Console.WriteLine("                                                             | 4 - Бухгалтер                   |");
                            Console.WriteLine("                                                             |                                 |");

                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Введите ID: - только цифры");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите логин:   ");
                            string login = Console.ReadLine();
                            Console.WriteLine("Введите пароль:");
                            string password = Console.ReadLine();
                            Console.WriteLine("Введите роль: Число от 0 до 4");
                            int rol = Convert.ToInt32(Console.ReadLine());

                            if (login == "" || password == "")
                            {
                                Console.WriteLine("Пароль или логин не могут быть пустыми. Нажмите Enter или ECS ");
                                ConsoleKeyInfo k;
                                k = Console.ReadKey();
                                Console.Clear();
                                if (k.Key == ConsoleKey.Escape)
                                {
                                    break;
                                }
                            }
                            else if (id == 0 || rol > 4)
                            {
                                Console.WriteLine("Повторите ввод! Выберите правильную роль и номер ID. Нажмите Enter или ECS");
                                Console.ReadLine();
                                Console.Clear();
                                ConsoleKeyInfo k;
                                k = Console.ReadKey();
                                Console.Clear();
                                if (k.Key == ConsoleKey.Escape)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                User u = new User();
                                u.Id = id; u.Login = login; u.Password = password; u.Rol = rol;
                                users.Add(u);
                                break;
                            }

                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("ID и Роль должны быть цифры. Нажмите Enter или ECS ");
                            ConsoleKeyInfo k;
                            k = Console.ReadKey();
                            Console.Clear();
                            if (k.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            Console.Clear();

                        }

                    }

                }
                else if (key == ConsoleKey.F4) // Удаление пользователя
                {
                    User u = new User();
                    u = users[st.Pos() - 4];

                    if (u.Rol == (int)Roll.Администратор)  // Admin
                    {
                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("Нельзя удалять пользователя Администратора. Нажмите Enter");
                        Console.ReadLine();
                    }
                    else
                    {
                        users.Remove(u);
                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("Пользователь " + u.Login + " удален. Нажмите Enter");
                        Console.ReadLine();
                    }
                }
                else if (key == ConsoleKey.F2)    // Поиск пользователя 
                {

                    Console.Clear();
                    Console.WriteLine("Кабинет Администратора - " + us.Login + "поиск пользователей");
                    Console.WriteLine("---+----------------------------------------+----------------+---------------------------------+");
                    Console.WriteLine("   | Выберите пункт по которому искать      |                |                                 |");
                    Console.WriteLine("---+----------------------------------------+                |                                 |");
                    Console.WriteLine("   | Поиск по ID                                             |                                 |");
                    Console.WriteLine("   | Поиск по логину                                         |                                 |");
                    Console.WriteLine("   | Поиск по паролю                                         |                                 |");
                    Console.WriteLine("   | Поиск по роли                                           |                                 |");
                    Strelka strel = new Strelka(4, 7);
                    key1 = strel.Movesearch(4);
                    Console.SetCursorPosition(0, 8);
                    if (key1 == ConsoleKey.Enter)
                    {
                        if (strel.Pos() == 4) // поиск по ID
                        {
                            Console.WriteLine("Введите ID: - только цифры");
                            int id = Convert.ToInt32(Console.ReadLine());
                            foreach (var us1 in users)
                            {
                                if (us1.Id == id)  //нашел
                                {
                                    Console.Clear();
                                    Console.WriteLine("Кабинет Администратора - " + us.Login);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("   | ID |  Login        |   Password    |Rol|                |                                 |");
                                    Console.WriteLine("---+----+---------------+-------------------+                |                                 |");
                                    Console.WriteLine("   |{0,4}|{1,15}|{2,15}|{3,3}|", us1.Id, us1.Login, us1.Password, us1.Rol);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("Нажмите Enter");
                                    Console.ReadLine();
                                }
                            }
                        }
                        if (strel.Pos() == 5) // поиск по логину
                        {
                            Console.WriteLine("Введите логин:   ");
                            string login = Console.ReadLine();
                            foreach (var us1 in users)
                            {
                                if (us1.Login == login)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Кабинет Администратора - " + us.Login);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("   | ID |  Login        |   Password    |Rol|                |                                 |");
                                    Console.WriteLine("---+----+---------------+-------------------+                |                                 |");
                                    Console.WriteLine("   |{0,4}|{1,15}|{2,15}|{3,3}|", us1.Id, us1.Login, us1.Password, us1.Rol);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("Нажмите Enter");
                                    Console.ReadLine();
                                }
                            }

                        }
                        if (strel.Pos() == 6) // поиск по паролю
                        {
                            Console.WriteLine("Введите пароль:");
                            string password = Console.ReadLine();
                            foreach (var us1 in users)
                            {
                                if (us1.Password == password)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Кабинет Администратора - " + us.Login);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("   | ID |  Login        |   Password    |Rol|                |                                 |");
                                    Console.WriteLine("---+----+---------------+-------------------+                |                                 |");
                                    Console.WriteLine("   |{0,4}|{1,15}|{2,15}|{3,3}|", us1.Id, us1.Login, us1.Password, us1.Rol);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("Нажмите Enter");
                                    Console.ReadLine();
                                }
                            }

                        }
                        if (strel.Pos() == 7) // поиск по роли
                        {
                            Console.WriteLine("Введите роль: Число от 1 до 5");
                            int rol = Convert.ToInt32(Console.ReadLine());
                            foreach (var us1 in users)
                            {
                                if (us1.Rol == rol)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Кабинет Администратора - " + us.Login);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("   | ID |  Login        |   Password    |Rol|                |                                 |");
                                    Console.WriteLine("---+----+---------------+-------------------+                |                                 |");
                                    Console.WriteLine("   |{0,4}|{1,15}|{2,15}|{3,3}|", us1.Id, us1.Login, us1.Password, us1.Rol);
                                    Console.WriteLine("---+----+---------------+-------------------+----------------+---------------------------------+");
                                    Console.WriteLine("Нажмите Enter");
                                    Console.ReadLine();
                                }
                            }

                        }

                    }
                }
                else if (key == ConsoleKey.F3) // Редактирование пользователя               
                {
                    Console.Clear();
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Кабинет Администратора - " + us.Login);
                            Console.WriteLine("-------------------------------------------------------------+---------------------------------+");
                            Console.WriteLine("Редактирование пользователя        ESC - выход               | 0 - Роль администратора         |");
                            Console.WriteLine("-------------------------------------------------------------+ 1 - Роль                        |");
                            Console.WriteLine("                                                             | 2 - Роль                        |");
                            Console.WriteLine("                                                             | 3 - Роль                        |");
                            Console.WriteLine("                                                             | 4 - Роль                        |");
                            Console.WriteLine("                                                             | 5 - Роль                        |");
                            User u = new User();
                            u = users[st.Pos() - 4];
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("Введите ID:    старое значение :" + u.Id);
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите логин: старое значение :" + u.Login);
                            string login = Console.ReadLine();
                            Console.WriteLine("Введите пароль: старое значение:" + u.Password);
                            string password = Console.ReadLine();
                            Console.WriteLine("Введите роль: Число от 1 до 5  :" + u.Rol);
                            int rol = Convert.ToInt32(Console.ReadLine());

                            if (login == "" || password == "")
                            {
                                Console.WriteLine("Пароль или логин не могут быть пустыми. Нажмите Enter или ECS ");
                                ConsoleKeyInfo k;
                                k = Console.ReadKey();
                                Console.Clear();
                                if (k.Key == ConsoleKey.Escape)
                                {
                                    break;
                                }
                            }
                            else if (id == 0 || rol > 6)
                            {
                                Console.WriteLine("Повторите ввод! Выберите правильную роль и номер ID. Нажмите Enter или ECS");
                                Console.ReadLine();
                                Console.Clear();
                                ConsoleKeyInfo k;
                                k = Console.ReadKey();
                                Console.Clear();
                                if (k.Key == ConsoleKey.Escape)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                User un = new User();
                                un.Id = id; un.Login = login; un.Password = password; un.Rol = rol;
                                users[st.Pos() - 4].Rol = rol; users[st.Pos() - 4].Password = password;
                                users[st.Pos() - 4].Id = id; users[st.Pos() - 4].Login = login;
                                break;
                            }

                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("ID и Роль должны быть цифры. Нажмите Enter или ECS ");
                            ConsoleKeyInfo k;
                            k = Console.ReadKey();
                            Console.Clear();
                            if (k.Key == ConsoleKey.Escape)
                            {
                                break;
                            }
                            Console.Clear();
                        }
                    }

                }
                else if (key == ConsoleKey.F5) // Просмотр пользователя  
                {
                    User u = new User();
                    u = users[st.Pos() - 4];
                    Console.Clear();
                    Console.WriteLine("Кабинет Администратора - " + us.Login);
                    Console.WriteLine("--------------------------------------------+                                                   ");
                    Console.WriteLine(" Данные пользователя                        |                                                   ");
                    Console.WriteLine("--------------------------------------------+                                                   ");
                    Console.WriteLine("Идентификатор пользоввателя: "+u.Id);
                    Console.WriteLine("--------------------------------------------+                                                   ");
                    Console.WriteLine("Логин пользователя         : "+u.Login);
                    Console.WriteLine("--------------------------------------------+");   
                    Console.WriteLine("Пароль пользователя        : "+ u.Password);
                    Console.WriteLine("--------------------------------------------+");
                    if (u.Rol == (int)Roll.Администратор)
                    {
                        Console.WriteLine("Роль  пользователя         : АДМИНИСТРАТОР");
                    }
                    else if (u.Rol == (int)Roll.Кладовщик)
                    {
                        Console.WriteLine("Роль  пользователя         : КЛАДОВЩИК");
                    }
                    else if (u.Rol == (int)Roll.Менеджер)
                    {
                        Console.WriteLine("Роль  пользователя         : МЕНЕДЖЕР");
                    }
                    else if (u.Rol == (int)Roll.Бухгалтер)
                    {
                        Console.WriteLine("Роль  пользователя         : БУХГАЛТЕР");
                    }
                    else if (u.Rol == (int)Roll.Кассир)
                    {
                        Console.WriteLine("Роль  пользователя         : КАССИР");
                    }
                    else
                    {
                        Console.WriteLine("ТАКОЙ РОЛИ НЕТ");
                    }
                    Console.WriteLine("Нажмите Еnter");
                    Console.ReadLine();

                }

            } while (key! > ConsoleKey.Escape);

            Cljson clj = new Cljson();
            clj.savejson("c:\\games\\users.json", users);
        }
    }
}

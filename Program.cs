using System.IO;
namespace Sklad
{
    internal class Program
    {
        static void Main(string[] args)
        {
           // ------------------Авторизация----------------------------
            Autor();
        }

    







        static void Autor()
        {
            int position = 3;
            string log = "";
            string pass = "";
            ConsoleKeyInfo key;
            List<User> aMas = new List<User>();
            int i = 0;
            Cljson cl = new Cljson();
            aMas=cl.readjson("c:\\games\\users.json");
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("  Авторизация пользователя    ECS - Выход");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("   Введите логин: ");
            Console.WriteLine("   Введите пароль ");
            Console.WriteLine("   Подтвердите    ");
            Strelka strel = new Strelka(3,5);
            while (true)
            {               
                strel.Draw(position);
                key = Console.ReadKey(); // нажали клавишу

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (position > strel.Mini())
                    {
                        strel.Del(position);
                        position--;
                        strel.Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (position < strel.Max())
                    {
                        strel.Del(position);
                        position++;
                        strel.Draw(position);
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {

                    if (position == 3) // вводим логин 
                    {
                        Console.SetCursorPosition(18, 3);
                        log = Console.ReadLine();
                    }
                    if (position == 4) // вводим пароль звездочками
                    {
                        Console.SetCursorPosition(18, 4);
                        pass = Getpas();                        
                    }

                    if (position == 5) // проверяем логин и пароль
                    {
                        foreach (User us in aMas)
                        { 
                            if (us.Login==log && us.Password==pass & us.Rol==0 )
                            {
                                Admin adm = new Admin();
                                adm.Menuadm(aMas,us);
                                break;
                            }
                        }
                        Console.Clear();
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("  Авторизация пользователя    ECS - Выход");
                        Console.WriteLine("------------------------------------------------");
                        Console.WriteLine("   Введите логин: ");
                        Console.WriteLine("   Введите пароль ");
                        Console.WriteLine("   Подтвердите    ");
                        Console.WriteLine(" Проверьте пароль и логин");
                    }    

                }


                else if (key.Key == ConsoleKey.Escape)
                        {
                    return;
                        }


            }
        }

        static string Getpas()  // ввод пароля звездочками
        {
        var pass = string.Empty;
        ConsoleKey key;
          do
            {
              var keyInfo = Console.ReadKey(intercept: true);
              key = keyInfo.Key;

              if (key == ConsoleKey.Backspace && pass.Length > 0)
                               {
                    Console.Write("\b \b");
                    pass = pass[0..^1];
                                }
              else if (!char.IsControl(keyInfo.KeyChar))
                        {
                            Console.Write("*");
                            pass += keyInfo.KeyChar;
                        }
            } while (key != ConsoleKey.Enter) ;
            return pass;
        }








    }
}
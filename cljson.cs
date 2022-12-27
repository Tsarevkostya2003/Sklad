using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad
{
    public class User
    {
        public int Id;
        public string Login;
        public string Password;
        public int Rol; // 0- Админ

    }
    internal class Cljson
    {

        public List<User> readjson(string cF) // десерелизируем json
        {
            List<User> users = new List<User>();            
            string cSt;
            cSt = File.ReadAllText(cF);
            users = JsonConvert.DeserializeObject<List<User>>(cSt);
            return users;
        }

        public void savejson(string cF,List<User> users)
        {
            // Сериализация в json
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(cF, json);

        }


    }
}

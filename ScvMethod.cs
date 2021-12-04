using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//using Csv;
using CsvHelper;
using System.Globalization;
using System.Windows.Forms;

namespace LoginIn
{
    class ScvMethod
    {


        #region 找到所有的用户     返回一个用户List集合
        public List<User> ReadAllUser()
        {
            var reader = new StreamReader("user.csv");//读取全部数据
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            //把记录映射
            csv.Read();//读取表头
            csv.ReadHeader();  //找到表头对应值
            List<User> user = new List<User>();
            while (csv.Read())
            {
                User userL = new User();
                userL.Uid = csv.GetField<int>("Uid");
                userL.Username = csv.GetField<string>("Password");
                userL.Sum = csv.GetField<int>("Sum");
                userL.Username = csv.GetField<string>("Username");
                // user2.stalk = csv.getfield<queue<int>>("stalk");
                user.Add(userL);
                Console.WriteLine(userL.Uid);
                Console.WriteLine(userL.Username);
                Console.WriteLine(userL.Sum);
                Console.WriteLine(userL.Username);
            }
            reader.Close();
            return user;

        }

        #endregion



        #region 输入用户id返回这个用户的类
        public User UserFind(int uid)
        {
            var reader = new StreamReader("user.csv");//读取全部数据
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();//读取表头
            csv.ReadHeader();  //找到表头对应值
            User user = new User();
            while (csv.Read())
            {
                user.Uid = csv.GetField<int>("Uid");
                if (user.Uid == uid)
                {

                    user.Username = csv.GetField<string>("Username");
                    user.Sum = csv.GetField<int>("Sum");
                    // user2.Stalk = csv.GetField<Queue<int>>("stalk");
                    Console.WriteLine(user.Uid);
                    Console.WriteLine(user.Username);
                    Console.WriteLine(user.Sum);
                    return user;
                }

            }
            MessageBox.Show("未找到该用户");
            reader.Close();
            return user;
        }
        #endregion

        #region 输入一个用户Uid 并写入user表中(插入表中最后位置)
        public void UserAdd(int uid, string userName)
        {

            StreamWriter sw = new StreamWriter("user.csv", true);
            sw.WriteLine(uid);
           
            sw.Close();
        }
        #endregion


        #region 将现有用户集合写入表中（覆盖历史数据）
        public void WriteUser(List<User> users)
        {
            var records = users;
            using (var writer = new StreamWriter("user.csv"))
            {
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }
                writer.Close();
            }
            
        } 
        #endregion
    }
}

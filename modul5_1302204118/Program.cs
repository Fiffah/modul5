using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul5_1302204118
{
    using System.Diagnostics.Contracts;
    public class SayaTubeVideo
    {
        int id;
        string title;
        int playCount;

        public SayaTubeVideo(string judul)
        {
            Contract.Requires(judul != null, "input null!");
            Contract.Requires(judul.Length <= 100, "input terlalu panjang!");

            Random random = new();
            this.id = random.Next(99999);
            this.title = judul;
            this.playCount = 0;
        }

        public void increasePlayCount(int number)
        {
            Contract.Requires(number <= 10000000, "input terlalu besar!");
            try
            {
                checked
                {
                    this.playCount += number;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public int GetPlaycount()
        {
            return playCount;
        }

        public string GetTitle()
        {
            return title;
        }

        public void printVideoDetails()
        {
            Console.WriteLine("ID\t\t:" + this.id.ToString());
            Console.WriteLine("Title\t\t:" + this.title);
            Console.WriteLine("Play Count\t:" + this.playCount.ToString());
        }



        internal void IncreasePlayCount(int v)
        {
            throw new NotImplementedException();
        }
    }

    public class SayaTubeUser
    {
        private int id;
        private List<SayaTubeVideo> uploadedVideos;
        private String Username;

        public SayaTubeUser(String judul)
        {
            Random ids = new Random();
            id = ids.Next(0, 100000);
            this.Username = null;
            this.uploadedVideos = new List<SayaTubeVideo>();
        }

        public int GetTotalVideoPlayCount()
        {
            int total = 0;
            foreach (SayaTubeVideo video in this.uploadedVideos)
            {
                total += video.GetPlaycount();
            }
            return total;
        }

        public void AddVideo(SayaTubeVideo video)
        {
            uploadedVideos.Add(video);
        }

        public void printAllvideoplayCount()
        {
            for (int i = 0; i < uploadedVideos.Count; i++)
            {
                Console.WriteLine("username:" + Username);
                Console.WriteLine("video:" + (i + 1) + ":" + uploadedVideos[i]);
            }
        }
    }
    public class main
    {
        public static void Main()
        {
            SayaTubeVideo test = new(null);
            test.printVideoDetails();

            SayaTubeVideo baru = new("Tutorial bernafas menggunakan" +
                " hidung dan mulut secara bergantian ");
            baru.printVideoDetails();

            SayaTubeVideo saya = new("Tutorial Design By Contract – Rizal Rafif Setiawan.");
            saya.printVideoDetails();

            for (int i = 0; i < 4; i++)
            {
                saya.increasePlayCount(123456789);
            }
            saya.printVideoDetails();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bai10
{
    class VanBan
    {
        private string text;
        public VanBan()
        {
            text = string.Empty;
        }

        public VanBan(string st)
        {
            text = st;
        }

        public int DemSoTu()
        {
            string[] words = Regex.Split(text.Trim(),@"\s+");
            return words.Length;
        }
        public int DemSoKyTuA()
        {
            return text.ToLower().Count(c => c == 'a');
        }
        public void ChuanHoaVanBan()
        {
            text = text.Trim();
            text = Regex.Replace(text, @"\s+", " ");
        }
        public void HienThiVanBan()
        {
            Console.WriteLine(text);
        }
    }
    public static class Bai10
    {
        public static void Main()
        {
            VanBan vanBan = new VanBan("   Thi  is  a  test  string  ");

            Console.WriteLine($"So tu trong van ban: {vanBan.DemSoTu()}");
            Console.WriteLine($"So ky tu 'a' trong van ban: {vanBan.DemSoKyTuA()}");

            Console.WriteLine("Van ban sau khi chuan hoa:");
            vanBan.ChuanHoaVanBan();
            vanBan.HienThiVanBan();
        }
    }
}
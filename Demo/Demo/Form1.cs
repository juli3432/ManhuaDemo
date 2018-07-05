using Demo.Data;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            ChromeDriver chrome = new ChromeDriver();

            // tạo mới 1 truyện

            Comic comic = new Comic();
            comic.link = "http://www.cartoonmad.com/comic/6051.html";
            comic.name = " 衛府之七忍";
            comic.codeWebsite = 1; // mặc định là cartoonmad
            db.Comics.Add(comic);
            db.SaveChanges();

            var ComicRecently = db.Comics.ToList().LastOrDefault();

            crawlTrap(chrome, ComicRecently.link, ComicRecently.code);
              


            // select list trap for comic
            var listTrap = db.ComicDetails.Where(x => x.codeComic == ComicRecently.code).ToList();

            foreach (var item in listTrap)
            {
                crawlImage(chrome, item.link,item.code);
            }

        }
        Manhua_DbContext db = new Manhua_DbContext();

        //lấy link tập
        void crawlTrap(ChromeDriver chrome, string url, int codeComic)
        {

            chrome.Url = (url);
            chrome.Navigate();

            var nodeList = chrome.FindElementsByCssSelector("#info > table > tbody > tr > td > a").ToList();

            var nameComic = chrome.FindElementsByCssSelector("body > table > tbody > tr:nth-child(1) > td:nth-child(2) > table > tbody > tr:nth-child(3) > td:nth-child(2) > a:nth-child(6)").FirstOrDefault().Text + "漫畫";

            //漫畫 : truyện tranh
            foreach (var item in nodeList)
            {
                ComicDetail comic = new ComicDetail();
                comic.link = item.GetAttribute("href");
                comic.name = nameComic + "-" + item.Text;
                comic.codeComic = codeComic;

                db.ComicDetails.Add(comic);
                db.SaveChanges();
            }



        }

        // lấy link ảnh
        void crawlImage(ChromeDriver chrome, string url, int codeComicDetail)
        {

            chrome.Url = (url);
            chrome.Navigate();

            var nodeList = chrome.FindElementsByCssSelector("select[name='jump'] > option").ToList();


            var linkImage = chrome.FindElementByCssSelector("body > table > tbody > tr:nth-child(5) > td > table > tbody > tr:nth-child(1) > td:nth-child(1) > a > img").GetAttribute("src");
            //http://web4.cartoonmad.com/c8n3o733a62/1416/033/001.jpg
            string imageOrigin = linkImage.ToString().Substring(0, linkImage.Length - 7);

            for (int i = 1; i < nodeList.Count; i++)
            {
                ComicDetailImgae image = new ComicDetailImgae();

                if (i < 10)
                {
                    image.link = imageOrigin + "00" + i + ".jpg";
                }
                else if (i < 99 && i > 9)
                {
                    image.link = imageOrigin + "0" + i + ".jpg";
                }

                image.codeComicDetail = codeComicDetail;

                db.ComicDetailImgaes.Add(image);
                db.SaveChanges();

            }


        }
    }
}

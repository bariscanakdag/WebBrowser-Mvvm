using Browser.Helper;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Forms;
using HtmlAgilityPack;
using System;
using System.Collections.ObjectModel;
using Browser.Model;
using mshtml;

namespace Browser.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        #region Cunstroctor

        PageListHelper GetPageListHelper = new PageListHelper();
        private ObservableCollection<PageModel> pageList;

        public ObservableCollection<PageModel> PageList
        {
            get { return pageList; }
            set
            {
                pageList = value;

            }
        }



        public MainWindowViewModel()
        {
            PageList = GetPageListHelper.PageListGetir();

        }
        private PageModel selectItem;

        public PageModel SelectItem
        {
            get { return selectItem; }
            set
            {
                selectItem = value;
                RaisePropertyChanged(nameof(SelectItem));
            }
        }


        private string url;

        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                if (url == value) return;
                url = value;
                RaisePropertyChanged("Url");
            }
        }




        #endregion

        #region ICommand

        private ICommand veriGetirCommand;

        public ICommand VeriGetirCommand
        {
            get
            {
                return veriGetirCommand ?? (veriGetirCommand = new RelayCommand(
                   x =>
                   {
                       VeriGetir();
                   }));
            }
        }



        private ICommand urlcommand;

        public ICommand UrlCommand
        {
            get
            {
                return urlcommand ?? (urlcommand = new RelayCommand(
                   x =>
                   {
                       SiteyeGit();
                   }));
            }
        }

        #endregion

        #region Metod

        public void DoubleClickMethod()
        {

        }
        private void SiteyeGit()
        {
            Url = "http://www.buraksenyurt.com/";


        }
        WebBrowser web = new WebBrowser();
        private void VeriGetir()
        {

            web.Navigate(Url);
            web.DocumentCompleted += Web_DocumentCompleted;

        }

        private void Web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {


            string[] baslik = new string[24];
            string[] tarih = new string[24];
            string[] url = new string[24];
            for (int i = 0; i < 24; i++)
            {
                string id = ("post" + i + "");
                var text = web.Document.GetElementById(id);
                HtmlElementCollection elems = text.GetElementsByTagName("a");
                url[i] =elems[0].GetAttribute("href");

                baslik[i] = elems[0].InnerText;

                HtmlElementCollection elem = text.GetElementsByTagName("span");
                tarih[i] = elem[0].InnerText;
            }
            for (int i = 0; i < 24; i++)
            {
                PageModel model = new PageModel();
                model.Baslik = baslik[i];
                model.Tarih = tarih[i];
                PageList.Add(model);

            }

           


            ///post/atlas-ile-node-js-uzerinden-haberlesmek
        }


        #endregion


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}

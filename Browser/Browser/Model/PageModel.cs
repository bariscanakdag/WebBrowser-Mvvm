using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Browser.Model
{
    public class PageModel
    {
        private string baslik;

        public string Baslik
        {
            get { return baslik; }
            set { baslik = value; }
        }
        private string tarih;

        public string Tarih
        {
            get { return tarih; }
            set { tarih = value; }
        }


    }
}

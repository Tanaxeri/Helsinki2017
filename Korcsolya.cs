using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki2017
{
    class Korcsolya
    {

        public string _nev;
        public string _orszag;
        public double _techpontszam;
        public double _komppontszam;
        public int _levonas;
        public double _osszpont;

        public Korcsolya(string Adatsor)
        {

            string[] AdatSorElemek = Adatsor.Split(';');
            this._nev = AdatSorElemek[0];
            this._orszag = AdatSorElemek[1];
            this._techpontszam = Convert.ToDouble(AdatSorElemek[2].Replace('.' , ','));
            this._komppontszam = Convert.ToDouble(AdatSorElemek[3].Replace('.', ','));
            this._levonas = Convert.ToInt32(AdatSorElemek[4]);

        }

    }
}

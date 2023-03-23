using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSepetIslemleri.CustomTools
{
    public class Cart
    {
        Dictionary<int, CartItem> _sepetUrunlerim;

        public Cart()
        {
            _sepetUrunlerim = new Dictionary<int, CartItem>();
        }

        public List<CartItem> Sepetim
        {
            get
            {
                return _sepetUrunlerim.Values.ToList();
            }
        }

        public void SepeteEkle(CartItem item)
        {
            //Öncelikle Sepete daha önce o aynı ürün atılmış mı onu sorguluyoruz...
            if (_sepetUrunlerim.ContainsKey(item.ID))
            {
                //Bir dictionari'ye index parantezi vermek o keyi yakalamak istediğimizi bildirir.

                _sepetUrunlerim[item.ID].Amount++;
                return;
            }
            _sepetUrunlerim.Add(item.ID, item);
        }

        //AdetAzalt

        //UrunCikar

        //Ödev + Geri Al butonu


        public void Yoket(int id)
        {
            if (_sepetUrunlerim.ContainsKey(id))
            {
                _sepetUrunlerim.Remove(id);
            }
        }

        public void SepettenSil(int id)
        {
            if (_sepetUrunlerim[id].Amount>1) 
            {
                _sepetUrunlerim[id].Amount--;
                return;
            }
            _sepetUrunlerim.Remove(id);
        }

        public void MiktarArttır(int id)
        {
           
          _sepetUrunlerim[id].Amount++;
            return;
            

        }


        public decimal? TotalPrice
        {
            get
            {
                return _sepetUrunlerim.Sum(x=> x.Value.SubTotal); //Dictionary içerisindeki CartItem value'sunun SubTotal property'sini toplayarak döndürüyoruz...
            }
        }

    }
}
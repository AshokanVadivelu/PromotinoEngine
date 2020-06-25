using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserProfile.Models;
using AppConst = UserProfile.Utility.ApplicationConstants;

namespace UserProfile.Utility
{
    public class Promotion
    {
        private static Promotion instance = null;

        private static readonly object padlock = new object();
        private List<SkuMaster> SKU_Master;

        private Promotion()
        {
            SKU_Master = new List<SkuMaster>
            {
                new SkuMaster{Id =1, Unit = "A", Price =50},
                new SkuMaster{Id =2, Unit = "B", Price =30},
                new SkuMaster{Id =3, Unit = "C", Price =20},
                new SkuMaster{Id =4, Unit = "D", Price =15}
            };
        }

        public static Promotion Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new Promotion();
                        }
                    }
                }
                return instance;
            }
        }

        public SkuModel GetTotal(SkuModel model)
        {
            model.ProductAprice = GetProductAPrice(model.ProductAcount);
            model.ProductBprice = GetProductBPrice(model.ProductBcount);
            model.ProductCprice = GetProductCPrice(model.ProductCcount);
            model.ProductDprice = GetProductDPrice(model.ProductDcount);
            return model;
        }

        public int GetProductAPrice(int count)
        {
            int price = 0;
            switch (count)
            {
                case 3:
                    price = AppConst.ProductAPrimotionalPrice;
                    break;

                case 1:
                case 2:
                    price = count * SKU_Master.Where(p => p.Unit == AppConst.ProductA).Select(s => s.Price).FirstOrDefault();
                    break;

                default:
                    price = GetProductA(count);
                    break;
            }

            return price;
        }

        public int GetProductBPrice(int count)
        {
            int price = 0;
            switch (count)
            {
                case 2:
                    price = AppConst.ProductBPrimotionalPrice;
                    break;

                case 1:
                    price = count * SKU_Master.Where(p => p.Unit == AppConst.ProductB).Select(s => s.Price).FirstOrDefault();
                    break;

                default:
                    price = GetProductB(count);
                    break;
            }

            return price;
        }

        public int GetProductCPrice(int count)
        {
            return count * SKU_Master.Where(p => p.Unit == AppConst.ProductC).Select(s => s.Price).FirstOrDefault();
        }

        public int GetProductDPrice(int count)
        {
            return count * SKU_Master.Where(p => p.Unit == AppConst.ProductD).Select(s => s.Price).FirstOrDefault();
        }

        private int GetProductA(int count)
        {
            var remain = count / AppConst.AppicabalePromotionCountA;
            var discountAmount = remain * AppConst.ProductAPrimotionalPrice;
            int actualAmount = 0;
            if (count % 3 != 0)
            {
                actualAmount = (count - (remain * AppConst.AppicabalePromotionCountA)) * SKU_Master.Where(p => p.Unit == AppConst.ProductA).Select(s => s.Price).FirstOrDefault();
            }

            return discountAmount + actualAmount;

        }


        private int GetProductB(int count)
        {
            var remain = count / AppConst.AppicabalePromotionCountB;
            var discountAmount = remain * AppConst.ProductBPrimotionalPrice;
            int actualAmount = 0;
            if (count % 2 != 0)
            {
                actualAmount = (count - (remain * AppConst.AppicabalePromotionCountB)) * SKU_Master.Where(p => p.Unit == AppConst.ProductB).Select(s => s.Price).FirstOrDefault();
            }
            return discountAmount + actualAmount;

        }
    }
}
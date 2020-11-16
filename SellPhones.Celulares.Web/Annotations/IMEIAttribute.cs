﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SellPhones.Celulares.Web.Annotations
{
    public class IMEIAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var IMEI = Convert.ToString(value);

            if (IMEI.Length != 15)
                return false;
            else
            {
                /*Int32[] PosIMEI = new Int32[15];
                for (int innlop = 0; innlop < 15; innlop++)
                {
                    PosIMEI[innlop] = Convert.ToInt32(IMEI.Substring(innlop, 1));
                    if (innlop % 2 != 0) PosIMEI[innlop] = PosIMEI[innlop] * 2;
                    while (PosIMEI[innlop] > 9) PosIMEI[innlop] = (PosIMEI[innlop] % 10) + (PosIMEI[innlop] / 10);
                }

                Int32 Totalval = 0;
                foreach (Int32 v in PosIMEI) Totalval += v;
                if (0 == Totalval % 10)
                    return true;
                else*/
                    return true;
            }

        }
    }
}
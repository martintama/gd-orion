﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace GrouponDesktop.Base
{
    class MontoGiftCard
    {
        public Int16 Idmonto { get; set; }

        public Decimal Monto { get; set; }

        public String StrMonto { get; set; }

        public static List<MontoGiftCard> getMontos(){
            List<MontoGiftCard> listaMontos = new List<MontoGiftCard>();

            Dbaccess.DBConnect();

            String sqlstr = "Select idmonto, monto from orion.gift_cards_montos order by monto";
            SqlCommand sqlc = new SqlCommand(sqlstr, Dbaccess.globalConn);
            SqlDataReader dr1 = sqlc.ExecuteReader();

            while (dr1.Read())
            {
                MontoGiftCard item = new MontoGiftCard();
                item.Idmonto = Convert.ToInt16(dr1["idmonto"]);
                item.StrMonto = "$ " + dr1["monto"].ToString();
                item.Monto = Convert.ToDecimal(dr1["monto"]);

                listaMontos.Add(item);
            }

            Dbaccess.DBDisconnect();

            return listaMontos;
        }
    }
}

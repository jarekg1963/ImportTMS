
using System;
using System.Collections.Generic;

namespace c_
{

    public class ShipmentImport
    {
        public string ID_UNIQUE { get; set; }

        public string CONSIGMENT_NUMBER { get; set; }
        public string SHIPMENT_NUMBER { get; set; }
        public string FROM_COUNTRY { get; set; }
        public string TO_COUNTRY { get; set; }
        public float? KOSZT { get; set; }
        public float? KOSZT_H { get; set; }
        public string DELIVERY_NUMBER { get; set; }
        public string MODEL { get; set; }
        public string NAME { get; set; }
        public float? ILOSC { get; set; }
        public string CARRIER { get; set; }
        public string CARRIER2 { get; set; }

        public DateTime DATA { get; set; }

    }
}
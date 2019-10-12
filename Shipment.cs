using System;
using System.Collections.Generic;


namespace c_
{
    public class Shipment
    {
        public Decimal id { get; set; }
        public String CONSIGMENT_NUMBER { get; set; }
        public String SHIPMENT_NUMBER { get; set; }

        public String FROM_COUNTRY { get; set; }
        public String TO_COUNTRY { get; set; }

        public Double KOSZT { get; set; }

        public Double KOSZT_H { get; set; }

        public String DELIVERY_NUMBER { get; set; }

        public String MODEL { get; set; }

        public String NAME { get; set; }

        public String ILOSC { get; set; }

        public String CARRIER { get; set; }

        public String CARRIER2 { get; set; }

        public DateTime DATA { get; set; }


    }
}

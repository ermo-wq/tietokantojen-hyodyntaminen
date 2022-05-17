using System;

namespace Autokauppa.Model {
    public abstract class Property {            // abstract class for all car's properties
        public string Nimi { get; set; }
        public abstract Property CreateNew();        
    }

    public class Gas : Property {        
        public int ID { get; set; }

        public string Polttoaineen_nimi {
            get { return Nimi; }
            set { Nimi = value; }
        }

        public override Property CreateNew() {
            return new Gas();
        }
    }

    public class Colour : Property {
        public int ID { get; set; }
        public string Varin_nimi {
            get { return Nimi; }
            set { Nimi = value; }
        }

        public override Property CreateNew() {
            return new Colour();
        }
    }

    public class Brand : Property {
        public int ID { get; set; }
        public string Merkki {
            get { return Merkki; }
            set { Nimi = value; }
        }

        public override Property CreateNew() {
            return new Brand();
        }
    }

    public class Model : Property {
        public int ID { get; set; }
        public string AutonMallinNimi {
            get { return Nimi; }
            set { Nimi = value; }
        }
        public string AutonMerkkiID { get; set; }

        public override Property CreateNew() {
            return new Model();
        }
    }

    public class Car {
        private int ID;
        public int Mittarilukema { get; set; }
        public decimal Moottorin_tilavuus { get; set; }
        public decimal Hinta { get; set; }
        public DateTime Rekisteri_paivamaara { get; set; }
        public int AutonMerkkiID { get; set; }
        public int AutonMalliID { get; set; }
        public int VaritID { get; set; }
        public int PolttoaineID { get; set; }

        public void SetId(int value) {
            ID = value;
        }

        public int GetId() {
            return ID;
        }
    }
}

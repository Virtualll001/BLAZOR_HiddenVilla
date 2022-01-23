namespace HiddenVilla_Server.Model
{
    public class Houba
    {
        public int Id { get; set; }
        public string Jmeno { get; set; }
        public string Stanoviste { get; set; }
        public string Obdobi { get; set; }
        public bool Jedla { get; set; }
        public List<HoubaParam> HoubaParametry { get; set; }        
        public List<HoubaObchod> HoubaNakup { get; set; }
    }    
}

//TODO: jedlost časem předělat na enum
namespace GorselProgramlamaOdev21010310066.Model

{

        public class Haber
    {
        public string title { get; set; }
        public string description { get; set; }
        public string link { get; set; }
    }

    public class RootObject
    {
        public List<Haber> Items { get; set; }
    }
}

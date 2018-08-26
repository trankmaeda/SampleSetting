namespace SampleSetting.Models
{
    public class School
    {
        public string Name { get; set; }
        public BuildingSize Size { get; set; }

        public enum BuildingSize
        {
            Small,
            Default,
            Big
        }
    }
}

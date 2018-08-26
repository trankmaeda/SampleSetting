using System.Collections.Generic;

namespace SampleSetting.Models
{
    public class School
    {
        public string Name { get; set; }
        public BuildingSize Size { get; set; }
        public List<string> TypeChoices { get; set; }
        public string Type { get; set; }

        public enum BuildingSize
        {
            Small,
            Default,
            Big,
        }
    }
}

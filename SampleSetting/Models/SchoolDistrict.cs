using System.Collections.Generic;

namespace SampleSetting.Models
{
    public class SchoolDistrict
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<School> Schools { get; set; }
    }
}

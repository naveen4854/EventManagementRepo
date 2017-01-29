using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventManagement.DataModels
{
    public class AbstractSubmitModel
    {
        public string SubmittedBy { get; set; }
        public string EmailId { get; set; }
        public int Telephone { get; set; }
        public string Organisation { get; set; }
        public string DocumentName { get; set; }
        public IEnumerable<TrackDTO> Tracks { get; set; }
        public IEnumerable<CountryModel> Countries { get; set; }
        public IEnumerable<CategoryModel> Categories { get; set; }
        public IEnumerable<TitleModel> Titles { get; set; }
    }
}

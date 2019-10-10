using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MWeb_test.Models.ModelView
{
    public class MarkerCommentRepository
    {
        public Markers markers { get; set; }
        public Comments comments { get; set; }
    }

    public class DataTablestoJson
    {
        MarkerCommentRepository MarComRepo = new MarkerCommentRepository
        {

        };

        string MarkerCommentJson = JsonConvert.SerializeObject(MarComRepo);
    }
}

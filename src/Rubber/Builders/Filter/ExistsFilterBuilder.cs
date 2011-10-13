using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class ExistsFilterBuilder : IFilterBuilder
    {
        private string _name;
        private string _filterName;


        public ExistsFilterBuilder(string name)
        {
            _name = name;
        }

        public ExistsFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("exists", new JObject(new JProperty("field",_name))));
            
            if(_filterName != null)
            {
                ((JObject)content.SelectToken("exists")).Add(new JProperty("_name",_filterName));
            }
            
            return content;
        }
    }
}

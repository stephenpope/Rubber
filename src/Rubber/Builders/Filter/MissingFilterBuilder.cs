using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class MissingFilterBuilder : IFilterBuilder
    {
        private string _name;
        private string _filterName;


        public MissingFilterBuilder(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Sets the filter name for the filter that can be used when searching for matched_filters per hit.
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns></returns>
        public MissingFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("missing", new JObject(new JProperty("field", _name))));

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("missing")).Add(new JProperty("_name", _filterName));
            }

            return content;
        }
    }
}
using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Filter
{
    public class ExistsFilterBuilder : IFilterBuilder
    {
        private readonly string _name;
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

        #region IFilterBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("exists", new JObject(new JProperty("field", _name))));

            if (_filterName != null)
            {
                content["exists"]["_name"] = _filterName;
            }

            return content;
        }

        #endregion
    }
}
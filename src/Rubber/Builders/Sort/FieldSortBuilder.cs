using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Sort
{
    public class FieldSortBuilder : ISortBuilder
    {
        private readonly string _fieldName;
        private SortOrder _order;
        private object _missing;

        public FieldSortBuilder(string fieldName)
        {
            _fieldName = fieldName;
        }

        public ISortBuilder Order(SortOrder order)
        {
            _order = order;
            return this;
        }

        public ISortBuilder Missing(object missing)
        {
            _missing = missing;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty(_fieldName, new JObject()));

            if(_order != SortOrder.ASC)
            {
                ((JObject)content.SelectToken(_fieldName)).Add(new JProperty("order","desc"));
            }

            if(_missing != null)
            {
                ((JObject)content.SelectToken(_fieldName)).Add(new JProperty("missing", _missing));    
            }

            return content;
        }
    }
}
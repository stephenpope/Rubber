using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Sort
{
    public class FieldSortBuilder : ISortBuilder
    {
        private readonly string _fieldName;
        private object _missing;
        private SortOrder _order;

        public FieldSortBuilder(string fieldName)
        {
            _fieldName = fieldName;
        }

        #region ISortBuilder Members

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
            var content = new JObject();
            content[_fieldName] = new JObject();

            if (_order != SortOrder.ASC)
            {
                content[_fieldName]["order"] = "desc";
            }

            if (_missing != null)
            {
                content[_fieldName]["missing"] = new JValue(_missing);
            }

            return content;
        }

        #endregion
    }
}
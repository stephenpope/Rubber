using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Query
{
    public class TermQueryBuilder : IQueryBuilder
    {
        private readonly string _name;

        private readonly object _value;

        private float? _boost;

        public TermQueryBuilder(string name, string value) : this(name, (object)value) { }

        public TermQueryBuilder(string name, int value) : this(name, (object)value) { }

        public TermQueryBuilder(string name, long value) : this(name, (object)value) { }

        public TermQueryBuilder(string name, float value) : this(name, (object)value) { }

        public TermQueryBuilder(string name, double value) : this(name, (object)value) { }

        public TermQueryBuilder(string name, bool value) : this(name, (object)value) { }

        public TermQueryBuilder(string name, object value)
        {
            _name = name;
            _value = value;
        }

        #region IQueryBuilder Members

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("term", new JObject()));

            if (_boost == null)
            {
                ((JObject)content.SelectToken("term")).Add(new JProperty(_name, _value));
            }
            else
            {
                ((JObject)content.SelectToken("term")).Add(new JProperty(_name, new JObject(new JProperty("value", _value), new JProperty("boost", _boost))));
            }

            return content;
        }

        #endregion

        public TermQueryBuilder Boost(float boost)
        {
            _boost = boost;
            return this;
        }
    }
}
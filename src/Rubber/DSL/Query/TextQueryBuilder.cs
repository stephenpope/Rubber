using Newtonsoft.Json.Linq;

namespace Rubber.DSL.Query
{
    public class TextQueryBuilder : IQueryBuilder
    {
        private readonly string _name;

        private readonly object _text;

        private string _analyzer;

        private float? _boost;

        private string _fuzziness;

        private int? _maxExpansions;
        private Operator _operator;
        private int? _prefixLength;
        private int? _slop;
        private TextQueryType _type;

        public TextQueryBuilder(string fieldName, object text)
        {
            _operator = Rubber.Operator.OR;
            _type = TextQueryType.BOOLEAN;
            _name = fieldName;
            _text = text;
        }

        #region IQueryBuilder Members

        public object ToJsonObject()
        {
            var content =
                new JObject(new JProperty("text",
                                          new JObject(
                                              new JObject(new JProperty(_name,
                                                                        new JObject(new JProperty("query", _text)))))));

            if (_type != TextQueryType.BOOLEAN)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("type", _type.ToString().ToLower()));
            }

            if (_operator != Rubber.Operator.OR)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("operator", "and"));
            }

            if (_boost != null)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("boost", _boost));
            }

            if (_analyzer != null)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("analyzer", _analyzer));
            }

            if (_slop != null)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("slop", _slop));
            }

            if (_fuzziness != null)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("fuzziness", _fuzziness));
            }

            if (_prefixLength != null)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("prefix_length", _prefixLength));
            }

            if (_maxExpansions != null)
            {
                ((JObject) content.SelectToken("text.location")).Add(new JProperty("max_expansions", _maxExpansions));
            }

            return content;
        }

        #endregion

        public TextQueryBuilder Type(TextQueryType type)
        {
            _type = type;
            return this;
        }

        public TextQueryBuilder Operator(Operator @operator)
        {
            _operator = @operator;
            return this;
        }

        public TextQueryBuilder Analyzer(string analyzer)
        {
            _analyzer = analyzer;
            return this;
        }

        public TextQueryBuilder Boost(float boost)
        {
            _boost = boost;
            return this;
        }

        public TextQueryBuilder Slop(int slop)
        {
            _slop = slop;
            return this;
        }

        public TextQueryBuilder Fuzziness(object fuzziness)
        {
            _fuzziness = fuzziness.ToString();
            return this;
        }

        public TextQueryBuilder PrefixLength(int prefixLength)
        {
            _prefixLength = prefixLength;
            return this;
        }

        public TextQueryBuilder MaxExpansions(int maxExpansions)
        {
            _maxExpansions = maxExpansions;
            return this;
        }
    }
}
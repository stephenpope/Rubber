using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Rubber.Builders.Filter;

namespace Rubber.Builders.Facet
{
    public class TermsFacetBuilder : AbstractFacetBuilder
    {
        private string _fieldName;
        private string[] _fieldsNames;
        private int _size = 10;
        private bool _allTerms;
        private object[] _exclude;
        private string _regex;
        private int _regexFlags = 0;
        private ComparatorType _comparatorType;
        private string _script;
        private string _lang;
        private Dictionary<string, object> _params;
        string _executionHint;

        public TermsFacetBuilder(string name) : base(name)
        {
            _comparatorType = ComparatorType.COUNT;
        }

        public TermsFacetBuilder Global(bool global)
        {
            base.Global(global);
            return this;
        }

        public TermsFacetBuilder Scope(string scope)
        {
            base.Scope(scope);
            return this;
        }

        public TermsFacetBuilder FacetFilter(IFilterBuilder filter)
        {
            _facetFilter = filter;
            return this;
        }

        public TermsFacetBuilder Nested(string nested)
        {
            _nested = nested;
            return this;
        }

        public TermsFacetBuilder Field(string field)
        {
            _fieldName = field;
            return this;
        }

        public TermsFacetBuilder Fields(IEnumerable<string> fields)
        {
            _fieldsNames = fields.ToArray();
            return this;
        }

        public TermsFacetBuilder ScriptField(string scriptField)
        {
            _script = scriptField;
            return this;
        }

        public TermsFacetBuilder Exclude(params object[] exclude)
        {
            _exclude = exclude;
            return this;
        }

        public TermsFacetBuilder Size(int size)
        {
            _size = size;
            return this;
        }

        public TermsFacetBuilder Regex(string regex)
        {
            return Regex(regex, 0);
        }

        public TermsFacetBuilder Regex(string regex, int flags)
        {
            _regex = regex;
            _regexFlags = flags;
            return this;
        }

        public TermsFacetBuilder Order(ComparatorType type)
        {
            _comparatorType = type;
            return this;
        }

        public TermsFacetBuilder Script(string script)
        {
            _script = script;
            return this;
        }

        public TermsFacetBuilder ScriptParam(string name, object value)
        {
            if(_params == null)
            {
                _params = new Dictionary<string, object>();
            }

            _params.Add(name,value);
            return this;
        }

        public TermsFacetBuilder Lang(string lang)
        {
            _lang = lang;
            return this;
        }

        public TermsFacetBuilder ExecutionHint(string executionHint)
        {
            _executionHint = executionHint;
            return this;
        }

        public TermsFacetBuilder AllTerms(bool allTerms)
        {
            _allTerms = allTerms;
            return this;
        }

        public override object ToJsonObject()
        {
            if (_fieldName == null && _fieldsNames == null && _script == null)
            {
                throw new InvalidOperationException("field/fields/script must be set on terms facet for facet [" + _name + "]");
            }

            var content = new JObject(new JProperty("terms", new JObject()));

            if(_fieldsNames != null)
            {
                if(_fieldsNames.Count() > 0)
                {
                    if(_fieldsNames.Count() == 1)
                    {
                        ((JObject)content.SelectToken("terms")).Add(new JProperty("field", _fieldsNames[0]));
                    }
                    else
                    {
                        ((JObject)content.SelectToken("terms")).Add(new JProperty("fields", new JArray(_fieldsNames)));
                    }
                }
            }else if(_fieldName != null)
            {
                ((JObject)content.SelectToken("terms")).Add(new JProperty("field", _fieldName));       
            }

            ((JObject)content.SelectToken("terms")).Add(new JProperty("size", _size));

            if(_exclude != null)
            {
                ((JObject)content.SelectToken("terms")).Add(new JProperty("exclude",new JArray(_exclude)));    
            }

            if (_comparatorType != ComparatorType.COUNT)
            {
                ((JObject)content.SelectToken("terms")).Add(new JProperty("order", _comparatorType.ToString().ToLower()));
            }

            if(_regex != null)
            {
                ((JObject)content.SelectToken("terms")).Add(new JProperty("regex", _regex));

                if(_regexFlags != 0)
                {
                    ((JObject)content.SelectToken("terms")).Add(new JProperty("regex_flags", Common.Regex.FlagsToString(_regexFlags)));
                }
            }

            if(_script != null)
            {
                ((JObject)content.SelectToken("terms")).Add(new JProperty("script", _script));

                if (_lang != null) 
                {
                    ((JObject)content.SelectToken("terms")).Add(new JProperty("lang", _lang));
                }
                if (_params != null) 
                {
                    ((JObject)content.SelectToken("terms")).Add(new JProperty("params",new JObject())); 

                    foreach (var param in _params)
                    {
                        ((JObject)content.SelectToken("terms.params")).Add(new JProperty(param.Key, param.Value));    
                    } 
                }
            }

            if (_allTerms)
            {
                ((JObject)content.SelectToken("terms")).Add(new JProperty("all_terms", _allTerms));
            }

            if (_executionHint != null)
            {
                ((JObject)content.SelectToken("terms")).Add(new JProperty("execution_hint", _executionHint));
            }

            return AddFilterFacetAndGlobal(content);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Rubber.DSL.Filter;

namespace Rubber.DSL.Facet
{
    public class TermsFacetBuilder : AbstractFacetBuilder
    {
        private bool _allTerms;
        private ComparatorType _comparatorType;
        private object[] _exclude;
        private string _executionHint;
        private string _fieldName;
        private string[] _fieldsNames;
        private string _lang;
        private Dictionary<string, object> _params;
        private string _regex;
        private int _regexFlags;
        private string _script;
        private int _size = 10;

        public TermsFacetBuilder(string name) : base(name)
        {
            _comparatorType = ComparatorType.COUNT;
        }

        public new TermsFacetBuilder Global(bool global)
        {
            base.Global(global);
            return this;
        }

        public new TermsFacetBuilder Scope(string scope)
        {
            base.Scope(scope);
            return this;
        }

        public new TermsFacetBuilder Filter(IFilterBuilder filter)
        {
            _facetFilter = filter;
            return this;
        }

        public new TermsFacetBuilder Nested(string nested)
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
            if (_params == null)
            {
                _params = new Dictionary<string, object>();
            }

            _params.Add(name, value);
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
                throw new SearchBuilderException("field/fields/script must be set on terms facet for facet [" + _name + "]");
            }

            var content = new JObject(new JProperty("terms", new JObject()));

            if (_fieldsNames != null)
            {
                if (_fieldsNames.Count() > 0)
                {
                    if (_fieldsNames.Count() == 1)
                    {
                        content["terms"]["field"] = _fieldsNames[0];
                    }
                    else
                    {
                        content["terms"]["fields"] = new JArray(_fieldsNames);
                    }
                }
            }
            else if (_fieldName != null)
            {
                content["terms"]["field"] = _fieldName;
            }

            content["terms"]["size"] = _size;

            if (_exclude != null)
            {
                content["terms"]["exclude"] = new JArray(_exclude);
            }

            if (_comparatorType != ComparatorType.COUNT)
            {
                content["terms"]["order"] = _comparatorType.ToString().ToLower();
            }

            if (_regex != null)
            {
                content["terms"]["regex"] = _regex;

                if (_regexFlags != 0)
                {
                    content["terms"]["regex_flags"] = Common.Regex.FlagsToString(_regexFlags);
                }
            }

            if (_script != null)
            {
                content["terms"]["script"] = _script;

                if (_lang != null)
                {
                    content["terms"]["lang"] = _lang;
                }
                if (_params != null)
                {
                    content["terms"]["params"] = new JObject();

                    foreach (var param in _params)
                    {
                        content["terms"]["params"][param.Key] = param.Value as JObject;
                    }
                }
            }

            if (_allTerms)
            {
                content["terms"]["all_terms"] = _allTerms;
            }

            if (_executionHint != null)
            {
                content["terms"]["execution_hint"] = _executionHint;
            }

            return AddFilterFacetAndGlobal(content);
        }
    }
}
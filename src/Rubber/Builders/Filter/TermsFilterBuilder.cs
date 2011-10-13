﻿using System.Linq;
using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class TermsFilterBuilder : IFilterBuilder
    {
        private readonly string _name;
        private readonly object[] _values;
        private bool _cache;
        private string _cacheKey;
        private string _filterName;

        /// <summary>
        /// A filer for a field based on several terms matching on any of them.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public TermsFilterBuilder(string name, params string[] values) : this(name, (object[]) values)
        {
        }

        /// <summary>
        /// A filer for a field based on several terms matching on any of them.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public TermsFilterBuilder(string name, params int[] values)
        {
            _name = name;
            _values = values.Select(t => (object) t).ToArray();
        }

        /// <summary>
        /// A filer for a field based on several terms matching on any of them.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public TermsFilterBuilder(string name, params long[] values)
        {
            _name = name;
            _values = values.Select(t => (object) t).ToArray();
        }

        /// <summary>
        /// A filer for a field based on several terms matching on any of them.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public TermsFilterBuilder(string name, params double[] values)
        {
            _name = name;
            _values = values.Select(t => (object) t).ToArray();
        }

        /// <summary>
        /// A filer for a field based on several terms matching on any of them.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public TermsFilterBuilder(string name, params float[] values)
        {
            _name = name;
            _values = values.Select(t => (object) t).ToArray();
        }

        /// <summary>
        /// A filer for a field based on several terms matching on any of them.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="values"></param>
        public TermsFilterBuilder(string name, params object[] values)
        {
            _name = name;
            _values = values;
        }

        public TermsFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public TermsFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public TermsFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("terms", new JObject(new JProperty(_name, new JArray(_values)))));

            if (_filterName != null)
            {
                ((JObject) content.SelectToken("terms")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject) content.SelectToken("terms")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject) content.SelectToken("terms")).Add(new JProperty("_cache_key", _cacheKey));
            }

            return content;
        }
    }
}
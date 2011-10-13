﻿using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Query
{
    public class MatchAllQueryBuilder : IQueryBuilder
    {
        private string _normsField;
        private float? _boost;

        public MatchAllQueryBuilder NormsField(string normsField)
        {
            _normsField = normsField;
            return this;
        }

        public MatchAllQueryBuilder Boost(float boost)
        {
            _boost = boost;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("match_all", new JObject()));

            if(_boost != null)
            {
                ((JObject)content.SelectToken("match_all")).Add(new JProperty("boost", _boost));
            }

            if (_normsField != null)
            {
                ((JObject)content.SelectToken("match_all")).Add(new JProperty("norms_field", _normsField));
            }

            return content;
        }
    }
}
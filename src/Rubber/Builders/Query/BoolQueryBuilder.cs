using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Query
{
    public class BoolQueryBuilder : IQueryBuilder
    {
        private List<IQueryBuilder> _mustClauses = new List<IQueryBuilder>();

        private List<IQueryBuilder> _mustNotClauses = new List<IQueryBuilder>();

        private List<IQueryBuilder> _shouldClauses = new List<IQueryBuilder>();

        private float? _boost;

        private bool _disableCoord;

        private int? _minimumNumberShouldMatch;

        public BoolQueryBuilder Must(IQueryBuilder queryBuilder)
        {
            _mustClauses.Add(queryBuilder);
            return this;
        }

        public BoolQueryBuilder MustNot(IQueryBuilder queryBuilder)
        {
            _mustNotClauses.Add(queryBuilder);
            return this;
        }

        public BoolQueryBuilder Should(IQueryBuilder queryBuilder)
        {
            _shouldClauses.Add(queryBuilder);
            return this;
        }

        public BoolQueryBuilder Boost(float boost)
        {
            _boost = boost;
            return this;
        }

        public BoolQueryBuilder DisableCoord(bool disableCoord)
        {
            _disableCoord = disableCoord;
            return this;
        }

        public BoolQueryBuilder MinimumNumberShouldMatch(int minimumNumberShouldMatch)
        {
            _minimumNumberShouldMatch = minimumNumberShouldMatch;
            return this;
        }

        public bool HasClauses()
        {
            return (_mustClauses.Count > 0) || (_mustNotClauses.Count > 0) || (_shouldClauses.Count > 0);
        }


        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("bool", new JObject()));

            ArrayToObject("must", _mustClauses, content);
            ArrayToObject("must_not", _mustNotClauses, content);
            ArrayToObject("should", _shouldClauses, content);

            if (_boost != null)
            {
                ((JObject)content.SelectToken("bool")).Add(new JProperty("boost", _boost));
            }

            if (_disableCoord)
            {
                ((JObject)content.SelectToken("bool")).Add(new JProperty("disable_coord", _disableCoord));
            }

            if (_minimumNumberShouldMatch != null)
            {
                ((JObject)content.SelectToken("bool")).Add(new JProperty("minimum_number_should_match", _minimumNumberShouldMatch));
            }

            return content;
        }

        public object ArrayToObject(string field, IList<IQueryBuilder> array, object contentObject)
        {
            var content = (JObject) contentObject;

            if(array.Count == 0)
            {
                return content;
            }

            if(array.Count == 1)
            {
                ((JObject)content.SelectToken("bool")).Add(new JProperty(field, array[0].ToJsonObject()));     
            }
            else
            {
                ((JObject)content.SelectToken("bool")).Add(new JProperty(field, new JArray())); 

                foreach (var item in array)
                {
                    ((JArray)content.SelectToken("bool."+field)).Add(item.ToJsonObject());    
                }
            }

            return content;
        }
    }
}
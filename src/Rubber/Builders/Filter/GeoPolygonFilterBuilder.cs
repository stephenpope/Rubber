using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Rubber.Common;

namespace Rubber.Builders.Filter
{
    public class GeoPolygonFilterBuilder : IFilterBuilder
    {
        private readonly string _name;
        private readonly List<Point> _points = new List<Point>();
        private bool _cache;
        private string _cacheKey;
        private string _filterName;

        public GeoPolygonFilterBuilder(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Adds a point with lat and lon
        /// </summary>
        /// <param name="lat">The latitude</param>
        /// <param name="lon">The longitude</param>
        /// <returns></returns>
        public GeoPolygonFilterBuilder AddPoint(double lat, double lon)
        {
            _points.Add(new Point(lat, lon));
            return this;
        }

        public GeoPolygonFilterBuilder AddPoint(string geohash)
        {
            var values = GeoHashUtils.Decode(geohash);
            return AddPoint(values[0], values[1]);
        }

        /// <summary>
        /// Sets the filter name for the filter that can be used when searching for matched_filters per hit.
        /// </summary>
        /// <param name="filterName"></param>
        /// <returns></returns>
        public GeoPolygonFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        /// <summary>
        /// Should the filter be cached or not. Defaults to false.
        /// </summary>
        /// <param name="cache"></param>
        /// <returns></returns>
        public GeoPolygonFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public GeoPolygonFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("geo_polygon", new JObject()));

            ((JObject) content.SelectToken("geo_polygon")).Add(new JProperty(_name, new JObject(new JProperty("points",new JArray(_points.Select(t=>new JArray(t.Lon,t.Lat)))))));

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("geo_polygon")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("geo_polygon")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("geo_polygon")).Add(new JProperty("_cache_key", _cacheKey));
            }
            
            return content;
        }
    }
}
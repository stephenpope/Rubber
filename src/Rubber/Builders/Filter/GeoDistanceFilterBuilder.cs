
using Newtonsoft.Json.Linq;

namespace Rubber.Builders.Filter
{
    public class GeoDistanceFilterBuilder : IFilterBuilder
    {
        private readonly string _name;
        private string _distance;
        private double _lat;
        private double _lon;
        private string _geohash;
        private GeoDistance _geoDistance;
        private string _optimizeBbox;
        private bool _cache;
        private string _cacheKey;
        private string _filterName;

        public GeoDistanceFilterBuilder(string name)
        {
           _name = name;
           _geoDistance = Rubber.GeoDistance.ARC;
        }

        public GeoDistanceFilterBuilder Point(double lat, double lon)
        {
            _lat = lat;
            _lon = lon;
            return this;
        }

        public GeoDistanceFilterBuilder Lat(double lat)
        {
            _lat = lat;
            return this;
        }

        public GeoDistanceFilterBuilder Lon(double lon)
        {
            _lon = lon;
            return this;
        }

        public GeoDistanceFilterBuilder Distance(string distance)
        {
            _distance = distance;
            return this;
        }

        public GeoDistanceFilterBuilder Distance(double distance, DistanceUnit unit)
        {
            if(unit == DistanceUnit.KILOMETERS)
            {
                _distance = distance + "km";
            }
            else
            {
                _distance = distance + "mi";
            }

            return this;
        }

        public GeoDistanceFilterBuilder Geohash(string geohash)
        {
            _geohash = geohash;
            return this;
        }

        public GeoDistanceFilterBuilder GeoDistance(GeoDistance geoDistance)
        {
            _geoDistance = geoDistance;
            return this;
        }

        public GeoDistanceFilterBuilder OptimizeBbox(string optimizeBbox)
        {
            _optimizeBbox = optimizeBbox;
            return this;
        }

        public GeoDistanceFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public GeoDistanceFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public GeoDistanceFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("geo_distance", new JObject()));

            if(_geohash != null)
            {
                ((JObject)content.SelectToken("geo_distance")).Add(new JProperty(_name, _geohash));
            }
            else
            {
                ((JObject)content.SelectToken("geo_distance")).Add(new JProperty(_name, new JArray(_lon, _lat)));     
            }

            ((JObject)content.SelectToken("geo_distance")).Add(new JProperty("distance", _distance));
  
            if(_geoDistance != Rubber.GeoDistance.ARC)
            {
                ((JObject)content.SelectToken("geo_distance")).Add(new JProperty("distance_type", _geoDistance.ToString().ToLower()));    
            }

            if (_optimizeBbox != null)
            {
                ((JObject)content.SelectToken("geo_distance")).Add(new JProperty("optimize_bbox", _optimizeBbox));
            }

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("geo_distance")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("geo_distance")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("geo_distance")).Add(new JProperty("_cache_key", _cacheKey));
            }

            return content;
        }
    }
}
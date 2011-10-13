

using System;
using Newtonsoft.Json.Linq;
using Rubber.Common;

namespace Rubber.Builders.Filter
{
    public class GeoBoundingBoxFilterBuilder : IFilterBuilder
    {

        private readonly string _name;
        private Point _topLeft;
        private string _topLeftGeohash;
        private Point _bottomRight;
        private string _bottomRightGeohash;
        private bool _cache;
        private string _cacheKey;
        private string _filterName;
        private string _type;

        public GeoBoundingBoxFilterBuilder(string name)
        {
            _name = name;
        }

        public GeoBoundingBoxFilterBuilder TopLeft(double lat, double lon)
        {
            _topLeft = new Point { Lat = lat, Lon = lon };
            return this;
        }

        public GeoBoundingBoxFilterBuilder BottomRight(double lat, double lon)
        {
            _bottomRight = new Point { Lat = lat, Lon = lon };
            return this;
        }

        public GeoBoundingBoxFilterBuilder TopLeft(string geohash)
        {
            _topLeftGeohash = geohash;
            return this;
        }

        public GeoBoundingBoxFilterBuilder BottomRight(string geohash)
        {
            _bottomRightGeohash = geohash;
            return this;
        }

        public GeoBoundingBoxFilterBuilder FilterName(string filterName)
        {
            _filterName = filterName;
            return this;
        }

        public GeoBoundingBoxFilterBuilder Cache(bool cache)
        {
            _cache = cache;
            return this;
        }

        public GeoBoundingBoxFilterBuilder CacheKey(string cacheKey)
        {
            _cacheKey = cacheKey;
            return this;
        }

        public GeoBoundingBoxFilterBuilder Type(string type)
        {
            _type = type;
            return this;
        }

        public object ToJsonObject()
        {
            var content = new JObject(new JProperty("geo_bbox", new JObject(new JProperty(_name,new JObject()))));

            if(_topLeftGeohash != null)
            {
                ((JObject)content.SelectToken("geo_bbox." + _name)).Add(new JProperty("top_left",_topLeftGeohash));
            }
            else if(_topLeft != null)
            {
                ((JObject)content.SelectToken("geo_bbox." + _name)).Add(new JProperty("top_left", new JArray(_topLeft.Lon,_topLeft.Lat)));    
            }
            else
            {
                throw new NotImplementedException("Need to add custom errors! - geo_bounding_box requires 'top_left' to be set");
            }

            if (_bottomRightGeohash != null)
            {
                ((JObject)content.SelectToken("geo_bbox." + _name)).Add(new JProperty("bottom_right", _bottomRightGeohash));
            }
            else if (_bottomRight != null)
            {
                ((JObject)content.SelectToken("geo_bbox." + _name)).Add(new JProperty("bottom_right", new JArray(_bottomRight.Lon, _bottomRight.Lat)));
            }
            else
            {
                throw new NotImplementedException("Need to add custom errors! - geo_bounding_box requires 'bottom_right' to be set");
            }

            if (_filterName != null)
            {
                ((JObject)content.SelectToken("geo_bbox")).Add(new JProperty("_name", _filterName));
            }

            if (_cache)
            {
                ((JObject)content.SelectToken("geo_bbox")).Add(new JProperty("_cache", _cache));
            }

            if (_cacheKey != null)
            {
                ((JObject)content.SelectToken("geo_bbox")).Add(new JProperty("_cache_key", _cacheKey));
            }

            if (_type != null)
            {
                ((JObject)content.SelectToken("geo_bbox")).Add(new JProperty("type", _cacheKey));
            }

            return content;
        }
    }
}
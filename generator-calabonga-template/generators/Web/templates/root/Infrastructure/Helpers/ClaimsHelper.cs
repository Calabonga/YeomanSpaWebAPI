using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace <%= projectName %>.Web.Infrastructure.Helpers {
    public class ClaimsHelper {
        public static IEnumerable<Claim> CreateClaims<T>(T entity, IEnumerable<Claim> additionalClaims = null) {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var result = new List<Claim>();
            if (additionalClaims != null) result.AddRange(additionalClaims);
            var properties = typeof(T).GetProperties().Where(t => t.PropertyType.IsPrimitive
                    || t.PropertyType.IsValueType || (t.PropertyType == typeof(string)));
            var items = from property in properties
                        let value = property.GetValue(entity)
                        where value != null
                        select new Claim(property.Name, value?.ToString());
            result.AddRange(items);
            return result;
        }
    }
}

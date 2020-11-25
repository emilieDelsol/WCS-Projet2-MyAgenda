using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace projet2Appointment.Extensions
{
    public static class SqlCommandExtensions
    {
        /// <summary>
        /// Adds a value to the end of the <see cref="System.Data.SqlClient.SqlParameterCollection">SqlParameterCollection</see>. Fills with DBNull if value is null
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static SqlParameter AddWithNullValue(this SqlParameterCollection parameters, String name, Object value)
        {
            return parameters.AddWithDefaultValue(name, value, DBNull.Value);
        }

        /// <summary>
        /// Adds a value to the end of the <see cref="System.Data.SqlClient.SqlParameterCollection">SqlParameterCollection</see>
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="name">Parameter name</param>
        /// <param name="value">Parameter value</param>
        /// <param name="defaultValue">Replacement for value if value is null</param>
        /// <returns>A <see cref="System.Data.SqlClient.SqlParameter"/> object</returns>
        public static SqlParameter AddWithDefaultValue(this SqlParameterCollection parameters, String name, Object value, Object defaultValue)
        {
            if (value is null)
            {
                value = defaultValue;
            }

            return parameters.AddWithValue(name, value);
        }
    }
}

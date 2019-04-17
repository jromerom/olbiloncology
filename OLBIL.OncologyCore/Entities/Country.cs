﻿namespace OLBIL.OncologyDomain.Entities
{
    public class Country : BaseEntity
    {
        /// <summary>
        /// Autogenerated ID in the database
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// The 3 character ISO code for this country
        /// </summary>
        public string ISOCode3 { get; set; }

        /// <summary>
        /// The 2 character ISO code for this country
        /// </summary>
        public string ISOCode2 { get; set; }

        /// <summary>
        /// The name of the country in English
        /// </summary>
        public string NameEn { get; set; }

        /// <summary>
        /// The name of the country in Spanish
        /// </summary>
        public string NameEs { get; set; }
    }
}

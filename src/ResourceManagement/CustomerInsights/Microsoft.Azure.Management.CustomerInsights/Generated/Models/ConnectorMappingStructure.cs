// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.CustomerInsights.Models
{
    using Azure;
    using Management;
    using CustomerInsights;
    using Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Connector mapping property structure.
    /// </summary>
    public partial class ConnectorMappingStructure
    {
        /// <summary>
        /// Initializes a new instance of the ConnectorMappingStructure class.
        /// </summary>
        public ConnectorMappingStructure() { }

        /// <summary>
        /// Initializes a new instance of the ConnectorMappingStructure class.
        /// </summary>
        /// <param name="propertyName">The property name of the mapping
        /// entity.</param>
        /// <param name="columnName">The column name of the import
        /// file.</param>
        /// <param name="customFormatSpecifier">Custom format specifier for
        /// input parsing.</param>
        /// <param name="isEncrypted">Indicates if the column is
        /// encrypted.</param>
        public ConnectorMappingStructure(string propertyName, string columnName, string customFormatSpecifier = default(string), bool? isEncrypted = default(bool?))
        {
            PropertyName = propertyName;
            ColumnName = columnName;
            CustomFormatSpecifier = customFormatSpecifier;
            IsEncrypted = isEncrypted;
        }

        /// <summary>
        /// Gets or sets the property name of the mapping entity.
        /// </summary>
        [JsonProperty(PropertyName = "propertyName")]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the column name of the import file.
        /// </summary>
        [JsonProperty(PropertyName = "columnName")]
        public string ColumnName { get; set; }

        /// <summary>
        /// Gets or sets custom format specifier for input parsing.
        /// </summary>
        [JsonProperty(PropertyName = "customFormatSpecifier")]
        public string CustomFormatSpecifier { get; set; }

        /// <summary>
        /// Gets or sets indicates if the column is encrypted.
        /// </summary>
        [JsonProperty(PropertyName = "isEncrypted")]
        public bool? IsEncrypted { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (PropertyName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PropertyName");
            }
            if (ColumnName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ColumnName");
            }
        }
    }
}


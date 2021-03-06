﻿#region References

using System.Configuration;

#endregion

namespace Raspberry.IO.GeneralPurpose.Configuration
{
    /// <summary>
    /// Represents the configuration of the GPIO connection.
    /// </summary>
    public class GpioConnectionConfigurationSection : ConfigurationSection
    {
        #region Constants

        /// <summary>
        /// The default poll interval, in milliseconds.
        /// </summary>
        public const decimal DefaultPollInterval = 50.0m;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the driver type.
        /// </summary>
        /// <value>
        /// The name of the driver type.
        /// </value>
        [ConfigurationProperty("driver")]
        public string DriverTypeName
        {
            get { return (string) this["driver"]; }
            set { this["driver"] = value; }
        }

        /// <summary>
        /// Gets or sets the board revision.
        /// </summary>
        /// <value>
        /// The board revision.
        /// </value>
        [ConfigurationProperty("boardRevision")]
        public string BoardRevision
        {
            get { return (string) this["boardRevision"]; }
            set { this["boardRevision"] = value; }
        }

        /// <summary>
        /// Gets or sets the poll interval, in milliseconds.
        /// </summary>
        /// <value>
        /// The poll interval, in millisecond.
        /// </value>
        /// <remarks>
        /// Default value is 50ms.
        /// Values lower than 1ms may be specified on Raspberry Pi using decimal notation.
        /// </remarks>
        [ConfigurationProperty("pollInterval", DefaultValue = "50")]
        public decimal PollInterval
        {
            get { return (decimal)this["pollInterval"]; }
            set { this["pollInterval"] = value; }
        }

        #endregion
    }
}

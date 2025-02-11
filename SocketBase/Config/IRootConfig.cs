﻿using System.Configuration;
using System.Collections.Specialized;

namespace SuperSocket.SocketBase.Config
{
    /// <summary>
    /// The root configuration interface
    /// </summary>
    public partial interface IRootConfig
    {
        /// <summary>
        /// Gets the max working threads.
        /// </summary>
        int MaxWorkingThreads { get; }

        /// <summary>
        /// Gets the min working threads.
        /// </summary>
        int MinWorkingThreads { get; }

        /// <summary>
        /// Gets the max completion port threads.
        /// </summary>
        int MaxCompletionPortThreads { get; }

        /// <summary>
        /// Gets the min completion port threads.
        /// </summary>
        int MinCompletionPortThreads { get; }


        /// <summary>
        /// Gets a value indicating whether [disable performance data collector].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [disable performance data collector]; otherwise, <c>false</c>.
        /// </value>
        bool DisablePerformanceDataCollector { get; }

        /// <summary>
        /// Gets the performance data collect interval, in seconds.
        /// </summary>
        int PerformanceDataCollectInterval { get; }


        /// <summary>
        /// Gets the log factory name.
        /// </summary>
        /// <value>
        /// The log factory.
        /// </value>
        string LogFactory { get; }



        /// <summary>
        /// Gets the option elements.
        /// </summary>
        NameValueCollection OptionElements { get; }

        /// <summary>
        /// Gets the child config.
        /// </summary>
        /// <typeparam name="TConfig">The type of the config.</typeparam>
        /// <param name="childConfigName">Name of the child config.</param>
        /// <returns></returns>
        TConfig GetChildConfig<TConfig>(string childConfigName)
            where TConfig : ConfigurationElement, new();


        /// <summary>
        /// Gets the default culture for all server instances.
        /// </summary>
        /// <value>
        /// The default culture.
        /// </value>
        string DefaultCulture { get; }
    }
}

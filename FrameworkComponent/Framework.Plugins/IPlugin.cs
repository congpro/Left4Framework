/******************************************************************************
 *  作者：       Bluexray
 *  创建时间：   2012/4/8 23:10:38
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Plugins
{
    /// <summary>
    /// Interface denoting plug-in attributes that are displayed throughout 
    /// the editing interface.
    /// </summary>
    public interface IPlugin
    {
        /// <summary>
        /// Gets or sets the plugin descriptor
        /// </summary>
        PluginDescriptor PluginDescriptor { get; set; }

        /// <summary>
        /// Install plugin
        /// </summary>
        void Install();

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        void Uninstall();
    }
}

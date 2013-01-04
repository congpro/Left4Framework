/******************************************************************************
 *  作者：       Bluexray
 *  创建时间：   2012/4/8 23:29:36
 *
 *
 ******************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Plugins
{
    public abstract class BasePlugin:IPlugin
    {
        protected BasePlugin()
        {
        }
        /// <summary>
        /// Gets or sets the plugin descriptor
        /// </summary>
        public virtual PluginDescriptor PluginDescriptor { get; set; }

        /// <summary>
        /// Install plugin
        /// </summary>
        public virtual void Install()
        {
            PluginManager.MarkPluginAsInstalled(this.PluginDescriptor.SystemName);
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public virtual void Uninstall()
        {
            PluginManager.MarkPluginAsUninstalled(this.PluginDescriptor.SystemName);
        }

    }
}

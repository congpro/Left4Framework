/******************************************************************************
 *  作者：       Bluexray
 *  创建时间：   2012/4/8 23:20:34
 *
 *
 ******************************************************************************/

using System.Collections.Generic;


namespace Framework.Plugins
{
    public interface IPluginFinder
    {
        /// <summary>Gets plugins found in the environment sorted.</summary>
        /// <typeparam name="T">The type of plugin to get.</typeparam>
        /// <returns>An enumeration of plugins.</returns>
        IEnumerable<T> GetPlugins<T>(bool installedOnly = true) where T : class, IPlugin;

        IEnumerable<PluginDescriptor> GetPluginDescriptors(bool installedOnly = true);

        IEnumerable<PluginDescriptor> GetPluginDescriptors<T>(bool installedOnly = true) where T : class, IPlugin;

        PluginDescriptor GetPluginDescriptorBySystemName(string systemName, bool installedOnly = true);

        PluginDescriptor GetPluginDescriptorBySystemName<T>(string systemName, bool installedOnly = true) where T : class, IPlugin;
    }
}
